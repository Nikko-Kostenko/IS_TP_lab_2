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
    public class PhoneFunctionsController : ControllerBase
    {
        private readonly Lab2PhoneContext _context;

        public PhoneFunctionsController(Lab2PhoneContext context)
        {
            _context = context;
        }

        // GET: api/PhoneFunctions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneFunction>>> GetPhoneFunctions()
        {
            return await _context.PhoneFunctions.ToListAsync();
        }

        // GET: api/PhoneFunctions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneFunction>> GetPhoneFunction(int id)
        {
            var phoneFunction = await _context.PhoneFunctions.FindAsync(id);

            if (phoneFunction == null)
            {
                return NotFound();
            }

            return phoneFunction;
        }

        // PUT: api/PhoneFunctions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneFunction(int id, PhoneFunction phoneFunction)
        {
            if (id != phoneFunction.Id)
            {
                return BadRequest();
            }

            _context.Entry(phoneFunction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneFunctionExists(id))
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

        // POST: api/PhoneFunctions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhoneFunction>> PostPhoneFunction(PhoneFunction phoneFunction)
        {
            _context.PhoneFunctions.Add(phoneFunction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneFunction", new { id = phoneFunction.Id }, phoneFunction);
        }

        // DELETE: api/PhoneFunctions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneFunction(int id)
        {
            var phoneFunction = await _context.PhoneFunctions.FindAsync(id);
            if (phoneFunction == null)
            {
                return NotFound();
            }

            _context.PhoneFunctions.Remove(phoneFunction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhoneFunctionExists(int id)
        {
            return _context.PhoneFunctions.Any(e => e.Id == id);
        }
    }
}
