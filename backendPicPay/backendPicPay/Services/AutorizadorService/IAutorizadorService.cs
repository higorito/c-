namespace backendPicPay.Services.AutorizadorService;

public interface IAutorizadorService
{
    Task<bool> AutorizarAsync();
}