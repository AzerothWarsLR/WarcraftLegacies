using System.Collections.Generic;
using MacroTools.BookSystem.Core;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.BookSystem.Powers
{
  /// <summary>
  /// Shows all the <see cref="Power"/>s a particular player has.
  /// </summary>
  public sealed class PowerBook : Book<PowerPage, PowerCard, PowerPageFactory, PowerCardFactory>
  {
    private Faction? _trackedFaction;
    private readonly Dictionary<Power, PowerPage> _pagesByPower = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="PowerBook"/> class.
    /// </summary>
    private PowerBook() : base(0.34f, 0.39f, 0.02f, 0.015f, 3)
    {
    }
    
    public static PowerBook Create(player trackedPlayer)
    {
      var book = new PowerBook
      {
        Title = "Powers",
        LauncherParent = BlzGetFrameByName("UpperButtonBarMenuButton", 0),
        Position = new Point(0.36f, 0.35f),
        TrackedFaction = trackedPlayer.GetFaction()
      };

      trackedPlayer.GetPlayerData().ChangedFaction += book.OnPlayerChangedFaction;

      return book;
    }

    /// <summary>
    ///   The <see cref="PowerBook" /> displays the <see cref="Power" />s of this <see cref="Faction" />.
    /// </summary>
    private Faction? TrackedFaction
    {
      set
      {
        if (_trackedFaction != null)
        {
          _trackedFaction.PowerAdded -= OnFactionAddPower;
          _trackedFaction.PowerRemoved -= OnFactionRemovePower;
          RemoveAllPowers(_trackedFaction);
        }
        
        if (_trackedFaction == value) 
          return;
        _trackedFaction = value;
        if (_trackedFaction != null)
        {
          _trackedFaction.PowerAdded += OnFactionAddPower;
          _trackedFaction.PowerRemoved += OnFactionRemovePower;
          AddAllPowers();
        }
      }
    }

    private void OnFactionAddPower(object? sender, FactionPowerEventArgs factionPowerEventArgs)
    {
      AddPower(factionPowerEventArgs.Power);
    }

    private void OnPlayerChangedFaction(object? sender, PlayerFactionChangeEventArgs args)
    {
      TrackedFaction = args.Player.GetFaction();
    }

    private void OnFactionRemovePower(object? sender, FactionPowerEventArgs factionPowerEventArgs)
    {
      ReRender();
    }

    private void RemoveAllPowers(Faction faction)
    {
      foreach (var power in faction.GetAllPowers()) 
        RemovePower(power);
    }

    private void AddAllPowers()
    {
      if (_trackedFaction == null) 
        return;
      
      foreach (var power in _trackedFaction.GetAllPowers())
        AddPower(power);
    }

    private void ReRender()
    {
      // foreach (var page in Pages)
      // {
      //   page.Visible = false; //This avoids a crash to desktop when rerendering a Book that a player has open.
      //   page.Dispose();
      // }
      // _pagesByPower.Clear();
      // Pages.Clear();
      // AddPagesAndPowers();
    }

    private void AddPower(Power power)
    {
      var lastPage = GetFirstAvailablePage();
      lastPage.AddPower(power);
      _pagesByPower.Add(power, lastPage);
    }

    private void RemovePower(Power power)
    {
      _pagesByPower[power].RemovePower(power);
      _pagesByPower.Remove(power);
    }
  }
}