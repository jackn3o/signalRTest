using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.HubClient;
using SignalR.Models;

namespace SignalR.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly IHubContext<ProductHub> _hubContext;
        public ProductsController(ProductContext context, IHubContext<ProductHub> hub)
        {
            _context = context;
            _hubContext = hub;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _context.Products.ToListAsync();
        }


        // GET: api/products/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            return await _context.Products.Where(p => p.Id == id).SingleOrDefaultAsync();
        }


        // Post: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("refreshProducts");

            return CreatedAtAction("Get Product", new { IDesignTimeMvcBuilderConfiguration = product.Id }, product);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> Put(int id, Product product)
        {
            var entity = _context.Products.Where(p => p.Id == id).SingleOrDefault();

            if (entity != null)
            {
                entity.Description = product.Description;
                entity.Quantity = product.Quantity;
                entity.Price = product.Price;
                entity.IsPublished = product.IsPublished;
                await _context.SaveChangesAsync();

                await _hubContext.Clients.All.SendAsync("refreshProducts");
            }

            return CreatedAtAction("Get Product", new { IDesignTimeMvcBuilderConfiguration = product.Id }, product);
        }
    }
}