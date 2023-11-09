using Invoicing.DTO;
using Invoicing.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SellerServicesTests
    {
        [Fact]
        public async Task AddSellerAsync_ShouldReturnSeller()
        {
            // Arrange
            var seller = new Seller(); // Utwórz przykładowego sprzedawcę
            var mockSellerService = new Mock<ISellerServices>();
            mockSellerService
                .Setup(service => service.AddSellerAsync(seller))
                .ReturnsAsync(new Seller()); // Mockowanie zwracania sprzedawcy

            // Act
            var result = await mockSellerService.Object.AddSellerAsync(seller);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Seller>(result);
        }

        [Fact]
        public async Task DeleteSellerAsync_ShouldReturnTrue()
        {
            // Arrange
            var sellerId = Guid.NewGuid(); // Utwórz przykładowy identyfikator sprzedawcy
            var mockSellerService = new Mock<ISellerServices>();
            mockSellerService
                .Setup(service => service.DeleteSellerAsync(sellerId))
                .ReturnsAsync(true); // Mockowanie zwracania true

            // Act
            var result = await mockSellerService.Object.DeleteSellerAsync(sellerId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task EditSellerAsync_ShouldReturnTrue()
        {
            // Arrange
            var sellerId = Guid.NewGuid(); // Utwórz przykładowy identyfikator sprzedawcy
            var seller = new Seller(); // Utwórz przykładowego sprzedawcę
            var mockSellerService = new Mock<ISellerServices>();
            mockSellerService
                .Setup(service => service.EditSellerAsync(sellerId, seller))
                .ReturnsAsync(true); // Mockowanie zwracania true

            // Act
            var result = await mockSellerService.Object.EditSellerAsync(sellerId, seller);

            // Assert
            Assert.True(result);
        }
    }
}
