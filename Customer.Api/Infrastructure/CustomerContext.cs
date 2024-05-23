using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Infrastructure;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
    {
    }

    public DbSet<DbCustomer> Customers { get; set; }
}
