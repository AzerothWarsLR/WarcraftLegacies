using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
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

  public QuestStonemaulDiplomacy(Rectangle stonemaul, unit korgall, LegendaryHero rexxar, QuestData previousQuest) : base(
    "Stonemaul Diplomacy",
    "Kor'gall, the brutish warchief of the Stonemaul ogres, refuses to parley with the Tauren. Rexxar, who has long walked among the ogres, will lend his aid if the tyrant is brought down.",
    @"ReplaceableTextures\CommandButtons\BTNOneHeadedOgre.blp")
  {
    AddObjective(new ObjectiveUnitIsDead(korgall));
    AddObjective(new ObjectiveControlPoint(UNIT_N022_STONEMAUL));
    AddObjective(new ObjectiveSelfExists());
    AddObjective(new ObjectiveQuestComplete(previousQuest)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    ResearchId = UPGRADE_RT16_QUEST_COMPLETED_STONEMAUL_DIPLOMACY_TAUREN_TRIBES;
    _stonemaul = stonemaul;
    _rexxar = rexxar;
    _rescueUnits = stonemaul.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  public override string RewardFlavour =>
    "With Kor'gall slain, the Stonemaul ogres pledge themselves to the Tauren, and Rexxar joins Cairne Bloodhoof's cause.";

  protected override string RewardDescription =>
    "Control of Stonemaul and any surviving ogres there, and Rexxar joins you at level 5 and can be trained at the Altar";

  protected override void OnComplete(Faction completingFaction)
  {
    var rewardedPlayer = completingFaction.Player;
    if (rewardedPlayer == null)
    {
      return;
    }

    rewardedPlayer.RescueGroup(_rescueUnits);

    var survivingOgres = GlobalGroup
      .EnumUnitsInRect(_stonemaul)
      .Where(x => x.Owner == player.NeutralAggressive && x.Alive)
      .ToList();
    foreach (var ogre in survivingOgres)
    {
      ogre.Rescue(rewardedPlayer);
    }

    _rexxar.ForceCreate(rewardedPlayer, _stonemaul.Center, 270);
    _rexxar.Unit?.SetLevel(RexxarLevel, false);
  }

  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }
}
