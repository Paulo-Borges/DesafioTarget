using DesafioTarget.Api.Models;

namespace DesafioTarget.Api.Services
{
    public class ComissaoService
    {
        public decimal CalcularComissao(decimal valorVenda)
        {
            if (valorVenda < 100)
            {
                return 0; // 0% de comissão, SEM COMISSÃO
            }
            else if (valorVenda < 500)
            {
                return valorVenda * 0.01m; // 1% de comissão
            }
            else
            {
                return valorVenda * 0.05m; // 5% de comissão
            }
        }

        public object CalcularPorVendedor(List<Venda> vendas)
        {
            return vendas
                .GroupBy(v => v.Vendedor)
                .Select(g => new
                {
                   Vendedor = g.Key,
                   TotalComissao = g.Sum(v => CalcularComissao(v.Valor))
                });
        }
    }
}
