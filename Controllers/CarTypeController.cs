using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypesController : ControllerBase
    {
        private readonly CarContext _context;

        public CarTypesController(CarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarType>>> GetCarTypes()
        {
            return await _context.CarTypes.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CarType>> GetCarType(int id)
        {
            var carType = await _context.CarTypes.FindAsync(id);

            if (carType == null)
                return NotFound();
            return carType;
        }
        [HttpPost]
        public async Task<ActionResult<CarType>> PostCarType(CarType carType)
        {
            _context.CarTypes.Add(carType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarType), new {id = carType.CarTypeId}, carType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarType(int id, CarType carType)
        {
            if (id != carType.CarTypeId)
            {
                return BadRequest();
            }
            
            
            _context.Entry(carType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CarTypes.Any(e => e.CarTypeId == id))
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
        public async Task<ActionResult<CarType>> DeleteCarType(int id)
        {
            var carType = await _context.CarTypes.FindAsync(id);
            if (carType == null)
            {
                return NotFound();
            }

            _context.CarTypes.Remove(carType);
            await _context.SaveChangesAsync();
            return carType;
        }
        
    }
}