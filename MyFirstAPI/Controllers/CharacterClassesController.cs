using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterClassesController : ControllerBase
    {
        private readonly dndContext _context;

        public CharacterClassesController(dndContext context)
        {
            _context = context;
        }

        // GET: api/CharacterClasses
        [HttpGet]
        public async Task<ActionResult<ClassResponse>> GetCharacterClasses()
        {
            var response = new ClassResponse();
            if (_context.CharacterClasses == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Class table Not Found";
                return response;
            }
            response.statusCode = 200;
            response.statusDescription = "OK, fetched classes";
            response.classes = await _context.CharacterClasses.ToListAsync();
            return response;
        }

        // GET: api/CharacterClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassResponse>> GetCharacterClass(string id)
        {
          var response = new ClassResponse();
          if (_context.CharacterClasses == null)
          {
                response.statusCode = 400;
                response.statusDescription = "Class table Not Found";
                return response;
            }
            var characterClass = await _context.CharacterClasses.FindAsync(id);

            if (characterClass == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Class Not Found";
                return response;
            }
            response.statusCode = 200;
            response.statusDescription = "OK, fetched class";
            response.classes.Add(characterClass);
            return response;
        }

        // PUT: api/CharacterClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ClassResponse> PutCharacterClass(string id, CharacterClass characterClass)
        {
            var response = new ClassResponse();
            if (id != characterClass.CharaClassID)
            {
                response.statusCode = 400;
                response.statusDescription = "bad request";
                return response;
            }

            _context.Entry(characterClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterClassExists(id))
                {
                    response.statusCode = 404;
                    response.statusDescription = "Class Not Found";
                    return response;
                }
                else
                {
                    throw;
                }
            }
            response.statusCode = 200;
            response.statusDescription = "OK, modified class";

            return response;
        }

        // POST: api/CharacterClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassResponse>> PostCharacterClass(CharacterClass characterClass)
        {
          var response = new ClassResponse();
          if (_context.CharacterClasses == null)
          {
                response.statusCode = 500;
                response.statusDescription = "Server error";
                return response;
            }
            _context.CharacterClasses.Add(characterClass);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CharacterClassExists(characterClass.CharaClassID))
                {
                    response.statusCode = 407;
                    response.statusDescription = "Conflict, class already exists";
                    return response;
                }
                else
                {
                    throw;
                }
            }
            response.statusCode = 200;
            response.statusDescription = "Ok, created Class";
            return response;
        }

        // DELETE: api/CharacterClasses/5
        [HttpDelete("{id}")]
        public async Task<ClassResponse> DeleteCharacterClass(string id)
        {
            var response = new ClassResponse();
            if (_context.CharacterClasses == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Database Not Found";
                return response;
            }
            var characterClass = await _context.CharacterClasses.FindAsync(id);
            if (characterClass == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Class Not Found";
                return response;
            }

            _context.CharacterClasses.Remove(characterClass);
            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "Ok, deleted class";
            return response;
        }

        private bool CharacterClassExists(string id)
        {
            return (_context.CharacterClasses?.Any(e => e.CharaClassID == id)).GetValueOrDefault();
        }
    }
}
