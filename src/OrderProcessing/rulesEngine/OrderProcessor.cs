using System;
using System.Linq;
using System.Linq.Expressions;

namespace OrderProcessing
{

    public class OrderProcessor : IOrderProcessor
    {
        IRulesManager _rulesManager {get; set;}
        public OrderProcessor(IRulesManager rulesManager = null)
        {
            _rulesManager = rulesManager?? new RulesManager();
        }
        public void ProcessOrder(Order order)
        {
            if(order == default(Order))
                throw new ArgumentNullException(nameof(order));

            var items = order.Items.ToList();
            foreach(var item in items)
                item.ProcessOrderItem(_rulesManager);
            
        }
    }
}
