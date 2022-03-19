using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Stormwind
{
  public class QuestStromgarde{

  
    private const int HERO_ID = FourCC(H00Z);
    private const int RESEARCH_ID = FourCC(R01M);
  


    private QuestItemAnyUnitInRect questItemAnyUnitInRect = 0;

    protected override string CompletionPopup => 
      return "Galen Trollbane has pledged his forces to StormwindFourCC(s cause.";
    }

    protected override string CompletionDescription => 
      return "Control of all units at Stromgarde, the artifact TrolFourCC(kalar, && you can summon the hero Galen Trollbane from the Altar of Kings";
    }

    private void GiveStromgarde(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;
      //Transfer all Neutral Passive units in Stromgarde
      GroupEnumUnitsInRect(tempGroup, gg_rct_Stromgarde, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, whichPlayer);
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
      UnitAddItemSafe(questItemAnyUnitInRect.TriggerUnit, ARTIFACT_TROLKALAR.item);
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
      Holder.ModObjectLimit(HERO_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Stromgarde", "Although StromgardeFourCC(s strength has dwindled since the days of the Arathorian Empire, it remains a significant bastion of humanity. They could be convinced to mobilize their forces for Stormwind.", "ReplaceableTextures\\CommandButtons\\BTNTheCaptain.blp");
      questItemAnyUnitInRect = QuestItemAnyUnitInRect.create(gg_rct_Stromgarde, "Stromgarde", true);
      this.AddQuestItem(questItemAnyUnitInRect);
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
