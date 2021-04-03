﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            DepartamentoNivel1s = new HashSet<DepartamentoNivel1>();
            Empleados = new HashSet<Empleado>();
        }

        public long IdDepartamento { get; set; }
        public long IdDepartamentExt { get; set; }
        public string Departamento1 { get; set; }

        public virtual ICollection<DepartamentoNivel1> DepartamentoNivel1s { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
