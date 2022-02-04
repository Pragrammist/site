using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Models.ProductModels;
using MarketPlace.Services;

namespace MarketPlace.Controllers
{
    public class ProductsController : Controller
    {
        readonly DbService _db;

        public ProductsController(DbService service) 
        {
            _db = service;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddProducToDb(ProductViewModel model)
        {
            Validate(model);
            if (ModelState.IsValid)
            {
                string name = model.Name;
                string manufacturer = model.Manufacturer;
                string description = model.Description;
                string photoPath = model.PhotoPath;
                ProductModel product = new();
                { 
                    product.Description = description;
                    product.Manufacturer = manufacturer;
                    product.Name = name;
                    product.PhotoPath = photoPath;
                }// initialize product
                AddToDb(product);
            }

            return Content("ACED");
        }


        private void AddToDb(ProductModel product)
        {
            _db.AddProduct(product);
        }


        static private void Validate(ProductViewModel model)
        {
            
        }


        public IActionResult GetProducts(int page = 1)
        {
            var prds = _db.GetProducts(page);
            return Content("aced");
        }

        
        public IActionResult AddScore(int score, int id)
        {
            _db.AddScore(score, id);
            return Content("aced");
        }


    }
}
