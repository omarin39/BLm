using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataResourceValidaciones
    {
        //public ParametrosValida(Carta_vContext context)
        //{
        //    _context = context;
        //}
        public async Task<List<ResourceValidacionCampo>> FindAllDatosValida()
        {
            using var context = new CARTAVContext();
            return await context.ResourceValidacionCampos.ToListAsync();
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
