using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text;
using GameFinder.Models;
using GameFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameFinder.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private GameFinderContext _db;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public LoginController(IConfiguration config, GameFinderContext db, UserManager<User> userManager,
        SignInManager<User> signInManager)
        {
            _config = config;
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginUser apiUser)
        {
            var user = await AuthenticateUser(apiUser.UserName, apiUser.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect"});
            }

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegisterUser apiUser)
        {
            var user = new User { UserName = apiUser.UserName, Email = apiUser.Email, FirstName = apiUser.FirstName, LastName = apiUser.LastName };
            IdentityResult result = await _userManager.CreateAsync(user, apiUser.Password);

            if (result.Succeeded)
            {
                return Ok(user);
            }
            else
            {
                var errorList = result.Errors.ToList();
                string errorMsg = "The following error(s) occurred: ";
                foreach (var error in errorList)
                {
                    errorMsg += error.Code + " " + error.Description + " ";
                }

                return BadRequest(new { message = errorMsg });
            }
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> AuthenticateUser(string username, string password)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: true, lockoutOnFailure: false);
            GameFinder.Models.User user;

            if(!result.Succeeded)
            {
                return null;
            }
            else{
                user = _userManager.Users.FirstOrDefault(r => r.UserName == username);
            }

            // generate then set valid token
            user.Token = GenerateJSONWebToken(user);
            UpdateUserToken(user);
            
            return user;
        }

        private void UpdateUserToken(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
        }

    }
}