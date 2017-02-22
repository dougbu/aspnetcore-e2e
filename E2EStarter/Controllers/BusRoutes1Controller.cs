using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E2EStarter;
using E2EStarter.Data;

namespace E2EStarter.Controllers
{
    [Produces("application/json")]
    [Route("api/BusRoutes1")]
    public class BusRoutes1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusRoutes1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BusRoutes1
        [HttpGet]
        public IEnumerable<BusRoute> GetBusRoute()
        {
            return _context.BusRoute;
        }

        // GET: api/BusRoutes1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusRoute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var busRoute = await _context.BusRoute.SingleOrDefaultAsync(m => m.Id == id);

            if (busRoute == null)
            {
                return NotFound();
            }

            return Ok(busRoute);
        }

        // PUT: api/BusRoutes1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusRoute([FromRoute] int id, [FromBody] BusRoute busRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != busRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(busRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusRouteExists(id))
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

        // POST: api/BusRoutes1
        [HttpPost]
        public async Task<IActionResult> PostBusRoute([FromBody] BusRoute busRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BusRoute.Add(busRoute);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BusRouteExists(busRoute.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBusRoute", new { id = busRoute.Id }, busRoute);
        }

        // DELETE: api/BusRoutes1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusRoute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var busRoute = await _context.BusRoute.SingleOrDefaultAsync(m => m.Id == id);
            if (busRoute == null)
            {
                return NotFound();
            }

            _context.BusRoute.Remove(busRoute);
            await _context.SaveChangesAsync();

            return Ok(busRoute);
        }

        private bool BusRouteExists(int id)
        {
            return _context.BusRoute.Any(e => e.Id == id);
        }
    }
}