using GpSys.Academy.Domain.Entities;

namespace GpSys.Academy.Domain.UnitTests.Entities
{
  public class CourseTests
  {
    [Fact]
    public void Create_ShouldReturnSuccess_WhenDataIsValid()
    {
      // Arrange
      var code = "CS100";
      var title = "C-Programming";
      var alias = "CP";

      // Act
      var result = Course.Create(code, title, alias);

      // Assert
      Assert.True(result.IsSuccess);
      Assert.NotNull(result.Value);
      Assert.Equal(code, result.Value.Code);
      Assert.Equal(title, result.Value.Title);
      Assert.Equal(alias, result.Value.Alias);
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenDataIsMissing()
    {
      // Act
      var result = Course.Create("", "", "");

      // Assert
      Assert.False(result.IsSuccess);
      Assert.Null(result.Value);
    }

    [Fact]
    public void Update_ShouldReturnSuccess_WhenDataIsValid()
    {
      // Arrange
      var course = Course.Create("CSC101", "C-Programming", "CP").Value!;

      // Act
      var result = course.Update("CSC102", "Java-Programming", "JP");

      // Assert
      Assert.True(result.IsSuccess);
      Assert.NotNull(result.Value);
      Assert.Equal("CSC102", result.Value.Code);
      Assert.Equal("Java-Programming", result.Value.Title);
      Assert.Equal("JP", result.Value.Alias);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Update_ShouldFail_WhenDataIsInvalid(string? invalidCode)
    {
      // Arrange
      var course = Course.Create("CSC101", "C-Programming", "CP").Value!;

      // Act
      var result = course.Update(invalidCode, null, null);

      // Assert
      Assert.False(result.IsSuccess);
    }
  }
}