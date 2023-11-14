using hotelProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //private static List<Orders> ordersList = new List<Orders>();
        //private static int orederNum=1;
        DataContext context;
        
        // GET: api/<CustomersController>
        public OrdersController(DataContext data)
        {
            context = data;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            return context.ordersList;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Orders> Get(int id)
        {
            Orders o = context.ordersList.Find(x => x.OrderID == id);
            if (o == null)
                return NotFound();
            return o;
        }
        

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult Post([FromBody] Orders o)
        {
            Customers c = context.customersList.Find(x => x.CustId == o.CustID);
            Rooms r = context.roomsList.Find(x => x.RoomId ==o.RoomID);
            if (r == null||c==null)
                return NotFound();
            //בדיקה האם החדר פנוי בתאריך המבוקש
            if (!Validation.isEmpty(o.OrderID,o.RoomID, o.Start,o.end))
                return BadRequest();
            Orders ord = new Orders { OrderID = context.orederNum, CustID = o.CustID, Start = o.Start, end = o.end, Payment =(int) (o.end-o.Start).TotalDays*r.Price, RoomID = o.RoomID };
            context.orederNum++;
            context.ordersList.Add(ord);
            return Ok();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Orders o)
        {
            Customers c = context.customersList.Find(x => x.CustId == o.CustID);
            Rooms r = context.roomsList.Find(x => x.RoomId == o.RoomID);
            Orders ord = context.ordersList.Find(x=>x.OrderID==id);
            if (ord == null||c==null||r==null) return NotFound();
            //בדיקה האם החדר פנוי בתאריך המבוקש
            if (!Validation.isEmpty(o.OrderID,o.RoomID, o.Start, o.end))
                return BadRequest();
            ord.Start = o.Start;
            ord.end = o.end;
            ord.Payment = o.Payment;
            ord.RoomID = o.RoomID;
            return Ok();   
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Orders ord = context.ordersList.Find(x=>x.OrderID==id);
            if(ord == null) return NotFound(); 
            context.ordersList.Remove(ord);
            return Ok();
        }
    }
}
