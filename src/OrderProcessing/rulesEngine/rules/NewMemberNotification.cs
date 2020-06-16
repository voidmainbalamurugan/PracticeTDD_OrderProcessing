namespace OrderProcessing
{
    public class NewMemberNotification : INotification<NewMembership>
    {
        public void SendNotification(NewMembership item)
        {
            // notification will be sent
        }
    }
}
