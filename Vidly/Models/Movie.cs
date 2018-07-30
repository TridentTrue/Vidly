using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Movie
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public byte GenreId { get; set; }

		public Genre Genre { get; set; }

		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }

		[Display(Name = "Date Added")]
		public DateTime DateAdded { get; set; }

		[Range(0, short.MaxValue)]
		[Display(Name = "Number in Stock")]
		public short NumberInStock { get; set; }
	}
}