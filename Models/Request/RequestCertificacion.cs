using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestCertificacion
    {   
        public long idCertificacion { get; set; }     
        public DateTime fechaEntrenamiento { get; set; }
        public DateTime fechaCertificacion { get; set; }
        public int idCertificador { get; set; }
        public string tokenCertificador { get; set; }
        public DateTime fechaCertificador { get; set; }
        public int idMentor { get; set; }
        public string tokenMentor { get; set; }
        public DateTime fechaMentor { get; set; }
        public int idResponsable { get; set; }
        public string tokenResponsable { get; set; }
        public DateTime fechaResponsable { get; set; }
        public float resultado { get; set; }
        public bool Activo { get; set; }
        
    }
}
