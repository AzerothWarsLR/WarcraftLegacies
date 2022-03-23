using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestStromgarde : QuestData{

  
    private static readonly int HeroId = FourCC("H00Z");
    private static readonly int ResearchId = FourCC("R01M");
  


    private QuestItemAnyUnitInRect _questItemAnyUnitInRect = 0;

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
      GiveStromgarde(Holder.Player);
      UnitAddItemSafe(_questItemAnyUnitInRect.TriggerUnit, ARTIFACT_TROLKALAR.item);
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(ResearchId, UNLIMITED);
      Holder.ModObjectLimit(HeroId, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Stromgarde", "Although StromgardeFourCC("s strength has dwindled since the days of the Arathorian Empire, it remains a significant bastion of humanity. They could be convinced to mobilize their forces for Stormwind.", "ReplaceableTextures\\CommandButtons\\BTNTheCaptain.blp"");
      _questItemAnyUnitInRect = QuestItemAnyUnitInRect.create(Regions.Stromgarde, "Stromgarde".Rect, true);
      this.AddQuestItem(_questItemAnyUnitInRect);
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
