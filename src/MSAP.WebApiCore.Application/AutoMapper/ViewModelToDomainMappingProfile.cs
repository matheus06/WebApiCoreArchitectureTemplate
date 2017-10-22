using AutoMapper;
using MSAP.WebApiCore.Application.ViewModels;
using MSAP.WebApiCore.Domain.Models;

namespace MSAP.WebApiCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TodoViewModel, Todo>();
        }
    }
}