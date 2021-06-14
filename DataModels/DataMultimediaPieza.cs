using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataMultimediaPieza
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataMultimediaPieza()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public  List<MultiMediaPieza> FindAllMultimediaPieza()
        {
            return  _context.MultiMediaPiezas.AsNoTracking().ToList();
        }
        public MultiMediaPieza FindMultimediaPieza(long idMultimedia, long idPieza)
        {
            return _context.MultiMediaPiezas.AsNoTracking().SingleOrDefault(us => us.Id == idMultimedia && us.IdPieza== idPieza);
        }

        public bool ValidaClaveExistente(string nombre)
        {
            //true si existe
            //false si no existe
            var busqueda = _context.MultiMediaPiezas.AsNoTracking().SingleOrDefault(us => us.Nombre.Trim().ToUpper() == nombre.Trim().ToUpper());
            return busqueda == null ? false : true;
        }

        public bool ValidaClaveEdit(string nombre, long id)
        {
            //true si existe
            //false si no existe
            var busqueda = _context.MultiMediaPiezas.AsNoTracking().SingleOrDefault(us => us.Nombre.Trim().ToUpper() == nombre.Trim().ToUpper() && us.Id != id);
            return busqueda == null ? false : true;
        }

        public MultiMediaPieza FindMultimediaPiezaPorId(long Id)
        {

            var busqueda = _context.MultiMediaPiezas.AsNoTracking().SingleOrDefault(us => us.Id == Id);
            return busqueda;
        }

        public List<MultiMediaPieza> FindMultimediaPiezaTipMedia(string TipoMedia, long idPieza)
        {
            if (string.IsNullOrEmpty(TipoMedia))
            {
                return _context.MultiMediaPiezas.AsNoTracking().Where(us => us.IdPieza == idPieza).ToList();
            }
            else
            {
                return _context.MultiMediaPiezas.AsNoTracking().Where(us => us.TipoMedia == TipoMedia && us.IdPieza == idPieza).ToList();
            }
            
        }

        public long AddMultimediaPieza(MultiMediaPieza item,string ip)
        {
            try
            {
                var MultimediaPiezaRes = _context.MultiMediaPiezas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(MultimediaPiezaRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateMultimediaPieza(MultiMediaPieza item,string ip)
        {
            try
            {
                _context.MultiMediaPiezas.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                return 0;
            }

        }

        internal List<VersionMultiMediaPieza> FindMultimediaPiezaVersiones(long idMultimedia, string version)
        {
            return _context.VersionMultiMediaPiezas.AsNoTracking().Where(us => us.IdMultiMediaPieza == idMultimedia).OrderBy(u => u.IdMultiMediaPieza).ToList();
        }

        internal long AddMultimediaPiezaVersion(VersionMultiMediaPieza item, string ip)
        {
            try
            {
                var MultimediaPiezaRes = _context.VersionMultiMediaPiezas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(MultimediaPiezaRes.Entity.IdMultiMediaPieza.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
    }
}
