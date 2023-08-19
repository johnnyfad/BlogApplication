using BlogApp.ClassLib.Model;
using BlogWebApi.Data;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly SqlServerDbContext _dbContext;

        public BlogController(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Blog>>> getRecipes()
        {
            List<Blog> recipes = await _dbContext.Blog.ToListAsync();
         
            return Ok(recipes);
        }
        [HttpGet("{id}")]
        public ActionResult<Blog> getRecipe(int id)
        {
            var recipe = _dbContext.Blog.Find(id);
            if (recipe == null)
            {
            
                return NotFound();
            }
           
            return Ok(recipe);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Blog blog)
        {

            User? user = await _dbContext.User.FindAsync(blog.UserId);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.Blog.Add(blog);
            await _dbContext.SaveChangesAsync();
           
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Blog recipe)
        {
            if (id != recipe.Id)
            {
               
                return NotFound();

            }
            _dbContext.Blog.Entry(recipe).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            
            return Ok(recipe);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _dbContext.Blog.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            _dbContext.Blog.Remove(recipe);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
