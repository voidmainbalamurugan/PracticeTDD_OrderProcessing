using System;

namespace OrderProcessing
{
    public class ActiveMembership : OrderItem, IMembership
    {
        const int _days = 28;
        public bool IsActive {get; set;}
        public User Owner {get; set;}
        public DateTime ExpiryDate {get; set;}
        INotification<ActiveMembership> _notification {get; set;}
        public ActiveMembership(){}
        public ActiveMembership(NewMembership membership)
        {
            if(membership == default(NewMembership))
                throw new ArgumentNullException(nameof(membership));

            GetValuesFrom(membership);
            this.IsActive = true;
            this.UpdatedOn = DateTime.Now;
        }

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

        public void NotifyUser()
        {
            _notification.SendNotification(this);
        }

        void GetValuesFrom(NewMembership membership)
        {
            this.CreatedOn = membership.CreatedOn;
            this.CurrentOrder = membership.CurrentOrder;
            this.ExpiryDate = DateTime.Now.AddDays(_days);
            this.Id = membership.Id;
            this.ItemName = membership.ItemName;
            this.ItemPrice = membership.ItemPrice;
            this.ItemStatus = membership.ItemStatus;
            this.ItemType = membership.ItemType;
            this.Owner = membership.Owner;
            this.Quantity = this.Quantity;
            this.UnitPrice = this.UnitPrice;
        }

    }

    public class ActiveMemberNotification : INotification<ActiveMembership>
    {
        public void SendNotification(ActiveMembership item)
        {
            
        }
    }

    public class NewMemberNotification : INotification<NewMembership>
    {
        public void SendNotification(NewMembership item)
        {
            
        }
    }

    public interface INotification<Titem>
        where Titem : OrderItem, new()
    {
        void SendNotification(Titem item);
    }
}
