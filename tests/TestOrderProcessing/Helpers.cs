using System;
using Xunit;
using OrderProcessing;
using System.Linq;
using AutoMapper;
using Moq;
using System.Linq.Expressions;

namespace TestOrderProcessing
{
    public class Helpers
    {
        static Mapper _mapper {get; set;}
        static MapperConfiguration config {get; set;}
        static Mapper mapper {

            get{

                if(_mapper == default(Mapper))
                    {
                        if(config == default(MapperConfiguration))
                        {
                            config = new MapperConfiguration(
                                cfg => {
                                    cfg.CreateMap<OrderItem, Product>();
                                    cfg.CreateMap<OrderItem, Book>();
                                    cfg.CreateMap<OrderItem, NewMembership>();
                                    cfg.CreateMap<OrderItem, VideoContent>();
                                });

                        }

                        _mapper = new Mapper(config);
                    }
                return _mapper;
            }
        }

        static OrderItem GetItem(string name)
        {
            var id = new Random().Next(int.MaxValue -5);
            
            return new Product(){
                Id = id,
                CreatedOn = DateTime.Now,
                ItemName = $"{name}-{id}",
                ItemPrice = id+1,
                ItemStatus = Status.Accepted,
                ItemType = name,
                Quantity = 1,
                UnitPrice = id +1
            };
        }

        public static Order GetOrder()
        {
            return new Order()
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

        }

        public static Product GetProduct()
        {
            var id = new Random().Next(int.MaxValue -5);
            var order = GetOrder();
            var item = mapper.Map<Product>(GetItem("Product"));
            item.Agent = order.Agent;
            item.CurrentOrder = order;
            
            order.AddOrderItem(item);

            return item;
        }


        public static Book GetBook()
        {
            var id = new Random().Next(int.MaxValue -5);
            var order = GetOrder();
            var item = mapper.Map<Book>(GetItem("Book"));
            item.Agent = order.Agent;
            item.CurrentOrder = order;
            item.Publisher = "publisher-1";
            item.Author = "author-1";

            order.AddOrderItem(item);

            return item;
        }

        public static VideoContent GetVideContent()
        {
            var id = new Random().Next(int.MaxValue -5);
            var order = GetOrder();
            var item = mapper.Map<VideoContent>(GetItem("VideoContent"));
            item.CurrentOrder = order;
            item.IsELearning = true;
            
            order.AddOrderItem(item);

            return item;
        }

        public static NewMembership GetNewMembership(INotification<NewMembership> notify)
        {
            var id = new Random().Next(int.MaxValue -5);
            var order = GetOrder();
            var mid = new Random().Next(int.MaxValue -5);
            var name = "NewMembership";
            var membership = new NewMembership(notify){
                Id = mid,
                CreatedOn = DateTime.Now,
                ItemName = $"{name}-{mid}",
                ItemPrice = id+1,
                ItemStatus = Status.Accepted,
                ItemType = name,
                Quantity = 1,
                UnitPrice = id +1,
                Owner = order.Customer,
                IsActive = true
            };
            
            order.AddOrderItem(membership);

            return membership;
        }

        public static ActiveMembership GetActiveMembership(INotification<ActiveMembership> notify)
        {
            var id = new Random().Next(int.MaxValue -5);
            var order = GetOrder();
            var mid = new Random().Next(int.MaxValue -5);
            var name = "ActiveMembership";
            var membership = new ActiveMembership(notify){
                Id = mid,
                CreatedOn = DateTime.Now,
                ItemName = $"{name}-{mid}",
                ItemPrice = id+1,
                ItemStatus = Status.Accepted,
                ItemType = name,
                Quantity = 1,
                UnitPrice = id +1,
                Owner = order.Customer,
                IsActive = true
            };
            
            order.AddOrderItem(membership);

            return membership;
        }

    }
}
