using DatabasenWebApp.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.Xml;

namespace DatabasenWebApp.Services
{
    public class SecurityService
    {

        UsersDAO usersDAO = new UsersDAO();
        public SecurityService() 
        {
        }

        public bool IsValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }
    }
}
