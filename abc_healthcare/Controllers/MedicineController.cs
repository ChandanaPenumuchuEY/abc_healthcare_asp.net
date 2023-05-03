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
    public class MedicineController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly UsersContext _context;
        public MedicineController(IConfiguration config, UsersContext context)
        {
            _config = config;
            _context = context;

        }
        [HttpPost("CreateMedicine")]
        public IActionResult Create(Medicine medicine)
        {


            _context.Medicines.Add(medicine);
            _context.SaveChanges();
            return Ok("Successfully Added Medicine to Database");
        }

        [HttpGet("MedicineDetails")]
        public async Task<IActionResult> GetMedicines()
        {
            var medicines = await _context.Medicines.ToListAsync();

            return Ok(medicines);
        }
        [HttpDelete("{name}")]
      //  [Route("api/[controller]/{name}")]
        public IActionResult Delete(string name)
        {

            var item = _context.Medicines.FirstOrDefault(x => x.name == name);

            if (item == null)
            {
                return NotFound();
            }

            _context.Medicines.Remove(item);
            _context.SaveChanges();

            return Ok();



        }
    }
}