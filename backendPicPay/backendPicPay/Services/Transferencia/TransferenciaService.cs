using backendPicPay.Data.Respository.Carteiras;
using backendPicPay.Data.Respository.Transferencias;
using backendPicPay.Mappers;
using backendPicPay.Models;
using backendPicPay.Models.DTOs;
using backendPicPay.Models.Enum;
using backendPicPay.Models.Request;
using backendPicPay.Models.Response;
using backendPicPay.Services.AutorizadorService;
using backendPicPay.Services.NotificacaoService;

namespace backendPicPay.Services.Transferencia;

public class TransferenciaService: ITransferenciaService
{   
    private readonly ICarteiraRepository _carteiraRepository;
    private readonly ITransferenciaRepository _transferenciaRepository;
    
    private readonly IAutorizadorService _autorizadorService;
    private readonly INotificacaoService _notificacaoService;
    
    public TransferenciaService(ICarteiraRepository carteiraRepository, ITransferenciaRepository transferenciaRepository, IAutorizadorService autorizadorService, INotificacaoService notificacaoService)
    {
        _carteiraRepository = carteiraRepository;
        _transferenciaRepository = transferenciaRepository;
        _autorizadorService = autorizadorService;
        _notificacaoService = notificacaoService;
    }
    
    public async Task<Result<TransferenciaDto>> ExecuteAsync(TransferenciaRequest request)
    {
        if (!await _autorizadorService.AutorizarAsync())
            return Result<TransferenciaDto>.Failure("Transação não autorizada");
        
        var carteiraOrigem = await _carteiraRepository.GetById(request.SenderId);
        var carteiraDestino = await _carteiraRepository.GetById(request.ReciverId);
        
        if (carteiraOrigem is null || carteiraDestino is null)
            return Result<TransferenciaDto>.Failure("Carteira não encontrada");
        
        if (carteiraOrigem.Saldo < request.Valor || carteiraOrigem.Saldo == 0)
            return Result<TransferenciaDto>.Failure("Saldo insuficiente");

        if (carteiraOrigem.TipoUsuario == UserType.Lojista)
            return Result<TransferenciaDto>.Failure("Lojista não pode realizar transferência");
        
        carteiraOrigem.DebitarSaldo(request.Valor);
        carteiraDestino.CreditarSaldo(request.Valor);
        
        var transferencia = new TransferenciaEntity(carteiraOrigem.Id, carteiraDestino.Id, request.Valor);

        // tudo dentro do using vai ser uma unica transação, vai no banco uma vez só
        using (var transScope = await _transferenciaRepository.BeginTransactionAsync())
        {
            try
            {
                var updateTransacao = new List<Task>
                {
                    _carteiraRepository.UpdateAsync(carteiraOrigem),
                    _carteiraRepository.UpdateAsync(carteiraDestino),
                    _transferenciaRepository.AddTransferenciaAsync(transferencia)
                };
                
                await Task.WhenAll(updateTransacao);
                
                await _carteiraRepository.CommitAsync();
                await _transferenciaRepository.CommitAsync();
                
                await transScope.CommitAsync(); // aq para dar rollback
                
            }
            catch (Exception e)
            {
                await transScope.RollbackAsync();
                return Result<TransferenciaDto>.Failure(e.Message);
            }
        }
        
        await _notificacaoService.Notificar();
        
        return Result<TransferenciaDto>.Success(transferencia.ToTransferenciaDto());
    }
}