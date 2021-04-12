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
                logNewRegistro.Planta1 = Planta.planta;
                logNewRegistro.Acronimo = Planta.acronimo;
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

        public ResponseGral UpdatePlanta( RequestPlanta Planta)
        {
            ResponseGral respAltaPlanta = new();
            var PlantaBuscado = FindPlanta(Planta.planta);
            if (PlantaBuscado == null)
            {
                return respAltaPlanta;
            }
            else
            {
                try
                {
                    PlantaBuscado.Planta1 = Planta.planta;
                    PlantaBuscado.Acronimo = Planta.acronimo;
                    PlantaBuscado.Activo = Planta.Activo;
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
