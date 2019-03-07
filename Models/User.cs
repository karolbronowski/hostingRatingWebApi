using System.Collections.Generic;

namespace hostingRatingWebApi.Models
{
    public class User : Entity
    {
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public UserRoles Role {get;protected set;} = UserRoles.User;
        public List<Brand> AddedBrands {get;set;}
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public User(string email, string password, bool isAdmin)
        {
            Email = email;
            Password = password;
            if(isAdmin) Role = UserRoles.Admin;
        }
        public User()
        {

        }
        public enum UserRoles {
            Admin = 0,
            User = 1
        }
    }
}