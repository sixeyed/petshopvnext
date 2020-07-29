using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetShop.Services.Entities;
using PetShop.Services.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Services.Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly PetShopContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(PetShopContext context, IConfiguration config,  ILogger<ProductsController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            _logger.LogInformation("* GET /products called");

            var products = await _context.Products.ToListAsync();
            FixImageUrl(products);

            _logger.LogInformation($"** Returning {products.Count} products");
            return products;
        }


        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(string productId)
        {
            _logger.LogInformation($"* GET /products/{productId} called");

            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                _logger.LogInformation($"** Product not found - productId: {productId}");
                return NotFound();
            }

            FixImageUrl(new List<Product> { product });

            _logger.LogInformation($"** Returning product - productId: {productId}");
            return Ok(product);
        }


        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(string categoryId)
        {
            _logger.LogInformation($"* GET /products/{categoryId} called");

            var products = await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            if (!products.Any())
            {
                _logger.LogInformation($"** Products not found - categoryId: {categoryId}");
                return NotFound();
            }

            FixImageUrl(products);

            _logger.LogInformation($"** Returning {products.Count} product(s) - categoryId: {categoryId}");
            return Ok(products);
        }

        private void FixImageUrl(List<Product> products)
        {
            var urlRoot = $"{_config["PetShop:Web:Scheme"]}://{_config["PetShop:Web:Domain"]}";
            products.ForEach(x => x.ImageUrl = $"{urlRoot}{x.ImageUrl.TrimStart('~')}");
        }
    }
}
