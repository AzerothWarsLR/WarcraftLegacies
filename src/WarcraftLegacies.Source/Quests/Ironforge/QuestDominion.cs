using System.Collections.Generic;
using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.ControlPointSystem;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Ironforge
{
  public sealed class QuestDominion : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestDominion(Rectangle rescueRect) : base("Dwarven Dominion",
      "The Dwarven Dominion must be established before Ironforge can join the war.",
      "ReplaceableTextures\\CommandButtons\\BTNNorthrendCastle.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n017"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n014"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n013"))));
      AddObjective(new ObjectiveUpgrade(FourCC("h07G"), FourCC("h07E")));
      AddObjective(new ObjectiveExpire(1462));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R043");
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "The Dwarven Empire is re-united again, Ironforge is ready for war again.";

    protected override string RewardDescription => "Control of all units in Ironforge";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player ?? Player(PLAYER_NEUTRAL_AGGRESSIVE));
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\DwarfTheme.mp3");
    }
  }
}