using APIRestV2.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponseOperacion
    {
        //public List<ComplementosSuccessResponse> Bien { get; set; }
        //public List<ComplementosFailResponse> Mal { get; set; }
        public String Id { get; set; }
        public String Codigo { get; set; }
        
    }

  /*  public class ComplementosFailResponse
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

    }*/
}
