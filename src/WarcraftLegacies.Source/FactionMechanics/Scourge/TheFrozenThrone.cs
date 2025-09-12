using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using WarcraftLegacies.Source.Powers;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge
{
  public static class TheFrozenThrone
  {
    private static FrozenThroneState _state = FrozenThroneState.Alive;

    private static Capital _frozenThrone = null!;

    /// <summary>
    /// Invoked when the Frozen Throne's state has changed.
    /// </summary>
    public static event EventHandler<FrozenThroneState>? FrozenThroneStateChanged;

    private static FrozenThroneState State
    {
      get => _state;
      set
      {
        _state = value;
        FrozenThroneStateChanged?.Invoke(null, value);
      }
    }
    
    public static void Setup(Factions.Scourge scourge, Capital frozenThrone, LegendaryHero lichKing)
    {
      _frozenThrone = frozenThrone;

      CreateTrigger()
        .RegisterUnitEvent(frozenThrone.Unit!, EVENT_UNIT_CHANGE_OWNER)
        .AddAction(OnFrozenThroneChangeOwner);

      lichKing.PermanentlyDied += OnLichKingDied;

      scourge.ScoreStatusChanged += OnScourgeScoreStatusChanged;
    }

    /// <summary>
    /// When the Scourge leaves, vacate Ner'zhul from the Throne.
    /// </summary>
    private static void OnScourgeScoreStatusChanged(object? sender, Faction scourge)
    {
      if (scourge.ScoreStatus != ScoreStatus.Defeated) 
        return;

      scourge.ScoreStatusChanged -= OnScourgeScoreStatusChanged;
      Vacate(false);
    }

    /// <summary>
    /// Remove Ner'zhul from the Throne, causing it to lose its powers permanently and allowing it to be destroyed.
    /// </summary>
    public static void Vacate(bool removeDomination)
    {
      if (State == FrozenThroneState.Empty)
        return;

      RemoveAbilities();
      unit tempQualifier1 = _frozenThrone.Unit;
      unit ret1 = null;
      if (tempQualifier1 != null)
      {
        BlzSetUnitName(tempQualifier1, "Frozen Throne (Empty)");
        ret1 = tempQualifier1;
      }

      BlzSetUnitSkin(ret1, UNIT_ZBFT_FROZEN_THRONE_EMPTY);
      State = FrozenThroneState.Empty;
      _frozenThrone.Capturable = false;
      _frozenThrone.DeathMessage =
        "Northrend quakes as Icecrown Citadel topples to the glacier below, bringing a final end to Ner'zhul's fortress and prison of ice.";

      if (_frozenThrone.ProtectorCount == 0)
      {
        unit tempQualifier = _frozenThrone.Unit;
        unit ret = null;
        if (tempQualifier != null)
        {
          SetUnitInvulnerable(tempQualifier, false);
          ret = tempQualifier;
        }
      }

      if (_frozenThrone.OwningPlayer == Player(PLAYER_NEUTRAL_PASSIVE))
      {
        unit tempQualifier = _frozenThrone.Unit;
        unit ret = null;
        if (tempQualifier != null)
        {
          player whichPlayer = Player(PLAYER_NEUTRAL_AGGRESSIVE);
          SetUnitOwner(tempQualifier, whichPlayer, true);
          ret = tempQualifier;
        }
      }

      if (removeDomination) 
        RemoveDomination();
    }

    /// <summary>
    /// Fracture the Throne, preventing it from using abilities ever again.
    /// </summary>
    private static void Fracture()
    {
      if (State != FrozenThroneState.Alive)
        return;

      RemoveAbilities();
      unit tempQualifier = _frozenThrone.Unit;
      unit ret = null;
      if (tempQualifier != null)
      {
        BlzSetUnitName(tempQualifier, "Frozen Throne (Ruptured)");
        unit tempQualifier1 = tempQualifier;
        player whichPlayer = Player(PLAYER_NEUTRAL_PASSIVE);
        SetUnitOwner(tempQualifier1, whichPlayer, true);
        ret = tempQualifier1;
      }

      SetUnitInvulnerable(ret, true);

      foreach (var player in Util.EnumeratePlayers())
        DisplayTextToPlayer(player, 0, 0,
          "\n|cffffcc00CAPITAL DAMAGED|r\nThe Frozen Throne, once thought to be an indomitable bastion of death, has been ruptured. Ner'zhul's consciousness recedes within, retreating desperately to protect what remains of Icecrown Citadel.");

      State = FrozenThroneState.Ruptured;
      
      RemoveDomination();
    }
    
    private static void RemoveDomination()
    {
      if (!FactionManager.TryGetFactionByType<Factions.Scourge>(out var scourge)) 
        return;

      var domination = scourge.GetPowerByType<Domination>();
      if (domination != null) 
        scourge.RemovePower(domination);
    }

    private static void RemoveAbilities()
    {
      unit tempQualifier = _frozenThrone.Unit;
      unit ret = null;
      if (tempQualifier != null)
      {
        UnitRemoveAbility(tempQualifier, ABILITY_A0W8_RECALL_FROZEN_THRONE);
        unit tempQualifier2 = tempQualifier;
        UnitRemoveAbility(tempQualifier2, ABILITY_A0L3_ANIMATE_DEAD_THE_FROZEN_THRONE);
        unit tempQualifier3 = tempQualifier2;
        UnitRemoveAbility(tempQualifier3, ABILITY_A001_FROST_NOVA_THE_FROZEN_THRONE);
        unit tempQualifier1 = tempQualifier3;
        BlzSetUnitMaxMana(tempQualifier1, 0);
        ret = tempQualifier1;
      }

      BlzSetUnitName(ret, "Icecrown Citadel");
    }

    private static void OnFrozenThroneChangeOwner()
    {
      GetTriggeringTrigger().Destroy();
      Fracture();
    }
    
    private static void OnLichKingDied(object? sender, LegendaryHero e)
    {
      if (e.UnitType == UNIT_N023_LORD_OF_THE_SCOURGE_SCOURGE)
        RemoveDomination();
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
}