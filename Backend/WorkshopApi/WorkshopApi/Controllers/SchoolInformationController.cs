using Microsoft.AspNetCore.Mvc;
using WorkshopApi.Data;
using WorkshopApi.Models;
using System.Linq;
using WorkshopApi.Data;

namespace ResourceBackend.Controllers
{
    [ApiController]
    [Route("school")]
    public class SchoolInformationController : ControllerBase
    {
        [HttpGet("students")]
        public IActionResult GetStudentNames()
        {
            var namen = InMemoryData.Leerlingen
                .Select(l => l.Naam)
                .ToList();

            return Ok(namen);
        }

        [HttpGet("lessons")]
        public IActionResult GetLessons()
        {
            return Ok(InMemoryData.Lessen);
        }

        [HttpGet("grades")]
        public IActionResult GetAllGrades()
        {
            var result = InMemoryData.Leerlingen
                .Select(l => new { l.Naam, l.Cijfer })
                .ToList();

            return Ok(result);
        }

        [HttpGet("grades/{naam}")]
        public IActionResult GetMyGrades(string naam)
        {
            var leerling = InMemoryData.Leerlingen
                .FirstOrDefault(l => l.Naam.Equals(naam, StringComparison.OrdinalIgnoreCase));

            if (leerling == null)
                return NotFound("Leerling niet gevonden");

            return Ok(new { leerling.Naam, leerling.Cijfer });
        }
    }
}
