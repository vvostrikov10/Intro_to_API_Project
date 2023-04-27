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
    public class CharactersController : ControllerBase
    {
        private readonly dndContext _context;

        public CharactersController(dndContext context)
        {
            _context = context;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<CharacterResponse>> GetCharacters()
        {


          var response = new CharacterResponse();
          if (_context.Characters == null)
          {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }
            response.statusCode = 200;
            response.statusDescription = "OK";
            response.characters = await  (_context.Characters.Include(c => c.CharaClass).Include(c => c.CharaSubClass).ToListAsync());
            return response;
        }

        // GET: api/Characters/Vax
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacter(string id)
        {
            var response = new CharacterResponse();
            response.statusCode = 400;
            response.statusDescription = "Not Found";
            if (_context.Characters == null)
            {
              return response;
            }
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Entry(character).Reference(c => c.CharaClass).Load();
                _context.Entry(character).Reference(c => c.CharaSubClass).Load();
                response.statusCode = 200;
                response.statusDescription = "OK";
                response.characters.Add(character);
                return response;
            }
            return response;
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<CharacterResponse> PutCharacter(string id, Character character)
        {
            var response = new CharacterResponse();
            if (id != character.CharacterName)
            {
                response.statusCode = 400;
                response.statusDescription = "bad request";
                return response;
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    response.statusCode = 404;
                    response.statusDescription = "Not Found";
                    return response;
                }
                else
                {
                    throw;
                }
            }
            response.statusCode = 200;
            response.statusDescription = "OK";

            return response;
        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterResponse>> PostCharacter(Character character)
        {
          var response = new CharacterResponse();
          if (_context.Characters == null)
          {
                response.statusCode = 500;
                response.statusDescription = "Server error";
                return response;
          }
            _context.Characters.Add(character);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CharacterExists(character.CharacterName))
                {
                    response.statusCode = 407;
                    response.statusDescription = "Conflict";
                    return response;
                }
                else
                {
                    throw;
                }
            }
            response.statusCode = 200;
            response.statusDescription = "Ok";
            return response;
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<CharacterResponse> DeleteCharacter(string id)
        {
            var response = new CharacterResponse();
            if (_context.Characters == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "Ok";
            return response;
        }

        private bool CharacterExists(string id)
        {
            return (_context.Characters?.Any(e => e.CharacterName == id)).GetValueOrDefault();
        }
    }
}
