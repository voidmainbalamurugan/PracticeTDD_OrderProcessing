using System;
using Xunit;
using OrderProcessing;
using System.Linq;

namespace TestOrderProcessing
{
    public class TestRulesManager
    {

        static Product GetProduct()
        {
            var id = new Random().Next(int.MaxValue -5);
            var order = new Order()
            {
                Id = new Random().Next(int.MaxValue -5),
                CreatedOn = DateTime.Now,
                Customer = new User()
                {
                    Name = "customer",
                    Email = "customer-id@domain.com",
                    Address = "Address1, Address2, city, state, country, postalcode"
                },
                OrderStatus = Status.Accepted,
                Agent = new Referrer()
                {
                    Name = "user-name",
                    Email = "email-id@domain.com",
                    Address = "Address1, Address2, city, state, country, postalcode"
                }
            };

            var item = new Product(){
                Id = id,
                CurrentOrder = order,
                CreatedOn = DateTime.Now,
                ItemName = $"Product{id}",
                ItemPrice = id+1,
                ItemStatus = Status.Accepted,
                ItemType = "Product",
                Quantity = 1,
                UnitPrice = id +1,
                Agent = new Referrer()
                {
                    Name = "user-name",
                    Email = "email-id@domain.com",
                    Address = "Address1, Address2, city, state, country, postalcode"
                }
            };
            order.AddOrderItem(item);

            return item;
        }

        [Fact]
        public void Apply_should_apply_rules_for_product()
        {
            //arrange
            var manager = new RulesManager();
            var product = GetProduct();

            //act
            manager.Process(product);

            //assert
            Assert.NotNull(product);
            Assert.NotEmpty(product.PackingSlips);
            Assert.True(product.PackingSlips.Last().IsOriginal);
            Assert.NotNull(product.PackingSlips.Last().Id);
        }

    }
}
