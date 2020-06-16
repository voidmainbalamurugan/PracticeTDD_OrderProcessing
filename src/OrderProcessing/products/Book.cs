namespace OrderProcessing
{
    public class Book : Product
    {
        public string Publisher {get; set;}
        public string Author {get; set;}
        
        public override void ProcessOrderItem(IRulesManager rulesManager)
        {
            // null-check

            rulesManager.Process(this);
        }

    }
}
