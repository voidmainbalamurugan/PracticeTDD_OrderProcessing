namespace OrderProcessing
{
    public class MembershipActivation : Rule<NewMembership>
    {
        protected override void Apply(NewMembership item)
        {
            item.IsActive = true;
            item.NotifyUser();
        }

        protected override bool PreValidation(NewMembership item)
        {
            return item.ItemStatus == Status.Accepted || item.ItemStatus == Status.Processing;
        }
    }

}
