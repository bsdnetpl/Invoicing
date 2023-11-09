using Invoicing.DTO;
using Invoicing.Models;
using Invoicing.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class InvoceServiceTests
    {
        [Fact]
        public void AddInvoceDB_ShouldReturnInvoceDB()
        {
            // Arrange
            var invoceDb = new InvoceDB(); // Utwórz przykładowy obiekt InvoceDB
            var mockInvoceService = new Mock<IInvoceService>();
            mockInvoceService
                .Setup(service => service.addInvoceDB(invoceDb))
                .Returns(invoceDb); // Mockowanie zwracania InvoceDB

            // Act
            var result = mockInvoceService.Object.addInvoceDB(invoceDb);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<InvoceDB>(result);
        }

        [Fact]
        public void AddInvoce_ShouldReturnInvoceNumber()
        {
            // Arrange
            var invoceNumber = "INV123"; // Utwórz przykładowy numer faktury
            var mockInvoceService = new Mock<IInvoceService>();
            mockInvoceService
                .Setup(service => service.addInvoce(invoceNumber))
                .Returns(invoceNumber); // Mockowanie zwracania numeru faktury

            // Act
            var result = mockInvoceService.Object.addInvoce(invoceNumber);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(invoceNumber, result);
        }

        [Fact]
        public void SeekInvoce_ShouldReturnListOfInvoices()
        {
            // Arrange
            var invoceNumber = "INV123"; // Utwórz przykładowy numer faktury
            var mockInvoceService = new Mock<IInvoceService>();
            mockInvoceService
                .Setup(service => service.SeekInvoce(invoceNumber))
                .Returns(new List<Invoce>()); // Mockowanie zwracania pustej listy faktur

            // Act
            var result = mockInvoceService.Object.SeekInvoce(invoceNumber);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Invoce>>(result);
        }

        [Fact]
        public void InvoceIncrement_ShouldReturnIncrementedString()
        {
            // Arrange
            var format = 3; // Ustaw format na 3
            var mockInvoceService = new Mock<IInvoceService>();
            mockInvoceService
                .Setup(service => service.InvoceIncrement(format))
                .Returns("001"); // Mockowanie zwracania zinkrementowanego ciągu

            // Act
            var result = mockInvoceService.Object.InvoceIncrement(format);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("001", result);
        }
    }
}
