using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestRoyalPlunder : QuestData
  {
    private readonly List<unit> _unitsToRescue = new();
  
    public QuestRoyalPlunder(Rectangle rescueRect) : base("Royal Plunder", "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Feathermoon Stronghold falls, it would become a simple matter to slaughter the Highborne and plunder their artifacts.", "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2.blp")
    {
      AddQuestItem(new QuestItemLegendNotPermanentlyDead(LegendWarsong.LegendStonemaul));
      AddQuestItem(new QuestItemLegendDead(LegendSentinels.legendFeathermoon));
      AddQuestItem(new QuestItemAnyUnitInRect(rescueRect, "Dire Maul", true));
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
      {
        if (!ControlPointManager.UnitIsControlPoint(unit))
        {
          SetUnitInvulnerable(unit, true);
          _unitsToRescue.Add(unit);
        }
      }
    }

    protected override void OnComplete()
    {
      SetItemPosition(ArtifactSetup.ArtifactScepterofthequeen?.Item, Regions.HighBourne.Center.X, Regions.HighBourne.Center.Y);
      foreach (var unit in _unitsToRescue)
      {
        GeneralHelpers.UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
    }

    protected override string RewardDescription =>
      "Gain the Scepter of the Queen and turn all units in Dire Maul hostile";

    protected override string CompletionPopup =>
      "The Highborne are no longer implicitly defended by the Night Elven presence at Feathermoon Stronghold. The Horde unleashes their full might against these Night Elven arcanists.";
  }
}