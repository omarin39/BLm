using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestEmpleado
    {   
        public long id_empleado { get; set; }     
        public string n_nomina { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public DateTime f_nacimiento { get; set; }
        public DateTime f_ingreso { get; set; }
        public string email { get; set; }
        public string nomina_jefe { get; set; }
        public Nullable<long> Departamento_id_departamento_nivel0 { get; set; }
        public Nullable<long> Departamento_id_departamento_nivel1 { get; set; }
        public Nullable<long> Departamento_id_departamento_nivel2 { get; set; }
        public Nullable<long> Departamento_id_departamento_nivel3 { get; set; }
        public long idioma_id_idioma { get; set; }
        public long Puestos_id_puesto { get; set; }
        public long Unidad_negocio_id_unidad_negocio { get; set; }
        public long Centro_costo_id_centro_costo { get; set; }
        public long id_Perfil { get; set; }
        
    }
}
