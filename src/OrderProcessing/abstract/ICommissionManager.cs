using System;

namespace OrderProcessing
{
    public interface ICommissionManager : IDisposable
    {
        float GetCommission(OrderItem orderItem);
    }

}
