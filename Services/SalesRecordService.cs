using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) {

            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue) {
                result = result.Where(x => x.Date >= minDate);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate);
            }
            return await result.Include(x => x.Seller) //Mesma coisa que o JOIN do SQL, sendo assim estamos dando um JOIN na tabela Seller
                .Include(x => x.Seller.Department) //E um JOIN na tabela Seller, trazendo os departamentos
                .OrderByDescending(x => x.Date) //Ordenando por data de forma decrescente
                .ToListAsync(); //Retorna o resultado em fornma de LISTA e executa a função no banco de dados
        }
    }
}
