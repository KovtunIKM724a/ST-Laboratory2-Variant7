using Lab2_App;
using Moq;
using Xunit;

namespace Lab2_Test;


// 1. STUB

public class CustomerRepositoryStub : ICustomerRepository
{
    public Customer? GetCustomerById(int id) => id == 1 ? new Customer { Id = 1, Name = "Тест Клиент" } : null;
}

public class ProductRepositoryStub : IProductRepository
{
    public Product? GetProductById(int id) => id == 10 ? new Product { Id = 10, Name = "Товар", Price = 100 } : null;
}

public class OrderServiceStubTests
{
    [Fact]
    public void PlaceOrder_Stub_EntitiesExist_ReturnsTrue()
    {
        var service = new OrderService(new ProductRepositoryStub(), new CustomerRepositoryStub());
        bool result = service.PlaceOrder(1, 10);
        Assert.True(result);
    }

    [Fact]
    public void PlaceOrder_Stub_EntityNotFound_ReturnsFalse()
    {
        var service = new OrderService(new ProductRepositoryStub(), new CustomerRepositoryStub());
        bool result = service.PlaceOrder(999, 10); 
        Assert.False(result);
    }
}


// 2. FAKE

public class FakeCustomerRepository : ICustomerRepository
{
    public List<Customer> Customers { get; } = new();
    public Customer? GetCustomerById(int id) => Customers.FirstOrDefault(c => c.Id == id);
}

public class FakeProductRepository : IProductRepository
{
    public List<Product> Products { get; } = new();
    public Product? GetProductById(int id) => Products.FirstOrDefault(p => p.Id == id);
}

public class OrderServiceFakeTests
{
    [Fact]
    public void PlaceOrder_Fake_Success_ReturnsTrue()
    {
        var customerRepo = new FakeCustomerRepository();
        customerRepo.Customers.Add(new Customer { Id = 2, Name = "Иван" });

        var productRepo = new FakeProductRepository();
        productRepo.Products.Add(new Product { Id = 20, Name = "Клавиатура", Price = 1500 });

        var service = new OrderService(productRepo, customerRepo);
        bool result = service.PlaceOrder(2, 20);

        Assert.True(result);
    }
}


// 3. MOCK 

public class OrderServiceMockTests
{
    [Fact]
    public void PlaceOrder_Mock_Success_CallsBothRepositoriesOnce()
    {

        var mockCustomerRepo = new Mock<ICustomerRepository>();
        var mockProductRepo = new Mock<IProductRepository>();

        mockCustomerRepo.Setup(repo => repo.GetCustomerById(5))
                        .Returns(new Customer { Id = 5, Name = "Ольга" });

        mockProductRepo.Setup(repo => repo.GetProductById(50))
                       .Returns(new Product { Id = 50, Name = "Монитор", Price = 8000 });

        var service = new OrderService(mockProductRepo.Object, mockCustomerRepo.Object);


        bool result = service.PlaceOrder(5, 50);


        Assert.True(result);
        mockCustomerRepo.Verify(repo => repo.GetCustomerById(5), Times.Once);
        mockProductRepo.Verify(repo => repo.GetProductById(50), Times.Once);
    }
}