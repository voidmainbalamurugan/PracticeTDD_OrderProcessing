namespace OrderProcessing
{
    public class VideoContent : OrderItem
    {
        public bool IsELearning {get; set;}
        
        public override void ProcessOrderItem(IRulesManager rulesManager)
        {
            // null-check

            rulesManager.Process(this);
        }

    }
}
