using System;
using System.Collections.Generic;

namespace OrderProcessing
{
    public class StaticRulesRepo : IRulesRepo
    {
        public IEnumerable<Rule<Titem>> GetRules<Titem>() where Titem : OrderItem, new()
        {
            

            return new List<Rule<Titem>>();
        }

    }
}
