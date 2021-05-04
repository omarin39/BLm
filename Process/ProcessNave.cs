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
                Nave logNewRegistro = new();
                logNewRegistro.Nombre = Nave.nombre;
                logNewRegistro.Descripcion = Nave.descripcion;
                logNewRegistro.PlantaIdPlanta = Nave.PlantaIdPlanta;
                logNewRegistro.Activo = Nave.Activo;
                long respNewUSR = NaveData.AddNave(logNewRegistro, ip);
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
            else
            {
                try
                {
                    var NaveBuscadox = new Nave { 
                        IdNave= NaveBuscado.IdNave,
                        PlantaIdPlanta= NaveBuscado.PlantasIdPlanta,
                    Nombre= Nave.nombre,
                    Descripcion= Nave.descripcion,
                    Activo= Nave.Activo
                    };


                    var respNewNave = NaveData.UpdateNave(NaveBuscadox,ip);
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
        public ResponseNave FindNave(long Nave){
            Nave respAltaNave = NaveData.FindNave(Nave);
            if (respAltaNave == null)
            {
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
                        LineasProduccions = respAltaNave.LineaProduccions.Count,
                        MáquinasFisicas = respAltaNave.MaquinaFisicas
                    };


            return result;



        }
        public List<ResponseNave> FindNavePlanta(string Nave)
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
                       LineasProduccions = nave.LineaProduccions.Count,
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
                          LineasProduccions= nave.LineaProduccions.Count,
                          MáquinasFisicas= nave.MaquinaFisicas
                      }).ToList();

            return result;
    }


}
}
