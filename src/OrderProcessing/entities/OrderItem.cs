using System;

namespace OrderProcessing
{
    public abstract class OrderItem
    {
        public string ItemType {get; set;}
        public long Id {get; set;}
        public string ItemName {get; set;}

        public int Quantity {get; set;}
        public float UnitPrice {get; set;}
        public float ItemPrice {get; set;}
        public Status ItemStatus {get; set;}
        public DateTime CreatedOn {get; set;}
        public DateTime UpdatedOn {get; set;}
        public Order CurrentOrder {get; set;}
        public abstract void ProcessOrderItem(IRulesManager rulesManager);
    }
}
