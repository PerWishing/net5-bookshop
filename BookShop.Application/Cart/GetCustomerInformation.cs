using BookShop.Domain.Infrastructure;

namespace BookShop.Application.Cart
{
    [Service]
    public class GetCustomerInformation
    {
        private ISessionManager _sessionManager;

        public GetCustomerInformation(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public class Response
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Adress1 { get; set; }
            public string Adress2 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }
        }

        public Response Do()
        {
            var customerInformation = _sessionManager.GetCustomerInformation();

            if (customerInformation == null)
                return null;

            return new Response
            {
                //FirstName = customerInformation.FIO,
                //LastName = customerInformation.LastName,
                //Email = customerInformation.Email,
                //PhoneNumber = customerInformation.PhoneNumber,
                //Adress1 = customerInformation.Adress1,
                //Adress2 = customerInformation.Adress2,
                //City = customerInformation.City,
                //PostCode = customerInformation.PostCode
            };
        }
    }
}
