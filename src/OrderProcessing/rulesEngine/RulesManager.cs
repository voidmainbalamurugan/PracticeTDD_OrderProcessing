using System;

namespace OrderProcessing
{
    public class RulesManager : IRulesManager
    {
        public IRulesRepo RulesRepo => _rulesRepo;
        IRulesRepo _rulesRepo {get; set;}

        public RulesManager(IRulesRepo repo = null)
        {
            _rulesRepo = repo?? new StaticRulesRepo();
        }

        public RulesManager()
        {
            _rulesRepo = new StaticRulesRepo();
        }

        public void Process(Product product)
        {
            if(product == default(Product))
                throw new ArgumentNullException(nameof(product));

            // get rules for Product 
            var rules = _rulesRepo.GetRules<Product>();

            // apply them
            foreach(var rule in rules)
                rule.Complete(product);
            
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
