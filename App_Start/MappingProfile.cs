using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieApp.Dtos;
using MovieApp.Models;

namespace MovieApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //domain to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();



            //dto to domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c=>c.Id, opt =>opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}