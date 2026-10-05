using DesafioTarget.Api.DTOs;
using DesafioTarget.Api.Models;
using System.Text.Json;

namespace DesafioTarget.Api.Services
{
    public class EstoqueService
    {
        private readonly string _arquivo = "Data/estoque.json";

        public object Movimentar(MovimentacaoRequestDTO request)
        {
            string json = File.ReadAllText(_arquivo);

            var dados = JsonSerializer.Deserialize<EstoqueJson>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var produto = dados!.Estoque.FirstOrDefault(
            p => p.CodigoProduto == request.CodigoProduto);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            if (request.Tipo.ToUpper() == "ENTRADA")
            {
                produto.Estoque += request.Quantidade;
            }
            else if (request.Tipo.ToUpper() == "SAIDA")
            {
                if (produto.Estoque < request.Quantidade)
                {
                    throw new Exception("Estoque insuficiente.");
                }

                produto.Estoque -= request.Quantidade;
            }

            string novoJson = JsonSerializer.Serialize(
            dados,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_arquivo, novoJson);

            var movimentacao = new MovimentacaoEstoque
            {
                CodigoProduto = request.CodigoProduto,
                Tipo = request.Tipo,
                Quantidade = request.Quantidade,
                Descricao = request.Descricao
            };

            string arquivoMovimentacoes = "Data/movimentacoes.json";

            var movimentacoes = new List<MovimentacaoEstoque>();

            if (File.Exists(arquivoMovimentacoes))
            {
                string jsonMovimentacoes =
                File.ReadAllText(arquivoMovimentacoes);

                movimentacoes =
                JsonSerializer.Deserialize<List<MovimentacaoEstoque>>(
                jsonMovimentacoes)
                ?? new List<MovimentacaoEstoque>();
            }

            movimentacoes.Add(movimentacao);

            string novoJsonMovimentacoes =
            JsonSerializer.Serialize(
            movimentacoes,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(
            arquivoMovimentacoes,
            novoJsonMovimentacoes);


            return new MovimentacaoResponseDTO
            {
                Id = movimentacao.Id,
                DataMovimentacao = movimentacao.DataMovimentacao,
                Tipo = movimentacao.Tipo,
                Descricao = movimentacao.Descricao,
                CodigoProduto = produto.CodigoProduto,
                DescricaoProduto = produto.DescricaoProduto,
                EstoqueFinal = produto.Estoque
            };
        }
    }
}
