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
    public class PhoneWishlistsController : ControllerBase
    {
        private readonly Lab2PhoneContext _context;

        public PhoneWishlistsController(Lab2PhoneContext context)
        {
            _context = context;
        }

        // GET: api/PhoneWishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneWishlist>>> GetPhoneWishlists()
        {
            return await _context.PhoneWishlists.ToListAsync();
        }

        // GET: api/PhoneWishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneWishlist>> GetPhoneWishlist(int id)
        {
            var phoneWishlist = await _context.PhoneWishlists.FindAsync(id);

            if (phoneWishlist == null)
            {
                return NotFound();
            }

            return phoneWishlist;
        }

        // PUT: api/PhoneWishlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneWishlist(int id, PhoneWishlist phoneWishlist)
        {
            if (id != phoneWishlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(phoneWishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneWishlistExists(id))
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

        // POST: api/PhoneWishlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhoneWishlist>> PostPhoneWishlist(PhoneWishlist phoneWishlist)
        {
            _context.PhoneWishlists.Add(phoneWishlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneWishlist", new { id = phoneWishlist.Id }, phoneWishlist);
        }

        // DELETE: api/PhoneWishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneWishlist(int id)
        {
            var phoneWishlist = await _context.PhoneWishlists.FindAsync(id);
            if (phoneWishlist == null)
            {
                return NotFound();
            }

            _context.PhoneWishlists.Remove(phoneWishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhoneWishlistExists(int id)
        {
            return _context.PhoneWishlists.Any(e => e.Id == id);
        }
    }
}
