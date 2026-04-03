using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentApi.Data;
using RentApi.Enums;
using RentApi.Models;

[ApiController]
[Route("api/properties")]
public class PropertyController : ControllerBase
{
    private readonly AppDbContext _context;

    public PropertyController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Property property)
    {
        var landlord = await _context.Users.FindAsync(property.LandlordId);

        if (landlord == null)
            return NotFound("Proprietário não encontrado");

        if (landlord.Type != UserType.LANDLORD)
            return BadRequest("Apenas LANDLORD pode cadastrar propriedades");

        _context.Properties.Add(property);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = property.Id }, property);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var properties = await _context.Properties
            .Include(p => p.Landlord)
            .ToListAsync();

        return Ok(properties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var property = await _context.Properties
            .Include(p => p.Landlord)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (property == null)
            return NotFound();

        return Ok(property);
    }
}