using Microsoft.AspNetCore.Mvc;
using hotelProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        DataContext context;
        // GET: api/<CustomersController>
        public CustomersController(DataContext data )
        {
            context = data;
        }

        [HttpGet]
        public IEnumerable<Customers> Get()
        {
            return context. customersList;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<Customers> Get(string id)
        {
            Customers c=context.customersList.Find(x => x.CustId ==id);
            if(c==null)
                return NotFound();
            return c;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public ActionResult Post([FromBody] Customers c)
        {
            Customers customers = new Customers { CustId=c.CustId, Name=c.Name, Email=c.Email, Adress=c.Adress,Phone=c.Phone };
            if (customers != null)
                return NotFound();
            context.customersList.Add(customers);
            return Ok();
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Customers c)
        {
            Customers cust = context.customersList.Find(x => x.CustId==id);
            if (cust != null)
                return NotFound();
            cust.Name = c.Name;
            cust.Email = c.Email;
            cust.Adress = c.Adress;
            cust.Phone = c.Phone;
            return Ok();

        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
             Customers cust = context.customersList.Find(x => x.CustId == id);
            if (cust != null)
                return NotFound();
            context.customersList.Remove(cust);
            return Ok();
         }
    }
}
