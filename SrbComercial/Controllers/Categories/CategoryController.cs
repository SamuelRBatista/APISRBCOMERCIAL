using Microsoft.AspNetCore.Mvc;
using SrbComercialInfrastructure.Repository;
using SrbComercialDomain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace SrbComercial.Controllers.Categories
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/category
        [HttpGet(Name = "GetCategory"),Authorize]
        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll();
            return Ok(categories);
        }

		// POST: api/category
		[HttpPost(Name = "CreateCategory"),Authorize]
		public IActionResult Create(Category category)
		{
			if (category == null)
			{
				return BadRequest("Category is null.");
			}

			// Validação simples
			if (string.IsNullOrEmpty(category.Name))
			{
				return BadRequest("Category name is required.");
			}

			_unitOfWork.Category.Add(category);
			_unitOfWork.Save();

			return CreatedAtAction(nameof(Index), new { id = category.Id }, category);
		}
	

}
}
