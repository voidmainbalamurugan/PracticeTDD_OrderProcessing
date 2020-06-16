using System;

namespace OrderProcessing
{
    public class MembershipUpgrade : Rule<ActiveMembership>
    {
        protected override void Apply(ActiveMembership item)
        {
            item.ExpiryDate = item.ExpiryDate > DateTime.Now? 
                item.ExpiryDate.AddDays(ActiveMembership._days)
                : DateTime.Now.AddDays(ActiveMembership._days);
            
            item.NotifyUser();
        }

        protected override bool PreValidation(ActiveMembership item)
        {
            return item.ItemStatus == Status.Accepted || item.ItemStatus == Status.Processing;
        }
    }

}
