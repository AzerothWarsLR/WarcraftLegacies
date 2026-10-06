using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

public sealed class QuestStonemaulDiplomacy : QuestData
{
  private const int RexxarLevel = 5;

  private readonly Rectangle _stonemaul;
  private readonly LegendaryHero _rexxar;
  private readonly List<unit> _rescueUnits;
  private readonly unit _korgall;
  private StonemaulStandoff? _standoff;

  public QuestStonemaulDiplomacy(Rectangle stonemaul, unit korgall, LegendaryHero rexxar, QuestData previousQuest) : base(
    "Stonemaul Diplomacy",
    "Kor'gall, the brutish warchief of the Stonemaul ogres, refuses to parley with the Tauren. Rexxar, who has long walked among the ogres, is locked in battle with the tyrant and cannot win alone. Help him bring Kor'gall down and he will join your cause.",
    @"ReplaceableTextures\CommandButtons\BTNOneHeadedOgre.blp")
  {
    AddObjective(new ObjectiveUnitIsDead(korgall));
    AddObjective(new ObjectiveSelfExists());
    AddObjective(new ObjectiveQuestResolved(previousQuest)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    ResearchId = UPGRADE_RT16_QUEST_COMPLETED_STONEMAUL_DIPLOMACY_TAUREN_TRIBES;
    _stonemaul = stonemaul;
    _rexxar = rexxar;
    _korgall = korgall;
    _rescueUnits = stonemaul.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  public override string RewardFlavour =>
    "With Kor'gall slain, the Stonemaul ogres pledge themselves to the Tauren, and Rexxar joins Cairne Bloodhoof's cause.";

  protected override string RewardDescription =>
    "Control of Stonemaul and any surviving ogres there, and Rexxar fights for you at level 5 and can be trained at the Altar";

  protected override void OnDiscovered(Faction whichFaction)
  {
    if (whichFaction.Player != null && _korgall.Alive && _rexxar.Unit == null)
    {
      _standoff = new StonemaulStandoff(whichFaction.Player, _rexxar, _korgall);
    }
  }

  protected override void OnComplete(Faction completingFaction)
  {
    var rewardedPlayer = completingFaction.Player;
    if (rewardedPlayer == null)
    {
      return;
    }

    rewardedPlayer.SetTechResearched(UPGRADE_RT21_QUEST_CONCLUDED_STONEMAUL_DIPLOMACY_TAUREN_TRIBES, 1);
    rewardedPlayer.RescueGroup(_rescueUnits);

    var survivingOgres = GlobalGroup
      .EnumUnitsInRect(_stonemaul)
      .Where(x => x.Owner == player.NeutralAggressive && x.Alive)
      .ToList();
    foreach (var ogre in survivingOgres)
    {
      ogre.Rescue(rewardedPlayer);
    }

    _standoff?.End();
    var rexxarUnit = _rexxar.Unit;
    if (rexxarUnit == null || !rexxarUnit.Alive)
    {
      _rexxar.ForceCreate(rewardedPlayer, _stonemaul.Center, 270);
    }
    else if (rexxarUnit.Owner != rewardedPlayer)
    {
      rexxarUnit.SetOwner(rewardedPlayer);
    }

    _rexxar.Unit?.SetLevel(RexxarLevel, false);
  }

  protected override void OnFail(Faction completingFaction)
  {
    _standoff?.End();
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
    completingFaction.Player?.SetTechResearched(UPGRADE_RT21_QUEST_CONCLUDED_STONEMAUL_DIPLOMACY_TAUREN_TRIBES, 1);
  }
}
