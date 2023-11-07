using Microsoft.AspNetCore.Mvc;
using hotelProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private static List<Rooms> roomsList = new List<Rooms>();
        private static int[] roomNumber = new int[8];
        // GET: api/<RoomsController>
        [HttpGet]
        public IEnumerable<Rooms> Get()
        {
            return roomsList;
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public Rooms Get(int id)
        {
            return roomsList.Find(x=>x.RoomId==id);
        }

        // POST api/<RoomsController>
        [HttpPost]
        public void Post([FromBody] Rooms r)
        {
            Rooms room = new Rooms { RoomId = r.Floor * 100 + roomNumber[r.Floor],  Floor = r.Floor, NumOfBad = r.NumOfBad, IsEmpty = true, Price = r.Price };
            roomNumber[r.Floor]++;
            roomsList.Add(room);
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Rooms r)
        {
            Rooms room= roomsList.Find(x => x.RoomId == id);   
            room.Floor = r.Floor;
            room.NumOfBad = r.NumOfBad;
            room.IsEmpty = r.IsEmpty;
            room.Price = r.Price;
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Rooms room = roomsList.Find(x => x.RoomId == id);
            roomsList.Remove(room);
        }
    }
}
