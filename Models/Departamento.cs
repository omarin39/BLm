using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            DepartamentoNivel1s = new HashSet<DepartamentoNivel1>();
        }

        public long IdDepartamento { get; set; }
        public long IdDepartamentExterno { get; set; }
        public string Departamento1 { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<DepartamentoNivel1> DepartamentoNivel1s { get; set; }
    }
}
