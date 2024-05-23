namespace Customer.Api.Domain;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerDetail>> GetAllAsync();
    Task<CustomerDetail?> GetByIdAsync(int id);
    Task AddAsync(CustomerDetail customer);
    Task UpdateAsync(CustomerDetail customer);
    Task DeleteAsync(int id);
}
