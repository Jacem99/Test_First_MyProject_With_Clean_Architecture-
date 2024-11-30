namespace MyProject.Core.Features.Users.Result
{

    public class GetApplicationUserPaginatedListResponse : GetApplicationUserResponse
    {

        public GetApplicationUserPaginatedListResponse(string Id, string FullName, string UserName, string Email, string Country, string Age, string PhoneNumber)
        {
            this.Id = Id;
            this.FullName = FullName;
            this.UserName = UserName;
            this.Email = Email;
            this.Country = Country;
            this.Age = Age;
            this.PhoneNumber = PhoneNumber;

        }
    }
}
