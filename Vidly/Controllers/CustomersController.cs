using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class CustomersController : BaseController
	{
		// GET: Customers
		public ActionResult Index()
		{
			var customers = db.Customers.Include(c => c.MembershipType).ToList();
			return View(db.Customers.Include(c => c.MembershipType).ToList());
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
				return Content("Please include a CustomerId in the URL");

			var customer = db.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		public ActionResult New()
		{
			var vm = new CustomerFormViewModel()
			{
				MembershipTypes = db.MembershipTypes.ToList(),
			};

			return View("CustomerForm", vm);
		}
		
		public ActionResult Edit(int? id)
		{
			if (id == null)
				return Content("Please include a CustomerId in the URL");

			var customer = db.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View("CustomerForm", Mapper.Map<Customer, CustomerFormViewModel>(customer));
		}

		[HttpPost]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
				return View("CustomerForm", Mapper.Map<Customer, CustomerFormViewModel>(customer));

			if (customer.Id == 0)
				db.Customers.Add(customer);
			else
			{
				db.Customers.Attach(customer);
				db.Entry(customer).State = EntityState.Modified;
			}

			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}