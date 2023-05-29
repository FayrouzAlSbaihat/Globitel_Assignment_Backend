using FayrouzGlobitelAssignmentFullStack.Models;
using FayrouzGlobitelAssignmentFullStack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FayrouzGlobitelAssignmentFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountService accountService;
        IConfiguration configuration;
        public AccountController(IAccountService _accountService , IConfiguration _configuration)
        {
            accountService= _accountService;
            configuration= _configuration;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {
           var result = await accountService.CreateAccount(signUp);
            if (result.Succeeded)
            {
                return Ok();
            }

            else
            {
                return StatusCode(500, result.Errors);
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(SignIn signIn)
        {
            var result = await accountService.SignIn(signIn);
            if (result.Succeeded)
            {
                var authClaim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,signIn.Username),
                    new Claim("UniqueValue",Guid.NewGuid().ToString())
                };

                var user = await accountService.GetUSerInfo(signIn.Username);

                var roles = accountService.getUserRoles(user);

                foreach (var item in roles)
                {
                    authClaim.Add(new Claim(ClaimTypes.Role, item));
                }


                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                            issuer: configuration["JWT:ValidIssuer"],
                            audience: configuration["JWT:ValidAudience"],
                            expires: DateTime.Now.AddDays(15),
                            claims: authClaim,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            );

                return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            user
                        });
            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpGet]
        [Route("LogOut")]
        public async Task LogOut()
        {
            accountService.Logout();
        }


        [HttpPost]
        [Route("AddRole")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(Role role)
        {
            var result = await accountService.NewRole(role);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, result.Errors);
            }
        }

        [HttpGet]
        [Route("UserList")]
        //[Authorize(Roles = "Admin")]
        public IActionResult UserList()
        {
            List<UsersDTO> users = accountService.getUsers();
            return Ok(users);

        }

        [HttpGet]
        [Route("Delete")]
        //[Authorize(Roles = "Admin")]
        public async Task Delete(string Id)
        {
            await accountService.DeleteUser(Id);
        }

        [HttpGet]
        [Route("UserRoles")]
        public async Task<IActionResult> UserRoles(string UserId)
        {
            List<UserRoles> userRoles = await accountService.getUserRoles(UserId);
            return Ok(userRoles);
        }

        [HttpPost]
        [Route("UpdateRole")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRole(List<UserRoles> userRoles)
        {
            await accountService.UpdateUserRoles(userRoles);
            userRoles = await accountService.getUserRoles(userRoles[0].UserId);

            return Ok(userRoles);
        }

        [HttpGet]
        [Route("NumOfUsers")]
        public int NumOfUsers()
        {
            List<UsersDTO> users = accountService.getUsers();
            return users.Count();

        }







    }
}
