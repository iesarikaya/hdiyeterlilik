// Controllers/FinancialReportsController.cs
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
    public class FinancialReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FinancialReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FinancialReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialReport>>> GetFinancialReports()
        {
            return await _context.FinancialReports.ToListAsync();
        }

        // GET: api/FinancialReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialReport>> GetFinancialReport(int id)
        {
            var financialReport = await _context.FinancialReports.FindAsync(id);

            if (financialReport == null)
            {
                return NotFound();
            }

            return financialReport;
        }

        // POST: api/FinancialReports
        [HttpPost]
        public async Task<ActionResult<FinancialReport>> PostFinancialReport(FinancialReport financialReport)
        {
            _context.FinancialReports.Add(financialReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFinancialReport), new { id = financialReport.FinancialReportID }, financialReport);
        }

        // PUT: api/FinancialReports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialReport(int id, FinancialReport financialReport)
        {
            if (id != financialReport.FinancialReportID)
            {
                return BadRequest();
            }

            _context.Entry(financialReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialReportExists(id))
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

        // DELETE: api/FinancialReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialReport(int id)
        {
            var financialReport = await _context.FinancialReports.FindAsync(id);
            if (financialReport == null)
            {
                return NotFound();
            }

            _context.FinancialReports.Remove(financialReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancialReportExists(int id)
        {
            return _context.FinancialReports.Any(e => e.FinancialReportID == id);
        }
    }
}
