namespace DesafioTarget.Api.DTOs
{
    public class JurosResponseDTO
    {
        public decimal ValorOriginal { get; set; }

        public int DiasAtraso { get; set; }

        public decimal Juros { get; set; }

        public decimal ValorFinal { get; set; }
    }
}
