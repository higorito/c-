using backendPicPay.Data;
using backendPicPay.Data.Respository.Carteiras;
using backendPicPay.Data.Respository.Transferencias;
using backendPicPay.Services;
using backendPicPay.Services.AutorizadorService;
using backendPicPay.Services.Notificacao;
using backendPicPay.Services.NotificacaoService;
using backendPicPay.Services.Transferencia;
using Microsoft.EntityFrameworkCore;

namespace backendPicPay;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        var serverVersion = new MySqlServerVersion(new Version(8, 1, 40));
        builder.Services.AddDbContext<PicPayDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("defaultConnection"), serverVersion)
        );
        
        builder.Services.AddScoped<ICarteiraRepository, CarteiraRespository>();
        builder.Services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
        builder.Services.AddScoped<ICarteiraService, CarteiraService>();
        builder.Services.AddScoped<ITransferenciaService, TransferenciaService>();
        

        builder.Services.AddHttpClient<IAutorizadorService, AutorizadorService>();
        builder.Services.AddScoped<INotificacaoService, NotificacaoService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}