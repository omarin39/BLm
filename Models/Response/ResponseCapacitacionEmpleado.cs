﻿using APIRestV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponseCapacitacionEmpleado
    {
        public long IdCapacitacion { get; set; }
        public long IdEmpleado { get; set; }
        public string Pieza { get; set; }
        public long IdProceso { get; set; }
        public string Maquina { get; set; }
        public long IdNivelCertificacion { get; set; }
        public long? IdMentor { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Turno { get; set; }
        public bool Concluida { get; set; }
        public bool Activo { get; set; }
    }
}
