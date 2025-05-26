using Microsoft.AspNetCore.Mvc;
using WorkshopApi.Data;
using WorkshopApi.Models;
using System.Linq;
using WorkshopApi.Data;
using Microsoft.AspNetCore.Authorization;

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
    }
}
