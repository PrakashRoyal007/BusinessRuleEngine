using BusinessRuleEngine.Models;
using BusinessRuleEngine.Utilities;
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
        /// <summary>
        /// This controller is to handle all orders
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public OrderResponse BusinessOrders(OrderdetailsModel input)
        {
            OrderResponse response = new OrderResponse();
            try
            {            
                if (input.orderType.ToLower() == "physical product" || input.orderType.ToLower() == "book")
                {
                    if (input.orderType.ToLower() == "physical product")
                    {
                        response.isOrderPacked = true;//here we will send packing slip for customer
                        response.messageType = "success";
                    }
                    else
                    {
                        response.isDuplicatePackageSlipForRoyalty = true;//heer we will create duplicate packing slip for royalty department
                        response.messageType = "success";
                    }
                    //code to generate comission to the agent
                }
                else if (input.orderType.ToLower() == "membership" || input.orderType.ToLower() == "upgrade membership")
                {

                    if (input.orderType.ToLower() == "membership")
                    {
                        response.isMembershipAdded = AddMembership(input.username);
                        response.messageType = "success";
                    }
                    else
                    {
                        response.isMembershipUpgraded = UpgradeMembership(input.username, input.membershipId);
                        response.messageType = "success";
                    }
                    //code to sent an email to the user
                }
                else if (input.orderType.ToLower() == "video")
                {
                    //code to add "First Aid" video to packing slip
                    response.messageType = "success";
                }
                else
                {
                    response.messageType = "failure";
                    response.message = "Something went wrong please check your order";
                }
            }catch(Exception ex)
            {
                response.messageType = "failure";
                response.message =string.Format(ex.Message);
            }
            return response;
        }
        /// <summary>
        /// To add new membership to the user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Boolean AddMembership(string username)
        {
            //will update the given userid in our DB
          
            string query = string.Format("update table set isMembership={0} where user={1}", true, username);//i have given sample here but different query for entity framework

            return  true;
        }
        /// <summary>
        /// To upgrade customer membership
        /// </summary>
        /// <param name="username"></param>
        /// <param name="membershipid"></param>
        /// <returns></returns>
        public Boolean UpgradeMembership(string username, int membershipid)
        {
            //will update the given userid in our DB
          
            string query = string.Format("update table set isMembershipupgrade={0} where user={1} and membershipid={2}", true,username, membershipid);
            return true;
        }
    }
}
