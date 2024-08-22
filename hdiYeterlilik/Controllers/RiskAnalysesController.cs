// Controllers/RiskAnalysesController.cs
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
    public class RiskAnalysesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RiskAnalysesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RiskAnalyses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiskAnalysis>>> GetRiskAnalyses()
        {
            return await _context.RiskAnalyses.Include(r => r.BusinessTopic).ToListAsync();
        }

        // GET: api/RiskAnalyses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RiskAnalysis>> GetRiskAnalysis(int id)
        {
            var riskAnalysis = await _context.RiskAnalyses
                .Include(r => r.BusinessTopic)
                .FirstOrDefaultAsync(r => r.RiskAnalysisID == id);

            if (riskAnalysis == null)
            {
                return NotFound();
            }

            return riskAnalysis;
        }

        // POST: api/RiskAnalyses
        [HttpPost]
        public async Task<ActionResult<RiskAnalysis>> PostRiskAnalysis(RiskAnalysis riskAnalysis)
        {
            _context.RiskAnalyses.Add(riskAnalysis);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRiskAnalysis), new { id = riskAnalysis.RiskAnalysisID }, riskAnalysis);
        }

        // PUT: api/RiskAnalyses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRiskAnalysis(int id, RiskAnalysis riskAnalysis)
        {
            if (id != riskAnalysis.RiskAnalysisID)
            {
                return BadRequest();
            }

            _context.Entry(riskAnalysis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiskAnalysisExists(id))
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

        // DELETE: api/RiskAnalyses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRiskAnalysis(int id)
        {
            var riskAnalysis = await _context.RiskAnalyses.FindAsync(id);
            if (riskAnalysis == null)
            {
                return NotFound();
            }

            _context.RiskAnalyses.Remove(riskAnalysis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RiskAnalysisExists(int id)
        {
            return _context.RiskAnalyses.Any(e => e.RiskAnalysisID == id);
        }
    }
}
