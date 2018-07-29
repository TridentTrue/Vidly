using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : BaseController
	{
		// GET: Movies/Random
		public ActionResult Random()
		{
			var movie = new Movie() { Name = "Shrek" };
			var customers = new List<Customer>()
			{
				new Customer { Name = "Customer1" },
				new Customer { Name = "Customer2" },
			};

			var viewModel = new RandomMovieViewModel()
			{
				Movie = movie,
				Customers = customers,
			};

			return View(viewModel);
		}

		[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}

		public ActionResult Edit(int id)
		{
			return Content("id = " + id);
		}

		public ActionResult Index(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue)
				pageIndex = 1;

			if (string.IsNullOrWhiteSpace(sortBy))
				sortBy = "Name";

			return View(db.Movies.Include(m => m.Genre).ToList());
		}

		[Route("movies/details/{movieId?}")]
		public ActionResult Details(int? movieId)
		{
			if (movieId == null)
				return Content("Please include a movieId in the URL");

			var movie = db.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == movieId);

			if (movie == null)
				return HttpNotFound();

			return View(movie);
		}
	}
}