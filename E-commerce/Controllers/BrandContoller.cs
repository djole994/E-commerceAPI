using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public BrandController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _context.Products
                .Select(p => p.Brand)
                .Distinct()
                .ToListAsync();

            return Ok(brands);
        }
    }
}
