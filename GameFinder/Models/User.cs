using System.Collections.Generic;

namespace GameFinder.Models
{
    public class User
    {
        public static List<User> _users = new List<User>
            {
                new User { Id = 1, FirstName = "Test", LastName = "User", Email = "test@test.com", Username = "test", Password = "test" }
            };
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}