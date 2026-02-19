using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;

namespace Tests.Modules.KWMODULENAME.Domain
{
    /// <summary>
    /// Tests for <see cref="ExampleA"/> domain entity.
    /// Verifies entity construction, defaults, and basic constraints.
    /// </summary>
    public class ExampleATests
    {
        [Fact]
        public void WhenCreated_ThenIdIsEmpty()
        {
            // Arrange & Act
            var entity = new ExampleA();

            // Assert
            Assert.Equal(Guid.Empty, entity.Id);
        }

        [Fact]
        public void WhenCreated_ThenTitleDefaultsToEmpty()
        {
            // Arrange & Act
            var entity = new ExampleA();

            // Assert
            Assert.Equal(string.Empty, entity.Title);
        }

        [Fact]
        public void WhenCreated_ThenIsActiveDefaultsToFalse()
        {
            // Arrange & Act
            var entity = new ExampleA();

            // Assert
            Assert.False(entity.IsActive);
        }

        [Fact]
        public void WhenTitleSet_ThenTitleIsRetained()
        {
            // Arrange
            var entity = new ExampleA();
            const string expected = "Test Title";

            // Act
            entity.Title = expected;

            // Assert
            Assert.Equal(expected, entity.Title);
        }

        [Fact]
        public void WhenDescriptionNotSet_ThenDescriptionIsNull()
        {
            // Arrange & Act
            var entity = new ExampleA();

            // Assert
            Assert.Null(entity.Description);
        }
    }
}
