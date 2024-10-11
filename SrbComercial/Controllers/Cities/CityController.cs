using Microsoft.AspNetCore.Mvc;
using SrbComercialInfrastructure.Repository;
using SrbComercialDomain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace SrbComercial.Controllers.Cities;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;

    public CityController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet(Name = "GetCity"), Authorize]
    public IActionResult Index()
    {
        var city = _unitOfWork.City.GetAll();
        return Ok(city);
    }

    [HttpPost(Name = "CreateCity"), Authorize]
    public IActionResult Create(City city)
    {
        if(city == null){
            return BadRequest("City is null");
        }

        if(string.IsNullOrEmpty(city.Name))
        {
            return BadRequest("City name is required");
        }
        
        _unitOfWork.City.Add(city);
        _unitOfWork.Save();

        return CreatedAtAction(nameof(Index), new { id = city.Id }, city);

    }

}