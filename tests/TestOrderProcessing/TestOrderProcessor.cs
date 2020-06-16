using System;
using Xunit;
using OrderProcessing;
using System.Linq;
using System.Collections.Generic;
using Moq;

namespace TestOrderProcessing
{
    public class TestOrderProcessor
    {

        [Fact]
        public void ProcessOrder_when_order_has_no_order_item()
        {
            //arrange
            var rmanager = new Mock<IRulesManager>();
            var processor = new OrderProcessor(rmanager.Object);

            var order = Helpers.GetOrder();

            //act
            processor.ProcessOrder(order);

            //assert
            Assert.True(order.OrderStatus == Status.Processing);
        }
        
        [Fact]
        public void ProcessOrder_with_multiple_order_items()
        {
            //arrange
            var rmanager = new Mock<IRulesManager>();
            var processor = new OrderProcessor(rmanager.Object);

            var order = Helpers.GetOrder();
            var product = Helpers.GetProduct();
            product.CurrentOrder = order;
            order.AddOrderItem(product);
            product = Helpers.GetProduct();
            product.CurrentOrder = order;
            order.AddOrderItem(product);

            //act
            processor.ProcessOrder(order);

            //assert
            Assert.True(order.OrderStatus == Status.Processing);
            Assert.True(order.Items.All(t => t.ItemStatus == Status.Processing));
            rmanager.Verify(rm => rm.Process(It.IsAny<Product>()), Times.Exactly(2));
        }

        [Fact]
        public void ProcessOrder_with_multiple_order_item_type()
        {
            //arrange
            var rmanager = new Mock<IRulesManager>();
            var processor = new OrderProcessor(rmanager.Object);

            var order = Helpers.GetOrder();
            var product = Helpers.GetProduct();
            product.CurrentOrder = order;
            order.AddOrderItem(product);
            var book = Helpers.GetBook();
            book.CurrentOrder = order;
            order.AddOrderItem(book);

            //act
            processor.ProcessOrder(order);

            //assert
            Assert.True(order.OrderStatus == Status.Processing);
            Assert.True(order.Items.All(t => t.ItemStatus == Status.Processing));
            rmanager.Verify(rm => rm.Process(product), Times.Once());
            rmanager.Verify(rm => rm.Process(book), Times.Once());
        }


        [Fact]
        public void ProcessOrder_returns_exception_while_processing()
        {
            //arrange
            var rmanager = new Mock<IRulesManager>();
            var processor = new OrderProcessor(rmanager.Object);
            rmanager.Setup(r => r.Process(It.IsAny<Product>())).Throws(
                new AggregateException("test-excptn")
            );
            

            var order = Helpers.GetOrder();
            var product = Helpers.GetProduct();
            product.CurrentOrder = order;
            order.AddOrderItem(product);
            
            //act
            var rslt = processor.ProcessOrder(order);

            //assert
            Assert.True(order.OrderStatus == Status.Processing);
            Assert.True(order.Items.All(t => t.ItemStatus == Status.Processing));
            Assert.False(rslt.IsAllSuccessful);
            Assert.True(rslt.Errors.Count == 1);
        }

        [Fact]
        public void ProcessOrder_throws_exception()
        {
            //arrange
            var rmanager = new Mock<IRulesManager>();
            var processor = new OrderProcessor(rmanager.Object);
            
            //act assert
            Assert.Throws<ArgumentNullException>(() => processor.ProcessOrder(null));
            
        }
    }
}