using APIRestV2.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestExamenDeCertificacion
    {
        public long IdExamenCertificacion { get; set; }
        public long IdCapacitacionEmpleado { get; set; }
        public double TotalFinalExamen { get; set; }
        public DateTime FechaExamen { get; set; }
        public bool FirmaEmpleado { get; set; }
        public DateTime? FechaFirmaEmpleado { get; set; }
        public DateTime? FechaFirmaFinal { get; set; }
        public bool EstadoExamen { get; set; }
        public int FirmasTotales { get; set; }
        public bool Activo { get; set; }

        public double TotalFinalMaquina { get; set; }
        public string TotalDescripcionFinalMaquina { get; set; }

        public double TotalFinalProceso { get; set; }
        public string TotalDescripcionFinalProceso { get; set; }

        public double TotalFinalPieza { get; set; }
        public string TotalDescripcionFinalPieza { get; set; }

        public List<DataGlobalPreguntasMaquina> DataGlobalPreguntasMaquinaList { get; set; }
        public List<DataGlobalPreguntasProceso> DataGlobalPreguntasProcesoList { get; set; }
        public List<DataGlobalPreguntasPieza> DataGlobalPreguntasPiezaList { get; set; }
    }

    public class DataGlobalPreguntasMaquina
    {
        public long IdGlobal { get; set; }
        public long IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public bool Demuestra { get; set; }
        public bool Reforzar { get; set; }
        public bool NoDemuestra { get; set; }
        public double Resultado { get; set; }
        public bool IsGral { get; set; }
        public long IdIdioma { get; set; }
        public long IdTipoPregunta { get; set; }
        public long IdNivelCertificacion { get; set; }
        
        
    }


    public class DataGlobalPreguntasProceso
    {
        public long IdGlobal { get; set; }
        public long IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public bool Demuestra { get; set; }
        public bool Reforzar { get; set; }
        public bool NoDemuestra { get; set; }
        public double Resultado { get; set; }
        public bool IsGral { get; set; }
        public long IdIdioma { get; set; }
        public long IdTipoPregunta { get; set; }
        public long IdNivelCertificacion { get; set; }
    }



    public class DataGlobalPreguntasPieza
    {
        public long IdGlobal { get; set; }
        public long IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public bool Demuestra { get; set; }
        public bool Reforzar { get; set; }
        public bool NoDemuestra { get; set; }
        public double Resultado { get; set; }
        public bool IsGral { get; set; }
        public long IdIdioma { get; set; }
        public long IdTipoPregunta { get; set; }
        public long IdNivelCertificacion { get; set; }
    }
}
