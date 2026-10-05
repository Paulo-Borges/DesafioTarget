using DesafioTarget.Api.Models;
using DesafioTarget.Api.Services;
using Microsoft.AspNetCore.Mvc;

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
        //public IActionResult GetComissao([FromQuery] decimal valorVenda)
        //{
        //    var comissao = _comissaoService.CalcularComissao(valorVenda);
        //    return Ok(new { ValorVenda = valorVenda, Comissao = comissao });
        //}
        public IActionResult Get()
        {
            var vendas = new List<Venda>()
            {
                new Venda { Vendedor = "João", Valor = 50 },
                new Venda { Vendedor = "Maria", Valor = 200 },
                new Venda { Vendedor = "João", Valor = 600 },
                new Venda { Vendedor = "Maria", Valor = 300 },
                new Venda { Vendedor = "Carlos", Valor = 700 }
            };
            var comissoesPorVendedor = _comissaoService.CalcularPorVendedor(vendas);
            return Ok(comissoesPorVendedor);
        }
    }
}
