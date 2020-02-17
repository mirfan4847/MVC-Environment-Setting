using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EnvironmentSetting.Model;
using EnvironmentSetting.ViewModel;

namespace EnvironmentSetting.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<UserViewModel, Users>();
            Mapper.CreateMap<Users, UserViewModel>();
        }

        protected override void Configure()
        {
            
        }
    }
}