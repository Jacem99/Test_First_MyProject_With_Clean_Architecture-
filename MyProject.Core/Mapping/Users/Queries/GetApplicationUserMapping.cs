using AutoMapper;
using MyProject.Core.Features.Users.Result;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Mapping.Users
{
    public partial class ApplicationUserProfile : Profile
    {
        public void GetApplicationUserMapping()
        {
            CreateMap<ApplicationUser,GetApplicationUserResponse>();
        }
    }
}
