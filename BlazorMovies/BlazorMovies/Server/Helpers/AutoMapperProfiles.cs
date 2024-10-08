﻿using AutoMapper;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, Actor>()
            .ForMember(x => x.Photo, option => option.Ignore()); 

            CreateMap<Movie, Movie>()
                .ForMember(x => x.Poster, option => option.Ignore());
        }
    }
}
