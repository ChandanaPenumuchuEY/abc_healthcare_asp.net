using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using abc_healthcare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace abc_healthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly UsersContext _context;
        public AdminController(IConfiguration config, UsersContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpGet("AdminDetails")]
        public async Task<IActionResult> GetUsers()
        {
            var ausers = await _context.Admins.ToListAsync();

            return Ok(ausers);
        }
        [HttpPost("AdminUser")]
        public IActionResult Login(login user)
        {
            var adminavailable = _context.Admins.Where(u => u.username == user.username && u.password == user.password).FirstOrDefault();
            if (adminavailable != null)
            {
                return Ok("success");
            }

            return Ok("Failure");
        }
    }
}
