using Microsoft.AspNetCore.Mvc;
using SrbComercialInfrastructure.Repository;

namespace SrbComercial.Controllers.States;

[ApiController]
[Route("api/[controller]")]
public class StateController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;

    public StateController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet(Name = "GetState")/*, Authorize*/]
    public IActionResult Index()
    {
        var state = _unitOfWork.State.GetAll();
        return Ok(state);
    }
}
