using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using AutoMapper;

namespace Vidly.Controllers
{
	public class MoviesController : BaseController
	{
		public ActionResult Index(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue)
				pageIndex = 1;

			if (string.IsNullOrWhiteSpace(sortBy))
				sortBy = "Name";

			return View(db.Movies.Include(m => m.Genre).ToList());
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
				return Content("Please include a MovieId in the URL");

			var movie = db.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

			if (movie == null)
				return HttpNotFound();

			return View(movie);
		}

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

		public ActionResult New()
		{
			var vm = new MovieFormViewModel()
			{
				Genres = db.Genres.ToList(),
			};

			return View("MovieForm", vm);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
				return Content("Please include a MovieId in the URL");

			var movie = db.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

			if (movie == null)
				return HttpNotFound();

			return View("MovieForm", Mapper.Map<Movie, MovieFormViewModel>(movie));
		}

		[HttpPost]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
				return View("MovieForm", Mapper.Map<Movie, MovieFormViewModel>(movie));

			if (movie.Id == 0)
				db.Movies.Add(movie);
			else
			{
				db.Movies.Attach(movie);
				db.Entry(movie).State = EntityState.Modified;
			}

			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}