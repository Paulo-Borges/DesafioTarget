namespace DesafioTarget.Api.Models
{
    public class MovimentacaoEstoque
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int CodigoProduto { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public int Quantidade { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public DateTime DataMovimentacao { get; set; } = DateTime.Now;
    }
}
