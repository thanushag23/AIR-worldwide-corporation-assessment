using Microsoft.AspNetCore.Mvc;
using Exercise3_RestApi.Data;
using Exercise3_RestApi.Models;

namespace Exercise3_RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo) => _repo = repo;

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll() =>
            Ok(_repo.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<Product> GetById(int id)
        {
            var p = _repo.GetById(id);
            return p is null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product p)
        {
            var created = _repo.Add(p);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Product p) =>
            _repo.Update(id, p) ? NoContent() : NotFound();

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id) =>
            _repo.Delete(id) ? NoContent() : NotFound();
    }
}