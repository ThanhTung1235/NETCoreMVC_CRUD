using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNetCoreMVC_again.Models;

namespace MyNetCoreMVC_again.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContentText _content;
        public ProductController(MyDbContentText context)
        {
            _content = context;
        }
        public IActionResult Index()
        {
            return View(_content.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Save(Product product)
        {
            _content.Products.Add(product);
            _content.SaveChanges();
            return Json(product);
        }
        public IActionResult Edit(long id)
        {
            var exitProduct = _content.Products.Find(id);
            if (exitProduct == null)
            {
                return NotFound();
            }
            return View(exitProduct);
        }
        public IActionResult Update(Product product)
        {
            var exitProduct = _content.Products.Find(product.Id);
            if (exitProduct == null)
            {
                return NotFound();
            }

            exitProduct.Name = product.Name;
            exitProduct.Price = product.Price;
            _content.Products.Update(exitProduct);
            _content.SaveChanges();
            return Redirect("Index");
        }
        public IActionResult Delete(long id)
        {
            var exitProduct = _content.Products.Find(id);
            if (exitProduct == null)
            {
                return NotFound();
            }
            _content.Products.Remove(exitProduct);
            _content.SaveChanges();
            return Redirect("Index");
        }

    }
}