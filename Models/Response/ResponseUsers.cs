using APIRest.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Response
{
    public class ResponseUsers
    {
        public List<ComplementosSuccessResponse> Bien { get; set; }
        public List<ComplementosFailResponse> Mal { get; set; }
        public int Codigo { get; set; }
        
    }

    public class ComplementosFailResponse
    {
        public string NoNomina { get; set; }
        public string Operacion { get; set; }
        public string Codigo{ get; set; }
        public string Mensaje { get; set; }
    }

    public class ComplementosSuccessResponse
    {
        public string NoNomina { get; set; }
        public string Id_user { get; set; }
        public string Operacion { get; set; } 
    }

    public class ResponseUsersValida
    {
        public List<RequestUsers> Bien { get; set; }
        public List<ComplementosFailResponse> Mal { get; set; }

    }
}
