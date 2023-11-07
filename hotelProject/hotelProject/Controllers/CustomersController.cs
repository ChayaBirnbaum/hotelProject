using Microsoft.AspNetCore.Mvc;
using hotelProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customers> customersList=new List<Customers>();
        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customers> Get()
        {
            return customersList;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customers Get(string id)
        {
            return customersList.Find(x => x.CustId ==id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] Customers c)
        {
            Customers customers = new Customers { CustId=c.CustId, Name=c.Name, Email=c.Email, Adress=c.Adress,Phone=c.Phone };
            customersList.Add(customers);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Customers c)
        {
            Customers cust = customersList.Find(x => x.CustId==id);
            cust.Name = c.Name;
            cust.Email = c.Email;
            cust.Adress = c.Adress;
            cust.Phone = c.Phone;

        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
             Customers cust = customersList.Find(x => x.CustId == id);
            customersList.Remove(cust);
         }
    }
}
