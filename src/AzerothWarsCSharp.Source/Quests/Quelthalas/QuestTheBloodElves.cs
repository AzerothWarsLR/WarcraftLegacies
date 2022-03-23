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

  
    private static readonly int QuestResearchId = FourCC("R04Q");
    private static readonly int UnittypeId = FourCC("n048");
    private static readonly int BuildingId = FourCC("n0A2");
    private static readonly int HeroId = FourCC("Hkal");
  


    private static group _secondChanceUnits;

    protected override string CompletionPopup => "The Legion Nexus has been obliterated. A group of ambitious mages seize the opportunity to study the demonsFourCC( magic, becoming the first Blood Mages.";

    private string operator FailurePopup( ){
      return "The Sunwell has fallen. The survivors escape to Dalaran && name themselves the Blood Elves in remembrance of their fallen people.";
    }

    protected override string CompletionDescription => "Learn to train " + GetObjectName(UnittypeId) + "s from the Consortium, && you can summon Prince KaelFourCC(thas from the Altar of Prowess";

    private string operator FailureDescription( ){
      return "You lose everything you control, but you gain Prince KaelFourCC("thas at the Dalaran dungeons, && you can train " + GetObjectName(UNITTYPE_ID") + "s from the Consortium";
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, QuestResearchId, 1);
      DisplayUnitTypeAcquired(Holder.Player, UnittypeId, "You can now train " + GetObjectName(UnittypeId) + "s from the " + GetObjectName(BuildingId) + ".");
    }

    protected override void OnFail( ){
      unit u;
      player holderPlayer = Holder.Person.Player;
      Legend triggerLegend = GetTriggerLegend();
      LEGEND_KAEL.StartingXp = GetHeroXP(LEGEND_ANASTERIAN.Unit);
      Holder.obliterate();
      if (Holder.ScoreStatus != SCORESTATUS_DEFEATED){
        while(true){
          u = FirstOfGroup(thistype.SecondChanceUnits);
          if ( u == null){ break; }
          UnitRescue(u, holderPlayer);
          GroupRemoveUnit(thistype.SecondChanceUnits, u);
        }
        DestroyGroup(thistype.SecondChanceUnits);
        SetPlayerTechResearched(Holder.Player, QuestResearchId, 1);
        LEGEND_KAEL.Spawn(Holder.Player, -11410, 21975, 110);
        UnitAddItem(LEGEND_KAEL.Unit, CreateItem(FourCC("I00M"), GetUnitX(LEGEND_KAEL.Unit), GetUnitY(LEGEND_KAEL.Unit)));
        if (GetLocalPlayer() == Holder.Player){
          SetCameraPosition(GetRectCenterX(Regions.BloodElfSecondChanceSpawn).Rect, GetRectCenterY(gg_rct_BloodElfSecondChanceSpawn));
        }
      }
      SetTriggerLegend(triggerLegend);
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(QuestResearchId, UNLIMITED);
      Holder.ModObjectLimit(UnittypeId, 6);
      Holder.ModObjectLimit(HeroId, 1);
    }

    private static void OnInit( ){
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
      AddQuestItem(new QuestItemControlLegend(LEGEND_DRAKTHARONKEEP, false));
      AddQuestItem(new QuestItemControlLegend(LEGEND_ANASTERIAN, true));
      AddQuestItem(new QuestItemControlLegend(LEGEND_SUNWELL, true));
      
    }


  }
}
