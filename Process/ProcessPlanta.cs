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
    public class ProcessPlanta
    {       
        public DataPlanta PlantaData = new();
        public ResponseGral AddPlanta(RequestPlanta Planta)
        {
            ResponseGral respAltaPlanta = new();
            try
            {
                Planta logNewRegistro = new();
                logNewRegistro.Planta1 = Planta.Planta1;
                logNewRegistro.Acronimo = Planta.Acronimo;
                logNewRegistro.Activo = Planta.Activo;
                long respNewUSR = PlantaData.AddPlanta(logNewRegistro);
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

        public ResponseGral UpdatePlanta( RequestPlanta planta)
        {
            ResponseGral respAltaPlanta = new();

            //Valida si una plata tiene naves asociadas
            if (planta.Activo == false)
            {
                DataNave naveData = new();
                List<Nafe> resNavesRet = naveData.FindAllNavesPorPlanta(planta.IdPlanta);
                if (resNavesRet.Count > 0)
                {
                    respAltaPlanta.Id = planta.IdPlanta;
                    respAltaPlanta.Codigo = "503";
                    respAltaPlanta.Mensaje = "La planta no puede desactivarse, por que tiene " + resNavesRet.Count.ToString() + " naves asociadas.";
                    return respAltaPlanta;
                }
            }



            var PlantaBuscado = FindPlanta(planta.Planta1);
            if (PlantaBuscado == null)
            {
                return respAltaPlanta;
            }
            else
            {
                try
                {
                    PlantaBuscado.Planta1 = planta.Planta1;
                    PlantaBuscado.Acronimo = planta.Acronimo;
                    PlantaBuscado.Activo = planta.Activo;
                    var respNewPlanta = PlantaData.UpdatePlanta(PlantaBuscado);
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
        public Planta FindPlanta(String planta){
            Planta respAltaPlanta = PlantaData.FindPlanta(planta);
            if (respAltaPlanta == null)
            {
                respAltaPlanta.IdPlanta = -1;
            }
            return respAltaPlanta;
        }
    


        public List<Planta> FindAllPlanta()
        {
            List<Planta> resPlantaRet = PlantaData.FindAllPlantas();
            return resPlantaRet;
        }


    }
}
