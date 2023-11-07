using Microsoft.AspNetCore.Mvc;
using hotelProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private static List<Orders> ordersList = new List<Orders>();
        private static int orederNum=1;
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            return ordersList;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public Orders Get(int id)
        {
            return ordersList.Find(x=>x.OrderID==id);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] Orders o)
        {

            Orders ord = new Orders { OrderID = orederNum, CustID = o.CustID, Start = o.Start, End = o.End, Payment = 200, RoomID = o.RoomID };
            orederNum++;
            ordersList.Add(ord);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Orders o)
        {
            Orders ord=ordersList.Find(x=>x.OrderID==id);
            ord.Start = o.Start;
            ord.End = o.End;
            ord.Payment = o.Payment;
            ord.RoomID = o.RoomID;
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Orders ord= ordersList.Find(x=>x.OrderID==id);
            ordersList.Remove(ord);
        }
    }
}
