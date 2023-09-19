using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;


namespace BookShop.Application.Cart
{
    [Service]
    public class AddCustomerInformation
    {
        private ISessionManager _sessionManager;

        public AddCustomerInformation(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public class Request
        {
            public string FirstName { get; set; }//Поля для валидации
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Adress1 { get; set; }
            public string Adress2 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }
        }

        public void Do(Request request)
        {
            _sessionManager.AddCustomerInformation(
                new CustomerInformation
                {
                    //FIO = request.FirstName,
                    //LastName = request.LastName,
                    //Email = request.Email,
                    //PhoneNumber = request.PhoneNumber,
                    //Adress1 = request.Adress1,
                    //Adress2 = request.Adress2,
                    //City = request.City,
                    //PostCode = request.PostCode
                });
        }
    }
}
