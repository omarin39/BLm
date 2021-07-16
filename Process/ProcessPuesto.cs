using APIRestV2.DataModels;
using APIRestV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessPuesto
    {
        public DataPuesto dataPuesto = new();

        public List<Puesto> FindAllPuesto()
        {
            List<Puesto> resPuestoRet = dataPuesto.FindAllPuestos();
            return resPuestoRet;
        }
    }
}
