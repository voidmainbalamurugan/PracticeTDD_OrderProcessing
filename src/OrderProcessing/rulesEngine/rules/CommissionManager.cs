using System;

namespace OrderProcessing
{
    public class CommissionManager : ICommissionManager
    {
        public float GetCommission(OrderItem orderItem)
        {
            if(orderItem == default(Product))
                throw new ArgumentNullException(nameof(orderItem));

            return (float)(orderItem.ItemPrice * 0.05);
        }

        public void Dispose()
        {

        }
    }

}
