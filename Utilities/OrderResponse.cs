using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Utilities
{
    public class OrderResponse
    {
        public int orderId { get; set; }
        public string messageType{ get; set; }
        public string message { get; set; }
        public Boolean isOrderPacked { get; set; }
        public Boolean isDuplicatePackageSlipForRoyalty { get; set; }
        public Boolean isEmailSent { get; set; }
        public Boolean isVideoAdded { get; set; }
        public Boolean isMembershipAdded { get; set; }
        public Boolean isMembershipUpgraded { get; set; }
        
    }
    
}
