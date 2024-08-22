// Controllers/BusinessTopicsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hdiYeterlilik.Data;
using hdiYeterlilik.Models;

namespace hdiYeterlilik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessTopicsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BusinessTopicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BusinessTopics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessTopic>>> GetBusinessTopics()
        {
            return await _context.BusinessTopics.Include(b => b.Partner).Include(b => b.Agreement).ToListAsync();
        }

        // GET: api/BusinessTopics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessTopic>> GetBusinessTopic(int id)
        {
            var businessTopic = await _context.BusinessTopics
                .Include(b => b.Partner)
                .Include(b => b.Agreement)
                .FirstOrDefaultAsync(b => b.BusinessTopicID == id);

            if (businessTopic == null)
            {
                return NotFound();
            }

            return businessTopic;
        }

        // POST: api/BusinessTopics
        [HttpPost]
        public async Task<ActionResult<BusinessTopic>> PostBusinessTopic(BusinessTopic businessTopic)
        {
            _context.BusinessTopics.Add(businessTopic);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBusinessTopic), new { id = businessTopic.BusinessTopicID }, businessTopic);
        }

        // PUT: api/BusinessTopics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessTopic(int id, BusinessTopic businessTopic)
        {
            if (id != businessTopic.BusinessTopicID)
            {
                return BadRequest();
            }

            _context.Entry(businessTopic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessTopicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/BusinessTopics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessTopic(int id)
        {
            var businessTopic = await _context.BusinessTopics.FindAsync(id);
            if (businessTopic == null)
            {
                return NotFound();
            }

            _context.BusinessTopics.Remove(businessTopic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessTopicExists(int id)
        {
            return _context.BusinessTopics.Any(e => e.BusinessTopicID == id);
        }
    }
}
