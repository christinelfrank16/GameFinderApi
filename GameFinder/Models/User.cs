using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GameFinder.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}