namespace OrderProcessing
{
    public interface IMembershipManager
    {
        IMembership Membership {get;}
        void SetMemership(IMembership membership);
    }
}
