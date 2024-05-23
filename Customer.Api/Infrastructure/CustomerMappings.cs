using Customer.Api.Domain;

namespace Customer.Api.Infrastructure;

public static class CustomerMappings
{
    public static CustomerDetail ToDomain(this DbCustomer dbCustomer)
    {
        return new CustomerDetail
        {
            Id = dbCustomer.Id,
            FirstName = dbCustomer.FirstName,
            LastName = dbCustomer.LastName,
            Email = dbCustomer.Email
        };
    }

    public static DbCustomer ToDb(this CustomerDetail customer)
    {
        return new DbCustomer
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email
        };
    }
}
