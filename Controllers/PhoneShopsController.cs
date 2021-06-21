using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IS_TP_lab2.Models;

namespace IS_TP_lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneShopsController : ControllerBase
    {
        private readonly Lab2PhoneContext _context;

        public PhoneShopsController(Lab2PhoneContext context)
        {
            _context = context;
        }

        // GET: api/PhoneShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneShop>>> GetPhoneShops()
        {
            return await _context.PhoneShops.ToListAsync();
        }

        // GET: api/PhoneShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneShop>> GetPhoneShop(int id)
        {
            var phoneShop = await _context.PhoneShops.FindAsync(id);

            if (phoneShop == null)
            {
                return NotFound();
            }

            return phoneShop;
        }

        // PUT: api/PhoneShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneShop(int id, PhoneShop phoneShop)
        {
            if (id != phoneShop.Id)
            {
                return BadRequest();
            }

            _context.Entry(phoneShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneShopExists(id))
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

        // POST: api/PhoneShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhoneShop>> PostPhoneShop(PhoneShop phoneShop)
        {
            _context.PhoneShops.Add(phoneShop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneShop", new { id = phoneShop.Id }, phoneShop);
        }

        // DELETE: api/PhoneShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneShop(int id)
        {
            var phoneShop = await _context.PhoneShops.FindAsync(id);
            if (phoneShop == null)
            {
                return NotFound();
            }

            _context.PhoneShops.Remove(phoneShop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhoneShopExists(int id)
        {
            return _context.PhoneShops.Any(e => e.Id == id);
        }
    }
}
