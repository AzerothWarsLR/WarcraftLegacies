using System.Collections.Generic;
using System.Linq;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Frames.Books.Powers
{
  public sealed class PowerBook : Book<PowerPage>
  {
    private Faction? _trackedFaction;
    private readonly Dictionary<Power, PowerPage> _pagesByPower = new();

    private PowerBook() : base(0.3f, 0.39f, 0.02f, 0.015f)
    {
      var firstPage = AddPage();
      firstPage.Visible = true;
      BookTitle = "Powers";
      LauncherParent = BlzGetFrameByName("UpperButtonBarMenuButton", 0);
      Position = new Point(0.4f, 0.36f);
      TrackedFaction = PlayerData.ByHandle(GetLocalPlayer()).Faction;
      PlayerData.FactionChange += OnPersonChangeFaction;
    }

    /// <summary>
    ///   The <see cref="PowerBook" /> displays the <see cref="Power" />s of this <see cref="Faction" />.
    /// </summary>
    public Faction? TrackedFaction
    {
      get => _trackedFaction;
      set
      {
        if (_trackedFaction != null)
        {
          _trackedFaction.PowerAdded -= OnFactionAddPower;
          _trackedFaction.PowerRemoved -= OnFactionRemovePower;
          RemoveAllPowers(_trackedFaction);
        }
        
        if (_trackedFaction == value) return;
        _trackedFaction = value;
        _trackedFaction.PowerAdded += OnFactionAddPower;
        _trackedFaction.PowerRemoved += OnFactionRemovePower;
        AddAllPowers(value);
      }
    }

    private void OnFactionAddPower(object? sender, FactionPowerEventArgs factionPowerEventArgs)
    {
      AddPower(factionPowerEventArgs.Power);
    }

    private void OnPersonChangeFaction(object? sender, PlayerFactionChangeEventArgs args)
    {
      if (args.Player == GetLocalPlayer())
      {
        TrackedFaction = args.Player.GetFaction();
      }
    }

    private void OnFactionRemovePower(object? sender, FactionPowerEventArgs factionPowerEventArgs)
    {
      RemovePower(factionPowerEventArgs.Power);
    }

    private void RemoveAllPowers(Faction faction)
    {
      foreach (var power in faction.GetAllPowers())
      {
        RemovePower(power);
      }
    }

    private void AddAllPowers(Faction faction)
    {
      foreach (var power in faction.GetAllPowers())
        AddPower(power);
    }

    private void AddPower(Power power)
    {
      var lastPage = Pages.Last();
      if (lastPage.CardCount >= lastPage.CardLimit)
      {
        AddPage();
        lastPage = Pages.Last();
      }

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