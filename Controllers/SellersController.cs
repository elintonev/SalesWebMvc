using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller //Recebeu a chamada do caminho /Sellers que apresenta no navegador
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()  //Como não tinba nenhuma ação configurada, a ação Index foi acionada.
                                      //O IActionResult chamou a View(), e a VIEW foi na pasta Views.Sellers e buscou pela view INDEX
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

    }
}
