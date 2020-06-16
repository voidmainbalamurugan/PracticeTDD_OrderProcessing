using System;

namespace OrderProcessing
{
    public class GenerateCommission : Rule<Product>
    {
        ICommissionManager _commissionManager {get; set;}

        public GenerateCommission(){
            _commissionManager = new CommissionManager();
        }
        public GenerateCommission(ICommissionManager commissionCalc = null)
        {
            _commissionManager = commissionCalc?? new CommissionManager();
        }
        protected override void Apply(Product item)
        {
            if(item == default(Product))
                throw new ArgumentNullException(nameof(item));

            item.Agent.AddComission(_commissionManager.GetCommission(item));
        }

        protected override bool PreValidation(Product item)
        {
            return item.ItemStatus == Status.Accepted;
        }

        public override void Dispose()
        {
            _commissionManager?.Dispose();
            _commissionManager = null;
        }
    }
}
