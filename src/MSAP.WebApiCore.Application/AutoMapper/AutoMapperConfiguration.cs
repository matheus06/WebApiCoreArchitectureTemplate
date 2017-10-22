using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace MSAP.WebApiCore.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return  new MapperConfiguration(p =>
            {
                p.AddProfile(new DomainToViewNodelMappingProfile());
                p.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
