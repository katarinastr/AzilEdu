using AzilEdu.Api.Data;
using AzilEdu.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzilEdu.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousingUnitsController : ControllerBase
{
    private readonly AzilEduDbContext _db;

    public HousingUnitsController(AzilEduDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<HousingUnit>>> GetHousingUnits()
    {
        var housingUnits = await _db.HousingUnits.ToListAsync();

        return Ok(housingUnits);
    }
}