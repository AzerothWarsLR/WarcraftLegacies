using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  /// <summary>
  /// A <see cref="QuestData"/> that unlocks Blackrock when completed.
  /// </summary>
  public sealed class QuestBlackrock : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBlackrock"/> class.
    /// </summary>
    /// <param name="rescueRect"></param>
    /// <param name="prequisites"></param>
    public QuestBlackrock(Rectangle rescueRect, IEnumerable<QuestData> prequisites) : base("Blackrock Unification",
      "Make contact with the Blackrock clan and convince them to join Magtheridon",
      "ReplaceableTextures\\CommandButtons\\BTNBlackhand.blp")
    {
      foreach (var prequisite in prequisites) 
        AddObjective(new ObjectiveCompleteQuest(prequisite));
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R090_ACTIVATE_THE_BLACKROCK_CLAN_FEL, Constants.UNIT_O008_HELLFIRE_CITADEL_FEL_HORDE));
      AddObjective(new ObjectiveExpire(1451));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R03C_QUEST_COMPLETED_BLACKROCK_UNIFICATION;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      Required = true;
    }

    //Todo: bad flavour
    /// <inheritdoc />
    protected override string RewardFlavour =>
      "Blackrock Citadel has been subjugated, and its military is now free to assist the Fel Horde.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units in Blackrock Citadel and enable Dal'rend Blackhand to be trained at the altar";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction) => 
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction) => 
      completingFaction.Player.RescueGroup(_rescueUnits);

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction) => 
      whichFaction.ModObjectLimit(Constants.UPGRADE_R090_ACTIVATE_THE_BLACKROCK_CLAN_FEL, Faction.UNLIMITED);
  }
}