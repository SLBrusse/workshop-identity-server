using Microsoft.AspNetCore.Mvc;
using WorkshopApi.Data;
using System.Linq;
using WorkshopApi.Data;

namespace ResourceBackend.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentInformationController : ControllerBase
    {
        [HttpGet("information/{naam}")]
        public IActionResult GetStudentInformation(string naam)
        {
            var leerling = InMemoryData.Leerlingen
                .FirstOrDefault(l => l.Naam.Equals(naam, StringComparison.OrdinalIgnoreCase));

            if (leerling == null)
                return NotFound("Leerling niet gevonden");

            return Ok(new { leerling.Naam, leerling.Informatie });
        }
    }
}
