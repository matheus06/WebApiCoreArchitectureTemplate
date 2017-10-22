using AutoMapper;
using MSAP.WebApiCore.Application.ViewModels;
using MSAP.WebApiCore.Domain.Models;

namespace MSAP.WebApiCore.Application.AutoMapper
{
    public class DomainToViewNodelMappingProfile : Profile
    {
        public DomainToViewNodelMappingProfile()
        {
            CreateMap<Todo, TodoViewModel>();

        }
    }
}