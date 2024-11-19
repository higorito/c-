using backendPicPay.Models.Request;
using backendPicPay.Services.Transferencia;
using Microsoft.AspNetCore.Mvc;

namespace backendPicPay.Controller;

[ApiController]
[Route("transferencia")]
public class TransferenciaController: ControllerBase
{
    private readonly ITransferenciaService _transferenciaService;
    
    public TransferenciaController(ITransferenciaService transferenciaService)
    {
        _transferenciaService = transferenciaService;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostTransferencia([FromBody] TransferenciaRequest request)
    {
        var result = await _transferenciaService.ExecuteAsync(request);
        
        if (!result.IsSuccess)
            return BadRequest(result);
        
        return Ok(result);
        
    }
}