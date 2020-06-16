using System;

namespace OrderProcessing
{
    public class VideoContent : OrderItem
    {
        public bool IsELearning {get; set;}
        
        public override void ProcessOrderItem(IRulesManager rulesManager)
        {
            if(rulesManager == default(IRulesManager))
                throw new ArgumentNullException(nameof(rulesManager));

            rulesManager.Process(this);
        }

    }
}
