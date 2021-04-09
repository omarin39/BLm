using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Idioma
    {
        public Idioma()
        {
            Empleados = new HashSet<Empleado>();
            PreguntasMaquinaGenerales = new HashSet<PreguntasMaquinaGenerale>();
            PreguntasMaquinas = new HashSet<PreguntasMaquina>();
            PreguntasPiezas = new HashSet<PreguntasPieza>();
            PreguntasPiezasGenerales = new HashSet<PreguntasPiezasGenerale>();
            PreguntasProcesos = new HashSet<PreguntasProceso>();
            PreguntasProcesosGenerales = new HashSet<PreguntasProcesosGenerale>();
            PreguntasPtGenerales = new HashSet<PreguntasPtGenerale>();
        }

        public long IdIdioma { get; set; }
        public string CodigoIdioma { get; set; }
        public string Idioma1 { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<PreguntasMaquinaGenerale> PreguntasMaquinaGenerales { get; set; }
        public virtual ICollection<PreguntasMaquina> PreguntasMaquinas { get; set; }
        public virtual ICollection<PreguntasPieza> PreguntasPiezas { get; set; }
        public virtual ICollection<PreguntasPiezasGenerale> PreguntasPiezasGenerales { get; set; }
        public virtual ICollection<PreguntasProceso> PreguntasProcesos { get; set; }
        public virtual ICollection<PreguntasProcesosGenerale> PreguntasProcesosGenerales { get; set; }
        public virtual ICollection<PreguntasPtGenerale> PreguntasPtGenerales { get; set; }
    }
}
