using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Idioma
    {
        public Idioma()
        {
            Empleados = new HashSet<Empleado>();
            PreguntaMaquinaGenerals = new HashSet<PreguntaMaquinaGeneral>();
            PreguntaMaquinas = new HashSet<PreguntaMaquina>();
            PreguntaPiezaGenerals = new HashSet<PreguntaPiezaGeneral>();
            PreguntaPiezas = new HashSet<PreguntaPieza>();
            PreguntaProcesoGenerals = new HashSet<PreguntaProcesoGeneral>();
            PreguntaProcesos = new HashSet<PreguntaProceso>();
            PreguntaPtGenerals = new HashSet<PreguntaPtGeneral>();
        }

        public long IdIdioma { get; set; }
        public string CodigoIdioma { get; set; }
        public string Idioma1 { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<PreguntaMaquinaGeneral> PreguntaMaquinaGenerals { get; set; }
        public virtual ICollection<PreguntaMaquina> PreguntaMaquinas { get; set; }
        public virtual ICollection<PreguntaPiezaGeneral> PreguntaPiezaGenerals { get; set; }
        public virtual ICollection<PreguntaPieza> PreguntaPiezas { get; set; }
        public virtual ICollection<PreguntaProcesoGeneral> PreguntaProcesoGenerals { get; set; }
        public virtual ICollection<PreguntaProceso> PreguntaProcesos { get; set; }
        public virtual ICollection<PreguntaPtGeneral> PreguntaPtGenerals { get; set; }
    }
}
