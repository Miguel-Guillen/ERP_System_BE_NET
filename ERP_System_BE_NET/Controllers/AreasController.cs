using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_System_BE_NET.Models;
using ERP_System_BE_NET.Models.DTO;

namespace ERP_System_BE_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly AplicationDBContext _context;

        public AreasController(AplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Areas
        [HttpGet]
        public async Task<ActionResult<AreasDTO>> GetAreas()
        {
            try
            {
                var areas = await _context.Areas.ToListAsync();
                return Ok(areas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AreasDTO>> GetArea(int id)
        {
            try
            {
                var area = await _context.Areas.FindAsync(id);
                if (area == null)
                {
                    return NotFound();
                }

                return Ok(area);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Areas
        [HttpPost]
        public async Task<ActionResult<AreasDTO>> PostAreas(Areas areaDTO)
        {
            try
            {
                var area = areaDTO;
                area.FechaCreacion = DateTime.Now;
                _context.Areas.Add(area);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAreas), new { id = area.id }, area);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Areas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreas(int id, Areas areas)
        {
            try
            {
                if (id != areas.id)
                {
                    return BadRequest();
                }

                _context.Entry(areas).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAreas(int id)
        {
            try
            {
                var area = await _context.Areas.FindAsync(id);
                if (area == null)
                {
                    return NotFound();
                }

                _context.Areas.Remove(area);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
