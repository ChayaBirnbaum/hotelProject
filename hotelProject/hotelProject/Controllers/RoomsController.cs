using Microsoft.AspNetCore.Mvc;
using hotelProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        //private static List<Rooms> roomsList = new List<Rooms>();
       // private static int[] roomNumber = new int[8];
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
        public Rooms Get(int id)
        {
            return context.roomsList.Find(x=>x.RoomId==id);
        }

        // POST api/<RoomsController>
        [HttpPost]
        public void Post([FromBody] Rooms r)
        {
            Rooms room = new Rooms { RoomId = r.Floor * 100 + context.roomNumber[r.Floor],  Floor = r.Floor, NumOfBad = r.NumOfBad, Price = r.Price };
            context.roomNumber[r.Floor]++;
            context.roomsList.Add(room);
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Rooms r)
        {
            Rooms room= context.roomsList.Find(x => x.RoomId == id);   
            room.Floor = r.Floor;
            room.NumOfBad = r.NumOfBad;          
            room.Price = r.Price;
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Rooms room = context.roomsList.Find(x => x.RoomId == id);
            context.roomsList.Remove(room);
        }
    }
}
