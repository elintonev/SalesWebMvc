using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
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
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()  //Como não tinba nenhuma ação configurada, a ação Index foi acionada.
                                      //O IActionResult chamou a View(), e a VIEW foi na pasta Views.Sellers e buscou pela view INDEX
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create() {
            var departments = _departmentService.FindAll();
            var viewModels = new SellerFormViewModel { Departments = departments};
            return View(viewModels);
        }
        [HttpPost] //Notação para definir que o método abaixo seja lido como um HTTPPOST
        [ValidateAntiForgeryToken] //Notação para definit que os dados pessoais do formulário não possam ser usados por token maliciosos
        public IActionResult Create(Seller seller) {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id) {
            if (id == null) {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id) {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
