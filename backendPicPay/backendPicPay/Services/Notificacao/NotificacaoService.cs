using backendPicPay.Services.NotificacaoService;

namespace backendPicPay.Services.Notificacao;

public class NotificacaoService: INotificacaoService
{
    public async Task Notificar()
    {
        await Task.Delay(1200);
        Console.WriteLine("Notificação enviada");
    }
}