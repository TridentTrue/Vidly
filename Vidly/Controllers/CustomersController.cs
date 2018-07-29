using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		public List<Customer> customerList = new List<Customer>()
		{
			new Customer { Id = 1, Name = "John Smith" },
			new Customer { Id = 2, Name = "Mary Williams" },
		};

		// GET: Customers
		public ActionResult Index()
		{
			return View(customerList);
		}

		[Route("customers/details/{customerId?}")]
		public ActionResult Details(int? customerId)
		{
			if (customerId == null)
				return Content("Please include a CustomerId in the URL");

			var customer = customerList.SingleOrDefault(c => c.Id == customerId);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}
	}
}