using CrazyMusicians.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        // GET: api/musicians/search(name)
        [HttpGet("Search")]
        public IActionResult GetMusicians([FromQuery] string search = null)
        {
            var musicians = MusicianData.Musicians;

            if (!string.IsNullOrEmpty(search))
            {
                musicians = musicians.Where(m => m.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                                 m.Profession.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Ok(musicians);
        }

        // GET: api/musicians
        [HttpGet]
        public IActionResult MusicianList()
        {
            var musicians = MusicianData.Musicians.ToList();
            return Ok(musicians);
        }

        // GET: api/musicians/{id}
        [HttpGet("{id}")]
        public IActionResult GetMusician(int id)
        {
            var musician = MusicianData.Musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound(new { Message = "Musician not found" });
            }

            return Ok(musician);
        }

        // POST: api/musicians
        [HttpPost]
        public IActionResult CreateMusician([FromBody] Musician musician)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            musician.Id = MusicianData.Musicians.Max(m => m.Id) + 1;
            MusicianData.Musicians.Add(musician);

            return CreatedAtAction(nameof(GetMusician), new { id = musician.Id }, musician);
        }

        // PUT: api/musicians/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMusician(int id, [FromBody] Musician musician)
        {
            var existingMusician = MusicianData.Musicians.FirstOrDefault(m => m.Id == id);
            if (existingMusician == null)
            {
                return NotFound(new { Message = "Musician not found" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingMusician.Name = musician.Name;
            existingMusician.Profession = musician.Profession;
            existingMusician.FunnyTrait = musician.FunnyTrait;

            return Ok(musician);
        }

        // PATCH: api/musicians/{id}
        [HttpPatch("{id}")]
        public IActionResult PatchMusician(int id, [FromBody] string funnyTrait)
        {
            var existingMusician = MusicianData.Musicians.FirstOrDefault(m => m.Id == id);
            if (existingMusician == null)
            {
                return NotFound(new { Message = "Musician not found" });
            }

            existingMusician.FunnyTrait = funnyTrait;

            return Ok();
        }

        // DELETE: api/musicians/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMusician(int id)
        {
            var musician = MusicianData.Musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound(new { Message = "Musician not found" });
            }

            MusicianData.Musicians.Remove(musician);

            return Ok("Musician deleted successfully");
        }
    }
}
