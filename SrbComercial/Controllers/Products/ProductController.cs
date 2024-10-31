using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SrbComercialDomain.Entities;
using SrbComercialInfrastructure.Repository;

namespace SrbComercial.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult Index()
        {
            var products = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return Ok(products);
        }

        // GET: api/product/{id}
        [HttpGet("{id}",Name = "GetProductId"), Authorize]
        public IActionResult GetById(int id)
        {
            var product = _unitOfWork.Product.Get(p => p.Id == id, includeProperties: "Category");
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Produto não pode ser nulo.");
            }

            // Aqui você pode validar se a categoria existe, etc.

            _unitOfWork.Product.Add(product);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(Index), new { id = product.Id }, product);
        }

        [HttpPut("{id}",Name = "UpdateProduct")/*, Authorize*/]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            try
            {
                // Chama o método de atualização no repositório de produto
                _unitOfWork.Product.Update(product);

                // Salva as alterações
                _unitOfWork.Save();

                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}",Name = "DeleteProduct")/*, Authorize*/]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Product.Get(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}
