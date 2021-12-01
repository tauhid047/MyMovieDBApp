using Microsoft.AspNetCore.Mvc;
using MyMovieDBApp.Models;
using MyMovieDBApp.Service.Interface;
using System;

namespace UserRecordManagerWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _UserService;

        public UserController(IUser User)
        {
            _UserService = User;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_UserService.GetUsers());
        }

        //[HttpGet]
        //public IEnumerable<User> Get()
        //{
        //    return _UserService.GetUsers();
        //}


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = _UserService.GetUser(id);

            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"User with id: {id} was not found.");
        }

        [HttpPost]
        public IActionResult Post(User User)
        {
            _UserService.CreateUser(User);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + User.UserId, User);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            User oldUser = _UserService.GetUser(id);
            if (oldUser != null)
            {
                user.UserId = oldUser.UserId;
                _UserService.UpdateUser(user);
                return Ok(user);
            }
            return NotFound($"User with id: {id} couldn't be updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User User = _UserService.GetUser(id);
            if (User != null)
            {
                _UserService.DeleteUser(id);
                return Ok();
            }
            return NotFound($"User with id: {id} was not found!");
        }
    }
}