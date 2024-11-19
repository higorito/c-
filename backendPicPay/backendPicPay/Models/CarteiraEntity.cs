using backendPicPay.Models.Enum;

namespace backendPicPay.Models;

public class CarteiraEntity
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string CPFCNPJ { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public decimal Saldo { get; set; }
    public UserType TipoUsuario { get; set; }
    
    public CarteiraEntity( string nomeCompleto, string cPFCNPJ, string email, string senha, UserType tipoUsuario, decimal saldo = 0)
    {
        NomeCompleto = nomeCompleto;
        CPFCNPJ = cPFCNPJ;
        Email = email;
        Senha = senha;
        TipoUsuario = tipoUsuario;
        Saldo = saldo;
    }
    
    public void DebitarSaldo(decimal valor)
    {
        Saldo -= valor;
    }
    
    public void CreditarSaldo(decimal valor)
    {
        Saldo += valor;
    }
    
    
}