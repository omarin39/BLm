using APIRestV2.Controllers.Process;
using APIRestV2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private ProcessPuesto process = new();

      
        [HttpGet()]
        public ActionResult<List<Puesto>> FindAll()
        {
            try
            {

                List<Puesto> result = process.FindAllPuesto();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Pregunta Proceso not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Pregunta Proceso not found");

            }

        }
    }
}
