using AutoMapper;
using MyProject.Core.Features.Users.Commands.Models;
using MyProject.Data.Entities;


namespace MyProject.Core.Mapping.Users
{
    public partial class ApplicationUserProfile : Profile
    {
        public void UpdateApplicationUserMapping()
        {
            CreateMap<UpdateApplicationUserCommand, ApplicationUser>();
        }

    }
}
