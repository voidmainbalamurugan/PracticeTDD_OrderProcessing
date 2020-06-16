using System;

namespace OrderProcessing
{
    public class MembershipManager : IMembershipManager
    {
        public IMembership Membership { get => throw new NotImplementedException(); }

        public void SetMemership(IMembership membership)
        {
            throw new NotImplementedException();
        }
    }
}
