using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderProcessing
{
    public class DuplicatePackingSlip : Rule<Book>
    {
        CreatePackingSlip _packingslip {get; set;}
        public DuplicatePackingSlip()
        {
            _packingslip = new CreatePackingSlip();
        }
        protected override void Apply(Book item)
        {
            
            if(item == default(Book))
                throw new ArgumentNullException(nameof(item));

            if (item.PackingSlips == default(List<Packingslip>))
                item.PackingSlips = new List<Packingslip>();
            
            var slip = _packingslip.GetPackingslip(item);
            slip.IsOriginal = false;
            
            item.PackingSlips.Add(_packingslip.GetPackingslip(item));
            item.PackingSlips.Add(slip);

        }

        protected override bool PreValidation(Book item)
        {
            return item.ItemStatus == Status.Accepted || item.ItemStatus == Status.Processing;
        }

        public override void Dispose()
        {
            _packingslip?.Dispose();
            _packingslip = null;
        }
    }

}
