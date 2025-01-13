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

    // Define constants for the ability IDs
    private const int ABILITY_A0OC_EXTRACT_VIAL_ALL = 123456; // Replace with actual ID
    private const int ABILITY_A0EP_SUMMON_GRANITE_GOLEMS_QUEL_THALAS_SUNWELL = 789012; // Replace with actual ID
    private const int ABILITY_AOEC_DESTROY_THE_SUNWELL_CORRUPTED_SUNWELL = 345678; // Replace with actual ID

    /// <summary>
    /// Invoked when the Sunwell's state has changed.
    /// </summary>
    public static event EventHandler<SunwellState>? SunwellStateChanged;

    private static SunwellState State
    {
      get => _state;
      set
      {
        _state = value;
        SunwellStateChanged?.Invoke(null, value);
      }
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
    private static void Corrupt()
    {
      if (State != SunwellState.Normal)
        return;

      RemoveAbilities();
      AddCorruptedAbilities();
      _sunwell.Unit?.SetName("Corrupted Sunwell");
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) DisplayTextToPlayer(player, 0, 0,
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
        .AddAbility(ABILITY_AOEC_DESTROY_THE_SUNWELL_CORRUPTED_SUNWELL);
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
    Corrupted
  }
}
