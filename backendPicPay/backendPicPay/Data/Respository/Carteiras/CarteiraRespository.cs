using backendPicPay.Models;
using Microsoft.EntityFrameworkCore;

namespace backendPicPay.Data.Respository.Carteiras;

public class CarteiraRespository: ICarteiraRepository
{   
    private readonly PicPayDbContext _context;
    
    public CarteiraRespository(PicPayDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(CarteiraEntity carteira)
    {
        await _context.AddAsync(carteira);
    }

    public Task UpdateAsync(CarteiraEntity carteira)
    {
        _context.Update(carteira);
        return Task.CompletedTask;
    }

    public async Task<CarteiraEntity?> GetByCpfcnpj(string cPfcnpj, string email)
    {
        return await _context.Carteiras.FirstOrDefaultAsync(w => w != null && w.CPFCNPJ == cPfcnpj && w.Email == email);
    }

    public async Task<CarteiraEntity?> GetById(int id)
    {
        return await _context.Carteiras.FindAsync(id);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}