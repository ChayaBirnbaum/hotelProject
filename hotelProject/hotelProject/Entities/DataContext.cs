namespace hotelProject.Entities
{
    public class DataContext
    {
        public List<Customers> customersList { get; set; }
        public List<Rooms> roomsList { get; set; }
        public List<Orders> ordersList { get; set; }
        public  int[] roomNumber;
        public  int orederNum { get; set; }

        public DataContext()
        {
            customersList = new List<Customers>();
            roomsList = new List<Rooms>();
            ordersList = new List<Orders>();
            roomNumber = new int[8];
            orederNum = 1;
        }
    }
}
