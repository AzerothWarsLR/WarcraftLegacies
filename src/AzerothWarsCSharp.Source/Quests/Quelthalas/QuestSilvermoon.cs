using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestSilvermoon : QuestData{

  
    private static readonly int QuestResearchId = FourCC("R02U");
  


    protected override string CompletionPopup => "Silvermoon siege has been lifted, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Silvermoon && enable Anasterian to be trained at the Altar";

    private void GrantSilvermoon(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Silvermoon
      GroupEnumUnitsInRect(tempGroup, Regions.SunwellAmbient.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    protected override void OnFail( ){
      GrantSilvermoon(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, FourCC("R02U"), 1);
      GrantSilvermoon(Holder.Player);
      if (UnitAlive(gg_unit_h00D_2122)){
        SetUnitInvulnerable(LEGEND_SILVERMOON.Unit, true );
      }
      SetUnitInvulnerable(LEGEND_SUNWELL.Unit, true );
      if (GetLocalPlayer() == Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\SilvermoonTheme.mp3" );
      }
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(QuestResearchId, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Siege of Silvermoon", "Silvermoon has been besieged by Trolls. Clear them out && destroy their city of ZulFourCC("aman.", "ReplaceableTextures\\CommandButtons\\BTNForestTrollTrapper.blp"");
      AddQuestItem(QuestItemKillUnit.create(gg_unit_O00O_1933)) ;//Zul)jin
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01V"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01L"))));
      this.AddQuestItem(new QuestItemUpgrade(FourCC("h03T"), )h033)));
      AddQuestItem(new QuestItemExpire(1480));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
