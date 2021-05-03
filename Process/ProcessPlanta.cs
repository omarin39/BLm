﻿using APIRestV2.DataModels;
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
    public class ProcessPlanta
    {       
        public DataPlanta PlantaData = new();
        public ResponseGral AddPlanta(RequestPlanta Planta, String ip)
        {
            ResponseGral respAltaPlanta = new();
            try
            {
                Plantum logNewRegistro = new();
                logNewRegistro.Planta = Planta.Planta1;
                logNewRegistro.IdPlantaExterno = Planta.IdPlantaExt;
                logNewRegistro.Acronimo = Planta.Acronimo;
                logNewRegistro.Activo = Planta.Activo;
                long respNewUSR = PlantaData.AddPlanta(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaPlanta.Id = respNewUSR;
                    respAltaPlanta.Codigo = "200";
                    return respAltaPlanta;
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

        public ResponseGral UpdatePlanta( RequestPlanta planta, String ip)
        {
            ResponseGral respAltaPlanta = new();

            //Valida si una plata tiene naves asociadas
            if (planta.Activo == false)
            {
                DataNave naveData = new();
                List<Nave> resNavesRet = naveData.FindAllNavesPorPlanta(planta.IdPlanta);
                if (resNavesRet.Count > 0)
                {
                    respAltaPlanta.Id = planta.IdPlanta;
                    respAltaPlanta.Codigo = "503";
                    respAltaPlanta.Mensaje = "La planta no puede desactivarse, por que tiene " + resNavesRet.Count.ToString() + " naves asociadas.";
                    return respAltaPlanta;
                }
            }



            var PlantaBuscado = FindPlanta(planta.IdPlantaExt);
            if (PlantaBuscado == null)
            {
                return respAltaPlanta;
            }
            else
            {
                try
                {

                    var PlantaBuscadox = new Plantum
                    {
                        Planta = planta.Planta1,
                        Acronimo = planta.Acronimo,
                        Activo = planta.Activo,
                        IdPlanta = PlantaBuscado.IdPlanta,
                        IdPlantaExterno = PlantaBuscado.IdPlantaExt,
                    };



                    var respNewPlanta = PlantaData.UpdatePlanta(PlantaBuscadox,ip);
                    if (respNewPlanta > 0)
                    {
                        respAltaPlanta.Id = PlantaBuscado.IdPlanta;
                        respAltaPlanta.Codigo = "200";
                        return respAltaPlanta;
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
        public ResponsePlanta FindPlanta(long IdPlantaExt){
            Plantum respAltaPlanta = PlantaData.FindPlanta(IdPlantaExt);
            if (respAltaPlanta == null)
            {
                respAltaPlanta.IdPlanta = -1;
            }

            var result = new ResponsePlanta
            {
                IdPlanta = respAltaPlanta.IdPlanta,
                IdPlantaExt = respAltaPlanta.IdPlantaExterno,
                Acronimo = respAltaPlanta.Acronimo,
                Activo = (bool)respAltaPlanta.Activo,
                Planta1= respAltaPlanta.Planta,
                Naves = respAltaPlanta.Naves.Count,

            };


            return result;
            //return respAltaPlanta;
        }
    


        public List<ResponsePlanta> FindAllPlanta()
        {
            List<Plantum> resPlantaRet = PlantaData.FindAllPlantas();
            // return resPlantaRet;
            var result = resPlantaRet.Select((planta, i) =>
                      new ResponsePlanta
                      {
                          IdPlanta = planta.IdPlanta,
                          IdPlantaExt = planta.IdPlantaExterno,
                          Acronimo = planta.Acronimo,
                          Planta1 = planta.Planta,
                          Activo = (bool)planta.Activo,
                          Naves = planta.Naves.Count,
                      }).ToList();


            return result;
        }


    }
}
