using System;

namespace OrderProcessing
{
    public class RulesManager : IRulesManager
    {
        public IRulesRepo RulesRepo => throw new NotImplementedException();

        public void Process(Product product)
        {
            throw new NotImplementedException();
        }

        public void Process(NewMembership membership)
        {
            throw new NotImplementedException();
        }

        public void Process(ActiveMembership membership)
        {
            throw new NotImplementedException();
        }

        public void Process(Book book)
        {
            throw new NotImplementedException();
        }

        public void Process(VideoContent video)
        {
            throw new NotImplementedException();
        }

        public void Process(FreeVideoContent video)
        {
            throw new NotImplementedException();
        }
    }
}
