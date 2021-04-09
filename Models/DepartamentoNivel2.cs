using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class DepartamentoNivel2
    {
        public DepartamentoNivel2()
        {
            DepartamentoNivel3s = new HashSet<DepartamentoNivel3>();
            Empleados = new HashSet<Empleado>();
        }

        public long IdDepartamentoNivel2 { get; set; }
        public long IdDepartamento { get; set; }
        public long IdDepartamentoNivel1 { get; set; }
        public long IdDepartamentExt { get; set; }
        public string Departamento { get; set; }
        public bool? Activo { get; set; }

        public virtual DepartamentoNivel1 IdDepartamentoNivel1Navigation { get; set; }
        public virtual ICollection<DepartamentoNivel3> DepartamentoNivel3s { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
