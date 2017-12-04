using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Viewings.Builders;
using OrangeBricks.Web.Models;


namespace OrangeBricks.Web.Tests.Controllers.Viewings.Builders
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
    public class MyViewingsViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuildShouldReturnVIewingsForMatchingBuyerId()
        {
            // Arrange
            var builder = new MyViewingsViewModelBuilder(_context);

            var offers = new List<Models.Viewing>{
            new Models.Viewing{ BuyerId = "1", ViewingAt = DateTime.Now, Property = new Models.Property { StreetName = "Smith Street", Description = "", IsListedForSale = true } },
            new Models.Viewing{ BuyerId = "1", ViewingAt = DateTime.Now, Property = new Models.Property { StreetName = "Jones Street", Description = "", IsListedForSale = true} }
        };

            var mockSet = Substitute.For<IDbSet<Models.Viewing>>()
                .Initialize(offers.AsQueryable());

            _context.Viewings.Returns(mockSet);

            var buyerId = "1";

            // Act
            var viewModel = builder.Build(buyerId);

            // Assert
            Assert.That(viewModel.Viewings.Count, Is.EqualTo(2));
        }
    }
}