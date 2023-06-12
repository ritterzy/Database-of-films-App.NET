using AutoMapper;
using EXAM.DAL.Models;
using EXAM.DAL.ViewModels;
using EXAM.DAL.ViewModelsWithId;

namespace EXAM.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ActorViewModel, Actor>();
            CreateMap<ActorViewModelWithId, Actor>();
            CreateMap<CountryViewModel, Country>();
            CreateMap<CountryViewModelWithId, Country>();
            CreateMap<GenreViewModel, Genre>();
            CreateMap<GenreViewModelWithId, Genre>();
            CreateMap<MovieViewModel, Movie>();
            CreateMap<MovieViewModelWithId, Movie>();
            CreateMap<ProducerViewModel, Producer>();
            CreateMap<ProducerViewModelWithId, Producer>();
        }
        
    }
}
