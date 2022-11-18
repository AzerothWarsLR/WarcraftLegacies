using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  public sealed class QuestBlackrock : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestBlackrock(Rectangle rescueRect, IEnumerable<QuestData> prequisites) : base("Blackrock Unification",
      "Make contact with the Blackrock clan and convince them to join Magtheridon",
      "ReplaceableTextures\\CommandButtons\\BTNBlackhand.blp")
    {
      foreach (var prequisite in prequisites) 
        AddObjective(new ObjectiveCompleteQuest(prequisite));
      AddObjective(new ObjectiveResearch(FourCC("R090"), FourCC("o00F")));
      AddObjective(new ObjectiveExpire(1451));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R03C_QUEST_COMPLETED_BLACKROCK_UNIFICATION;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      Required = true;
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Blackrock Citadel has been subjugated, and its military is now free to assist the Fel Horde.";

    protected override string RewardDescription =>
      "Control of all units in Blackrock Citadel and enable Dal'rend Blackhand to be trained at the altar";

    protected override void OnFail(Faction completingFaction) => 
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);

    protected override void OnComplete(Faction completingFaction) => 
      completingFaction.Player?.RescueGroup(_rescueUnits);
  }
}