using System;
using System.Collections.Generic;

namespace MacroTools.Chat;

/// <summary>
/// Builds width-aligned text for chat output.
/// </summary>
public static class ColumnFormatter
{
  internal const int ColumnGapSpaces = 5;
  internal const string RowIndent = "  ";

  /// <summary>
  /// One row of a two-column block: a command and its description.
  /// </summary>
  public sealed class Row
  {
    public Row(string command, string description)
    {
      Command = command;
      Description = description;
    }

    public string Command { get; }
    public string Description { get; }
  }

  /// <summary>
  /// Formats a header line followed by a column-aligned list of rows.
  /// </summary>
  public static string BuildUsage(string header, IReadOnlyList<Row> rows)
  {
    var col = 0;
    foreach (var r in rows)
    {
      col = Math.Max(col, GameText.MeasureWidth(RowIndent + r.Command));
    }

    col += ColumnGapSpaces * GameText.CharWidth(' ');

    var result = header;
    foreach (var r in rows)
    {
      result += "\n" + GameText.PadToWidth(RowIndent + r.Command, col) + r.Description;
    }

    return result;
  }
}
