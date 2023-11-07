namespace hotelProject.Entities
{
    public class Orders
    {
       

        public int OrderID { get; set; }
        public string CustID { get; set; }
        public int RoomID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Payment { get; set; }
    }
}
