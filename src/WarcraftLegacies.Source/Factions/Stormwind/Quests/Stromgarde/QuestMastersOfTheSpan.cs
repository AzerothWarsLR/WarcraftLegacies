using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Stormwind.Powers;
using WarcraftLegacies.Source.GameLogic.ThandolSpan;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Stormwind.Quests.Stromgarde;

/// <summary>Hold both ends of the Thandol Span to fortify it and collect tolls from everyone who crosses.</summary>
public sealed class QuestMastersOfTheSpan : QuestData
{
  private const float ClearRadius = 200;
  private const int TollIncome = 75;

  private static readonly int[] _bridgeEnds = { UNIT_N01Z_ARATHI_HIGHLANDS, UNIT_N017_DUN_MODR };

  private static readonly int[] _bridgeBaseTypes =
  {
    UNIT_H0FZ_IMPROVED_GUARD_TOWER_STROMGARDE, UNIT_H0FP_HOMESTEAD_STROMGARDE,
    UNIT_H0G1_IMPROVED_CANNON_TOWER_STROMGARDE, UNIT_H0FR_BARRACKS_STROMGARDE, UNIT_H0FZ_IMPROVED_GUARD_TOWER_STROMGARDE,
    UNIT_H0FP_HOMESTEAD_STROMGARDE, UNIT_H0FP_HOMESTEAD_STROMGARDE, UNIT_H0FZ_IMPROVED_GUARD_TOWER_STROMGARDE
  };

  private static readonly Point[] _bridgeBaseSpots =
  {
    new(15488, 960), new(15488, 832), new(16064, 832), new(16352, 1184),
    new(16128, -384), new(15360, -512), new(15424, -384), new(15296, -384)
  };

  private readonly ThandolSpanTolls _tolls = new(TollIncome)
  {
    Name = "Thandol Span Tolls",
    IconName = "ChestOfGold"
  };

  private Faction? _faction;
  private bool _completed;

  public QuestMastersOfTheSpan() : base("Masters of the Span",
    "The Thandol Span links Arathi to the Wetlands, and Stromgarde has long guarded its northern end. Hold both ends of the bridge and every caravan that crosses will pay the king's toll.",
    @"ReplaceableTextures\CommandButtons\BTNRepair.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N01Z_ARATHI_HIGHLANDS, 0));
    AddObjective(new ObjectiveControlPoint(UNIT_N017_DUN_MODR, 0));
    var bridgeRestored = new ObjectiveTriggered("The Thandol Span is restored")
    {
      ShowsInPopups = false,
      ShowsInQuestLog = false,
      Progress = ThandolSpanBridge.IsRestored ? QuestProgress.Complete : QuestProgress.Undiscovered
    };
    AddObjective(bridgeRestored);
    if (!ThandolSpanBridge.IsRestored)
    {
      ThandolSpanBridge.Restored += bridgeRestored.Trigger;
    }
  }

  /// <inheritdoc/>
  public override string RewardFlavour => "Both ends of the Thandol Span are in Stromgarde's hands. Its towers rise again, and the tolls flow to the king.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Fortifications at both ends of the Thandol Span, and your Thandol Span Tolls power becomes active: +75 income while you hold both of its control points";

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

    _completed = true;
    RefreshTolls();
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    _faction = whichFaction;
    whichFaction.AddPower(_tolls);
    foreach (var controlPointType in _bridgeEnds)
    {
      ControlPointManager.Instance.GetFromUnitType(controlPointType).OwnerAllianceChanged += _ => RefreshTolls();
    }
  }

  private void RefreshTolls()
  {
    if (_faction == null)
    {
      return;
    }

    var holder = _faction.Player;
    var holdsBothEnds = _completed && holder != null;
    foreach (var controlPointType in _bridgeEnds)
    {
      if (ControlPointManager.Instance.GetFromUnitType(controlPointType).Owner != holder)
      {
        holdsBothEnds = false;
      }
    }

    _tolls.SetActive(holdsBothEnds);
  }
}
