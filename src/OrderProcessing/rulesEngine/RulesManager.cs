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
            if(membership == default(NewMembership))
                throw new ArgumentNullException(nameof(membership));

            // get rules for Product 
            var rules = _rulesRepo.GetRules<NewMembership>();

            // apply them
            foreach(var rule in rules)
                rule.Complete(membership);
            
        }

        public void Process(ActiveMembership membership)
        {
            if(membership == default(ActiveMembership))
                throw new ArgumentNullException(nameof(membership));

            // get rules for Product 
            var rules = _rulesRepo.GetRules<ActiveMembership>();

            // apply them
            foreach(var rule in rules)
                rule.Complete(membership);
        }

        public void Process(Book book)
        {
            if(book == default(Book))
                throw new ArgumentNullException(nameof(book));

            // get rules for Product 
            var rules = _rulesRepo.GetRules<Book>();

            // apply them
            foreach(var rule in rules)
                rule.Complete(book);
            
        }

        public void Process(VideoContent video)
        {
            if(video == default(VideoContent))
                throw new ArgumentNullException(nameof(video));

            // get rules for Product 
            var rules = _rulesRepo.GetRules<VideoContent>();

            // apply them
            foreach(var rule in rules)
                rule.Complete(video);
            
        }

        public void Process(FreeVideoContent video)
        {
            // no rules available
        }
    }
}
