namespace OrderProcessing
{
    public class MembershipUpgrade : Rule<ActiveMembership>
    {
        protected override void Apply(ActiveMembership item)
        {
            item.NotifyUser();
        }

        protected override bool PreValidation(ActiveMembership item)
        {
            return item.ItemStatus == Status.Accepted || item.ItemStatus == Status.Processing;
        }
    }

}
