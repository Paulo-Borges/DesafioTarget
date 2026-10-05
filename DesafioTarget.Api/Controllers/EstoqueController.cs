using DesafioTarget.Api.DTOs;
using DesafioTarget.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTarget.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueService _estoqueService;
        public EstoqueController(EstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpPost("movimentar")]
        public IActionResult Movimentar([FromBody] MovimentacaoRequestDTO request)
        {
            var resultado = _estoqueService.Movimentar(request);
            return Ok(resultado);
        }
    }
}
