using backendPicPay.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace backendPicPay.Data.Respository.Transferencias;

public class TransferenciaRepository: ITransferenciaRepository
{
    private readonly PicPayDbContext _context;
    
    public TransferenciaRepository(PicPayDbContext context)
    {
        _context = context;
    }
    
    public async Task AddTransferenciaAsync(TransferenciaEntity transferencia)
    {
        await _context.AddAsync(transferencia);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
}