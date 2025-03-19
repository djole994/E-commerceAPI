﻿using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public CategoryController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category updatedCategory)
        {
            if (id != updatedCategory.Id)
                return BadRequest("Id mismatch");

            if (!await _context.Categories.AnyAsync(c => c.Id == id))
                return NotFound();

            _context.Entry(updatedCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
