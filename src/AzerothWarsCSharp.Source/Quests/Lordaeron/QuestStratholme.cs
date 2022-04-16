using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestStratholme : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    
    public QuestStratholme(Rectangle rescueRect) : base("Blackrock and Roll",
      "The Blackrock clan has taken over Alterac, they must be eliminated for the safety of Lordaeron",
      "ReplaceableTextures\\CommandButtons\\BTNChaosBlademaster.blp")
    {
      AddQuestItem(new QuestItemKillUnit(PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00B")))); //Jubei
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n019"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("hcas"), FourCC("htow")));
      AddQuestItem(new QuestItemExpire(1470));
      AddQuestItem(new QuestItemSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
      {
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
      }
    }
    
    protected override string CompletionPopup =>
      "Stratholme has been liberated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Stratholme";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits)
      {
        UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
      LegendLordaeron.LegendArthas.AddUnitDependency(LegendLordaeron.LegendStratholme.Unit);
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits)
      {
        UnitRescue(unit, Holder.Player);
      }
      LegendLordaeron.LegendArthas.AddUnitDependency(LegendLordaeron.LegendStratholme.Unit);
    }
  }
}