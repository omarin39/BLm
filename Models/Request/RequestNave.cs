﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestNave
    {   
        public long IdNave { get; set; }     
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public long PlantaIdPlanta { get; set; }
        public bool Activo { get; set; }
        
    }
}
