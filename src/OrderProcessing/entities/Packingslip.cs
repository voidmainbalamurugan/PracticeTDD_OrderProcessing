using System;

namespace OrderProcessing
{
    public class Packingslip
    {
        public string Id {get; set;}
        public bool IsActive {get; set;}
        public bool IsOriginal {get; set;}
        public string From {get; set;}
        public string To {get; set;}

        public string ItemDetails {get; set;}

        public DateTime CreatedOn {get; set;}

    }
}
