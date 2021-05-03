using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
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

        public virtual Operacion IdOperacionNavigation { get; set; }
        public virtual Perfil IdPerfilNavigation { get; set; }
    }
}
