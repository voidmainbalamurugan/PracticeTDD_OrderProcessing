using System;
using System.Collections.Generic;

namespace OrderProcessing
{
    public interface IOrderProcessor
    {
        ProcessingResults ProcessOrder(Order order);

    }

    public class ProcessingResults
    {
        public bool IsAllSuccessful {get; set;}
        public List<Exception> Errors {get; set;}
    }
}
