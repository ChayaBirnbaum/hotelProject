using Microsoft.AspNetCore.Mvc;
using hotelProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        
        DataContext context;
        // GET: api/<CustomersController>
        public RoomsController(DataContext data)
        {
            context = data;
        }
        // GET: api/<RoomsController>
        [HttpGet]
        public IEnumerable<Rooms> Get()
        {
            return context.roomsList ;
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public ActionResult< Rooms> Get(int id)
        {
            Rooms r = context.roomsList.Find(x => x.RoomId == id);
            if (r == null)
                return NotFound();

            return r;
        }

        // POST api/<RoomsController>
        [HttpPost]
        public ActionResult Post([FromBody] Rooms r)
        {
            Rooms room = new Rooms { RoomId = r.Floor * 100 + context.roomNumber[r.Floor],  Floor = r.Floor, NumOfBad = r.NumOfBad, Price = r.Price };
            
            context.roomNumber[r.Floor]++;
            context.roomsList.Add(room);
            return Ok();
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Rooms r)
        {
            Rooms room= context.roomsList.Find(x => x.RoomId == id);
            if (room == null)
                return NotFound();
            room.Floor = r.Floor;
            room.NumOfBad = r.NumOfBad;          
            room.Price = r.Price;
            return Ok();   
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Rooms room = context.roomsList.Find(x => x.RoomId == id);
            if (room == null)
                return NotFound();
            context.roomsList.Remove(room);
            return Ok();
        }
    }
}
