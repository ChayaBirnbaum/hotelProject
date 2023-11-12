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
        public Customers Get(string id)
        {
            return context.customersList.Find(x => x.CustId ==id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] Customers c)
        {
            Customers customers = new Customers { CustId=c.CustId, Name=c.Name, Email=c.Email, Adress=c.Adress,Phone=c.Phone };
            context.customersList.Add(customers);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Customers c)
        {
            Customers cust = context.customersList.Find(x => x.CustId==id);
            cust.Name = c.Name;
            cust.Email = c.Email;
            cust.Adress = c.Adress;
            cust.Phone = c.Phone;

        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
             Customers cust = context.customersList.Find(x => x.CustId == id);
            context.customersList.Remove(cust);
         }
    }
}
