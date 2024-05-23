namespace Customer.UI.Services;

public class CustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Models.Customer>> GetAllCustomersAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Models.Customer>>("api/customers");
    }

    public async Task<Models.Customer> GetCustomerByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Models.Customer>($"api/customers/{id}");
    }

    public async Task CreateCustomerAsync(Models.Customer customer)
    {
        await _httpClient.PostAsJsonAsync("api/customers", customer);
    }

    public async Task UpdateCustomerAsync(int id, Models.Customer customer)
    {
        await _httpClient.PutAsJsonAsync($"api/customers/{id}", customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/customers/{id}");
    }
}
