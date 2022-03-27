using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestSilvermoon : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R02U");

    public QuestSilvermoon() : base("The Siege of Silvermoon", "Silvermoon has been besieged by Trolls. Clear them out and destroy their city of Zul'aman.", "ReplaceableTextures\\CommandButtons\\BTNForestTrollTrapper.blp")
    {
      AddQuestItem(new QuestItemKillUnit(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O00O")))); //Zul'jin
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01V"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01L"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("h033"), FourCC("h033")));
      AddQuestItem(new QuestItemExpire(1480));
      AddQuestItem(new QuestItemSelfExists());
    }
    
    protected override string CompletionPopup =>
      "Silvermoon siege has been lifted, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription =>
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
      if (UnitAlive(gg_unit_h00D_2122)) SetUnitInvulnerable(LegendQuelthalas.LegendSilvermoon.Unit, true);
      SetUnitInvulnerable(LegendQuelthalas.LegendSunwell.Unit, true);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\SilvermoonTheme.mp3");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(QuestResearchId, 1);
    }
  }
}