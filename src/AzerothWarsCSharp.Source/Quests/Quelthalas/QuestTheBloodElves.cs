//If Quel)thalas destroys the Legion Nexus, they can train Kael)thas and Blood Mages.
//If they instead lose the Sunwell, they lose everything. If that doesn)t defeat them, they get Kael)thalas, Lorthemar, and some free units at Dalaran Dungeons.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestTheBloodElves : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R04Q");
    private const int UNITTYPE_ID = FourCC("n048");
    private const int BUILDING_ID = FourCC("n0A2");
    private const int HERO_ID = FourCC("Hkal");
  


    private static group SecondChanceUnits;

    protected override string CompletionPopup => "The Legion Nexus has been obliterated. A group of ambitious mages seize the opportunity to study the demonsFourCC( magic, becoming the first Blood Mages.";

    private string operator FailurePopup( ){
      return "The Sunwell has fallen. The survivors escape to Dalaran && name themselves the Blood Elves in remembrance of their fallen people.";
    }

    protected override string CompletionDescription => "Learn to train " + GetObjectName(UNITTYPE_ID) + "s from the Consortium, && you can summon Prince KaelFourCC(thas from the Altar of Prowess";

    private string operator FailureDescription( ){
      return "You lose everything you control, but you gain Prince KaelFourCC("thas at the Dalaran Dungeons, && you can train " + GetObjectName(UNITTYPE_ID") + "s from the Consortium";
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, QUEST_RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(Holder.Player, UNITTYPE_ID, "You can now train " + GetObjectName(UNITTYPE_ID) + "s from the " + GetObjectName(BUILDING_ID) + ".");
    }

    private void OnFail( ){
      unit u;
      player holderPlayer = this.Holder.Person.Player;
      Legend triggerLegend = GetTriggerLegend();
      LEGEND_KAEL.StartingXp = GetHeroXP(LEGEND_ANASTERIAN.Unit);
      this.Holder.obliterate();
      if (this.Holder.ScoreStatus != SCORESTATUS_DEFEATED){
        while(true){
          u = FirstOfGroup(thistype.SecondChanceUnits);
          if ( u == null){ break; }
          GeneralHelpers.UnitRescue(u, holderPlayer);
          GroupRemoveUnit(thistype.SecondChanceUnits, u);
        }
        DestroyGroup(thistype.SecondChanceUnits);
        SetPlayerTechResearched(Holder.Player, QUEST_RESEARCH_ID, 1);
        LEGEND_KAEL.Spawn(this.Holder.Player, -11410, 21975, 110);
        UnitAddItem(LEGEND_KAEL.Unit, CreateItem(FourCC("I00M"), GetUnitX(LEGEND_KAEL.Unit), GetUnitY(LEGEND_KAEL.Unit)));
        if (GetLocalPlayer() == this.Holder.Player){
          SetCameraPosition(GetRectCenterX(Regions.BloodElfSecondChanceSpawn).Rect, GetRectCenterY(gg_rct_BloodElfSecondChanceSpawn));
        }
      }
      SetTriggerLegend(triggerLegend);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, UNLIMITED);
      Holder.ModObjectLimit(UNITTYPE_ID, 6);
      Holder.ModObjectLimit(HERO_ID, 1);
    }

    private static void onInit( ){
      //Setup initially invulnerable and hidden group at Dalaran Dungeons
      group tempGroup = CreateGroup();
      unit u;
      var i = 0;
      thistype.SecondChanceUnits = CreateGroup();
      GroupEnumUnitsInRect(tempGroup, Regions.BloodElfSecondChanceSpawn.Rect, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          ShowUnit(u, false);
          SetUnitInvulnerable(u, true);
          GroupAddUnit(thistype.SecondChanceUnits, u);
        }
        GroupRemoveUnit(tempGroup, u);
        i = i + 1;
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Blood Elves", "The Elves of QuelFourCC("thalas have a deep reliance on the Sunwell")s magic. Without it, they would have to turn to darker magicks to sate themselves.", "ReplaceableTextures\\CommandButtons\\BTNHeroBloodElfPrince.blp");
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_DRAKTHARONKEEP, false));
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_ANASTERIAN, true));
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_SUNWELL, true));
      ;;
    }


  }
}
