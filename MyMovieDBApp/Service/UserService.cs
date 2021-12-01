using MyMovieDBApp.Models;
using MyMovieDBApp.Service.Interface;
using System;
using System.Collections.Generic;

namespace MyMovieDBApp.Service
{
    public class UserService : IUser
    {
        private UserContext _UserContext;

        public UserService(UserContext UserContext)
        {
            _UserContext = UserContext;
        }

        //private List<User> Users = new List<User>()
        //{
        //    new User()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Musanna",
        //        MiddleName = "Bin",
        //        LastName = "Tauhid"
        //    },
        //    new User()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Muhammad",
        //        MiddleName = "Bin",
        //        LastName = "Tauhid"
        //    }
        //};
        public User CreateUser(User User)
        {
            _UserContext.Users.Add(User);
            _UserContext.SaveChanges();
            return User;
        }

        public void DeleteUser(int userId)
        {
            _UserContext.Users.Remove(GetUser(userId));
            _UserContext.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _UserContext.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _UserContext.Users;
        }

        public User UpdateUser(User User)
        {
            User oldUser = GetUser(User.UserId);
            oldUser.UserName = User.UserName;
            return oldUser;
        }
    }
}
