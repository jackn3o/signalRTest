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
    [Route("api/shopping")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly ProductContext _dbContext;

        public ShoppingController(ProductContext context)
        {
            _dbContext = context;
        }

        // GET: api/shopping
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _dbContext.Products.Where(p => p.IsPublished).ToListAsync();
        }

    }
}