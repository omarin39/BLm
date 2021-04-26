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
    public class ProcessNave
    {       
        public DataNave NaveData = new();
        public ResponseGral AddNave(RequestNave Nave)
        {
            ResponseGral respAltaNave = new();
            try
            {
                Nafe logNewRegistro = new();
                logNewRegistro.Nombre = Nave.nombre;
                logNewRegistro.Descripcion = Nave.descripcion;
                logNewRegistro.PlantasIdPlanta = Nave.PlantasIdPlanta;
                logNewRegistro.Activo = Nave.Activo;
                long respNewUSR = NaveData.AddNave(logNewRegistro);
                if(respNewUSR >0)
                {
                    respAltaNave.Id = respNewUSR;
                    respAltaNave.Codigo = "200";
                    return respAltaNave;
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

        public ResponseGral UpdateNave( RequestNave Nave)
        {
            ResponseGral respAltaNave = new();
           

            //Valida si una nave esta asociada a una linea de produccion
            if (Nave.Activo == false)
             {
                 DataNave naveData = new();
                 List<LineasProduccion> resNavesRet = naveData.FindAllNavesPorLineaProduccion(Nave.IdNave);
                 if (resNavesRet.Count > 0)
                 {
                    respAltaNave.Id = Nave.IdNave;
                    respAltaNave.Codigo = "503";
                    respAltaNave.Mensaje = "La Linea de Produccion no puede desactivarse, por que tiene " + resNavesRet.Count.ToString() + " naves asociadas.";
                     return respAltaNave;
                 }
             }


            var NaveBuscado = FindNave(Nave.nombre);
            if (NaveBuscado == null)
            {
                return respAltaNave;
            }
            else
            {
                try
                {
                    NaveBuscado.Nombre = Nave.nombre;
                    NaveBuscado.Descripcion = Nave.descripcion;
                    NaveBuscado.Activo = Nave.Activo;
                    var respNewNave = NaveData.UpdateNave(NaveBuscado);
                    if (respNewNave > 0)
                    {
                        respAltaNave.Id = NaveBuscado.IdNave;
                        respAltaNave.Codigo = "200";
                        return respAltaNave;
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
        public Nafe FindNave(string Nave){
            Nafe respAltaNave = NaveData.FindNave(Nave);
            if (respAltaNave == null)
            {
                respAltaNave.IdNave = -1;
            }
            return respAltaNave;
        }
        public List<Nafe> FindNavePlanta(string Nave)
        {
            List<Nafe> respAltaNave = NaveData.FindNavePlanta(Nave);
            return respAltaNave;
        }



        public List<Nafe> FindAllNave()
    {
        List<Nafe> resNaveRet = NaveData.FindAllNaves();
        return resNaveRet;
    }


}
}
