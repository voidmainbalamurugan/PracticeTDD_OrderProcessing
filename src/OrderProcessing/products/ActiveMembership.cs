using System;

namespace OrderProcessing
{
    public class ActiveMembership : OrderItem, IMembership
    {
        public const int _days = 28;
        public bool IsActive {get; set;}
        public User Owner {get; set;}
        public DateTime ExpiryDate {get; set;}
        INotification<ActiveMembership> _notification {get; set;}
        public ActiveMembership(){

            _notification = new ActiveMemberNotification();
        }
        public ActiveMembership(INotification<ActiveMembership> notification = null)
        {
            this.IsActive = true;
            this.UpdatedOn = DateTime.Now;
            _notification = notification?? new ActiveMemberNotification();
        }

        public override void ProcessOrderItem(IRulesManager rulesManager)
        {
            if(rulesManager == default(IRulesManager))
                throw new ArgumentNullException(nameof(rulesManager));

            rulesManager.Process(this);
        }

        public void NotifyUser()
        {
            _notification.SendNotification(this);
        }

    }
}
