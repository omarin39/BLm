using APIRestV2.DataModels;
using APIRestV2.Helpers;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessNave
    {       
        public DataNave NaveData = new();
        public ResponseGral AddNave(RequestNave Nave, String ip)
        {
            ResponseGral respAltaNave = new();
            try
            {
                if (NaveData.FindNombreNave(Nave)==false)
                {
                    Nave logNewRegistro = new();
                    logNewRegistro.Nombre = Nave.nombre;
                    logNewRegistro.Descripcion = Nave.descripcion;
                    logNewRegistro.PlantaIdPlanta = Nave.PlantaIdPlanta;
                    logNewRegistro.Activo = Nave.Activo;
                    long respNewUSR = NaveData.AddNave(logNewRegistro, ip);
                    if (respNewUSR > 0)
                    {
                        respAltaNave.Id = respNewUSR;
                        respAltaNave.Codigo = "200";
                        respAltaNave.Mensaje = "OK";
                        return respAltaNave;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    respAltaNave.Id = -1;
                    respAltaNave.Codigo = "-1";
                    respAltaNave.Mensaje = "Nombre Duplicado";
                    return respAltaNave;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResponseGral UpdateNave( RequestNave Nave, String ip)
        {
            ResponseGral respAltaNave = new();
           

            //Valida si una nave esta asociada a una linea de produccion
            if (Nave.Activo == false)
             {
                 DataNave naveData = new();
                 List<LineaProduccion> resNavesRet = naveData.FindAllNavesPorLineaProduccion(Nave.IdNave,ip);
                 if (resNavesRet.Count > 0)
                 {
                    respAltaNave.Id = Nave.IdNave;
                    respAltaNave.Codigo = "503";
                    respAltaNave.Mensaje = "La Linea de Produccion no puede desactivarse, por que tiene " + resNavesRet.Count.ToString() + " naves asociadas.";
                     return respAltaNave;
                 }
             }


            var NaveBuscado = FindNave(Nave.IdNave);
            if (NaveBuscado == null)
            {
                return respAltaNave;
            }
            else if (NaveBuscado.IdNave == -1)
            {
                respAltaNave.Id = Nave.IdNave;
                respAltaNave.Codigo = "400";
                respAltaNave.Mensaje = "Not found";
                return respAltaNave;
            }
            else
            {
                try
                {
                    if (NaveData.FindNombreNave(Nave) == false)
                    {
                        var NaveBuscadox = new Nave
                        {
                            IdNave = NaveBuscado.IdNave,
                            PlantaIdPlanta = NaveBuscado.PlantasIdPlanta,
                            Nombre = Nave.nombre,
                            Descripcion = Nave.descripcion,
                            Activo = Nave.Activo
                        };


                        var respNewNave = NaveData.UpdateNave(NaveBuscadox, ip);
                        if (respNewNave > 0)
                        {
                            respAltaNave.Id = NaveBuscado.IdNave;
                            respAltaNave.Codigo = "200";
                            respAltaNave.Mensaje = "OK";
                            return respAltaNave;
                        }
                        else
                        {
                            respAltaNave.Id = NaveBuscado.IdNave;
                            respAltaNave.Codigo = "400";
                            respAltaNave.Mensaje = "Record not found";
                            return respAltaNave;
                        }
                    }
                    else
                    {
                        respAltaNave.Id = -1;
                        respAltaNave.Codigo = "-1";
                        respAltaNave.Mensaje = "Nombre Duplicado";
                        return respAltaNave;

                    }
                }
                catch (Exception ex)
                {
                    respAltaNave.Id = NaveBuscado.IdNave;
                    respAltaNave.Codigo = "400";
                    respAltaNave.Mensaje = ex.InnerException.Message;
                    return respAltaNave;
                }
            }
        }
        public ResponseNave FindNave(long Nave){
            Nave respAltaNave = NaveData.FindNave(Nave);
            if (respAltaNave == null)
            {
                respAltaNave = new Nave();
                respAltaNave.IdNave = -1;
            }



            // return respAltaNave;
            var result = new ResponseNave
                    {
                        IdNave = respAltaNave.IdNave,
                        Nombre = respAltaNave.Nombre,
                        Descripcion = respAltaNave.Descripcion,
                        PlantasIdPlanta = respAltaNave.PlantaIdPlanta,
                        Activo = (bool)respAltaNave.Activo,
                        PlantasIdPlantaNavigation = respAltaNave.PlantaIdPlantaNavigation,
                        LineaProduccions = respAltaNave.LineaProduccions.Count,
                        MáquinasFisicas = respAltaNave.MaquinaFisicas
                    };


            return result;



        }
        public List<ResponseNave> FindNavePlanta(long Nave)
        {
            List<Nave> respAltaNave = NaveData.FindNavePlanta(Nave);
            /*
            return respAltaNave;*/
            var result = respAltaNave.Select((nave, i) =>
                   new ResponseNave
                   {
                       IdNave = nave.IdNave,
                       Nombre = nave.Nombre,
                       Descripcion = nave.Descripcion,
                       PlantasIdPlanta = nave.PlantaIdPlanta,
                       Activo = (bool)nave.Activo,
                       PlantasIdPlantaNavigation = nave.PlantaIdPlantaNavigation,
                       LineaProduccions = nave.LineaProduccions.Where(lp => lp.Activo ==true).Count(),
                       MáquinasFisicas = nave.MaquinaFisicas
                   }).ToList();


            return result;
        }



        public List<ResponseNave> FindAllNave()
    {
        List<Nave> resNaveRet = NaveData.FindAllNaves();

            var result = resNaveRet.Select((nave, i) =>
                      new ResponseNave
                      {
                          IdNave = nave.IdNave,
                          Nombre = nave.Nombre,
                          Descripcion = nave.Descripcion,
                          PlantasIdPlanta = nave.PlantaIdPlanta,
                          Activo = (bool)nave.Activo,
                          PlantasIdPlantaNavigation= nave.PlantaIdPlantaNavigation,
                          LineaProduccions= nave.LineaProduccions.Count,
                          MáquinasFisicas= nave.MaquinaFisicas
                      }).ToList();

            return result;
    }


}
}
