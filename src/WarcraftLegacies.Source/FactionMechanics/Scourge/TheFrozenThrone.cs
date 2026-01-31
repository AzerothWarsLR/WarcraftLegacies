using System;
using MacroTools.FactionSystem;
using MacroTools.Legends;
using WarcraftLegacies.Source.Powers;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge;

public static class TheFrozenThrone
{
  private static FrozenThroneState _state = FrozenThroneState.Alive;

  private static Capital _frozenThrone = null!;

  /// <summary>
  /// Invoked when the Frozen Throne's state has changed.
  /// </summary>
  public static event EventHandler<FrozenThroneState>? FrozenThroneStateChanged;

  public static FrozenThroneState State
  {
    get => _state;
    private set
    {
      _state = value;
      FrozenThroneStateChanged?.Invoke(null, value);
    }
  }

  public static void Setup(Factions.Scourge scourge, Capital frozenThrone, LegendaryHero lichKing)
  {
    _frozenThrone = frozenThrone;

    var ownerChangeTrigger = trigger.Create();
    ownerChangeTrigger.RegisterUnitEvent(frozenThrone.Unit!, unitevent.ChangeOwner);
    ownerChangeTrigger.AddAction(OnFrozenThroneChangeOwner);

    lichKing.PermanentlyDied += OnLichKingDied;

    scourge.ScoreStatusChanged += OnScourgeScoreStatusChanged;
  }

  /// <summary>
  /// When the Scourge leaves, vacate Ner'zhul from the Throne.
  /// </summary>
  private static void OnScourgeScoreStatusChanged(object? sender, Faction scourge)
  {
    if (scourge.ScoreStatus != ScoreStatus.Defeated)
    {
      return;
    }

    scourge.ScoreStatusChanged -= OnScourgeScoreStatusChanged;
    Vacate(false);
  }

  /// <summary>
  /// Remove Ner'zhul from the Throne, causing it to lose its powers permanently and allowing it to be destroyed.
  /// </summary>
  public static void Vacate(bool removeDomination)
  {
    if (State == FrozenThroneState.Empty)
    {
      return;
    }

    RemoveAbilities();
    if (_frozenThrone.Unit != null)
    {
      _frozenThrone.Unit.Name = "Frozen Throne (Empty)";
      _frozenThrone.Unit.Skin = UNIT_ZBFT_FROZEN_THRONE_SCOURGE_EMPTY;
    }

    State = FrozenThroneState.Empty;
    _frozenThrone.Capturable = false;
    _frozenThrone.DeathMessage =
      "Northrend quakes as Icecrown Citadel topples to the glacier below, bringing a final end to Ner'zhul's fortress and prison of ice.";

    if (_frozenThrone.Unit != null)
    {
      if (_frozenThrone.ProtectorCount == 0)
      {
        _frozenThrone.Unit.IsInvulnerable = false;
      }

      if (_frozenThrone.OwningPlayer == player.NeutralPassive)
      {
        _frozenThrone.Unit.SetOwner(player.NeutralAggressive);
      }
    }

    if (removeDomination)
    {
      RemoveDomination();
    }
  }

  /// <summary>
  /// Fracture the Throne, preventing it from using abilities ever again.
  /// </summary>
  private static void Fracture()
  {
    if (State != FrozenThroneState.Alive)
    {
      return;
    }

    RemoveAbilities();
    if (_frozenThrone.Unit != null)
    {
      _frozenThrone.Unit.Name = "Frozen Throne (Ruptured)";
      _frozenThrone.Unit.SetOwner(player.NeutralPassive);
      _frozenThrone.Unit.IsInvulnerable = true;
    }

    foreach (var player in Util.EnumeratePlayers())
    {
      player.DisplayTextTo("\n|cffffcc00CAPITAL DAMAGED|r\nThe Frozen Throne, once thought to be an indomitable bastion of death, has been ruptured. Ner'zhul's consciousness recedes within, retreating desperately to protect what remains of Icecrown Citadel.");
    }

    State = FrozenThroneState.Ruptured;

    RemoveDomination();
  }

  private static void RemoveDomination()
  {
    if (!FactionManager.TryGetFactionByType<Factions.Scourge>(out var scourge))
    {
      return;
    }

    var domination = scourge.GetPowerByType<Domination>();
    if (domination != null)
    {
      scourge.RemovePower(domination);
    }
  }

  private static void RemoveAbilities()
  {
    if (_frozenThrone.Unit == null)
    {
      return;
    }

    _frozenThrone.Unit.RemoveAbility(ABILITY_A0W8_RECALL_FROZEN_THRONE);
    _frozenThrone.Unit.RemoveAbility(ABILITY_A0L3_ANIMATE_DEAD_THE_FROZEN_THRONE);
    _frozenThrone.Unit.RemoveAbility(ABILITY_A001_FROST_NOVA_THE_FROZEN_THRONE);
    _frozenThrone.Unit.MaxMana = 0;
    _frozenThrone.Unit.Name = "Icecrown Citadel";
  }

  private static void OnFrozenThroneChangeOwner()
  {
    @event.Trigger.Dispose();
    Fracture();
  }

  private static void OnLichKingDied(object? sender, LegendaryHero e)
  {
    if (e.UnitType == UNIT_N023_LORD_OF_THE_SCOURGE_SCOURGE)
    {
      RemoveDomination();
    }
  }
}

public enum FrozenThroneState
{
  /// <summary>
  /// The Throne is fully intact and has Ner'zhul inside it.
  /// </summary>
  Alive,

  /// <summary>
  /// The Throne has been severely damaged and can no longer function.
  /// </summary>
  Ruptured,

  /// <summary>
  /// Ner'zhul has been removed from the Throne.
  /// </summary>
  Empty
}
