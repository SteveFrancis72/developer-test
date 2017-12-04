using System;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public BookViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(BookViewingCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);

            var viewing = new Viewing
            {
                ViewingAt = command.ViewingAt,
                CreatedAt = DateTime.Now,
                BuyerId = command.BuyerId,
                PropertyId = command.PropertyId
            };

            _context.Viewings.Add(viewing);

            _context.SaveChanges();
        }
    }
}