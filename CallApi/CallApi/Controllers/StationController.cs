using CallApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private Context _context;
        public StationController(Context context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MasaClass masa)
        {
            var masas = _context.MasaTable.Find(id);
            if (masas.Equals(null))
                return NotFound("Id'nin doğru olduğuna emin olun.");
            else
            {
                masas.StationID = masa.StationID;
                _context.SaveChanges();
                return Ok("Güncelleme başarılı.");
            }
        }
    }
}
