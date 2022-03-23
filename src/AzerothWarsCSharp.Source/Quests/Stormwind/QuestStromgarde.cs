using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestStromgarde : QuestData{

  
    private const int HERO_ID = FourCC("H00Z");
    private const int RESEARCH_ID = FourCC("R01M");
  


    private QuestItemAnyUnitInRect questItemAnyUnitInRect = 0;

    protected override string CompletionPopup => "Galen Trollbane has pledged his forces to StormwindFourCC(s cause.";

    protected override string CompletionDescription => "Control of all units at Stromgarde, the artifact TrolFourCC(kalar, && you can summon the hero Galen Trollbane from the Altar of Kings";

    private void GiveStromgarde(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;
      //Transfer all Neutral Passive units in Stromgarde
      GroupEnumUnitsInRect(tempGroup, Regions.Stromgarde.Rect, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          GeneralHelpers.UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
      }
      //Cleanup
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      GiveStromgarde(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      SetItemPosition(ARTIFACT_TROLKALAR.item, 140889, 12363);
      ARTIFACT_TROLKALAR.setStatus(ARTIFACT_STATUS_GROUND);
    }

    protected override void OnComplete(){
      GiveStromgarde(this.Holder.Player);
      GeneralHelpers.UnitAddItemSafe(questItemAnyUnitInRect.TriggerUnit, ARTIFACT_TROLKALAR.item);
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
      Holder.ModObjectLimit(HERO_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Stromgarde", "Although StromgardeFourCC("s strength has dwindled since the days of the Arathorian Empire, it remains a significant bastion of humanity. They could be convinced to mobilize their forces for Stormwind.", "ReplaceableTextures\\CommandButtons\\BTNTheCaptain.blp"");
      questItemAnyUnitInRect = QuestItemAnyUnitInRect.create(Regions.Stromgarde, "Stromgarde".Rect, true);
      this.AddQuestItem(questItemAnyUnitInRect);
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
