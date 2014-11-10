﻿namespace CinemaWorld.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using AutoMapper;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class DetailsMovieViewModel : HomePageMovieViewModel, IMapFrom<Movie>, IHaveCustomMappings
    {
        [Required]
        public string Description { get; set; }

        [RegularExpression(@"^\d{4}$")]
        public int Year { get; set; }

        public int Duration { get; set; }

        public string Director { get; set; }

        public string Country { get; set; }

        public string Category { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Movie, DetailsMovieViewModel>()
               .ForMember(m => m.Country, opt => opt.MapFrom(u => u.Country.Name));
            configuration.CreateMap<Movie, DetailsMovieViewModel>()
                .ForMember(m => m.Category, opt => opt.MapFrom(u => u.Category.Name));
        }
    }
}