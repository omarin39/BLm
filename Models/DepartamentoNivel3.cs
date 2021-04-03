using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class DepartamentoNivel3
    {
        public DepartamentoNivel3()
        {
            Empleados = new HashSet<Empleado>();
        }

        public long IdDepartamentoNivel3 { get; set; }
        public long IdDepartamento { get; set; }
        public long IdDepartamentoNivel2 { get; set; }
        public long IdDepartamentExt { get; set; }
        public string Departamento { get; set; }

        public virtual DepartamentoNivel2 IdDepartamentoNivel2Navigation { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
