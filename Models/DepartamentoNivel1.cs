using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class DepartamentoNivel1
    {
        public DepartamentoNivel1()
        {
            DepartamentoNivel2s = new HashSet<DepartamentoNivel2>();
            Empleados = new HashSet<Empleado>();
        }

        public long IdDepartamentoNivel1 { get; set; }
        public long IdDepartamento { get; set; }
        public long IdDepartamentExterno { get; set; }
        public string Departamento { get; set; }
        public bool? Activo { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual ICollection<DepartamentoNivel2> DepartamentoNivel2s { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
