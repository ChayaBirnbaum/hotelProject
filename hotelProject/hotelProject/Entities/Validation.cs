namespace hotelProject.Entities
{
    public static class Validation
    {
        public static bool isEmpty(int ordId,int id,DateTime start,DateTime end)
        {
            DataContext context=new DataContext();
            List<Orders> ordersList = context.ordersList;
            foreach (Orders order in ordersList)
            {
                if (order.OrderID!=ordId&& order.RoomID == id &&end>order.Start&&start<order.end)
                    return false;
            }
            return true;
        }

        public static bool checkId (string id)
    {
            if(id.Length<9)
                return false;
            int digit, sum = 0;
            int checksum = id [8];
            //id /= 10;
            for (int i = 0; i < 8; i++)
            {
                digit = id [7-i];
               // id /= 10;
                if (i % 2==0)
                    digit *= 2;
                if (digit > 9)
                    digit = digit / 10 + digit % 10;
                sum += digit;
            }
            if ((10 - sum % 10) == checksum)
                return true;
        return false;
    }
        public static bool checkPhon(string phon)
        {
            if (phon.Substring(0,1) == "0" && (phon.Substring(2,3)=="-"&&phon.Length==10||phon.Substring(3,4)=="-"&&phon.Length==11))
                return true;
            return false;
        }
       public  static bool checkEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false; // email must have exactly one @ symbol
            }

            string localPart = parts[0];
            string domainPart = parts[1];
            if (string.IsNullOrWhiteSpace(localPart) || string.IsNullOrWhiteSpace(domainPart))
            {
                return false; // local and domain parts cannot be empty
            }

            // check local part for valid characters
            foreach (char c in localPart)
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '-')
                {
                    return false; // local part contains invalid character
                }
            }

            // check domain part for valid format
            if (domainPart.Length < 2 || !domainPart.Contains(".") || domainPart.Split(".").Length != 2 || domainPart.EndsWith(".") || domainPart.StartsWith("."))
            {
                return false; // domain part is not a valid format
            }

            return true;
        }
    
}

  
}
