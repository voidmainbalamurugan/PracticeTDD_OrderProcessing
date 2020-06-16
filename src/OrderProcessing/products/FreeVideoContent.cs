using System;

namespace OrderProcessing
{
    public class FreeVideoContent : OrderItem
    {
        public new float UnitPrice {
            get { return 0;} set{}
        }

        public new float ItemPrice {
            get { return 0;} set{}
        }

        public new float Quantity {
            get { return 1;} set{}
        }
        
        public override void ProcessOrderItem(IRulesManager rulesManager)
        {
            if(rulesManager == default(IRulesManager))
                throw new ArgumentNullException(nameof(rulesManager));

            rulesManager.Process(this);
        }

    }
}
