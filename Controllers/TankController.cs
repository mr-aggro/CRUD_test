using CRUD.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TankController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: TankController
        [HttpGet(Name = "GetTankIndex")]
        public IEnumerable<Tank> Index()
        {
            return db.Tanks.ToList();
        }

        [HttpGet("{id}", Name = "GetTank")]
        public IEnumerable<Tank> Get(int id)
        {
            return db.Tanks.Where(x => x.Id == id).ToList();
        }

        [HttpDelete("{id}", Name = "Delete Tank")]
        public List<bool> Delete(int id)
        {
            try
            {
                var tank = new Tank { Id = id };
                db.Tanks.Attach(tank);
                db.Tanks.Remove(tank);
                db.SaveChanges();
                return new List<bool> { true };
            }
            catch (Exception)
            {

                return new List<bool> { false };
            }
        }

        [HttpPut(Name = "Add Tank")]
        public string Add([FromBody] Tankadd tank)
        {
                Tank for_add = new Tank
                {
                    Name = tank.Name,
                    CurrentVolume = tank.CurrentVolume,
                    MinVolume = tank.MinVolume,
                    MaxVolume = tank.MaxVolume,
                    Description = tank.Description
                };
                // Logic to update an Employee
                db.Add(for_add);
                db.SaveChanges();
                return "ok";
  
        }

        [HttpPut("{id}", Name = "Update Tank")]
        public Tank Update(int id, [FromBody] Tankadd tank)
        {
            
            var existing = db.Tanks.Find(id);
            if (existing != null)
            {
                db.Entry(existing).CurrentValues.SetValues(tank);
                db.SaveChanges();
                return existing;
            }
            return new Tank { };
        }
    }
}
