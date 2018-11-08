using System.Collections.Generic;
using System.Linq;
using Heroes.DbContext;
using Heroes.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        // GET: api/<controller>
        private readonly HeroesDbContext _dbContext;

        public HeroesController(HeroesDbContext heroes)
        {
            _dbContext = heroes;

            if (!_dbContext.Heroes.Any())
            {
                //create a new hero if collection is empty
                //which means you cant delete all heroes
                _dbContext.Heroes.Add(new Hero { Name = "Hero11" });
                _dbContext.Heroes.Add(new Hero { Name = "Hero12" });
                _dbContext.Heroes.Add(new Hero { Name = "Hero13" });
                _dbContext.Heroes.Add(new Hero { Name = "Hero14" });
                _dbContext.Heroes.Add(new Hero { Name = "Hero15" });
                _dbContext.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Hero>> GetHeroes()
        {
            return _dbContext.Heroes.ToList();

        }

        [HttpGet("{id}", Name = "GetHero")]
        public ActionResult<Hero> GetHeroById(long id)
        {
            var item = _dbContext.Heroes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult create(Hero person)
        {
            _dbContext.Heroes.Add(person);
            _dbContext.SaveChanges();

            return CreatedAtRoute("GetHero", new {id = person.Id}, person);
        }


    }
}
