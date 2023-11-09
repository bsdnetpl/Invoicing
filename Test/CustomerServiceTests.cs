using Invoicing.DTO;
using Moq;
using Invoicing.Services;

namespace Test
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task AddCustomerAsync_ShouldReturnCustomer()
        {
            // Arrange
            var customerDto = new CustomerDTO(); // Utwórz przyk³adowy obiekt CustomerDTO
            var mockCustomerService = new Mock<ICustomerServices>();
            mockCustomerService
                .Setup(service => service.AddCustomerAsync(customerDto))
                .ReturnsAsync(new Customer()); // Mockowanie zwracania Customer

            // Act
            var result = await mockCustomerService.Object.AddCustomerAsync(customerDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Customer>(result);
        }

        [Fact]
        public async Task DeleteCustomerAsync_ShouldReturnTrue()
        {
            // Arrange
            var userId = Guid.NewGuid(); // Utwórz przyk³adowy identyfikator u¿ytkownika
            var mockCustomerService = new Mock<ICustomerServices>();
            mockCustomerService
                .Setup(service => service.DeleteCustomerAsync(userId))
                .ReturnsAsync(true); // Mockowanie zwracania true

            // Act
            var result = await mockCustomerService.Object.DeleteCustomerAsync(userId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task EditCustomerAsync_ShouldReturnTrue()
        {
            // Arrange
            var customerDto = new CustomerDTO(); // Utwórz przyk³adowy obiekt CustomerDTO
            var customerId = Guid.NewGuid(); // Utwórz przyk³adowy identyfikator klienta
            var mockCustomerService = new Mock<ICustomerServices>();
            mockCustomerService
                .Setup(service => service.EditCustomerAsync(customerDto, customerId))
                .ReturnsAsync(true); // Mockowanie zwracania true

            // Act
            var result = await mockCustomerService.Object.EditCustomerAsync(customerDto, customerId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task SeekCustomerByNameAsync_ShouldReturnListOfCustomers()
        {
            // Arrange
            var customerName = "John Doe"; // Utwórz przyk³adowe imiê klienta
            var mockCustomerService = new Mock<ICustomerServices>();
            mockCustomerService
                .Setup(service => service.SeekCustomerByNameAsync(customerName))
                .ReturnsAsync(new List<Customer>()); // Mockowanie zwracania pustej listy

            // Act
            var result = await mockCustomerService.Object.SeekCustomerByNameAsync(customerName);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Customer>>(result);
        }

        [Fact]
        public async Task SeekCustomerByNipAsync_ShouldReturnListOfCustomers()
        {
            // Arrange
            var customerNip = "1234567890"; // Utwórz przyk³adowy numer NIP klienta
            var mockCustomerService = new Mock<ICustomerServices>();
            mockCustomerService
                .Setup(service => service.SeekCustomerByNipAsync(customerNip))
                .ReturnsAsync(new List<Customer>()); // Mockowanie zwracania pustej listy

            // Act
            var result = await mockCustomerService.Object.SeekCustomerByNipAsync(customerNip);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Customer>>(result);
        }
    }
}