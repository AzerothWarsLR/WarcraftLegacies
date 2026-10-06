using System;
using System.Collections.Generic;
using MacroTools.Localization;

namespace MacroTools.Chat;

/// <summary>Splits chat output into pages sized to fit on screen.</summary>
public static class Pager
{
  private const int ReservedLines = 2;

  /// <summary>Parses an optional page number, defaulting to 1 if absent.</summary>
  public static bool TryParsePage(IReadOnlyList<string> args, int index, out int page)
  {
    if (index >= args.Count)
    {
      page = 1;
      return true;
    }

    return int.TryParse(args[index], out page) && page >= 1;
  }

  /// <summary>Builds one page of chat output, or an out-of-range message if the page number is invalid.</summary>
  public static string BuildPage(string header, IReadOnlyList<string> lines, int pageNumber)
  {
    var pageCapacity = Math.Max(1, GameText.MaxLines - ReservedLines);
    var pages = SplitIntoPages(lines, pageCapacity);

    if (pageNumber < 1 || pageNumber > pages.Count)
    {
      return Loc.Format("Page {page} out of range. Valid pages: 1-{count}.",
        ("{page}", pageNumber.ToString()), ("{count}", pages.Count.ToString()));
    }

    var suffix = pages.Count <= 1
      ? ""
      : pageNumber < pages.Count
        ? Loc.Format(" [Page {page}/{count}, add a page number for more]",
          ("{page}", pageNumber.ToString()), ("{count}", pages.Count.ToString()))
        : Loc.Format(" [Page {page}/{count}]",
          ("{page}", pageNumber.ToString()), ("{count}", pages.Count.ToString()));
    return $"{header}{suffix}\n" + string.Join("\n", pages[pageNumber - 1]);
  }

  private static List<List<string>> SplitIntoPages(IReadOnlyList<string> lines, int pageCapacity)
  {
    var pages = new List<List<string>>();
    var currentPage = new List<string>();
    var currentHeight = 0;

    foreach (var line in lines)
    {
      var lineHeight = GameText.EstimateLineCount(line);
      if (currentPage.Count > 0 && currentHeight + lineHeight > pageCapacity)
      {
        pages.Add(currentPage);
        currentPage = new List<string>();
        currentHeight = 0;
      }

      currentPage.Add(line);
      currentHeight += lineHeight;
    }

    if (currentPage.Count > 0 || pages.Count == 0)
    {
      pages.Add(currentPage);
    }

    return pages;
  }
}
