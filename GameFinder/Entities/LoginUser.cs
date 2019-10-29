using System.ComponentModel.DataAnnotations;

namespace GameFinder.Entities
{
    public class LoginUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}