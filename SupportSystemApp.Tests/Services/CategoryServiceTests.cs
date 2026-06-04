using Moq;
using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Implementation;
using SupportSystemApp.Service.Interface;
using Xunit;

namespace SupportSystemApp.Tests.Services
{
    public class CategoryServiceTests
    {
        private readonly Mock<IRepository<Category>> _categoryRepositoryMock;
        private readonly CategoryService _categoryService;

        public CategoryServiceTests()
        {
            _categoryRepositoryMock = new Mock<IRepository<Category>>();
            _categoryService = new CategoryService(_categoryRepositoryMock.Object);
        }

        [Fact]
        public void Insert_ShouldInsertCategory()
        {
            var category = new Category
            {
                Name = "Network"
            };

            _categoryRepositoryMock
                .Setup(x => x.Insert(It.IsAny<Category>()))
                .Returns((Category c) => c);

            var result = _categoryService.Insert(category);

            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.Id);
            Assert.Equal("Network", result.Name);

            _categoryRepositoryMock.Verify(x => x.Insert(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public void Update_ShouldUpdateCategory()
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Hardware"
            };

            _categoryRepositoryMock
                .Setup(x => x.Update(It.IsAny<Category>()))
                .Returns((Category c) => c);

            category.Name = "Software";

            var result = _categoryService.Update(category);

            Assert.Equal("Software", result.Name);
            _categoryRepositoryMock.Verify(x => x.Update(category), Times.Once);
        }

        [Fact]
        public void Delete_ShouldDeleteCategory()
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Network"
            };

            _categoryRepositoryMock
                .Setup(x => x.Delete(It.IsAny<Category>()))
                .Returns((Category c) => c);

            var result = _categoryRepositoryMock.Object.Delete(category);

            Assert.Equal(category.Id, result.Id);
            Assert.Equal("Network", result.Name);

            _categoryRepositoryMock.Verify(x => x.Delete(category), Times.Once);
        }
    }
}