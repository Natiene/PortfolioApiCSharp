using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        // GET: api/portfolio
        [HttpGet]
        public IActionResult GetPortfolio()
        {
            Console.WriteLine("GET /api/portfolio called");
            var portfolio = new
            {
                Name = "John Doe",
                Skills = new[] { "C#", "ASP.NET Core", "JavaScript" },
                Projects = new[] { "Portfolio Website", "API Service", "E-commerce App" }
            };

            return Ok(portfolio);
        }

        // GET: api/portfolio/5
        [HttpGet("{id}")]
        public IActionResult GetPortfolioItem(int id)
        {
            var portfolioItem = new
            {
                ProjectName = $"Project {id}",
                Description = "Description of the project"
            };

            return Ok(portfolioItem);
        }
    }
}
