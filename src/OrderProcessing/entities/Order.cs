using System;
using System.Collections.Generic;

namespace OrderProcessing
{
    // entites
    public class Order
    {
        public long Id {get; set;}
        public float Total {get; set;}

        public Status OrderStatus {get; set;}
        public DateTime CreatedOn {get; set;}
        public DateTime UpdatedOn {get; set;}

        public Referrer Agent {get; set;}
        public User Customer {get; set;}

        public IList<OrderItem> Items {get; set;}

    }
}
