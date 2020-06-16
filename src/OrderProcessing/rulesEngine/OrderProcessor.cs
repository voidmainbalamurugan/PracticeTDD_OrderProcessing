using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OrderProcessing
{

    public class OrderProcessor : IOrderProcessor
    {
        IRulesManager _rulesManager { get; set; }
        public OrderProcessor(IRulesManager rulesManager = null)
        {
            _rulesManager = rulesManager ?? new RulesManager();
        }

        public ProcessingResults ProcessOrder(Order order)
        {
            if (order == default(Order))
                throw new ArgumentNullException(nameof(order));

            List<Exception> errors = new List<Exception>();
                        
            if (order.Items.Any())
            {
                var items = order.Items.ToList();
                foreach (var item in items)
                {
                    try
                    {
                        item.ProcessOrderItem(_rulesManager);
                    }
                    catch(Exception ex)
                    {
                        errors.Add(ex);
                    }
                    finally
                    {
                        item.ItemStatus = Status.Processing;
                    }
                }
            }

            order.OrderStatus = Status.Processing;

            return new ProcessingResults() { 
                IsAllSuccessful = !errors.Any(),
                Errors = errors
            };
        }
    }
}
