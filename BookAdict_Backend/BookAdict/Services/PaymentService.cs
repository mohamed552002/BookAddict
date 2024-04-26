using DataRepository.Core.Dtos.CartDtos;
using DataRepository.Core.Models;
using Stripe;
using Stripe.Checkout;

namespace BookAdict.Services
{
    public class PaymentService
    {
        IConfiguration configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        public string CheckOut(CheckOutRequestDto checkOutRequest)
        {
            
            var options = CreateStripeOptions(checkOutRequest.ApplicationUser);
            foreach(OrderItem item in checkOutRequest.OrderItems)
            {
                var sessionListItem = HandlingSessionListItem(item);
                options.LineItems.Add(sessionListItem);
            }
            var service = new SessionService();
            Session session = service.Create(options);
            return session.Url;
        }
        private SessionCreateOptions CreateStripeOptions(ApplicationUser user )
        {
            return new SessionCreateOptions
            {
                SuccessUrl = configuration.GetSection("BaseURL").Get<string>() + "/api/Order/AddOrder",
                CancelUrl = configuration.GetSection("BaseURL").Get<string>(),
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                CustomerEmail = user.Email
            };
        }

        private SessionLineItemOptions HandlingSessionListItem( OrderItem item )
        {
            return new SessionLineItemOptions
            {

                PriceData = new SessionLineItemPriceDataOptions
                {

                    UnitAmount = (long)(item.Book.Price * 100),
                    Currency = "USD",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name =  item.Book.Title,
                    }
                },
                Quantity = item.Qyantity,
            };
        }
    }
}
