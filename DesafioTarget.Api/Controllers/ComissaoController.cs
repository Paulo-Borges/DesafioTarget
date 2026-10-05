using DesafioTarget.Api.Models;
using DesafioTarget.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DesafioTarget.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComissaoController : ControllerBase
    {
        private readonly ComissaoService _comissaoService;

        public ComissaoController(ComissaoService comissaoService)
        {
            _comissaoService = comissaoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string json = System.IO.File.ReadAllText("Data/vendas.json");
            //return Ok(json);

            var dados = JsonSerializer.Deserialize<VendasJson>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            //return Ok(dados);

            var resultado = _comissaoService.CalcularPorVendedor(dados!.Vendas);

            return Ok(resultado);
        }
    }
}
