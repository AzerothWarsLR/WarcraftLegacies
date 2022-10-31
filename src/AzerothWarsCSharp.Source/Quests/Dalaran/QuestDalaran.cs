using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.Extensions;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestDalaran : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestDalaran(IEnumerable<Rectangle> rescueRects) : base("Outskirts",
      "The territories of Dalaran are fragmented, secure the lands and protect Dalaran citizens .",
      "ReplaceableTextures\\CommandButtons\\BTNArcaneCastle.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01D"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n08M"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n018"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01I"))));
      AddObjective(new ObjectiveUpgrade(FourCC("h068"), FourCC("h065")));
      AddObjective(new ObjectiveExpire(1445));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R038_QUEST_COMPLETED_OUTSKIRTS;

      foreach (var rectangle in rescueRects)
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rectangle.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Dalaran outskirs are now secure, the mages will join Dalaran.";

    protected override string RewardDescription =>
      "Control of all units in Dalaran and enables Antonidas to be trained at the Altar";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\DalaranTheme.mp3");
    }
  }
}