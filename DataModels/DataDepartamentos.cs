using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataDepartamentos
    {
        private readonly Carta_vContext _context;

        public DataDepartamentos()
        {
            _context = new Carta_vContext();
        }

        public async Task<List<Departamento>> FindAllDepartamentos()
        {

            return await _context.Departamentos.ToListAsync();
        }
        public Departamento FindDepartamento(int tipoBusqueda, long id_depaExterno, string nombreDepa)
        {
            Departamento resultadobusqueda = new();
            switch (tipoBusqueda)
            {
                case 1:
                    resultadobusqueda = _context.Departamentos.AsNoTracking().SingleOrDefault(us => us.IdDepartamentExt == id_depaExterno);
                    break;
                case 2:
                    resultadobusqueda = _context.Departamentos.AsNoTracking().SingleOrDefault(us => us.Departamento1 == nombreDepa);
                    break;
                default:
                    break;
            }
            return resultadobusqueda;
        }

        public long AddDepartamento(Departamento NewDepartamento)
        {
            try
            {
                var departamentoRes = _context.Departamentos.Add(NewDepartamento);
                _context.SaveChanges();
                return Int32.Parse(departamentoRes.Entity.IdDepartamento.ToString());
            }
            catch (Exception ex)
            {
                var r =  ex.Message;
                return 0;
            }
            
        }

        public long UpdateDepartamento(Departamento _depto)
        {
            try
            {
                _context.Departamentos.Update(_depto);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return 0; ;
            }

        }

    }
}
