using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestSilvermoon : QuestData
  {
    private unit _elvenRunestone;
    
    public QuestSilvermoon(unit elvenRunestone) : base("The Siege of Silvermoon",
      "Silvermoon has been besieged by Trolls. Clear them out and destroy their city of Zul'aman.",
      "ReplaceableTextures\\CommandButtons\\BTNForestTrollTrapper.blp")
    {
      _elvenRunestone = elvenRunestone;
      AddQuestItem(new QuestItemKillUnit(
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_O00O_CHIEFTAN_OF_THE_AMANI_TRIBE_CREEP_ZUL_AMAN)));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01V"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01L"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("h033"), FourCC("h033")));
      AddQuestItem(new QuestItemExpire(1480));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = Constants.UPGRADE_R02U_QUEST_COMPLETED_THE_SIEGE_OF_SILVERMOON;
    }

    protected override string CompletionPopup =>
      "Silvermoon siege has been lifted, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "Control of all units in Silvermoon and enable Anasterian to be trained at the Altar";

    private static void GrantSilvermoon(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Silvermoon
      GroupEnumUnitsInRect(tempGroup, Regions.SunwellAmbient.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) UnitRescue(u, whichPlayer);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnFail()
    {
      GrantSilvermoon(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, FourCC("R02U"), 1);
      GrantSilvermoon(Holder.Player);
      if (UnitAlive(_elvenRunestone))
        SetUnitInvulnerable(LegendQuelthalas.LegendSilvermoon.Unit, true);
      SetUnitInvulnerable(LegendQuelthalas.LegendSunwell.Unit, true);
      if (GetLocalPlayer() == Holder.Player)
        PlayThematicMusicBJ("war3mapImported\\SilvermoonTheme.mp3");
    }
  }
}