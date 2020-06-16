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

        [Fact]
        public void Apply_should_apply_rules_for_book()
        {
            //arrange
            var manager = new RulesManager();
            var book = Helpers.GetBook();

            //act
            manager.Process(book);

            //assert
            Assert.NotNull(book);
            Assert.NotEmpty(book.PackingSlips);
            Assert.True(book.PackingSlips.First().IsOriginal);
            Assert.NotNull(book.PackingSlips.First().Id);
            Assert.True(!book.PackingSlips.Last().IsOriginal);
            Assert.NotNull(book.PackingSlips.Last().Id);

            Assert.True(book.Agent?.CommissionEarned == (float)(book.ItemPrice * 0.05));
        }

        [Fact]
        public void Apply_should_not_apply_rules_for_completed_book()
        {
            //arrange
            var manager = new RulesManager();
            var book = Helpers.GetBook();
            book.ItemStatus = Status.Completed;

            //act
            manager.Process(book);

            //assert
            Assert.NotNull(book);
            Assert.True(book.PackingSlips == default(List<Packingslip>));
            Assert.True(book.Agent?.CommissionEarned == 0);
        }


    }
}
