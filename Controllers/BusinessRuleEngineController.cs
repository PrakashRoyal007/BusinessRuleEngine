using BusinessRuleEngine.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Controllers
{
    public class BusinessRuleEngineController
    {
        public string BusinessOrders(OrderdetailsModel input)
        {
            string response = string.Empty;
            if(input.orderType.ToLower()=="physical product" || input.orderType.ToLower() == "book")
            {
                if (input.orderType.ToLower() == "physical product")
                {
                    response = "Your order has been packed and will deliver soon with our delivery agents";
                }
                else
                {
                    response = "created duplicate packing slip for royalty department";
                }

            }
            else if(input.orderType.ToLower() == "membership" || input.orderType.ToLower() == "upgrade membership")
            {

                if (input.orderType.ToLower() == "membership")
                {
                    response = AddMembership(input.username);
                }
                else
                {
                    response = UpgradeMembership(input.username, input.membershipId);
                }
            }
            return response;
        }
        public string AddMembership(string username)
        {
            //will update the given userid in our DB
            string result = string.Empty;
            string query = string.Format("update table set isMembership={0} where user={1}", true, username);//i have given sample here but different query for entity framework

            return result ="Added membership successfully to the given userid";
        }
        public string UpgradeMembership(string username, int membershipid)
        {
            //will update the given userid in our DB
            string result = string.Empty;
            string query = string.Format("update table set isMembershipupgrade={0} where user={1} and membershipid={2}", true,username, membershipid);
            return result = "Membership upgraded successfully to the given userid";
        }
    }
}
