using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestProcessLogByDate
    {   
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }

    }
}
