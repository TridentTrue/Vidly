using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
	public class CustomersController : BaseController
	{
		// GET: Customers
		public ActionResult Index()
		{
			return View(db.Customers.Include(c => c.MembershipType).ToList());
		}

		[Route("customers/details/{customerId?}")]
		public ActionResult Details(int? customerId)
		{
			if (customerId == null)
				return Content("Please include a CustomerId in the URL");

			var customer = db.Customers.SingleOrDefault(c => c.Id == customerId);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}
	}
}