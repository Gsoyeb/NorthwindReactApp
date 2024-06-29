using Microsoft.AspNetCore.Mvc;
using NorthwindReactApp.Domain.Entities;
using NorthwindReactApp.Infrastructure.Repository.IRepository;

namespace NorthwindReactApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

            
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _unitOfWork.Category.GetAll();
            return Ok(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _unitOfWork.Category.Get(filter: c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _unitOfWork.Category.Get(filter: c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            return NoContent();
        }

    }
}
