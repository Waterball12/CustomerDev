using Customer.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Infrastructure;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerContext _context;

    public CustomerRepository(CustomerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CustomerDetail>> GetAllAsync()
    {
        var dbCustomers = await _context.Customers.ToListAsync();
        return dbCustomers.Select(c => c.ToDomain()).ToList();
    }

    public async Task<CustomerDetail?> GetByIdAsync(int id)
    {
        var dbCustomer = await _context.Customers.FindAsync(id);
        return dbCustomer?.ToDomain();
    }

    public async Task AddAsync(CustomerDetail customer)
    {
        var dbCustomer = customer.ToDb();
        _context.Customers.Add(dbCustomer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CustomerDetail customer)
    {
        var existing = await _context.Customers.FindAsync(customer.Id);

        if (existing is null)
            throw new Exception($"Entity with ID {customer.Id} does not exist");

        existing.Email = customer.Email;
        existing.FirstName = customer.FirstName;
        existing.LastName = customer.LastName;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var dbCustomer = await _context.Customers.FindAsync(id);
        if (dbCustomer != null)
        {
            _context.Customers.Remove(dbCustomer);
            await _context.SaveChangesAsync();
        }
    }
}
