using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using abc_healthcare.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace abc_healthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly UsersContext _context;
        public UsersController(IConfiguration config, UsersContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("CreateUser")]
        public IActionResult Create(Users user)
        {
            /* if (_context.Userss.Where(u => u.username == user.username).FirstOrDefault() != null)
             {
                 return Ok("Username exists");
             }
             if (_context.Userss.Where(u=>u.mail==user.mail).FirstOrDefault()!=null)
             {
                 return Ok("Email already registered");
             }*/
            _context.Userss.Add(user);
            _context.SaveChanges();
            return Ok("Successfully registered !");
        }

        [HttpPost("LoginUser")]
        public IActionResult Login(login user)
        {
            var useravailable = _context.Userss.Where(u => u.username == user.username && u.password == user.password).FirstOrDefault();
            if (useravailable != null)
            {
                return Ok("success");
            }

            return Ok("Failure");
        }
        [HttpGet("UserDetails")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Userss.ToListAsync();

            return Ok(users);
        }

        [HttpGet("UserData")]
        public async Task<IActionResult> GetUserss()
        {
            var users = await _context.Userss.ToListAsync();

            return Ok(users);
        }

        [HttpDelete("{name}")]
        //  [Route("api/[controller]/{name}")]
        public IActionResult Delete(string name)
        {

            var item = _context.Userss.FirstOrDefault(x => x.username == name);

            if (item == null)
            {
                return NotFound();
            }

            _context.Userss.Remove(item);
            _context.SaveChanges();

            return Ok();



        }



    }
}
