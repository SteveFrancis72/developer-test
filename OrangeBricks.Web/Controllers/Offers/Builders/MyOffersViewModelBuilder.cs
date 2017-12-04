using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System.Linq;


namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class MyOffersViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyOffersViewModel Build(string buyerId)
        {
            return new MyOffersViewModel
            {
                Offers = _context.Offers
                      .Where(o => o.BuyerId == buyerId)
                        .Select(o => new OfferViewModel
                        {
                            Id = o.Id,
                            Amount = o.Amount,
                            Status = o.Status.ToString(),
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