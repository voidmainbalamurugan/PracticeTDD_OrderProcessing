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
            // null-check

            rulesManager.Process(this);
        }

    }
}
