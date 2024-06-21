﻿using KhumaloWebApplication.Data;
using KhumaloWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KhumaloWebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin dashboard action
        public IActionResult AdminDashboard()
        {
            return View();
        }

        // Action to view all products
        public IActionResult ViewProducts()
        {
            var products = _context.Product.ToList();
            return View(products);
        }

        // Example of an admin-only action to insert a new product
        [HttpGet]
        public IActionResult InsertProduct()
        {
            return View(new Products()); // Return the view with a new instance of Products model
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertProduct(Products product)
        {
            if (ModelState.IsValid)
            {
                _context.Product.Add(product);
                _context.SaveChanges();
                return RedirectToAction("AdminDashboard");
            }
            return View(product); // Return to the view with validation errors
        }

        // Action to edit a product
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return NotFound(); // Return 404 if product is not found
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Products product)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(ViewProducts));
            }
            return View(product); // Return to the view with validation errors
        }

        // Action to delete a product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return NotFound(); // Return 404 if product is not found
            }
            _context.Product.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(ViewProducts));
        }

        // Action to view all orders
        public IActionResult ViewOrders()
        {
            var orders = _context.Order.Include(o => o.User).ToList();
            return View(orders);
        }

        // Action to process an order
        public IActionResult ProcessOrder(int id)
        {
            var order = _context.Order.Find(id);
            if (order == null)
            {
                return NotFound(); // Return 404 if order is not found
            }

            // Process the order (e.g., update status)
            order.Status = OrderStatus.Processed; // Assuming OrderStatus is an enum
            _context.SaveChanges();

            return RedirectToAction(nameof(ViewOrders));
        }

        // Action to update order status
        [HttpPost]
        public IActionResult UpdateOrderStatus(int id, OrderStatus status)
        {
            var order = _context.Order.Find(id);
            if (order == null)
            {
                return NotFound(); // Return 404 if order is not found
            }

            // Update the order status
            order.Status = status;
            _context.SaveChanges();

            return RedirectToAction(nameof(ViewOrders));
        }

        // Other admin-only actions...
    }
}
