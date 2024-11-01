

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

        [HttpGet(Name = "GetSupplier")/*, Authorize*/]
        public IActionResult Index()
        {
            var supplier = _unitOfWork.Supplier.GetAll();
            return Ok(supplier);
        }

        [HttpPost(Name = "GetSupplier")/*, Authorize*/]
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

    [HttpPut("{id}", Name = "UpdateSupplier")/*, Authorize*/]
    public IActionResult Update(int id, Supplier supplier)
    {
        if (id != supplier.Id)
        {
            return BadRequest("Product ID mismatch");
        }

        try
        {
            // Chama o método de atualização no repositório de produto
            _unitOfWork.Supplier.Update(supplier);

            // Salva as alterações
            _unitOfWork.Save();

            return Ok("Supplier updated successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/supplier/{id}
    [HttpDelete("{id}", Name = "DeleteSupplier")/*, Authorize*/]
    public IActionResult Delete(int id)
    {
        var supplier = _unitOfWork.Supplier.Get(p => p.Id == id);
        if (supplier == null)
        {
            return NotFound();
        }

        _unitOfWork.Supplier.Remove(supplier);
        _unitOfWork.Save();

        return NoContent();
    }

}