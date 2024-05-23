namespace Customer.Api.Domain;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerDetail>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<CustomerDetail?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(CustomerDetail customer)
    {
        await _repository.AddAsync(customer);
    }

    public async Task UpdateAsync(CustomerDetail customer)
    {
        await _repository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
