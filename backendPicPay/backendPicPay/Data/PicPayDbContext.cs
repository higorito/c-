using backendPicPay.Models;
using Microsoft.EntityFrameworkCore;

namespace backendPicPay.Data;

public class PicPayDbContext(DbContextOptions<PicPayDbContext> options) : DbContext(options)
{
    public DbSet<CarteiraEntity?> Carteiras { get; set; }
    
    public DbSet<TransferenciaEntity?> Transferencias { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CarteiraEntity>()
            .HasIndex(w => new { w.CPFCNPJ, w.Email })
            .IsUnique();
        
        
        modelBuilder.Entity<CarteiraEntity>()
            .Property(t => t.Saldo)
            .HasColumnType("decimal(18, 2)");
        
        modelBuilder.Entity<CarteiraEntity>()
            .Property(w => w.TipoUsuario)
            .HasConversion<string>();

        modelBuilder.Entity<TransferenciaEntity>()
            .HasKey(t => t.IdTransferencia);

        modelBuilder.Entity<TransferenciaEntity>()
            .HasOne(t => t.CarteiraOrigem)
            .WithMany()
            .HasForeignKey(t => t.IdCarteiraOrigem)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transaction_Origem");
        
        modelBuilder.Entity<TransferenciaEntity>()
            .Property(t => t.Valor)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<TransferenciaEntity>()
            .HasOne(t => t.CarteiraDestino)
            .WithMany()
            .HasForeignKey(t => t.IdCarteiraDestino)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transaction_Destino");
    }
}