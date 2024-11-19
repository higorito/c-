namespace backendPicPay.Models;

public class TransferenciaEntity
{
    public Guid IdTransferencia { get; set; }
    
    public int IdCarteiraOrigem { get; set; }
    public CarteiraEntity CarteiraOrigem { get; set; }
    
    public int IdCarteiraDestino { get; set; }
    public CarteiraEntity CarteiraDestino { get; set; }
    
    public decimal Valor { get; set; }

    public TransferenciaEntity(int idCarteiraOrigem, int idCarteiraDestino, decimal valor)
    {
        IdTransferencia = Guid.NewGuid();
        IdCarteiraOrigem = idCarteiraOrigem;
        IdCarteiraDestino = idCarteiraDestino;
        Valor = valor;
    }

}