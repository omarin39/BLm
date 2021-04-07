using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestUsers
    {        
        public string Operacion { get; set; }
        public int NoNomina { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string FechaIngreso { get; set; }
        public string Email { get; set; }
        public long IdPlanta { get; set; }
        public string Planta { get; set; }
        public int IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public int IdDepNivel1 { get; set; }
        public string DepNivel1 { get; set; }
        public int IdDepNivel2 { get; set; }
        public string DepNivel2 { get; set; }
        public int IdDepNivel3 { get; set; }
        public string DepNivel3 { get; set; }
        public int IdPuesto{ get; set; }
        public string Puesto { get; set; }
        public int NominaJefe { get; set; }
        public int IdUnidad { get; set; }
        public string Unidad { get; set; }
        public int IdCeCo { get; set; }
        public string CeCo { get; set; }
        public string NoCentros { get; set; }
        public int Dueno { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string id_depa_externo { get; set; }
        public string id_puesto_externo { get; set; }
        public long IdPerfil { get; set; }
    }
}
