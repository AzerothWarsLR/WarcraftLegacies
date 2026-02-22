using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Rocks;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Warsong;


public sealed class QuestOrgrimmar : QuestData
{
  private readonly List<unit> _rescueUnits;
  private const int RequiredResearchId = UPGRADE_R05O_BUILD_ORGRIMMAR_WARSONG;
  private readonly List<RockGroup> _rockGroups;

  public QuestOrgrimmar(Rectangle rescueRect) : base("To Tame a Land",
    "This new continent is ripe for the taking. If the Horde is to survive, a new city needs to be built.",
    @"ReplaceableTextures\CommandButtons\BTNFortress.blp")
  {
    AddObjective(new ObjectiveResearch(RequiredResearchId, UNIT_O02S_FORTRESS_WARSONG_T3));
    AddObjective(new ObjectiveExpire(13, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R05R_QUEST_COMPLETED_TO_TAME_A_LAND;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    _rockGroups = new List<RockGroup>();
    RegisterRockGroups();
  }

  private void RegisterRockGroups()
  {
    _rockGroups.Add(new RockGroup(Regions.KaliRock12, FourCC("LTrc")));
    foreach (var rockGroup in _rockGroups)
    {
      RockSystem.Register(rockGroup);
    }
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The city of Orgrimmar was finally constructed by the Warsong engineers, it is now a home for the new Horde and a symbol of power and innovation. The Warchief has rewarded us generously for our work!";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"Control of all units in Orgrimmar and can now train Varok and Azerite Siege Engines";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(completingFaction.Player);
    }

    completingFaction.Player?.PlayMusicThematic("war3mapImported\\OrgrimmarTheme.mp3");
    CleanupRocks();
  }

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(RequiredResearchId, 1);
  }

  private void CleanupRocks()
  {
    foreach (var rockGroup in _rockGroups)
    {
      RockSystem.Remove(rockGroup);
    }
  }
}
