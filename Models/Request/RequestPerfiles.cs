﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestPerfiles
    {   
        public long Id { get; set; }     
        public string Perfil { get; set; }
        public bool Activo { get; set; }
        
    }
}
