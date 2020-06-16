using System;
using System.Collections.Generic;

namespace OrderProcessing
{
    public class Product : OrderItem
    {
        public Referrer Agent {get; set;}
        public List<Packingslip> PackingSlips {get; set;}

        public override void ProcessOrderItem(IRulesManager rulesManager)
        {
            if(rulesManager == default(IRulesManager))
                throw new ArgumentNullException(nameof(rulesManager));

            rulesManager.Process(this);
        }
    }
}
