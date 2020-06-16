namespace OrderProcessing
{
    public class ActiveMemberNotification : INotification<ActiveMembership>
    {
        public void SendNotification(ActiveMembership item)
        {
            // notification will be sent
        }
    }
}
