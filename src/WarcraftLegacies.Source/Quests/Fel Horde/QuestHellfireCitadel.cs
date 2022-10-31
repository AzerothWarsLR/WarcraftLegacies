using System.Collections.Generic;
using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.ControlPointSystem;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  public sealed class QuestHellfireCitadel : QuestData
  {
    private readonly List<unit> _demonGates;
    private readonly List<unit> _rescueUnits = new();

    //Todo: mediocre flavour
    public QuestHellfireCitadel(Rectangle rescueRect, List<unit> demonGates) : base("The Citadel",
      "The clans holding Hellfire Citadel do not respect Kargath authority yet, destroy Murmur to finally establish Magtheridon as the undisputable king of Outland",
      "ReplaceableTextures\\CommandButtons\\BTNFelOrcFortress.blp")
    {
      _demonGates = demonGates;
      AddObjective(new ObjectiveLegendDead(LegendDraenei.LegendExodarship));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N01J_ZANGARMARSH_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N02N_BLADE_S_EDGE_MOUNTAINS_15GOLD_MIN)));
      AddObjective(new ObjectiveUpgrade(FourCC("o030"), FourCC("o02Y")));
      AddObjective(new ObjectiveExpire(1450));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R00P");
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE))
          _rescueUnits.Add(unit);
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