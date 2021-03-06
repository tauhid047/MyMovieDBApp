using MyMovieDBApp.Models;
using System;
using System.Collections.Generic;

namespace MyMovieDBApp.Service.Interface
{
    public interface IUser
    {
        IEnumerable<User> GetUsers();

        User GetUser(int id);

        User CreateUser(User User);

        User UpdateUser(User User);

        void DeleteUser(int UserId);
    }
}
