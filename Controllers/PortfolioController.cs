using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private static readonly List<PortfolioItem> PortfolioItems = new List<PortfolioItem>
        {
            new PortfolioItem { Id = 1, BookName = "Eat, pray and Love", Description = "Eat, Pray, Love is a memoir by Elizabeth Gilbert about her year-long journey of self-discovery through travel to Italy, India, and Indonesia after a divorce." },
            new PortfolioItem { Id = 2, BookName = "The Little Prince.", Description = "The Little Prince is a classic tale about love, friendship, and seeing with the heart." },
            new PortfolioItem { Id = 3, BookName = "The Cat in the Hat", Description = "A mischievous cat brings chaos and fun to a rainy day." }
        };

        // GET: api/portfolio
        [HttpGet]
        public IActionResult GetPortfolio()
        {
            return Ok(PortfolioItems);
        }

        // GET: api/portfolio/{id}
        [HttpGet("{id}")]
        public IActionResult GetPortfolioItem(int id)
        {
            var item = PortfolioItems.FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/portfolio
        [HttpPost]
        public IActionResult CreatePortfolioItem([FromBody] PortfolioItem newItem)
        {
            if (newItem == null)
            {
                return BadRequest("Item inválido.");
            }

            // Adiciona o novo item à lista
            newItem.Id = PortfolioItems.Max(p => p.Id) + 1; // Gera um ID único
            PortfolioItems.Add(newItem);

            return CreatedAtAction(nameof(GetPortfolioItem), new { id = newItem.Id }, newItem);  // Retorna o item criado
        }
    }
}
