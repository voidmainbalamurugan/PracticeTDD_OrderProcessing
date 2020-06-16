using System;

namespace OrderProcessing
{
    public class FreeVideoRule : Rule<VideoContent>
    {
        const long _defaultId = 100;
        const string _name = "Free-Video-Content";
        const string itemType = "FreeVideoContent";
        
        protected override void Apply(VideoContent item)
        {
            item.CurrentOrder.AddOrderItem(
                new FreeVideoContent()
                {
                    Id = _defaultId,
                    CreatedOn = DateTime.Now,
                    CurrentOrder = item.CurrentOrder,
                    ItemName = _name,
                }
            );
        }

        protected override bool PreValidation(VideoContent item)
        {
            var exists = false ;
            foreach(var p in item.CurrentOrder?.Items)
            {
                if(p is FreeVideoContent)
                {
                    exists = true;
                    break;
                }
            }
                
            return (item.ItemStatus == Status.Accepted || item.ItemStatus == Status.Processing)
            && !exists && item.IsELearning; 
        }
    }
}
