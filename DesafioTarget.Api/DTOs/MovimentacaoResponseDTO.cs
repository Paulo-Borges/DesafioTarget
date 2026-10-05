namespace DesafioTarget.Api.DTOs
{
    public class MovimentacaoResponseDTO
    {
        public Guid Id { get; set; }

        public DateTime DataMovimentacao { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public int CodigoProduto { get; set; }

        public string DescricaoProduto { get; set; } = string.Empty;

        public int EstoqueFinal { get; set; }
    }
}
