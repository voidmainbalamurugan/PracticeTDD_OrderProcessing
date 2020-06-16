using System;
using Xunit;
using OrderProcessing;
using System.Linq;
using System.Collections.Generic;

namespace TestOrderProcessing
{
    public class TestRulesManager
    {

        [Fact]
        public void Apply_should_apply_rules_for_product()
        {
            //arrange
            var manager = new RulesManager();
            var product = Helpers.GetProduct();

            //act
            manager.Process(product);

            //assert
            Assert.NotNull(product);
            Assert.NotEmpty(product.PackingSlips);
            Assert.True(product.PackingSlips.Last().IsOriginal);
            Assert.NotNull(product.PackingSlips.Last().Id);

            Assert.True(product.Agent?.CommissionEarned == (float)(product.ItemPrice * 0.05));
        }
        
        [Fact]
        public void Apply_should_not_apply_rules_for_completed_product()
        {
            //arrange
            var manager = new RulesManager();
            var product = Helpers.GetProduct();
            product.ItemStatus = Status.Completed;

            //act
            manager.Process(product);

            //assert
            Assert.NotNull(product);
            Assert.True(product.PackingSlips == default(List<Packingslip>));
            Assert.True(product.Agent?.CommissionEarned == 0);
        }

    }
}
