using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Empleado
    {
        public long IdEmpleado { get; set; }
        public string NNomina { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FNacimiento { get; set; }
        public DateTime FIngreso { get; set; }
        public string Email { get; set; }
        public string NominaJefe { get; set; }
        public long DepartamentoIdDepartamentoNivel0 { get; set; }
        public long? DepartamentoIdDepartamentoNivel1 { get; set; }
        public long? DepartamentoIdDepartamentoNivel2 { get; set; }
        public long? DepartamentoIdDepartamentoNivel3 { get; set; }
        public long IdiomaIdIdioma { get; set; }
        public long PuestosIdPuesto { get; set; }
        public long UnidadNegocioIdUnidadNegocio { get; set; }
        public long CentroCostoIdCentroCosto { get; set; }
        public long? IdPerfil { get; set; }
        public bool? Activo { get; set; }

        public virtual CentroCosto CentroCostoIdCentroCostoNavigation { get; set; }
        public virtual Departamento DepartamentoIdDepartamentoNivel0Navigation { get; set; }
        public virtual DepartamentoNivel1 DepartamentoIdDepartamentoNivel1Navigation { get; set; }
        public virtual DepartamentoNivel2 DepartamentoIdDepartamentoNivel2Navigation { get; set; }
        public virtual DepartamentoNivel3 DepartamentoIdDepartamentoNivel3Navigation { get; set; }
        public virtual Perfile IdPerfilNavigation { get; set; }
        public virtual Idioma IdiomaIdIdiomaNavigation { get; set; }
        public virtual Puesto PuestosIdPuestoNavigation { get; set; }
        public virtual UnidadNegocio UnidadNegocioIdUnidadNegocioNavigation { get; set; }
    }
}
