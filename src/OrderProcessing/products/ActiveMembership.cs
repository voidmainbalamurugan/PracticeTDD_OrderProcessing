using System;

namespace OrderProcessing
{
    public class ActiveMembership : OrderItem, IMembership
    {
        public bool IsActive {get; set;}
        public User Owner {get; set;}
        public DateTime ExpiryDate {get; set;}

        public override void ProcessOrderItem(IRulesManager rulesManager)
        {
            // null-check

            rulesManager.Process(this);
        }

        public void Assign(IMembershipManager manager)
        {
            // null-check

            manager.SetMemership(this);
        }

    }
}
