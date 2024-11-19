using backendPicPay.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace backendPicPay.Data.Respository.Transferencias;

public interface ITransferenciaRepository
{
    Task AddTransferenciaAsync(TransferenciaEntity transferencia);
    
    Task CommitAsync();
    
    Task<IDbContextTransaction> BeginTransactionAsync();
}