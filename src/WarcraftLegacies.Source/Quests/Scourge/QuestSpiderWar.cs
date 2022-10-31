using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestSpiderWar : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R03A");
    private readonly List<unit> _rescueUnits = new();

    public QuestSpiderWar(Rectangle rescueRect, unit spiderQueen) : base("War of the Spider",
      "The proud Nerubians have declared war on the newly formed Lich King, destroy them to secure the continent of Northrend.",
      "ReplaceableTextures\\CommandButtons\\BTNNerubianQueen.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00I"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n08D"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00G"))));
      AddObjective(new ObjectiveKillUnit(spiderQueen));
      AddObjective(new ObjectiveUpgrade(FourCC("unp2"), FourCC("unp1")));
      AddObjective(new ObjectiveExpire(1480));
      AddObjective(new ObjectiveSelfExists());

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      Required = true;
    }

    protected override string CompletionPopup =>
      "Northrend and the Icecrown Citadel is now under full control of the Lich King and the Scourge.";

    protected override string RewardDescription =>
      "Access to the Plague Research at the Frozen Throne, Kel'thuzad and Rivendare trainable and a base in Icecrown";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      SetPlayerTechResearched(completingFaction.Player, FourCC("R03A"), 1);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\ScourgeTheme.mp3");
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(QuestResearchId, 1);
    }
  }
}