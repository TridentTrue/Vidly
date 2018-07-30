using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.App_Start
{
	public class MappingProfile : Profile
	{
		protected ApplicationDbContext db;

		public MappingProfile()
		{
			db = new ApplicationDbContext();

			CreateMap<Customer, CustomerFormViewModel>().IgnoreAllVirtual()
				.ForMember(dest => dest.MembershipTypes, opt => opt.MapFrom(src => db.MembershipTypes.ToList()))
				.ReverseMap();

			CreateMap<Movie, MovieFormViewModel>().IgnoreAllVirtual()
				.ForMember(dest => dest.Genres, opt => opt.MapFrom(src => db.Genres.ToList()))
				.ReverseMap();
		}
	}

	public static class IgnoreVirtualExtenisons
	{
		public static IMappingExpression<TSource, TDestination>
		
		IgnoreAllVirtual<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
		{
			var desType = typeof(TDestination);
			foreach (var property in desType.GetProperties().Where(p => p.GetGetMethod().IsVirtual && !p.GetGetMethod().IsFinal))
			{
				expression.ForMember(property.Name, opt => opt.Ignore());
			}

			return expression;
		}
	}
}