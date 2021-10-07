using System;
using System.Collections.Generic;
using System.Drawing;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public static class Utils
  {
    private static readonly Dictionary<Point, char> _hotkeyByButtonPosition = new()
    {
      { new Point(0, 2), 'Q' },
      { new Point(1, 2), 'W' },
      { new Point(2, 2), 'E' },
      { new Point(3, 2), 'R' },
      { new Point(0, 1), 'A' },
      { new Point(1, 1), 'S' },
      { new Point(2, 1), 'D' },
      { new Point(3, 1), 'F' },
      { new Point(0, 0), 'Z' },
      { new Point(1, 0), 'X' },
      { new Point(2, 0), 'C' },
      { new Point(3, 0), 'V' },
    };

    public static char GetHotkeyByButtonPosition(Point buttonPosition)
    {
      throw new NotImplementedException();
    }
  }
}
