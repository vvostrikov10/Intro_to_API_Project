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
    public class CharacterSubClassesController : ControllerBase
    {
        private readonly dndContext _context;

        public CharacterSubClassesController(dndContext context)
        {
            _context = context;
        }

        // GET: api/CharacterSubClasses
        [HttpGet]
        public async Task<ActionResult<SubClassResponse>> GetCharacterSubClasses()
        {
          var response = new SubClassResponse();
          if (_context.CharacterSubClasses == null)
          {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }
            response.statusCode = 200;
            response.statusDescription = "OK";
            response.subClasses = await _context.CharacterSubClasses.ToListAsync();
            return response;
        }

        // GET: api/CharacterSubClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubClassResponse>> GetCharacterSubClass(string id)
        {
            var response = new SubClassResponse();
            if (_context.CharacterSubClasses == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }
            var characterSubClass = await _context.CharacterSubClasses.FindAsync(id);

            if (characterSubClass == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }
            response.statusCode = 200;
            response.statusDescription = "OK";
            response.subClasses.Add(characterSubClass);
            return response;
        }

        // PUT: api/CharacterSubClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<SubClassResponse> PutCharacterSubClass(string id, CharacterSubClass characterSubClass)
        {
            var response = new SubClassResponse();
            if (id != characterSubClass.CharaSubClassID)
            {
                response.statusCode = 400;
                response.statusDescription = "bad request";
                return response;
            }

            _context.Entry(characterSubClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterSubClassExists(id))
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

        // POST: api/CharacterSubClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubClassResponse>> PostCharacterSubClass(CharacterSubClass characterSubClass)
        {
            var response = new SubClassResponse();
            if (_context.CharacterSubClasses == null)
            {
                response.statusCode = 500;
                response.statusDescription = "Server error";
                return response;
            }
            _context.CharacterSubClasses.Add(characterSubClass);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CharacterSubClassExists(characterSubClass.CharaSubClassID))
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

        // DELETE: api/CharacterSubClasses/5
        [HttpDelete("{id}")]
        public async Task<SubClassResponse> DeleteCharacterSubClass(string id)
        {
            var response = new SubClassResponse();
            if (_context.CharacterSubClasses == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }
            var characterSubClass = await _context.CharacterSubClasses.FindAsync(id);
            if (characterSubClass == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found";
                return response;
            }

            _context.CharacterSubClasses.Remove(characterSubClass);
            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "Ok";
            return response;
        }

        private bool CharacterSubClassExists(string id)
        {
            return (_context.CharacterSubClasses?.Any(e => e.CharaSubClassID == id)).GetValueOrDefault();
        }
    }
}
