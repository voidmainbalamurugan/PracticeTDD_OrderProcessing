using System;
using Xunit;
using OrderProcessing;
using System.Linq;
using System.Collections.Generic;
using Moq;

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

        [Fact]
        public void Apply_should_apply_rules_for_new_membership()
        {
            //arrange
            var manager = new RulesManager();
            var notify = new Mock<INotification<NewMembership>>();
            var membership = Helpers.GetNewMembership(notify.Object);

            //act
            manager.Process(membership);

            //assert
            notify.Verify(n => n.SendNotification(membership), Times.Once());
        }

        [Fact]
        public void Apply_should_not_apply_rules_for_new_completed_membership()
        {
            //arrange
            var manager = new RulesManager();
            var notify = new Mock<INotification<NewMembership>>();
            var membership = Helpers.GetNewMembership(notify.Object);
            membership.ItemStatus = Status.Completed;

            //act
            manager.Process(membership);

            //assert
            notify.Verify(n => n.SendNotification(membership), Times.Never());
        }

        [Fact]
        public void Apply_should_apply_rules_for_active_membership()
        {
            //arrange
            var manager = new RulesManager();
            var notify = new Mock<INotification<ActiveMembership>>();
            var membership = Helpers.GetActiveMembership(notify.Object);

            //act
            manager.Process(membership);

            //assert
            notify.Verify(n => n.SendNotification(membership), Times.Once());
            Assert.True(DateTime.Now.AddDays(ActiveMembership._days).Date == membership.ExpiryDate.Date);
        }

        [Fact]
        public void Apply_should_not_apply_rules_for_active_completed_membership()
        {
            //arrange
            var notification = new Mock<INotification<ActiveMembership>>();
            var manager = new RulesManager();
            var membership = Helpers.GetActiveMembership(notification.Object);
            membership.ItemStatus = Status.Completed;

            //act
            manager.Process(membership);

            //assert
            notification.Verify(n => n.SendNotification(membership), Times.Never());
        }


        [Fact]
        public void Apply_should_apply_rules_for_videocontent()
        {
            //arrange
            var manager = new RulesManager();
            var video = Helpers.GetVideContent();
            //book.ItemStatus = Status.Completed;

            //act
            manager.Process(video);

            //assert
            Assert.NotNull(video);
            Assert.Contains(video.CurrentOrder.Items, o => o is FreeVideoContent);
        }

        [Fact]
        public void Apply_should_not_apply_rules_for_videocontent()
        {
            //arrange
            var manager = new RulesManager();
            var video = Helpers.GetVideContent();
            video.IsELearning = false;

            //act
            manager.Process(video);

            //assert
            Assert.NotNull(video);
            Assert.DoesNotContain(video.CurrentOrder.Items, o => o is FreeVideoContent);
        }

    }
}
