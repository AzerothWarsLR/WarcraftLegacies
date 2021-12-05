using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.UserInterface
{
  public class FactionMultiboard : MultiboardEx
  {
    private static FactionMultiboard _instance;

    private FactionMultiboard(IEnumerable<Team> teams) : base()
    {
      Title = "Factions";
      ColumnCount = 3;
      Display = true;
      Minimized = false;
      foreach (var team in teams)
      {
        AddRow(new MultiboardTeamRow(team));
        foreach (var faction in team.GetFactions())
        { 
          AddRow(new MultiboardFactionRow(faction));
        }
      }
    }

    private static void CreateInstance()
    {
      try
      {
        _instance = new FactionMultiboard(FactionSystem.GetAllTeams());
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