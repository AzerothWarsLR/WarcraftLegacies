using MacroTools.Chat;

namespace MacroTools.Tests.Chat;

public sealed class GameTextTests
{
  [Fact]
  public void CharWidth_CalibratedCharacter_MatchesStoredCount()
  {
    // Arrange

    // Act & Assert
    foreach (var (character, count) in GameText.Calibrations)
    {
      Assert.Equal(GameText.LineWidthUnits / count, GameText.CharWidth(character));
    }
  }

  [Fact]
  public void CharWidth_UncalibratedCharacter_ReturnsFallback()
  {
    // Arrange
    var calibratedChars = GameText.Calibrations.Keys.ToHashSet();
    Assert.DoesNotContain('@', calibratedChars);
    Assert.DoesNotContain('#', calibratedChars);

    // Act
    var widthOfAt = GameText.CharWidth('@');
    var widthOfHash = GameText.CharWidth('#');

    // Assert
    Assert.Equal(GameText.LineWidthUnits / 64, widthOfAt);
    Assert.Equal(widthOfAt, widthOfHash);
  }

  [Fact]
  public void MeasureWidth_EmptyString_ReturnsZero()
  {
    // Arrange

    // Act
    var result = GameText.MeasureWidth("");

    // Assert
    Assert.Equal(0, result);
  }

  [Fact]
  public void MeasureWidth_MultipleCharacters_SumsEachCharacterWidth()
  {
    // Arrange
    var (first, _) = GameText.Calibrations.ElementAt(0);
    var (second, _) = GameText.Calibrations.ElementAt(1);

    // Act
    var result = GameText.MeasureWidth($"{first}{second}");

    // Assert
    Assert.Equal(GameText.CharWidth(first) + GameText.CharWidth(second), result);
  }

  [Fact]
  public void MeasureWidth_ColorCode_IsSkipped()
  {
    // Arrange

    // Act
    var result = GameText.MeasureWidth("|cffffffffA|r");

    // Assert
    Assert.Equal(GameText.CharWidth('A'), result);
  }

  [Fact]
  public void MeasureWidth_PipeNotFollowedByColorCode_CountsAsOrdinaryCharacter()
  {
    // Arrange

    // Act
    var result = GameText.MeasureWidth("|x");

    // Assert
    Assert.Equal(GameText.CharWidth('|') + GameText.CharWidth('x'), result);
  }

  [Fact]
  public void MeasureWidth_TrailingPipeWithNoFollowingCharacter_CountsAsOrdinaryCharacter()
  {
    // Arrange

    // Act
    var result = GameText.MeasureWidth("A|");

    // Assert
    Assert.Equal(GameText.CharWidth('A') + GameText.CharWidth('|'), result);
  }

  [Fact]
  public void PadToWidth_AlreadyAtTargetWidth_ReturnsStringUnchanged()
  {
    // Arrange

    // Act
    var result = GameText.PadToWidth("hello", 0);

    // Assert
    Assert.Equal("hello", result);
  }

  [Fact]
  public void PadToWidth_BelowTargetWidth_AppendsTrailingSpacesUntilMet()
  {
    // Arrange
    var target = GameText.MeasureWidth("hello") + 1;

    // Act
    var result = GameText.PadToWidth("hello", target);

    // Assert
    Assert.StartsWith("hello", result);
    Assert.EndsWith(" ", result);
    Assert.True(GameText.MeasureWidth(result) >= target);
    Assert.True(GameText.MeasureWidth(result[..^1]) < target);
  }

  [Fact]
  public void EstimateLineCount_EmptyString_ReturnsOne()
  {
    // Arrange

    // Act
    var result = GameText.EstimateLineCount("");

    // Assert
    Assert.Equal(1, result);
  }

  [Theory]
  [InlineData(1)]
  [InlineData(50)]
  [InlineData(200)]
  public void EstimateLineCount_RepeatedCharacter_RoundsWidthUpToNextLine(int repeatCount)
  {
    // Arrange
    var text = new string('a', repeatCount);

    // Act
    var result = GameText.EstimateLineCount(text);

    // Assert
    var expectedWidth = repeatCount * GameText.CharWidth('a');
    var expectedLines = (expectedWidth + GameText.LineWidthUnits - 1) / GameText.LineWidthUnits;
    Assert.Equal(expectedLines, result);
  }
}
