using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OrderProcessing
{
    public partial class StaticRulesRepo : IRulesRepo
    {
        public IEnumerable<Rule<Titem>> GetRules<Titem>() where Titem : OrderItem, new()
        {
            var ruletypes = typeof(StaticRulesRepo).Assembly
                .GetTypes()
                .Where(t => t.BaseType?.FullName == typeof(Rule<Titem>).FullName);
            
            var rules = new List<Rule<Titem>>();
            foreach(var t in ruletypes)
            {
                rules.Add(Activator.CreateInstance(t) as Rule<Titem>);
            }

            return rules;
        }

    }
}
