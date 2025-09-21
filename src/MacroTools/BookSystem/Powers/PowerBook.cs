using MacroTools.BookSystem.Core;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;

namespace MacroTools.BookSystem.Powers;

/// <summary>
/// Shows all the <see cref="Power"/>s a particular player has.
/// </summary>
public sealed class PowerBook : Book<Power, PowerPage, PowerCard, PowerPageFactory, PowerCardFactory>
{
  private Faction? _trackedFaction;

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
      LauncherParent = framehandle.Get("UpperButtonBarMenuButton", 0),
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
      }

      if (_trackedFaction == value)
      {
        return;
      }

      _trackedFaction = value;

      if (_trackedFaction != null)
      {
        _trackedFaction.PowerAdded += OnFactionAddPower;
        _trackedFaction.PowerRemoved += OnFactionRemovePower;
      }

      ReRender();
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

  /// <inheritdoc />
  protected override void PopulatePages()
  {
    if (_trackedFaction == null)
    {
      return;
    }

    foreach (var power in _trackedFaction.GetAllPowers())
    {
      AddPower(power);
    }

    RefreshNavigationButtonVisiblity();
  }

  private void AddPower(Power power)
  {
    var lastPage = GetFirstAvailablePage();
    lastPage.AddItem(power);
  }
}
