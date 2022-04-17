using System.Collections.Generic;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestThelsamar : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestThelsamar(Rectangle rescueRect) : base("Murloc Menace",
      "A vile group of Murloc is terrorizing Thelsamar. Destroy them!",
      "ReplaceableTextures\\CommandButtons\\BTNMurlocNightCrawler.blp")
    {
      AddQuestItem(new QuestItemKillUnit(PreplacedUnitSystem.GetUnitByUnitType(FourCC("N089")))); //Murloc
      AddQuestItem(new QuestItemExpire(1435));
      AddQuestItem(new QuestItemSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
      {
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
      }
    }

    protected override string CompletionPopup => "The Murlocs have been defeated, Thelsamar will join your cause.";

    protected override string RewardDescription => "Control of all units in Thelsamar";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits)
      {
        UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits)
      {
        UnitRescue(unit, Holder.Player);
      }
    }
  }
}