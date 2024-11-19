namespace backendPicPay.Models.DTOs;

public record TransferenciaDto(Guid IdTransferencia, int IdCarteiraOrigem, int IdCarteiraDestino, decimal Valor);