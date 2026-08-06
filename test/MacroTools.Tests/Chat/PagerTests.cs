using MacroTools.Chat;

namespace MacroTools.Tests.Chat;

public sealed class PagerTests
{
  [Fact]
  public void TryParsePage_ArgumentAbsent_DefaultsToPageOne()
  {
    // Arrange

    // Act
    var result = Pager.TryParsePage([], 0, out var page);

    // Assert
    Assert.True(result);
    Assert.Equal(1, page);
  }

  [Theory]
  [InlineData("1", 1)]
  [InlineData("7", 7)]
  public void TryParsePage_ValidPageNumber_ReturnsTrueAndParsedPage(string arg, int expectedPage)
  {
    // Arrange

    // Act
    var result = Pager.TryParsePage([arg], 0, out var page);

    // Assert
    Assert.True(result);
    Assert.Equal(expectedPage, page);
  }

  [Theory]
  [InlineData("0")]
  [InlineData("-1")]
  [InlineData("notanumber")]
  public void TryParsePage_InvalidPageNumber_ReturnsFalse(string arg)
  {
    // Arrange

    // Act
    var result = Pager.TryParsePage([arg], 0, out _);

    // Assert
    Assert.False(result);
  }

  [Fact]
  public void BuildPage_AllLinesFitOnePage_ReturnsHeaderWithoutPageIndicator()
  {
    // Arrange
    var lines = Enumerable.Range(1, 13).Select(i => $"L{i}").ToList();

    // Act
    var result = Pager.BuildPage("Header", lines, 1);

    // Assert
    Assert.Equal("Header\n" + string.Join("\n", lines), result);
  }

  [Fact]
  public void BuildPage_LinesOverflowOnePage_SplitsAcrossPages()
  {
    // Arrange
    var lines = Enumerable.Range(1, 14).Select(i => $"L{i}").ToList();

    // Act
    var firstPage = Pager.BuildPage("Header", lines, 1);
    var secondPage = Pager.BuildPage("Header", lines, 2);

    // Assert
    Assert.Equal("Header [Page 1/2, add page # for more]\n" + string.Join("\n", lines.Take(13)), firstPage);
    Assert.Equal("Header [Page 2/2]\n" + "L14", secondPage);
  }

  [Fact]
  public void BuildPage_PageNumberTooLow_ReturnsOutOfRangeMessage()
  {
    // Arrange
    var lines = Enumerable.Range(1, 14).Select(i => $"L{i}").ToList();

    // Act
    var result = Pager.BuildPage("Header", lines, 0);

    // Assert
    Assert.Equal("Page 0 out of range. Valid pages: 1-2.", result);
  }

  [Fact]
  public void BuildPage_PageNumberTooHigh_ReturnsOutOfRangeMessage()
  {
    // Arrange
    var lines = Enumerable.Range(1, 14).Select(i => $"L{i}").ToList();

    // Act
    var result = Pager.BuildPage("Header", lines, 3);

    // Assert
    Assert.Equal("Page 3 out of range. Valid pages: 1-2.", result);
  }

  [Fact]
  public void BuildPage_NoLines_ReturnsHeaderWithNoBody()
  {
    // Arrange

    // Act
    var result = Pager.BuildPage("Header", [], 1);

    // Assert
    Assert.Equal("Header\n", result);
  }
}
