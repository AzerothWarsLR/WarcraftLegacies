using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Factions;
using WarcraftLegacies.Source.Powers;
using WarcraftLegacies.Source.Quests.Quelthalas;

namespace WarcraftLegacies.Source.FactionMechanics.QuelThalas
{
  public static class TheSunwell
  {
    private static SunwellState _state = SunwellState.Normal;
    private static Capital _sunwell = null!;
    private static Quelthalas _quelthalas = null!;

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

    public static void Setup(Quelthalas quelthalas, Capital sunwell)
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
      _sunwell.Essential = false;
      _sunwell.Unit?.SetName("Corrupted Sunwell");

      State = SunwellState.Corrupted;
      var corruptedSunwellPower = new CorruptedSunwell(0.2f);
      _quelthalas.AddPower(corruptedSunwellPower);
      var destroySunwellQuest = new QuestDestroyCorruptedSunwell(_sunwell, corruptedSunwellPower, _quelthalas.GetPowerByType<FontOfPower>()!);
      _quelthalas.AddQuest(destroySunwellQuest);
      _quelthalas.DisplayDiscovered(destroySunwellQuest);
    }
    
    /// <summary>
    /// Destroy the Sunwell, changing its state and displaying a message.
    /// </summary>
    public static void Destroy()
    {
      if (State != SunwellState.Corrupted)
        return;

      _sunwell.Capturable = false;
      _sunwell.Unit!.Kill();
      State = SunwellState.Destroyed;
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