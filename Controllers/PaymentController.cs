[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var payment = await _paymentService.Create(dto.ContractId, dto.Amount);

        return Ok(payment);
    }
}