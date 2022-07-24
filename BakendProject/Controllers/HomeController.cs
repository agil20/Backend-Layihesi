﻿using BakendProject.DAL;
using BakendProject.Models;
using BakendProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BakendProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List <Slider> dbsliders = _context.Sliders.ToList();
            List<ModalProduct> dbModalProduct= _context.modalProducts.ToList();
            List<Product> dbProducts = _context.Products
                .Include(p=>p.ProductImages)
                .Include(p=>p.Category).ToList();
            List<Category> dbCategories = _context.Categories.ToList();
            HomeVM homeVM = new HomeVM();
            homeVM.modalProducts = dbModalProduct;
            homeVM.sliders = dbsliders;
            homeVM.products = dbProducts;
            homeVM.categories = dbCategories;
            return View(homeVM);
        }
    }
}
