using backendPicPay.Models.Request;
using backendPicPay.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendPicPay.Controller;

[ApiController]
[Route("[controller]")]
public class CarteiraController: ControllerBase
{
    private readonly ICarteiraService _carteiraService;
    
    public CarteiraController(ICarteiraService carteiraService)
    {
        _carteiraService = carteiraService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CarteiraRequest request)
    {
        var result = await _carteiraService.ExecuteAsync(request);
        
        if (!result.IsSuccess)
            return BadRequest(result);

        return Created();
    }
}