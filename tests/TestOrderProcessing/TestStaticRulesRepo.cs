using System;
using Xunit;
using OrderProcessing;
using System.Linq;

namespace TestOrderProcessing
{
    public class TestStaticRulesRepo
    {
        class NewProduct : OrderItem
        {
            public override void ProcessOrderItem(IRulesManager rulesManager)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void GetRules_should_return_empty_when_norules_available()
        {
            //arrange
            IRulesRepo repo= new StaticRulesRepo();
        

            //act
            var rules = repo.GetRules<NewProduct>();

            //assert
            Assert.NotNull(rules);
            Assert.Empty(rules);
        }

        [Fact]
        public void GetRules_should_return_product_rules()
        {
            //arrange
            IRulesRepo repo= new StaticRulesRepo();

            //act
            var rules = repo.GetRules<Product>();
            
            //assert
            Assert.NotNull(rules);
            Assert.NotEmpty(rules);
            Assert.True(rules.Count() > 0);
            
        }

        [Fact]
        public void GetRules_should_return_product_rule_packingslips()
        {
            //arrange
            IRulesRepo repo= new StaticRulesRepo();

            //act
            var rules = repo.GetRules<Product>();

            //assert
            Assert.NotNull(rules);
            Assert.NotEmpty(rules);
            Assert.Contains(rules, t => t is CreatePackingSlip);
        }

        [Fact]
        public void GetRules_should_return_product_rule_generate_commission()
        {
            //arrange
            IRulesRepo repo= new StaticRulesRepo();

            //act
            var rules = repo.GetRules<Product>();

            //assert
            Assert.NotNull(rules);
            Assert.NotEmpty(rules);
            Assert.Contains(rules, t => t is GenerateCommission);
        }
    }
}
