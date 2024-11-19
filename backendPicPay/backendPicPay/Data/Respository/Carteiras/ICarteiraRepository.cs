using backendPicPay.Models;

namespace backendPicPay.Data.Respository.Carteiras;

public interface ICarteiraRepository
{
    Task AddAsync(CarteiraEntity carteira);
    
    Task UpdateAsync(CarteiraEntity carteira);
    
    Task<CarteiraEntity?> GetByCpfcnpj(string cPfcnpj, string email);
    
    Task<CarteiraEntity?> GetById(int id);
    
    Task CommitAsync();
}