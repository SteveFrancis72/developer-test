using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Offers.Builders
{
    public static class ExtentionMethods
    {
        public static IDbSet<T> Initialize<T>(this IDbSet<T> dbSet, IQueryable<T> data) where T : class
        {
            dbSet.Provider.Returns(data.Provider);
            dbSet.Expression.Returns(data.Expression);
            dbSet.ElementType.Returns(data.ElementType);
            dbSet.GetEnumerator().Returns(data.GetEnumerator());
            return dbSet;
        }
    }

    [TestFixture]
    public class MyOffersViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuildShouldReturnOffersForMatchingBuyerId()
        {
            // Arrange
            var builder = new MyOffersViewModelBuilder(_context);

            var offers = new List<Models.Offer>{
                new Models.Offer{ BuyerId="1", Status = OfferStatus.Accepted, Amount = 350000, Property = new Models.Property { StreetName = "Smith Street", Description = "", IsListedForSale = true } },
                new Models.Offer{ BuyerId="1", Status = OfferStatus.Accepted, Amount = 375000, Property = new Models.Property { StreetName = "Jones Street", Description = "", IsListedForSale = true} }
            };

            var mockSet = Substitute.For<IDbSet<Models.Offer>>()
                .Initialize(offers.AsQueryable());

            _context.Offers.Returns(mockSet);

            var buyerId = "1";

            // Act
            var viewModel = builder.Build(buyerId);

            // Assert
            Assert.That(viewModel.Offers.Count, Is.EqualTo(2));
        }
    }
}
