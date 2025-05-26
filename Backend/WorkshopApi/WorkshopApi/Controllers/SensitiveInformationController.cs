using Microsoft.AspNetCore.Mvc;
using WorkshopApi.Data;
using System.Linq;
using WorkshopApi.Data;
using Microsoft.AspNetCore.Authorization;

namespace ResourceBackend.Controllers
{
    [ApiController]
    [Route("sensitive")]
    public class SensitiveInformationController : ControllerBase
    {
        [HttpGet("information")]
        public IActionResult GetAllStudentInformation()
        {
            var result = InMemoryData.Leerlingen
                .Select(l => new { l.Naam, l.Informatie })
                .ToList();

            return Ok(result);
        }

        [HttpGet("grades")]
        public IActionResult GetAllGrades()
        {
            var result = InMemoryData.Leerlingen
                .Select(l => new { l.Naam, l.Cijfer })
                .ToList();

            return Ok(result);
        }

        [HttpGet("grade")]
        public IActionResult GetGradeByName([FromQuery] string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
                return BadRequest("Naam is verplicht.");

            var leerling = InMemoryData.Leerlingen
                .FirstOrDefault(l => l.Naam.Equals(naam, StringComparison.OrdinalIgnoreCase));

            if (leerling == null)
                return NotFound("Leerling niet gevonden.");

            return Ok(new { leerling.Naam, leerling.Cijfer });
        }
    }
}
