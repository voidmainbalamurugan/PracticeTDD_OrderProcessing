using System.Collections.Generic;

namespace OrderProcessing
{
    public interface IRulesRepo
    {
        IEnumerable<Rule<Titem>> GetRules<Titem>()
               where Titem : OrderItem, new() ;
    
    }
}
