using System;
using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public class FactionMultiboard : MultiboardEx
  {
    private static FactionMultiboard _instance;

    private static void CreateInstance()
    {
      try
      {
        _instance = new FactionMultiboard
        {
          Title = "Factions",
          ColumnCount = 3,
          Display = true,
          Minimized = false
        };
        foreach (var faction in FactionSystem.GetAllFactions())
        {
          _instance.AddRow(new MultiboardFactionRow(faction));
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
    
    public static void Initialize()
    {
      if (_instance == null)
      {
        var timer = CreateTimer();
        TimerStart(timer, 5, false, CreateInstance);
      }
    }
  }
}