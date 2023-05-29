using FayrouzGlobitelAssignmentFullStack.data;
using FayrouzGlobitelAssignmentFullStack.Models;
using Microsoft.AspNetCore.Identity;

namespace FayrouzGlobitelAssignmentFullStack.Services
{
    public class AccountService : IAccountService
    {

        UserManager<ApplicationUsers> userManager;
        RoleManager<IdentityRole> roleManager;
        SignInManager<ApplicationUsers> signInManager;
        public AccountService(UserManager<ApplicationUsers> _userManager, RoleManager<IdentityRole> _roleManager, SignInManager<ApplicationUsers> _signInManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }

        public async Task<IdentityResult> CreateAccount(SignUp signUp)
        {
            ApplicationUsers user = new ApplicationUsers()
            {
                UserName = signUp.Name,
                Name = signUp.Name,
                Email = signUp.Email,
                //PasswordHash=signUp.Password

            };
            var result = await userManager.CreateAsync(user, signUp.Password);
            return result;
        }


        public async Task<SignInResult> SignIn(SignIn signIn)
        {
            var result = await signInManager.PasswordSignInAsync(signIn.Username, signIn.Password, signIn.RememberMe, false);
            return result;
        }


        public async Task<ApplicationUsers> GetUSerInfo(string username)
        {
            var result = await userManager.FindByNameAsync(username);
            return result;

        }

        public List<string> getUserRoles(ApplicationUsers obj)
        {
            var result = userManager.GetRolesAsync(obj).Result.ToList();
            return result;

        }

        //public async Task<List<UserRoles>> getUserRoles(string UserId)
        //{
        //    List<IdentityRole> li = roleManager.Roles.ToList();

        //    List<UserRoles> userRoles = new List<UserRoles>();

        //    foreach (var item in li)
        //    {

        //        userRoles.Add(new UserRoles()
        //        {
        //            RoleId = item.Id,
        //            RoleName = item.Name,
        //            IsSelected = false,
        //            UserId = UserId
        //        });
        //    }

        //    foreach (var item in userRoles)
        //    {
        //        var user = await userManager.FindByIdAsync(UserId);
        //        var uroles = await userManager.GetRolesAsync(user);
        //        foreach (var roleName in uroles)
        //        {
        //            if (roleName == item.RoleName)
        //            {
        //                item.IsSelected = true;
        //            }
        //        }
        //    }
        //    return userRoles;
        //}

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }


        public async Task<IdentityResult> NewRole(Role role)
        {
            IdentityRole Irole = new IdentityRole()
            {
                Name = role.Name
            };

            var result = await roleManager.CreateAsync(Irole);
            return result;

        }

        public List<UsersDTO> getUsers()
        {
            List<ApplicationUsers> li = userManager.Users.ToList();
            List<UsersDTO> users = new List<UsersDTO>();
            foreach (var item in li)
            {
                users.Add(new UsersDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                });

            }

            return users;
        }

        public async Task DeleteUser(string Id)
        {
            var appUser = await userManager.FindByIdAsync(Id);
            await userManager.DeleteAsync(appUser);
            userManager.UpdateAsync(appUser);

        }

        public async Task<List<UserRoles>> getUserRoles(string UserId)
        {
            List<IdentityRole> li = roleManager.Roles.ToList();

            List<UserRoles> userRoles = new List<UserRoles>();

            foreach (var item in li)
            {

                userRoles.Add(new UserRoles()
                {
                    RoleId = item.Id,
                    RoleName = item.Name,
                    IsSelected = false,
                    UserId = UserId
                });
            }

            foreach (var item in userRoles)
            {
                var user = await userManager.FindByIdAsync(UserId);
                var USERroles = await userManager.GetRolesAsync(user);
                foreach (var roleName in USERroles)
                {
                    if (roleName == item.RoleName)
                    {
                        item.IsSelected = true;
                    }
                }
            }
            return userRoles;
        }

        public async Task UpdateUserRoles(List<UserRoles> liUserRoles)
        {

            foreach (var item in liUserRoles)
            {
                var user = await userManager.FindByIdAsync(item.UserId);
                if (item.IsSelected)
                {
                    if (await userManager.IsInRoleAsync(user, item.RoleName) == false)
                        await userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    if (await userManager.IsInRoleAsync(user, item.RoleName))
                    {
                        await userManager.RemoveFromRoleAsync(user, item.RoleName);
                    }
                }
            }
        }




    }

    }

