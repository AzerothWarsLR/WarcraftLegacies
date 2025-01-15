using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using WarcraftLegacies.Source.Factions;
using WarcraftLegacies.Source.Powers;

namespace WarcraftLegacies.Source.FactionMechanics.QuelThalas
{
  public static class TheSunwell
  {
    private static SunwellState _state = SunwellState.Normal;
    private static Capital _sunwell = null!;
    private static Quelthalas _quelthalas;

    /// <summary>
    /// Invoked when the Sunwell's state has changed.
    /// </summary>
    public static event EventHandler<SunwellState>? SunwellStateChanged;

    public static SunwellState State
    {
      get => _state;
      private set
      {
        _state = value;
        SunwellStateChanged?.Invoke(null, value);
      }
    }

    public static void Setup(Factions.Quelthalas quelthalas, Capital sunwell, Factions.Scourge scourge)
    {
      _sunwell = sunwell;
      _quelthalas = quelthalas;
      quelthalas.ScoreStatusChanged += OnQuelThalasScoreStatusChanged;
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
          "\n|cffffcc00CAPITAL LOST|r\nThe Sunwell, a beacon of eternal light and power, has been corrupted. Its radiant energies have been twisted into a font of dark magic, spreading malevolence across the land.");
      
      State = SunwellState.Corrupted;
      _quelthalas.AddPower(new CorruptedSunwell(0.2f));
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
}