using System;

namespace OrderProcessing
{
    public interface IMembership
    {
        bool IsActive {get; set;}
        User Owner {get; set;}

        DateTime ExpiryDate {get; set;}

        void Assign(IMembershipManager manager);
    }
}
