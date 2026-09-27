namespace Lab2_App;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public interface IProductRepository
{
    Product? GetProductById(int id);
}

public interface ICustomerRepository
{
    Customer? GetCustomerById(int id);
}

public class OrderService
{
    private readonly IProductRepository _productRepository;
    private readonly ICustomerRepository _customerRepository;

    public OrderService(IProductRepository productRepository, ICustomerRepository customerRepository)
    {
        _productRepository = productRepository;
        _customerRepository = customerRepository;
    }

    public bool PlaceOrder(int customerId, int productId)
    {
        var customer = _customerRepository.GetCustomerById(customerId);
        var product = _productRepository.GetProductById(productId);

        if (customer == null || product == null)
        {
            return false;
        }

        return true;
    }
}