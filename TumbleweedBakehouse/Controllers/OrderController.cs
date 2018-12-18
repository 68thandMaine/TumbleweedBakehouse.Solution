using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakehouse.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet("/order/")]
        public ActionResult Index()
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            List<Customer> customerList = Customer.GetAll();
            List<Order> orderList = Order.GetAll();
            model.Add("customers", customerList);
            model.Add("orders", orderList);
            return View(model);
        }

        [HttpGet("/order/new")]
        public ActionResult New()
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            List<Customer> customerList = Customer.GetAll();
            List<Order> orderList = Order.GetAll();
            model.Add("customers", customerList);
            model.Add("orders", orderList);
            return View(model);
        }

        [HttpPost("/order")]
        public ActionResult Create(int customerId, DateTime requestedPickupDate, string pickupLocation)
        {

            Order newOrder = new Order(1, requestedPickupDate, pickupLocation, customerId);
            newOrder.Save();
            // return RedirectToAction("Index");
            return RedirectToAction("Show");
        }

        [HttpGet("/order/{orderId}")]
        public ActionResult Show()
        {
            return View();
        }

        [HttpGet("/order/{customerId}")]
        public ActionResult CustomerIndex(int customerId)
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            //Customer currentCustomer = Customer.Find(customerId);
            List<Order> orderList = Order.GetAll();

            return View(model);
        }

        [HttpGet("/order/{customerId}/show/{orderId}")]
        public ActionResult ShowCustomerOrder(int customerId, int orderId)
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };

            return View(model);
        }

        [HttpGet("/order/{customerId}/new")]
        public ActionResult NewCustomerOrder(int customerId)
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };

            return View();
        }
    }
}
