using AutoMapper;

namespace MyProject.Core.Mapping.Users
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            AddUserMapping();
            UpdateApplicationUserMapping();
            GetApplicationUserMapping();
        }
    }
}
