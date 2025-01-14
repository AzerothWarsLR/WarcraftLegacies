using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.FactionMechanics.QuelThalas
{
  public static class Sunwell
  {
    private static SunwellState _state = SunwellState.Normal;
    private static Capital _sunwell = null!;

    /// <summary>
    /// Invoked when the Sunwell's state has changed.
    /// </summary>
    public static event EventHandler<SunwellState>? SunwellStateChanged;

    public static SunwellState State
    {
      get => _state; private set { _state = value; SunwellStateChanged?.Invoke(null, value); }
    }

    public static void Setup(Factions.Quelthalas quelThalas, Capital sunwell)
    {
      _sunwell = sunwell;

      CreateTrigger()
        .RegisterUnitEvent(sunwell.Unit!, EVENT_UNIT_CHANGE_OWNER)
        .AddAction(OnSunwellChangeOwner);

      quelThalas.ScoreStatusChanged += OnQuelThalasScoreStatusChanged;
    }

    /// <summary>
    /// When Quel'Thalas is defeated, the Sunwell remains normal.
    /// </summary>
    private static void OnQuelThalasScoreStatusChanged(object? sender, Faction quelThalas)
    {
      if (quelThalas.ScoreStatus != ScoreStatus.Defeated)
        return;

      quelThalas.ScoreStatusChanged -= OnQuelThalasScoreStatusChanged;
    }

    /// <summary>
    /// Corrupt the Sunwell, changing its state and abilities.
    /// </summary>
    public static void Corrupt()
    {
      if (State != SunwellState.Normal)
        return;

      RemoveAbilities();
      AddCorruptedAbilities();
      _sunwell.Unit?.SetName("Corrupted Sunwell");
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        DisplayTextToPlayer(player, 0, 0,
        "\n|cffffcc00CAPITAL LOST|r\nThe Sunwell, a beacon of eternal light and power, has been corrupted. Its radiant energies twisted into a font of dark magic, spreading malevolence across the land.");
      State = SunwellState.Corrupted;
    }


    private static void RemoveAbilities()
    {
      _sunwell.Unit?
        .RemoveAbility(ABILITY_A0OC_EXTRACT_VIAL_ALL)
        .RemoveAbility(ABILITY_A0EP_SUMMON_GRANITE_GOLEMS_QUEL_THALAS_SUNWELL);
    }

    private static void AddCorruptedAbilities()
    {
      _sunwell.Unit?
        .AddAbility(ABILITY_A00D_DESTROY_THE_CORRUPTED_SUNWELL_QUEL_THALAS_SUNWELL);
    }

    /// <summary>
    /// Destroy the Sunwell, changing its state and displaying a message.
    /// </summary>
    private static void DestroySunwell()
    {
      if (State != SunwellState.Corrupted)
        return;

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        DisplayTextToPlayer(player, 0, 0,
        "\n|cffffcc00CAPITAL DESTROYED|r\nThe Sunwell, once a source of great magical energy, is no more. Its corruption has ended, and the land is free from its dark influence.");
      State = SunwellState.Destroyed;
    }

    private static void OnSunwellChangeOwner()
    {
      GetTriggeringTrigger().Destroy();
      Corrupt();
    }
  }

  public enum SunwellState
  {
    /// <summary>
    /// The Sunwell is in its normal state.
    /// </summary>
    Normal,

    /// <summary>
    /// The Sunwell has been corrupted.
    /// </summary>
    Corrupted,

    /// <summary>
    /// The Sunwell has been destroyed.
    /// </summary>
    Destroyed
  }
}
