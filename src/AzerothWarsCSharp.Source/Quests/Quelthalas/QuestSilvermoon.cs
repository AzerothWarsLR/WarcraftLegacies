using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestSilvermoon : QuestData
  {
    private readonly unit _elvenRunestone;
    private readonly List<unit> _rescueUnits = new();

    public QuestSilvermoon(Rectangle rescueRect, unit elvenRunestone) : base("The Siege of Silvermoon",
      "Silvermoon has been besieged by Trolls. Clear them out and destroy their city of Zul'aman.",
      "ReplaceableTextures\\CommandButtons\\BTNForestTrollTrapper.blp")
    {
      _elvenRunestone = elvenRunestone;
      AddQuestItem(new QuestItemKillUnit(
        PreplacedUnitSystem.GetUnit(Constants.UNIT_O00O_CHIEFTAN_OF_THE_AMANI_TRIBE_CREEP_ZUL_AMAN)));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01V"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01L"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("h03T"), FourCC("h033")));
      AddQuestItem(new QuestItemExpire(1480));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = Constants.UPGRADE_R02U_QUEST_COMPLETED_THE_SIEGE_OF_SILVERMOON;

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          _rescueUnits.Add(unit);
          SetUnitInvulnerable(unit, true);
        }
    }

    protected override string CompletionPopup =>
      "Silvermoon siege has been lifted, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "Control of all units in Silvermoon and enable Anasterian to be trained at the Altar";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, FourCC("R02U"), 1);
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
      if (UnitAlive(_elvenRunestone))
        SetUnitInvulnerable(LegendQuelthalas.LegendSilvermoon.Unit, true);
      SetUnitInvulnerable(LegendQuelthalas.LegendSunwell.Unit, true);
      if (GetLocalPlayer() == Holder.Player)
        PlayThematicMusicBJ("war3mapImported\\SilvermoonTheme.mp3");
    }
  }
}