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

     
        public ResponseGral AddMultimediaPieza(RequestMultimediaPieza MultimediaPieza, string ip)
        {
            ResponseGral respAltaMultimediaPieza = new();
            try
            {
                if (multimediaPiezaData.ValidaClaveExistente(MultimediaPieza.Nombre) == false)
                {


                    MultiMediaPieza logNewRegistro = new();
                    logNewRegistro.IdPieza = MultimediaPieza.IdPieza;
                    logNewRegistro.IdTipoDocumento = MultimediaPieza.IdTipoDocumento;
                    logNewRegistro.Nombre = MultimediaPieza.Nombre;
                    logNewRegistro.Descripcion = MultimediaPieza.Descripcion;
                    logNewRegistro.Version = MultimediaPieza.Version;
                    logNewRegistro.Recertificacion = MultimediaPieza.Recertificacion;
                    logNewRegistro.TipoMedia = MultimediaPieza.TipoMedia;
                    logNewRegistro.Activo = MultimediaPieza.Activo;
                    logNewRegistro.Extension = MultimediaPieza.Extension;
                    logNewRegistro.Tamanio = MultimediaPieza.Tamanio;


                    try
                    {

                        //Genera path del nuevo archivo    falta la extension
                        string filePath = save2(MultimediaPieza.TipoMedia, MultimediaPieza.Nombre.Trim().ToLower() + MultimediaPieza.Extension.Trim());
                        logNewRegistro.Ruta = armaPath(MultimediaPieza.TipoMedia, MultimediaPieza.Nombre.Trim().ToLower() + MultimediaPieza.Extension);
                        File.WriteAllBytes(filePath, Convert.FromBase64String(MultimediaPieza.Documento));


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
                else
                {
                    respAltaMultimediaPieza.Id = -1;
                    respAltaMultimediaPieza.Codigo = "-1";
                    respAltaMultimediaPieza.Mensaje = "Nombre de archivo Duplicado";
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

        internal object AddMultimediaPiezaVersion(RequestMultimediaPiezaVersion req, string ip)
        {
            ResponseGral respAltaMultimediaPieza = new();
            try
            {
                var old = multimediaPiezaData.FindMultimediaPiezaPorId(req.Id);

                if (old==null)
                {
                    respAltaMultimediaPieza.Id = -1;
                    respAltaMultimediaPieza.Codigo = "-1";
                    respAltaMultimediaPieza.Mensaje = "Nombre de archivo no existe";
                    return respAltaMultimediaPieza;

                }

                try
                {
                    if (Convert.ToDouble(req.Version) <= Convert.ToDouble(old.Version))
                    {
                        respAltaMultimediaPieza.Id = -1;
                        respAltaMultimediaPieza.Codigo = "-1";
                        respAltaMultimediaPieza.Mensaje = "Version menor o igual a la anterior. Revise el valor";
                        return respAltaMultimediaPieza;

                    }
                }
                catch (Exception ex)
                {
                    respAltaMultimediaPieza.Id = -1;
                    respAltaMultimediaPieza.Codigo = "-1";
                    respAltaMultimediaPieza.Mensaje = "Valor de la version no es numerica. Revise el valor";
                    return respAltaMultimediaPieza;
                }

                //interchange place between old and new in multimedia table
                RequestMultimediaPieza updatedVersion = new();
                   updatedVersion.IdPieza = req.IdPieza;
                   updatedVersion.IdTipoDocumento = req.IdTipoDocumento;
                   updatedVersion.Nombre = req.Nombre;
                   updatedVersion.Descripcion = req.Descripcion;
                   updatedVersion.Version = req.Version;
                   updatedVersion.Recertificacion = req.Recertificacion;
                   updatedVersion.TipoMedia = req.TipoMedia;
                   updatedVersion.Extension = req.Extension;
                   updatedVersion.Tamanio = req.Tamanio;
                  // updatedVersion.Ruta = old.Ruta;
                   updatedVersion.HistorialVersion = true;

                 try
                  {

                      //Genera path de la nueva version del archivo    
                      string filePath = save2(req.TipoMedia, req.Nombre.Trim().ToLower()+"_"+ req.Version.Trim().Replace(".","_") + req.Extension.Trim());
                    updatedVersion.Ruta = armaPath(req.TipoMedia, req.Nombre.Trim().ToLower() + "_" + req.Version.Trim().Replace(".", "_")+ req.Extension);
                      File.WriteAllBytes(filePath, Convert.FromBase64String(req.Documento));


                  }
                  catch (Exception ex)
                  {
                      respAltaMultimediaPieza.Id = 0;
                      respAltaMultimediaPieza.Codigo = "400";
                      respAltaMultimediaPieza.Mensaje = "Error al guardar el documento de la nueva version";
                      return respAltaMultimediaPieza;
                  }


                //get version historico before update it
                VersionMultiMediaPieza historicoVersion = new();
                historicoVersion.IdMultiMediaPieza = old.Id;
                historicoVersion.IdTipoDocumento = old.IdTipoDocumento;
                historicoVersion.Nombre = old.Nombre;
                historicoVersion.Descripcion = old.Descripcion;
                historicoVersion.Version = old.Version;
                historicoVersion.Recertificacion = old.Recertificacion;
                historicoVersion.TipoMedia = old.TipoMedia;
                historicoVersion.Extension = old.Extension;
                historicoVersion.Tamanio = old.Tamanio;
                historicoVersion.Ruta = old.Ruta;


                var res = UpdateMultimediaPiezaVersiones(updatedVersion,ip,old);

                if (res.Codigo != "200")
                {
                    respAltaMultimediaPieza.Id = 0;
                    respAltaMultimediaPieza.Codigo = "400";
                    respAltaMultimediaPieza.Mensaje = "Error al guardar el datos de la nueva version";
                    return respAltaMultimediaPieza;
                }
               



              

                 
                //add old version to versions table
                long respNewUSR = multimediaPiezaData.AddMultimediaPiezaVersion(historicoVersion, ip);
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

        internal List<VersionMultiMediaPieza> FindMultimediaPiezaTipMediaVersiones(long idMultimedia, string version)
        {
            List<VersionMultiMediaPieza> respAltaMultimediaPieza = multimediaPiezaData.FindMultimediaPiezaVersiones(idMultimedia, version);
            return respAltaMultimediaPieza;
        }



        /*  public  ResponseGral AddMultimediaPieza(RequestMultimediaPieza MultimediaPieza, string ip)
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
          }*/

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
                    if(multimediaPiezaBuscado.Tamanio!= multimediaPieza.Tamanio)
                    {
                        //Prepara path del archivo  
                        string filePath = save2(multimediaPieza.TipoMedia, multimediaPieza.Nombre.Trim().ToLower() + multimediaPieza.Extension.Trim());
                        multimediaPieza.Ruta = armaPath(multimediaPieza.TipoMedia, multimediaPieza.Nombre.Trim().ToLower() + multimediaPieza.Extension);
                        File.WriteAllBytes(filePath, Convert.FromBase64String(multimediaPieza.Documento));
                    }
                    else
                    {
                        multimediaPieza.Ruta = multimediaPiezaBuscado.Ruta;
                    }
                   


                }
                catch (Exception ex)
                {
                    respAltaMultimediaPieza.Id = 0;
                    respAltaMultimediaPieza.Codigo = "400";
                    respAltaMultimediaPieza.Mensaje = "Error al actualizar el documento";
                    return respAltaMultimediaPieza;
                }




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
                        Extension = multimediaPieza.Extension,
                        Tamanio = multimediaPieza.Tamanio,
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

        public ResponseGral UpdateMultimediaPiezaVersiones(RequestMultimediaPieza multimediaPieza, String ip, MultiMediaPieza multimediaPiezaBuscado)
        {
            ResponseGral respAltaMultimediaPieza = new();
        
                try
                {
                

               // multimediaPiezaBuscado.Id = multimediaPieza.Id;
                //multimediaPiezaBuscado.IdPieza = multimediaPieza.IdPieza;
                multimediaPiezaBuscado.IdTipoDocumento = multimediaPieza.IdTipoDocumento;
               // multimediaPiezaBuscado.Nombre = multimediaPieza.Nombre;
                multimediaPiezaBuscado.Descripcion = multimediaPieza.Descripcion;
                multimediaPiezaBuscado.Version = multimediaPieza.Version;
                multimediaPiezaBuscado.Recertificacion = multimediaPieza.Recertificacion;
                multimediaPiezaBuscado.Ruta = multimediaPieza.Ruta;
                multimediaPiezaBuscado.TipoMedia = multimediaPieza.TipoMedia;
                multimediaPiezaBuscado.Extension = multimediaPieza.Extension;
                multimediaPiezaBuscado.Tamanio = multimediaPieza.Tamanio;
                multimediaPiezaBuscado.Activo = multimediaPieza.Activo;
                multimediaPiezaBuscado.HistorialVersion = true;

                var respNewMultimediaPieza = multimediaPiezaData.UpdateMultimediaPieza(multimediaPiezaBuscado, ip);
                    if (respNewMultimediaPieza > 0)
                    {
                        respAltaMultimediaPieza.Id = multimediaPieza.Id;
                        respAltaMultimediaPieza.Codigo = "200";
                        respAltaMultimediaPieza.Mensaje = "OK";
                        return respAltaMultimediaPieza;
                    }
                    else
                    {//nuevo
                        respAltaMultimediaPieza.Id = multimediaPieza.Id;
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
