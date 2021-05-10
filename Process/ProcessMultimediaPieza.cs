using APIRestV2.DataModels;
using APIRestV2.Helpers;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessMultimediaPieza
    {       
        public DataMultimediaPieza multimediaPiezaData = new();
        public  ResponseGral AddMultimediaPieza(RequestMultimediaPieza MultimediaPieza, string ip)
        {
            ResponseGral respAltaMultimediaPieza = new();
            try
            {
                MultiMediaPieza logNewRegistro = new();
                logNewRegistro.IdPieza = MultimediaPieza.IdPieza;
                logNewRegistro.IdTipoDocumento = MultimediaPieza.IdTipoDocumento;
                logNewRegistro.Nombre = MultimediaPieza.Nombre;
                logNewRegistro.Descripcion = MultimediaPieza.Descripcion;
                logNewRegistro.Version = MultimediaPieza.Version;
                logNewRegistro.Recertificacion = MultimediaPieza.Recertificacion;
                logNewRegistro.TipoMedia = MultimediaPieza.TipoMedia;
                logNewRegistro.Activo= MultimediaPieza.Activo;



                try
                {
                    foreach (IFormFile file in MultimediaPieza.documento)
                    {
                        if (file.Length > 0)
                        {
                            string filePath = save2(MultimediaPieza.TipoMedia, file.FileName.Trim().ToLower());
                            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                logNewRegistro.Ruta = armaPath(MultimediaPieza.TipoMedia, file.FileName.Trim().ToLower());
                                file.CopyTo(fileStream);
                            }
                        }
                    }

                   

                }
                catch (Exception ex)
                {
                    respAltaMultimediaPieza.Id = 0;
                    respAltaMultimediaPieza.Codigo = "400";
                    respAltaMultimediaPieza.Mensaje = "Error al guardar el documento";
                    return respAltaMultimediaPieza;
                }



                long respNewUSR = multimediaPiezaData.AddMultimediaPieza(logNewRegistro, ip);
                if (respNewUSR > 0)
                {
                    respAltaMultimediaPieza.Id = respNewUSR;
                    respAltaMultimediaPieza.Codigo = "200";
                    respAltaMultimediaPieza.Mensaje = "OK";
                    return respAltaMultimediaPieza;
                }
                else
                {
                    respAltaMultimediaPieza.Id = respNewUSR;
                    respAltaMultimediaPieza.Codigo = "400";
                    respAltaMultimediaPieza.Mensaje = "Error al guardar datos";
                    return respAltaMultimediaPieza;
                }





            }
            catch (Exception ex)
            {
                respAltaMultimediaPieza.Id = -1;
                respAltaMultimediaPieza.Codigo = "400";
                respAltaMultimediaPieza.Mensaje = ex.InnerException.Message;
                return respAltaMultimediaPieza;
            }
        }

        private string save2(string tipoMedia, string nombre)
        {
            string path = "";
            switch (tipoMedia)
            {
                case "IMG": path = "C:\\multimedia\\imagenes\\" + nombre.Trim().ToLower(); break;
                case "VIDEO": path = "C:\\multimedia\\videos\\" + nombre.Trim().ToLower(); break;
                case "DOC": path = "C:\\multimedia\\documentos\\" + nombre.Trim().ToLower(); break;
                default: path = "C:\\multimedia\\error\\" + nombre.Trim().ToLower(); break;
            }
            return path;
        }

        private string armaPath(string tipoMedia, string nombre)
        {
            string path = "";
            switch (tipoMedia)
            {
                case "IMG": path = "/imagenes/" + nombre.Trim().ToLower(); break;
                case "VIDEO": path = "/videos/" + nombre.Trim().ToLower(); break;
                case "DOC": path = "/documentos/" + nombre.Trim().ToLower(); break;
                default: path = "/error/" + nombre.Trim().ToLower(); break;
            }
            return path;
        }

        public ResponseGral UpdateMultimediaPieza( RequestMultimediaPieza multimediaPieza, String ip)
        {
            ResponseGral respAltaMultimediaPieza = new();

            var multimediaPiezaBuscado = FindMultimediaPieza(multimediaPieza.IdPieza,  multimediaPieza.Id);
            if (multimediaPiezaBuscado == null)
            {
                return respAltaMultimediaPieza;
            }else if (multimediaPiezaBuscado.Id==-1)
            {
                respAltaMultimediaPieza.Id = multimediaPieza.Id;
                respAltaMultimediaPieza.Codigo = "400";
                respAltaMultimediaPieza.Mensaje = "Not found";
                return respAltaMultimediaPieza;
            }
            else
            {
                try
                {

                    var multimediaPiezaBuscadox = new MultiMediaPieza
                        {
                            Id = multimediaPieza.Id,
                            IdPieza=multimediaPieza.IdPieza,
                        IdTipoDocumento = multimediaPieza.IdTipoDocumento,
                        Nombre = multimediaPieza.Nombre,
                        Descripcion = multimediaPieza.Descripcion,
                        Version = multimediaPieza.Version,
                        Recertificacion = multimediaPieza.Recertificacion,
                        Ruta = multimediaPieza.Ruta,
                        TipoMedia = multimediaPieza.TipoMedia,
                        Activo = multimediaPieza.Activo

                };



                    var respNewMultimediaPieza = multimediaPiezaData.UpdateMultimediaPieza(multimediaPiezaBuscadox, ip);
                    if (respNewMultimediaPieza > 0)
                    {
                        respAltaMultimediaPieza.Id = multimediaPiezaBuscado.Id;
                        respAltaMultimediaPieza.Codigo = "200";
                        respAltaMultimediaPieza.Mensaje = "OK";
                        return respAltaMultimediaPieza;
                    }
                    else
                    {//nuevo
                        respAltaMultimediaPieza.Id = multimediaPiezaBuscado.Id;
                        respAltaMultimediaPieza.Codigo = "400";
                        respAltaMultimediaPieza.Mensaje = "Record not found";
                        return respAltaMultimediaPieza;
                    }
                }
                catch (Exception ex)
                {
                    respAltaMultimediaPieza.Id = multimediaPiezaBuscado.Id;
                    respAltaMultimediaPieza.Codigo = "400";
                    respAltaMultimediaPieza.Mensaje = ex.InnerException.Message;
                    return respAltaMultimediaPieza;
                }
            }
        }
        public MultiMediaPieza FindMultimediaPieza(long idPieza, long idMultimedia)
        {
            MultiMediaPieza respAltaMultimediaPieza = multimediaPiezaData.FindMultimediaPieza(idMultimedia,idPieza);
            if (respAltaMultimediaPieza == null)
            {
                respAltaMultimediaPieza = new MultiMediaPieza();
                respAltaMultimediaPieza.Id = -1;
            }
            return respAltaMultimediaPieza;
        }

        public List<MultiMediaPieza> FindMultimediaPiezaTipMedia(long idPieza, string TipoMedia)
        {
           return multimediaPiezaData.FindMultimediaPiezaTipMedia(TipoMedia, idPieza);
        }

        public List<MultiMediaPieza> FindAllMultimediaPieza()
        {
            List<MultiMediaPieza> resMultimediaPiezaRet = multimediaPiezaData.FindAllMultimediaPieza();
             return resMultimediaPiezaRet;
        }


    }
}
