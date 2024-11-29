using MediatR;
using MyProject.Core.Features.Users.Result;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Users.Queries.Models
{
    public class GetApplicationUserByIdModel : IRequest<Response<GetApplicationUserResponse>>
    {
        public readonly string _userId ;

        public GetApplicationUserByIdModel(string userId)
        {
            _userId = userId;
        }
    }

}
