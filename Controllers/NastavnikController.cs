using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleWebApplication.Models;

namespace NastavnikBase.Controllers
{

        [Route("api2/[controller]")]
        [ApiController]
        public class NastavnkController : Controller
        {
            private readonly NastavnkContext _contextN;
            public NastavnkController(NastavnkContext contextN)
            {
                _contextN = contextN;
            }
            //// GET: Nastavnik
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Nastavnik>>> GetNastavnik()
            {
            if (_contextN.Nastavnik == null)
            {
                return NotFound();
            }
            return await _contextN.Nastavnik.ToListAsync();
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<Nastavnik>> GetNastavnik(long? id)
            {
                if (_contextN.Nastavnik == null)
                {
                    return NotFound();
                }

                var Nastavnik = await _contextN.Nastavnik.FindAsync(id);

                if (Nastavnik == null)
                {
                    return NotFound();
                }

                return Nastavnik;
            }


            [HttpPost]
            public async Task<ActionResult<Nastavnik>> PostStudent(Nastavnik Nastavnik)
            {
                if (_contextN.Nastavnik == null)
                {
                    return Problem("0000000000");
                }
                _contextN.Nastavnik.Add(Nastavnik);
                await _contextN.SaveChangesAsync();
                return CreatedAtAction("GetSt", new { id = Nastavnik.Id }, Nastavnik);
            }


            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteNastavnik(long id)
            {
                if (_contextN.Nastavnik == null)
                {
                    return NotFound();
                }
                var Nastavnik = await _contextN.Nastavnik.FindAsync(id);
                if (Nastavnik == null)
                {
                    return NotFound();
                }
                _contextN.Nastavnik.Remove(Nastavnik);
                await _contextN.SaveChangesAsync();
                return NoContent();

            }



            //private bool NastavnikExists(long id)
            //{
            //    return (_contextN.Nastavnik?.Any(e => e.Id == id)).GetValueOrDefault();
            //}


        }


}
