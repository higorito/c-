using backendPicPay.Models.Request;
using backendPicPay.Models.Response;

namespace backendPicPay.Services;

public interface ICarteiraService
{
    Task<Result<bool>> ExecuteAsync(CarteiraRequest request);
}