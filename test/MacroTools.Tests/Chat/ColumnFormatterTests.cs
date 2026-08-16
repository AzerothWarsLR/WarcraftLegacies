using MacroTools.Chat;

namespace MacroTools.Tests.Chat;

public sealed class ColumnFormatterTests
{
  [Fact]
  public void BuildUsage_NoRows_ReturnsHeaderUnchanged()
  {
    // Arrange
    const string header = "Usage:";

    // Act
    var result = ColumnFormatter.BuildUsage(header, []);

    // Assert
    Assert.Equal(header, result);
  }

  [Fact]
  public void BuildUsage_SingleRow_PadsCommandColumnBeforeDescription()
  {
    // Arrange
    const string header = "h";
    const string c1 = "c1";
    const string d1 = "d1";
    var rows = new[] { new ColumnFormatter.Row(c1, d1) };

    // Act
    var result = ColumnFormatter.BuildUsage(header, rows);

    // Assert
    const string indentedCommand = $"{ColumnFormatter.RowIndent}{c1}";
    var expectedCol = GameText.MeasureWidth(indentedCommand) + ColumnFormatter.ColumnGapSpaces * GameText.CharWidth(' ');
    var expectedLine = $"{GameText.PadToWidth(indentedCommand, expectedCol)}{d1}";
    Assert.Equal($"{header}\n{expectedLine}", result);
  }

  [Fact]
  public void BuildUsage_MultipleRows_AlignsToWidestCommand()
  {
    // Arrange
    const string header = "h";
    const string c1 = "a-short-command";
    const string c2 = "a-much-longer-command";
    const string d1 = "d1";
    const string d2 = "d2";
    var rows = new[]
    {
      new ColumnFormatter.Row(c1, d1),
      new ColumnFormatter.Row(c2, d2),
    };

    // Act
    var result = ColumnFormatter.BuildUsage(header, rows);

    // Assert
    const string indentedCommand1 = $"{ColumnFormatter.RowIndent}{c1}";
    const string indentedCommand2 = $"{ColumnFormatter.RowIndent}{c2}";
    var expectedCol = Math.Max(
      GameText.MeasureWidth(indentedCommand1),
      GameText.MeasureWidth(indentedCommand2)) + ColumnFormatter.ColumnGapSpaces * GameText.CharWidth(' ');
    var expectedLines = string.Join("\n",
      $"{GameText.PadToWidth(indentedCommand1, expectedCol)}{d1}",
      $"{GameText.PadToWidth(indentedCommand2, expectedCol)}{d2}");
    Assert.Equal($"{header}\n{expectedLines}", result);
  }
}
