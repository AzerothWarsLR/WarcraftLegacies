using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Stormwind.Quests.Stromgarde;

/// <summary>Hold both ends of the Thandol Span to fortify it and collect tolls from everyone who crosses.</summary>
public sealed class QuestMastersOfTheSpan : QuestData
{
  private const float ClearRadius = 200;
  private const int TollPerTurn = 25;

  private static readonly int[] _bridgeEnds = { UNIT_N01Z_ARATHI_HIGHLANDS, UNIT_N017_DUN_MODR };

  private static readonly int[] _bridgeBaseTypes =
  {
    UNIT_H0FZ_IMPROVED_GUARD_TOWER_STROMGARDE, UNIT_H0FP_HOMESTEAD_STROMGARDE, UNIT_H0FP_HOMESTEAD_STROMGARDE,
    UNIT_H0G1_IMPROVED_CANNON_TOWER_STROMGARDE, UNIT_H0FR_BARRACKS_STROMGARDE, UNIT_H0FZ_IMPROVED_GUARD_TOWER_STROMGARDE,
    UNIT_H0FP_HOMESTEAD_STROMGARDE, UNIT_H0FP_HOMESTEAD_STROMGARDE, UNIT_H0FZ_IMPROVED_GUARD_TOWER_STROMGARDE
  };

  private static readonly Point[] _bridgeBaseSpots =
  {
    new(15488, 960), new(15488, 832), new(15936, 768), new(16064, 832), new(16352, 1184),
    new(16128, -384), new(15360, -512), new(15424, -384), new(15296, -384)
  };

  public QuestMastersOfTheSpan() : base("Masters of the Span",
    "The Thandol Span links Arathi to the Wetlands, and Stromgarde has long guarded its northern end. Hold both ends of the bridge and every caravan that crosses will pay the king's toll.",
    @"ReplaceableTextures\CommandButtons\BTNRepair.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N01Z_ARATHI_HIGHLANDS));
    AddObjective(new ObjectiveControlPoint(UNIT_N017_DUN_MODR));
  }

  /// <inheritdoc/>
  public override string RewardFlavour => "Both ends of the Thandol Span are in Stromgarde's hands. Its towers rise again, and the tolls flow to the king.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Fortifications at both ends of the Thandol Span, and 25 gold each turn while you hold both of its control points";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner == null)
    {
      return;
    }

    for (var i = 0; i < _bridgeBaseTypes.Length; i++)
    {
      var spot = _bridgeBaseSpots[i];
      RefundSystem.RefundOtherStructuresInRange(owner, spot.X, spot.Y, ClearRadius);
      PathBase.CreateStructure(owner, _bridgeBaseTypes[i], spot.X, spot.Y);
    }

    GameTimeManager.RegisterOnTurnRepeating(GameTimeManager.Turn + 1, () => CollectTolls(owner));
  }

  private static void CollectTolls(player owner)
  {
    foreach (var controlPointType in _bridgeEnds)
    {
      if (ControlPointManager.Instance.GetFromUnitType(controlPointType).Unit.Owner != owner)
      {
        return;
      }
    }

    owner.Gold += TollPerTurn;
    owner.DisplayTextTo(Loc.Format("Thandol Span tolls: +{gold} gold.", ("{gold}", TollPerTurn.ToString())));
  }
}
