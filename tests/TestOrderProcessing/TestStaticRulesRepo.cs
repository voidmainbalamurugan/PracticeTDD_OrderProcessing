using System;
using Xunit;
using OrderProcessing;

namespace TestOrderProcessing
{
    public class TestStaticRulesRepo
    {
        [Fact]
        public void GetRules_for_Product()
        {
            //arrange
            IRulesRepo repo= new StaticRulesRepo();

            //act
            //assert
            var rules = repo.GetRules<Product>();
        }
    }
}
