using EndPoint.Result;
using EndPoint.Model;
using System.Collections.Generic;

namespace EndPoint.Services
{
    public interface ICustomerService
    {
        Result<Customer> Add(Customer customer);
    }
    public class CustomerService : ICustomerService
    {
        private readonly IMessageService _message;

        public CustomerService(IMessageService message)
        {
            _message = message;
        }
        public Result<Customer> Add(Customer customer)
        {
            // not found
            if (customer.Id == -1)
            {
                return Result<Customer>.NotFound();
            }

            // validation
            var validation = CustomerValidation(customer);
            if (!validation.IsValid)
            {
                return Result<Customer>.Invalid(validation.Errors);
            }

            try
            {
                //throw new System.Exception("Test exception");
                return Result<Customer>.Success(customer,string.Format(_message.Get(MessageKey.AddCustomerSuccess),customer.Name));
            }
            catch (System.Exception ex)
            {
                return Result<Customer>.Error(ex.Message);
            }

        }
        public (bool IsValid, List<ValidationError> Errors) CustomerValidation(Customer customer)
        {
            var errors = new List<ValidationError>();
            // validation
            if (string.IsNullOrEmpty(customer.Name))
            {
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(customer.Name),
                    ErrorMessage = $"{nameof(customer.Name)} is required."
                });
            }
            if (customer.Age <= 0)
            {

                errors.Add(new ValidationError()
                {
                    Identifier = nameof(customer.Age),
                    ErrorMessage = $"{nameof(customer.Age)} is required."
                });
            }
            if (errors.Count > 0)
            {
                return (false, errors);
            }
            return (true, null);
        }

    }
}
