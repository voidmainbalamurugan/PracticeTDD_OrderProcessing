using System;
using System.Collections.Generic;

namespace OrderProcessing
{
    public class StaticRulesRepo : IRulesRepo
    {
        public IEnumerable<Rule<Titem>> GetRules<Titem>() where Titem : OrderItem, new()
        {
            

            throw new NotImplementedException();
        }

    }
}
