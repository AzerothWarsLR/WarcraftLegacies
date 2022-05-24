using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestStormwindCity : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R02S");
    private readonly List<unit> _rescueUnits = new();

    public QuestStormwindCity(Rectangle rescueRect) : base("Clear the Outskirts",
      "The outskirts of Stormwind are infested by evil creatures. Kill their leaders and regain control of the Towns.",
      "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionCastle.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00V"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00Z"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n011"))));
      AddObjective(new ObjectiveUpgrade(FourCC("h06K"), FourCC("h06K")));
      AddObjective(new ObjectiveExpire(1020));
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      ResearchId = FourCC("R02S");
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Stormwind has been liberated, and its military is now free to assist the Alliance.";

    protected override string RewardDescription =>
      "Control of all units in Stormwind and enable Varian to be trained at the altar";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\StormwindTheme.mp3");
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(QuestResearchId, 1);
    }
  }
}