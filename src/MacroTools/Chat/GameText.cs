using System.Collections.Generic;
using MacroTools.Extensions;

namespace MacroTools.Chat;

/// <summary>
/// Approximates character widths in Warcraft III's in-game message font, and provides
/// helpers for measuring and padding strings built from those widths.
/// </summary>
/// <remarks>
/// Widths are expressed as how many of that character fit on one message line before
/// wrapping, measured at 1920x1080 on the Reforged client with English locale.
/// Resolution, client version, and locale may shift these further.
/// </remarks>
public static class GameText
{
  /// <summary>Fixed-point base for character-width fractions (Anitarf's 1/10000 convention).</summary>
  public const int LineWidthUnits = 10000;

  /// <summary>Max lines before a message overflows and spills down over the UI.</summary>
  public const int MaxLines = 15;

  // Fallback for uncalibrated characters
  private const int DefaultCount = 64;

  private static readonly Dictionary<char, int> _widths = new()
  {
    // Letters
    ['a'] = 69,
    ['b'] = 60,
    ['c'] = 69,
    ['d'] = 60,
    ['e'] = 64,
    ['f'] = 112,
    ['g'] = 64,
    ['h'] = 64,
    ['i'] = 150,
    ['j'] = 150,
    ['k'] = 69,
    ['l'] = 150,
    ['m'] = 39,
    ['n'] = 60,
    ['o'] = 56,
    ['p'] = 56,
    ['q'] = 56,
    ['r'] = 112,
    ['s'] = 81,
    ['t'] = 112,
    ['u'] = 64,
    ['v'] = 69,
    ['w'] = 45,
    ['x'] = 69,
    ['y'] = 75,
    ['z'] = 75,

    ['A'] = 53,
    ['B'] = 60,
    ['C'] = 53,
    ['D'] = 47,
    ['E'] = 69,
    ['F'] = 81,
    ['G'] = 47,
    ['H'] = 45,
    ['I'] = 128,
    ['J'] = 128,
    ['K'] = 60,
    ['L'] = 69,
    ['M'] = 39,
    ['N'] = 45,
    ['O'] = 42,
    ['P'] = 64,
    ['Q'] = 42,
    ['R'] = 60,
    ['S'] = 69,
    ['T'] = 69,
    ['U'] = 47,
    ['V'] = 60,
    ['W'] = 37,
    ['X'] = 53,
    ['Y'] = 60,
    ['Z'] = 56,

    // Whitespace/punctuation
    ['.'] = 150,
    [','] = 150,
    [' '] = 149,
    ['-'] = 81,

    // Digits
    ['0'] = 56,
    ['1'] = 53,
    ['2'] = 56,
    ['3'] = 56,
    ['4'] = 56,
    ['5'] = 56,
    ['6'] = 56,
    ['7'] = 56,
    ['8'] = 56,
    ['9'] = 56,

    // Symbols
    ['<'] = 56,
    ['>'] = 56,
    ['|'] = 225,
    ['('] = 112,
    [')'] = 112,
    ['{'] = 81,
    ['}'] = 81,
    ['['] = 100,
    [']'] = 100
  };

  /// <summary>All calibrated characters and their stored wrap-boundary counts.</summary>
  public static IReadOnlyDictionary<char, int> Calibrations => _widths;

  /// <summary>Measures the approximate rendered width of a single character.</summary>
  public static int CharWidth(char c)
  {
    return LineWidthUnits / _widths.GetValueOrDefault(c, DefaultCount);
  }

  /// <summary>Measures the total approximate rendered width of a string, skipping color codes.</summary>
  public static int MeasureWidth(string s)
  {
    var total = 0;
    var i = 0;
    while (i < s.Length)
    {
      if (s[i] == '|' && i + 1 < s.Length)
      {
        switch (s[i + 1])
        {
          case 'c':
            i += 10; continue;
          case 'r':
            i += 2; continue;
        }
      }
      total += CharWidth(s[i]);
      i++;
    }
    return total;
  }

  /// <summary>Appends trailing spaces until the string's measured width meets <paramref name="targetWidth"/>.</summary>
  public static string PadToWidth(string s, int targetWidth)
  {
    while (MeasureWidth(s) < targetWidth)
    {
      s += " ";
    }

    return s;
  }

  /// <summary>Estimates how many rendered lines a message will wrap into.</summary>
  public static int EstimateLineCount(string s)
  {
    var width = MeasureWidth(s);
    return width == 0 ? 1 : (width + LineWidthUnits - 1) / LineWidthUnits;
  }
}
