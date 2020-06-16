using System;

namespace OrderProcessing
{
    public class NewMembership : OrderItem, IMembership
    {
        public bool IsActive {

            get; set;
        }
        public User Owner {get; set;}
        public DateTime ExpiryDate {get; set;}
        INotification<NewMembership> _notification {get; set;}

        public NewMembership()
        {
            _notification = new NewMemberNotification();
        }

        public NewMembership(INotification<NewMembership> notification = null)
        {
            _notification = notification?? new NewMemberNotification();
        }

        public override void ProcessOrderItem(IRulesManager rulesManager)
        {
            // null-check

            rulesManager.Process(this);
        }

        public void NotifyUser()
        {
            _notification.SendNotification(this);
        }

    }
}
