using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Pieza
    {
        public Pieza()
        {
            MultiMediaPiezas = new HashSet<MultiMediaPieza>();
            PiezaClientes = new HashSet<PiezaCliente>();
            ProcesoPiezaMaquinas = new HashSet<ProcesoPiezaMaquina>();
            Workflows = new HashSet<Workflow>();
        }

        public long IdPieza { get; set; }
        public string NumeroParte { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<MultiMediaPieza> MultiMediaPiezas { get; set; }
        public virtual ICollection<PiezaCliente> PiezaClientes { get; set; }
        public virtual ICollection<ProcesoPiezaMaquina> ProcesoPiezaMaquinas { get; set; }
        public virtual ICollection<Workflow> Workflows { get; set; }
    }
}
