using HeroBelemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroBelemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroBelemController : ControllerBase
    {
        private readonly DataContext _context;

        public HeroBelemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HeroBelem>>> Get()
        {
            
            return Ok(await _context.HeroesBelem.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HeroBelem>> Get(int id)
        {
            var herobel = await _context.HeroesBelem.FindAsync(id);
            if (herobel == null) return BadRequest("O personagem não foi encontrado.");
            return Ok(herobel);
        }

        [HttpPost]
        public async Task<ActionResult<List<HeroBelem>>> AddHero(HeroBelemPost heroBelem)
        {
            _context.HeroesBelem.Add(new HeroBelem
            {
                Name = heroBelem.Name,
                FirstName = heroBelem.FirstName,
                LastName = heroBelem.LastName,
                Place = heroBelem.Place
            });
            await _context.SaveChangesAsync();

            return Ok("Adicionado com sucesso.");
        }

        [HttpPut]
        public async Task<ActionResult<List<HeroBelem>>> UpdateHero(HeroBelem request)
        {
            var herobel = await _context.HeroesBelem.FindAsync(request.Id);
            if (herobel == null) return BadRequest("O personagem não foi encontrado.");

            herobel.Name = (request.Name == null || request.Name == "string")? herobel.Name:request.Name;
            herobel.FirstName = (request.FirstName == null || request.FirstName == "string") ? herobel.FirstName : request.FirstName;
            herobel.LastName = (request.LastName == null || request.LastName == "string") ? herobel.LastName : request.LastName;
            herobel.Place = (request.Place == null || request.Place == "string") ? herobel.Place : request.Place;

            await _context.SaveChangesAsync();
            return Ok("Registro atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HeroBelem>> Delete(int id)
        {
            var herobel = await _context.HeroesBelem.FindAsync(id);
            if (herobel == null) return BadRequest("O personagem não foi encontrado.");

            _context.HeroesBelem.Remove(herobel);
            await _context.SaveChangesAsync();
            
            return Ok("Registro removido com sucesso.");
        }
    }
}
