using backendPicPay.Data.Respository.Carteiras;
using backendPicPay.Models;
using backendPicPay.Models.Request;
using backendPicPay.Models.Response;

namespace backendPicPay.Services;

public class CarteiraService: ICarteiraService
{
    private readonly ICarteiraRepository _carteiraRepository;
    
    public CarteiraService(ICarteiraRepository carteiraRepository)
    {
        _carteiraRepository = carteiraRepository;
    }
    
    public async Task<Result<bool>> ExecuteAsync(CarteiraRequest request)
    {
        var carteiraExiste = await _carteiraRepository.GetByCpfcnpj(request.CPFCNPJ, request.Email);
        
        if (carteiraExiste is not null)
            return Result<bool>.Failure("Carteira já existe");
        
        var carteira = new CarteiraEntity(request.NomeCompleto, request.CPFCNPJ, request.Email, request.Senha, request.UserType, request.SaldoConta);
        
        await _carteiraRepository.AddAsync(carteira);
        
        await _carteiraRepository.CommitAsync();
        
        return Result<bool>.Success(true);
    }
}