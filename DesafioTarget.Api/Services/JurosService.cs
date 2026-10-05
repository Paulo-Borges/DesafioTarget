using DesafioTarget.Api.DTOs;

namespace DesafioTarget.Api.Services
{
    public class JurosService
    {
        public JurosResponseDTO Calcular(JurosRequestDTO request)
        {
            int diasAtraso =
            (DateTime.Today - request.DataVencimento.Date).Days;

            if (diasAtraso < 0)
            {
                diasAtraso = 0;
            }

            decimal juros =
            request.Valor * 0.025m * diasAtraso;

            decimal valorFinal =
            request.Valor + juros;

            return new JurosResponseDTO
            {
                ValorOriginal = request.Valor,
                DiasAtraso = diasAtraso,
                Juros = juros,
                ValorFinal = valorFinal
            };
        }
    }
}
