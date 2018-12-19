using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TumbleweedBakehouse.Models;
using System;

namespace TumbleweedBakehouse.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet("/customer")]
        public ActionResult Index()
        {
          List<Customer> allCustomers = Customer.GetAll();
          return View(allCustomers);
        }
        [HttpGet("/customer/{customerId}/edit")]
        public ActionResult Edit(int customerId)
        {
          Dictionary<string, object> model = new Dictionary<string, object>( );
          Customer customer = Customer.Find(customerId);
          model.Add("customer", customer);
          return View("edit", model);
        }
        [HttpPost("/customer/{customerId}")]
        public ActionResult Update(int customerId, string firstName, string lastName, string phoneNumber, string email, string homeAddress, string city, string state, int zipCode)
        {
          Customer customer = Customer.Find(customerId);
          customer.Edit(firstName, lastName, phoneNumber, email, homeAddress, city, state, zipCode);
          return RedirectToAction("show");
        }
// "index", new {id = customerId}
        [HttpGet("/customer/new")]
        public ActionResult New()
        {
          // List<Customer> allCustomers = Customer.GetAll();
          return View();
        }
        [HttpPost("/customer")]
        public ActionResult Create(string firstName, string lastName, string phoneNumber, string email, string homeAddress, string city, string state, int zipCode)
        {
          Customer newCustomer = new Customer(firstName, lastName, phoneNumber, email, homeAddress, city, state, zipCode);
          newCustomer.Save();
          return RedirectToAction("index");
        }

        [HttpGet("/customer/{customerId}")]
        public ActionResult Show(int customerId)
        {
          Dictionary<string, object> model = new Dictionary<string, object> { };
          Customer customer = Customer.Find(customerId);
          List<Order> orders = Customer.FindOrders(customerId);
          model.Add("orders", orders);
          model.Add("customer", customer);
          return View(model);
        }
    }
}
