using DesafioTarget.Api.DTOs;
using DesafioTarget.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTarget.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        private readonly JurosService _service;

        public JurosController(JurosService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Calcular(
        [FromBody] JurosRequestDTO request)
        {
            var resultado = _service.Calcular(request);

            return Ok(resultado);
        }
    }
}
