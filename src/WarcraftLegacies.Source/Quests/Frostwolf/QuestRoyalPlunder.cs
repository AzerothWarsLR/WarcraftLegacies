using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  public sealed class QuestRoyalPlunder : QuestData
  {
    private readonly List<unit> _unitsToRescue = new();

    public QuestRoyalPlunder(Rectangle rescueRect) : base("Royal Plunder",
      "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Feathermoon Stronghold falls, it would become a simple matter to slaughter the Highborne and plunder their artifacts.",
      "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2.blp")
    {
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendWarsong.StonemaulKeep));
      AddObjective(new ObjectiveLegendDead(LegendSentinels.Feathermoon));
      AddObjective(new ObjectiveAnyUnitInRect(rescueRect, "Dire Maul", true));
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (!ControlPointManager.UnitIsControlPoint(unit))
        {
          SetUnitInvulnerable(unit, true);
          _unitsToRescue.Add(unit);
        }
    }

    protected override string RewardDescription =>
      "Gain the Scepter of the Queen and turn all units in Dire Maul hostile";

    protected override string CompletionPopup =>
      "The Highborne are no longer implicitly defended by the Night Elven presence at Feathermoon Stronghold. The Horde unleashes their full might against these Night Elven arcanists.";

    protected override void OnComplete(Faction completingFaction)
    {
      SetItemPosition(ArtifactSetup.ArtifactScepterofthequeen?.Item, Regions.HighBourne.Center.X,
        Regions.HighBourne.Center.Y);
      foreach (var unit in _unitsToRescue) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }
  }
}