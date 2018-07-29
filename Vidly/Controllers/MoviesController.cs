﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		public List<Movie> movieList = new List<Movie>()
		{
			new Movie { Id = 1, Name = "Shrek" },
			new Movie { Id = 2, Name = "Wall-E" },
		};

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

			return View(movieList);
		}
	}
}