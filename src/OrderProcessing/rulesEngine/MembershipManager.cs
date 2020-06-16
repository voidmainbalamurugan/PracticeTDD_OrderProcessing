using System;

namespace OrderProcessing
{
    public class MembershipManager : IMembershipManager
    {
        public IMembership Membership => _membership;
        IMembership _membership {get; set;}
        public void SetMemership(IMembership membership)
        {
            if(membership == default(IMembership))
                throw new ArgumentNullException(nameof(membership));

            this._membership = membership;
        }
    }
}
