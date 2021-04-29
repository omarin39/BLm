using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controllers.Process
{
    public class ProcessPieza
    {       
        public DataPieza PiezaData = new();
        public ResponseGral AddPieza(RequestPieza Pieza, String ip)
        {
            ResponseGral respAltaPieza = new();
            try
            {
                Pieza logNewRegistro = new();
                logNewRegistro.Nombre = Pieza.nombre;
                logNewRegistro.Descripción = Pieza.descripcion;
                logNewRegistro.Activo = Pieza.Activo;
                long respNewUSR = PiezaData.AddPieza(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaPieza.Id = respNewUSR;
                    respAltaPieza.Codigo = "200";
                    return respAltaPieza;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResponseGral UpdatePieza( RequestPieza Pieza, String ip)
        {
            ResponseGral respAltaPieza = new();
            var PiezaBuscado = FindPieza(Pieza.nombre);
            if (PiezaBuscado == null)
            {
                return respAltaPieza;
            }
            else
            {
                try
                {
                    PiezaBuscado.Nombre = Pieza.nombre;
                    PiezaBuscado.Descripción = Pieza.descripcion;
                    PiezaBuscado.Activo = Pieza.Activo;
                    var respNewPieza = PiezaData.UpdatePieza(PiezaBuscado,ip);
                    if (respNewPieza > 0)
                    {
                        respAltaPieza.Id = PiezaBuscado.IdPieza;
                        respAltaPieza.Codigo = "200";
                        return respAltaPieza;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public Pieza FindPieza(String Pieza){
            Pieza respAltaPieza = PiezaData.FindPieza(Pieza);
            if (respAltaPieza == null)
            {
                respAltaPieza.IdPieza = -1;
            }
            return respAltaPieza;
        }
    


    public List<Pieza> FindAllPieza()
    {
        List<Pieza> resPiezaRet = PiezaData.FindAllPiezas();
        return resPiezaRet;
    }


}
}
