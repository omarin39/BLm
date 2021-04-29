﻿using APIRest.Models;
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
        private Controllers.Process.Process_Log procLog;
        public DataPreguntaPtGeneral()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<PreguntasPtGenerale> FindAllPreguntas()
        {
            return  _context.PreguntasPtGenerales.ToList();
        }
        public PreguntasPtGenerale FindPregunta(string Pregunta)
        {
            return _context.PreguntasPtGenerales.AsNoTracking().SingleOrDefault(us => us.Pregunta == Pregunta);
        }

        public long AddPregunta(PreguntasPtGenerale item,string ip)
        {
            try
            {
                var PreguntaRes = _context.PreguntasPtGenerales.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PreguntaRes.Entity.IdPreguntaPt.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdatePregunta(PreguntasPtGenerale item,string ip)
        {
            try
            {
                _context.PreguntasPtGenerales.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                return 0;
            }

        }
    }
}
