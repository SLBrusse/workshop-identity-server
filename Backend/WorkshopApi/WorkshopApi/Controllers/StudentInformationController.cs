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
        [HttpGet("information")]
        public IActionResult GetAllStudentInformation()
        {
            var result = InMemoryData.Leerlingen
                .Select(l => new { l.Naam, l.Informatie })
                .ToList();

            return Ok(result);
        }
    }
}
