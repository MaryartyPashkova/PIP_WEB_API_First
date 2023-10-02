using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleWebApplication.Models;

namespace StudentBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly StudentContext _context;
       

        public StudentsController(StudentContext context)
        {
            _context = context;
        }
        

        // GET: Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
              return await _context.Students.ToListAsync();
        }


        // GET: Students/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudent(long? id)
        {
            if ( _context.Students == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FindAsync(id);
               
            if (students == null)
            {
                return NotFound();
            }

            return students;
        }

        // GET: Students/Create



        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(long id, Students students)
        {
            if (id != students.Id)
            {
                return BadRequest();
            }
            _context.Entry(students).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Students>> PostStudent(Students students)
        {
            if(_context.Students == null)
            {
                return Problem("0000000000");
            }
            _context.Students.Add(students);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSt", new {id = students.Id}, students);
        }












        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(long id)
        {
            if ( _context.Students == null)
            {
                return NotFound();
            }
            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            _context.Students.Remove(students);
            await _context.SaveChangesAsync();
            return NoContent();
           
        }

       

        private bool StudentsExists(long id)
        {
          return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
