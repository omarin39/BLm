using APIRestV2.DataModels;
using APIRestV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessDepartamento
    {
        public DataDepartamentos dataDepartamento = new();

        public List<Departamento> FindAllDepartamento()
        {
            List<Departamento> resDepartamentoRet = dataDepartamento.FindAllDepartamentos();
            return resDepartamentoRet;
        }
    }
}
