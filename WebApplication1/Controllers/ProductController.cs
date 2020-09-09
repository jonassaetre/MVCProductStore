using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product Product)
        {
            try
            {
                // Kall til metoden save i repository
                repository.Save(Product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
