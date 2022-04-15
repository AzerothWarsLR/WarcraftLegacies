using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestCapitalCity : QuestData
  {
    private readonly unit _unitToMakeInvulnerable;
    private readonly List<unit> _rescueUnits = new();

    public QuestCapitalCity(Rectangle rescueRect, unit unitToMakeInvulnerable) : base("Hearthlands",
      "The territories of Lordaeron are fragmented. Regain control of the old Alliance's hold to secure the kingdom.",
      "ReplaceableTextures\\CommandButtons\\BTNCastle.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendCaerdarrow, false));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01M"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01C"))));
      AddQuestItem(new QuestItemExpire(1472));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R04Y");
      _unitToMakeInvulnerable = unitToMakeInvulnerable;
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
      "Capital City has been liberated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Capital City";

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
        UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
      SetUnitInvulnerable(_unitToMakeInvulnerable, true);
      if (GetLocalPlayer() == Holder.Player) 
        PlayThematicMusicBJ("war3mapImported\\CapitalCity.mp3");
    }
  }
}