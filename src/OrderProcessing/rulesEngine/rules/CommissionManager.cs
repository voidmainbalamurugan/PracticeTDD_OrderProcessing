using System;

namespace OrderProcessing
{
    public class CommissionManager : ICommissionManager
    {
        const double _percentage = 0.05;
        public float GetCommission(OrderItem orderItem)
        {
            if(orderItem == default(OrderItem))
                throw new ArgumentNullException(nameof(orderItem));

            return (float)(orderItem.ItemPrice * _percentage);
        }

        public void Dispose() {}
        
    }

}
