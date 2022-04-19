using Microsoft.Extensions.Logging;
using MilleniumRecruitmentTask.Controllers;
using MilleniumRecruitmentTask.Domain;
using MilleniumRecruitmentTask.Domain.Models;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MilleniumRecruitmentTask.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Should_CreateObject_when_ObjectIsValid()
        {
            var ilogger = new Mock<ILogger<ProductController>>();
            var irepository = new Mock<IRepository<Product>>();
            ProductController controller = new ProductController(ilogger.Object, irepository.Object);

            var result = await controller.Create(new Dtos.ProductCreateUpdateDto
            {
                Name = "Name",
                Price = 5
            });

            Assert.NotNull(result);
        }
    }
}
