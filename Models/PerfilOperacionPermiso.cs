using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class PerfilOperacionPermiso
    {
        public long Id { get; set; }
        public long IdPerfil { get; set; }
        public long IdOperacion { get; set; }
        public bool Crear { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool? Ver { get; set; }

        public virtual Operacione IdOperacionNavigation { get; set; }
        public virtual Perfile IdPerfilNavigation { get; set; }
    }
}
