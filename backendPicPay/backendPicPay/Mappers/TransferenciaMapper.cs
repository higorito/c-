using backendPicPay.Models;
using backendPicPay.Models.DTOs;

namespace backendPicPay.Mappers;

public static class TransferenciaMapper
{
    public static TransferenciaDto ToTransferenciaDto(this TransferenciaEntity transferencia)
    {
        return new TransferenciaDto(
            transferencia.IdTransferencia,
            transferencia.CarteiraOrigem.Id,
            transferencia.CarteiraDestino.Id,
            transferencia.Valor
        );
       
    }
}