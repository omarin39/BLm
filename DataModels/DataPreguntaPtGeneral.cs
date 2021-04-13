using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataPreguntaPtGeneral
    {
        private readonly Carta_vContext _context;

        public DataPreguntaPtGeneral()
        {
            _context = new Carta_vContext();
        }

        public List<PreguntasPtGenerale> FindAllPreguntas()
        {
            return  _context.PreguntasPtGenerales.ToList();
        }
        public PreguntasPtGenerale FindPregunta(string Pregunta)
        {
            return _context.PreguntasPtGenerales.AsNoTracking().SingleOrDefault(us => us.Pregunta == Pregunta);
        }

        public long AddPregunta(PreguntasPtGenerale NewPregunta)
        {
            try
            {
                var PreguntaRes = _context.PreguntasPtGenerales.Add(NewPregunta);
                _context.SaveChanges();
                return Int32.Parse(PreguntaRes.Entity.IdPreguntaPt.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }
        public int UpdatePregunta(PreguntasPtGenerale _Pregunta)
        {
            try
            {
                _context.PreguntasPtGenerales.Update(_Pregunta);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
