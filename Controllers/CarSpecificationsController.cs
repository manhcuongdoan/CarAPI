using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarSpecificationsController : ControllerBase
    {
        private readonly CarContext _context;

        public CarSpecificationsController(CarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarSpecification>>> GetCarSpecifications()
        {
            return await _context.CarSpecifications.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarSpecification>> GetCarSpecification(int id)
        {
            var carSpecification = await _context.CarSpecifications.FindAsync(id);

            if (carSpecification == null)
                return NotFound();
            return carSpecification;
        }

        [HttpPost]
        public async Task<ActionResult<CarSpecification>> PostCarSpecification(CarSpecification carSpecification)
        {
            carSpecification.DateCreateAt = DateTime.Now;
            _context.CarSpecifications.Add(carSpecification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarSpecification), new {id = carSpecification.CarId}, carSpecification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarSpecification(int id, CarSpecification carSpecification)
        {
            if (id != carSpecification.CarId)
            {
                return BadRequest();
            }


            _context.Entry(carSpecification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CarSpecifications.Any(e => e.CarId == id))
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<CarSpecification>> DeleteCarSpecification(int id)
        {
            var carSpecification = await _context.CarSpecifications.FindAsync(id);
            if (carSpecification == null)
            {
                return NotFound();
            }

            _context.CarSpecifications.Remove(carSpecification);
            await _context.SaveChangesAsync();
            return carSpecification;
        }
    }
}