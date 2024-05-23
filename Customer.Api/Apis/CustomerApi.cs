using Customer.Api.Domain;

namespace Customer.Api.Apis;

public static class CustomerApi
{
    public static IEndpointRouteBuilder MapCustomerApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/customers", async (ICustomerService service) =>
        {
            var customers = await service.GetAllAsync();
            return Results.Ok(customers);
        });

        app.MapGet("/api/customers/{id:int}", async (int id, ICustomerService service) =>
        {
            var customer = await service.GetByIdAsync(id);
            return customer is not null ? Results.Ok(customer) : Results.NotFound();
        });

        app.MapPost("/api/customers", async (CustomerDetail customer, ICustomerService service) =>
        {
            await service.AddAsync(customer);
            return Results.Created($"/api/customers/{customer.Id}", customer);
        });

        app.MapPut("/api/customers/{id:int}", async (int id, CustomerDetail customer, ICustomerService service) =>
        {
            var existingCustomer = await service.GetByIdAsync(id);
            if (existingCustomer is null)
            {
                return Results.NotFound();
            }

            customer.Id = id; // Ensure the ID is correct
            await service.UpdateAsync(customer);
            return Results.NoContent();
        });

        app.MapDelete("/api/customers/{id:int}", async (int id, ICustomerService service) =>
        {
            var customer = await service.GetByIdAsync(id);
            if (customer is null)
            {
                return Results.NotFound();
            }

            await service.DeleteAsync(id);
            return Results.NoContent();
        });

        return app;
    }

}
