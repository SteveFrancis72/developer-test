using System;
using OrangeBricks.Web.Controllers.Property.ViewModels;

namespace OrangeBricks.Web.Controllers.Viewings.ViewModels
{
    public class ViewingsViewModel
    {
        public int Id;
        public DateTime ViewingAt { get; set; }
        public DateTime CreatedAt { get; set; }
         public string BuyerId { get; set; }

        public PropertyViewModel Property { get; set; }
    }
}