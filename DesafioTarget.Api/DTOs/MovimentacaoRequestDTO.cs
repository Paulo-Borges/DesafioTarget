namespace DesafioTarget.Api.DTOs
{
    public class MovimentacaoRequestDTO
    {
        public int CodigoProduto { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public int Quantidade { get; set; }

        public string Descricao { get; set; } = string.Empty;
    }
}
