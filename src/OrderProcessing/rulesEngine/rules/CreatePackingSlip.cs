using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderProcessing
{
    public class CreatePackingSlip : Rule<Product>
    {
        protected override void Apply(Product item)
        {
            
            if(item == default(Product))
                throw new ArgumentNullException(nameof(item));

            if (!item.PackingSlips.Any())
                item.PackingSlips = new List<Packingslip>();

            item.PackingSlips.Add(GetPackingslip(item));

        }

        public Packingslip GetPackingslip(Product item)
        {
            return new Packingslip()
            {
                CreatedOn = DateTime.Now,
                IsActive = true,
                From = item.Agent?.Address,
                To = item.CurrentOrder?.Customer.Address,
                Id = new Guid().ToString().Substring(0, 5),
                IsOriginal = true,
                ItemDetails = item.ItemName
            };
        }

        protected override bool PreValidation(Product item)
        {
            return item.ItemStatus == Status.Accepted;
        }

    }

    

}
