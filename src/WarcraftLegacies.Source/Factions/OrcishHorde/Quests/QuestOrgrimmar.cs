using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Quests;

public sealed class QuestOrgrimmar : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestOrgrimmar(Rectangle rescueRect, Faction faction, QuestData countdownToExtinction) : base("To Tame a Land",
    "This new continent is ripe for the taking. If the Horde is to survive, a new city needs to be built.",
    @"ReplaceableTextures\CommandButtons\BTNFortress.blp")
  {
    AddObjective(new ObjectiveBuildInRect(Regions.Orgrimmar, "in Orgrimmar", UNIT_OALT_ALTAR_OF_STORMS_ORCISH_HORDE_ALTAR));
    AddObjective(new ObjectiveBuildInRect(Regions.Orgrimmar, "in Orgrimmar", UNIT_OFOR_WAR_MILL_ORCISH_HORDE_RESEARCH));
    AddObjective(new ObjectiveBuildInRect(Regions.Orgrimmar, "in Orgrimmar", UNIT_OBAR_WAR_CAMP_ORCISH_HORDE_BARRACKS));
    AddObjective(new ObjectiveExpire(15, Title));
    AddObjective(new ObjectiveSelfExists());
    AddObjective(new ObjectiveFactionQuestResolved(countdownToExtinction, faction)
    {
      ShowsInPopups = false,
      ShowsInQuestLog = false,
      Progress = QuestProgress.Undiscovered
    });
    ResearchId = UPGRADE_R05R_QUEST_COMPLETED_TO_TAME_A_LAND;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The city of Orgrimmar was finally constructed by the Horde's own engineers, it is now a home for the Horde and a symbol of power and innovation.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Control of all units in Orgrimmar, and Grom Hellscream becomes trainable at the Altar of Storms.";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    var whichPlayer = completingFaction.Player;

    OrgrimmarSetup.RevealUnits();
    OrgrimmarSetup.RevealDoodads(Regions.Orgrimmar);

    if (whichPlayer != null)
    {
      whichPlayer.PlayMusicThematic("war3mapImported\\OrgrimmarTheme.mp3");

      foreach (var unit in _rescueUnits)
      {
        unit.Rescue(whichPlayer);
      }
    }
  }

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
    OrgrimmarSetup.RevealUnits();
    OrgrimmarSetup.RevealDoodads(Regions.Orgrimmar);
  }
}
