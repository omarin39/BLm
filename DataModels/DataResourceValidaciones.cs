using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataResourceValidaciones
    {
        //public ParametrosValida(Carta_vContext context)
        //{
        //    _context = context;
        //}
        public async Task<List<ResourceValidacionesCampo>> FindAllDatosValida()
        {
            using var context = new Carta_vContext();
            return await context.ResourceValidacionesCampos.ToListAsync();
        }
        //public IReadOnlyList<ResourceValidacionesCampo> DatosValida()
        //{
        //    using (var context = new Carta_vContext())
        //    {
        //        return context.ResourceValidacionesCampos.ToList();
        //    }
        //}
    }
}
