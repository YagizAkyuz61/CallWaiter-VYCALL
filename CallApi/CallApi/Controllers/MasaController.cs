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
    public class MasaController : ControllerBase
    {
        private Context _context;
        public MasaController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMasa()
        {
            var masas = from masa in _context.MasaTable
                        join s in _context.StationTable on masa.StationID equals s.Id
                        where masa.StationID != 1
                        select new
                        {
                            Id = masa.Id,
                            MasaName = masa.MasaName,
                            Station = s.StationName
                        };
            return Ok(masas);
        }
    }
}
