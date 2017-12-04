using OrangeBricks.Web.Controllers.Viewings.ViewModels;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System.Linq;

namespace OrangeBricks.Web.Controllers.Viewings.Builders
{
    public class MyViewingsViewModelBuilder
    {
        private IOrangeBricksContext _context;

        public MyViewingsViewModelBuilder(IOrangeBricksContext _context)
        {
            this._context = _context;
        }
        public MyViewingsViewModel Build(string buyerId)
        {
            return new MyViewingsViewModel
            {
                Viewings = _context.Viewings
                      .Where(o => o.BuyerId == buyerId)
                        .Select(o => new ViewingsViewModel
                        {
                            Id = o.Id,
                            ViewingAt = o.ViewingAt,
                            CreatedAt = o.CreatedAt,
                            Property = new PropertyViewModel
                            {
                                Description = o.Property.Description,
                                IsListedForSale = o.Property.IsListedForSale,
                                Id = o.Property.Id,
                                NumberOfBedrooms = o.Property.NumberOfBedrooms,
                                PropertyType = o.Property.PropertyType,
                                StreetName = o.Property.StreetName
                            }
                        }).ToList()

            };
        }
    }
}