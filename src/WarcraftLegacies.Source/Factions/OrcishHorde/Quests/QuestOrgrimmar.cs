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
  private const int RequiredResearchId = UPGRADE_R05O_BUILD_ORGRIMMAR_WARSONG;

  public QuestOrgrimmar(Rectangle rescueRect, Faction faction, QuestData countdownToExtinction) : base("To Tame a Land",
    "This new continent is ripe for the taking. If the Horde is to survive, a new city needs to be built.",
    @"ReplaceableTextures\CommandButtons\BTNFortress.blp")
  {
    AddObjective(new ObjectiveResearch(RequiredResearchId, UNIT_O07G_FORTRESS_ORCISH_HORDE_T3));
    AddObjective(new ObjectiveExpire(13, Title));
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
    "Control of all units in Orgrimmar.";

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

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(RequiredResearchId, 1);
  }
}
