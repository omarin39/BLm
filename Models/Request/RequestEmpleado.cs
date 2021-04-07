using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestEmpleado
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
        public Nullable<long> DepartamentoIdDepartamentoNivel0 { get; set; }
        public Nullable<long> DepartamentoIdDepartamentoNivel1 { get; set; }
        public Nullable<long> DepartamentoIdDepartamentoNivel2 { get; set; }
        public Nullable<long> DepartamentoIdDepartamentoNivel3 { get; set; }
        public long IdiomaIdIdioma { get; set; }
        public long PuestosIdPuesto { get; set; }
        public long UnidadNegocioIdUnidadNegocio { get; set; }
        public long CentroCostoIdCentroCosto { get; set; }
        public long? IdPerfil { get; set; }
    }
}
