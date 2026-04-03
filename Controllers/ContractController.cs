using Microsoft.AspNetCore.Mvc;

namespace RentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateContractDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contract = await _contractService.Create(dto.TenantId, dto.PropertyId);

            return Ok(contract);
        }
    }
}