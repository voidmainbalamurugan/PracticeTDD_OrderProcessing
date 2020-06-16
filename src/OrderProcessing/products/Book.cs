using System;

namespace OrderProcessing
{
    public class Book : Product
    {
        public string Publisher {get; set;}
        public string Author {get; set;}
        
        public override void ProcessOrderItem(IRulesManager rulesManager)
        {
            if(rulesManager == default(IRulesManager))
                throw new ArgumentNullException(nameof(rulesManager));

            rulesManager.Process(this);
        }

    }
}
