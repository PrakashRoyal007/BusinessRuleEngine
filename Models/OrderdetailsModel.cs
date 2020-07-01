using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Models
{
    public class OrderdetailsModel
    {
        public int orderId { get; set; }
        public string username { get; set; }
       public string orderType { get; set; }
        public int membershipId { get; set; }
        
    }
}
