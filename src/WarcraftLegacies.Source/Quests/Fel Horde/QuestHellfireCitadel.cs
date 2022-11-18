using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  public sealed class QuestHellfireCitadel : QuestData
  {
    private readonly List<unit> _demonGates;
    private readonly List<unit> _rescueUnits = new();

    //Todo: mediocre flavour
    public QuestHellfireCitadel(Rectangle rescueRect, List<unit> demonGates, IEnumerable<QuestData> prerequisites) : base("The Citadel",
      "The clans holding Hellfire Citadel do not respect Magtheridon's authority yet, capture a large part of Outland to finally establish Magtheridon as the undisputable king of Outland",
      "ReplaceableTextures\\CommandButtons\\BTNFelOrcFortress.blp")
    {
      _demonGates = demonGates;
      foreach (var prerequisite in prerequisites) 
        AddObjective(new ObjectiveCompleteQuest(prerequisite));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N01J_ZANGARMARSH_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N02N_BLADE_S_EDGE_MOUNTAINS_15GOLD_MIN)));
      AddObjective(new ObjectiveUpgrade(FourCC("o030"), FourCC("o02Y")));
      AddObjective(new ObjectiveExpire(1450));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R00P_QUEST_COMPLETED_THE_CITADEL;
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE))
          _rescueUnits.Add(unit);
      Required = true;
    }

    //Todo: bad flavor
    protected override string CompletionPopup =>
      "Hellfire Citadel has been subjugated, and its military is now free to assist the Fel Horde.";

    protected override string RewardDescription =>
      "Control of all units in Hellfire Citadel and enable Kargath to be trained at the altar";

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _demonGates) unit.Rescue(completingFaction.Player);
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\FelTheme.mp3");
    }

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }
  }
}