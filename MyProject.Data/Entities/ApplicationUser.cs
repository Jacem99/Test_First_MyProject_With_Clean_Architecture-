using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Entities
{
  public  class ApplicationUser : IdentityUser
    {
        public string? FullName  { get; set; }
        public string?  Country { get; set; }
        public string?  Age { get; set; }

    }
}
