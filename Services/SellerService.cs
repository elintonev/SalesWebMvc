using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj) {
            _context.Add(obj); //Metodo que pega minha variável do tipo Seller e insere no banco de dados
            _context.SaveChanges(); // Método que confirma a ação de inserir informações no banco de dados
        }
    }
}
