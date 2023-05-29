using FayrouzGlobitelAssignmentFullStack.Models;
using Microsoft.AspNetCore.Identity;

namespace FayrouzGlobitelAssignmentFullStack.Services
{
    public interface IAccountService
    {
        public Task<IdentityResult> CreateAccount(SignUp signUp);
        public Task<SignInResult> SignIn(SignIn signIn);
        //public Task<ApplicationUsers> GetUserInfo(string username);
        public Task<ApplicationUsers> GetUSerInfo(string username);
        public List<string> getUserRoles(ApplicationUsers obj);

        //public Task<List<UserRoles>> GetUserRoles(string UserId);

        public Task Logout();
        public Task<IdentityResult> NewRole(Role role);
        public List<UsersDTO> getUsers();
        public Task DeleteUser(string Id);
        public Task<List<UserRoles>> getUserRoles(string UserId);
        public Task UpdateUserRoles(List<UserRoles> liUserRoles);





    }
}
