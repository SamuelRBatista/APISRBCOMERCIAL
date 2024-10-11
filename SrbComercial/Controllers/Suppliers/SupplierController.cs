

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SrbComercialDomain.Entities;
using SrbComercialInfrastructure.Repository;

namespace SrbComercial.Controllers.Suppliers;

[ApiController]
[Route("api/[controller]")]
public class SupplierController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;

        public SupplierController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetSupplier"), Authorize]
        public IActionResult Index()
        {
            var supplier = _unitOfWork.Supplier.GetAll();
            return Ok(supplier);
        }

        [HttpPost(Name = "GetSupplier"), Authorize]
		public IActionResult Create(Supplier supplier)
		{
			if (supplier == null)
			{
				return BadRequest("Supplier is null.");
			}

			// Validação simples
			if (string.IsNullOrEmpty(supplier.Name))
			{
				return BadRequest("Supplier name is required.");
			}

			_unitOfWork.Supplier.Add(supplier);
			_unitOfWork.Save();

			return CreatedAtAction(nameof(Index), new { id = supplier.Id }, supplier);
		}

}