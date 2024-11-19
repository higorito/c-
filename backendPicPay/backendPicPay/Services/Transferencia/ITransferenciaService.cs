using backendPicPay.Models.DTOs;
using backendPicPay.Models.Request;
using backendPicPay.Models.Response;

namespace backendPicPay.Services.Transferencia;

public interface ITransferenciaService
{
    Task<Result<TransferenciaDto>> ExecuteAsync(TransferenciaRequest request);
}