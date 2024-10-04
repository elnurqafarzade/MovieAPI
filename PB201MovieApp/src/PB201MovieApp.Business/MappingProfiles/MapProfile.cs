using AutoMapper;
using PB201MovieApp.Business.DTOs.GenreDTOs;
using PB201MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB201MovieApp.Business.MappingProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Movie, MovieGetDTO>().ReverseMap();
            CreateMap<MovieCreateDTO, Movie>().ReverseMap();
            CreateMap<MovieUpdateDTO, Movie>().ReverseMap();


            CreateMap<Genre, GenreGetDTO>().ReverseMap();
            CreateMap<Genre, GenreCreateDTO>().ReverseMap();
            CreateMap<Genre, GenreUpdateDTO>().ReverseMap();
        }
    }
}
