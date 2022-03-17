using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests
{
  public class QuestScepterOfTheQueen{


    private string operator CompletionPopup( ){
      return "The Highborne are no longer implicitly defended by the Night Elven presence at Feathermoon Stronghold. The Horde unleashes their full might against these Night Elven arcanists.";
    }

    private string operator CompletionDescription( ){
      return "Gain the Scepter of the Queen && turn all units in Dire Maul hostile";
    }

    private void OnComplete( ){
      SetItemPosition(ARTIFACT_SCEPTEROFTHEQUEEN.item, GetRectCenterX(gg_rct_HighBourne), GetRectCenterY(gg_rct_HighBourne));
      RescueNeutralUnitsInRect(gg_rct_HighBourne, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Royal Plunder", "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Feathermoon Stronghold falls, it would become a simple matter to slaughter the Highborne && plunder their artifacts.", "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2blp");
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_STONEMAUL));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_FEATHERMOON));
      this.AddQuestItem(QuestItemAnyUnitInRect.create(gg_rct_HighBourne, "Dire Maul", true));
      ;;
    }



    private static int researchId = FourCC(R02O);

    private string operator CompletionPopup( ){
      return "The ShenFourCC(dralar, the Highborne survivors of the Sundering, swear allegiance to their fellow Night Elves. As a sign of their loyalty, they offer up an artifact they have guarded for thousands of years: the Scepter of the Queen.";
    }

    private string operator CompletionDescription( ){
      return "Gain the Scepter of the Queen && control of all units in Dire Maul";
    }

    private void OnFail( ){
      this.Holder.ModObjectLimit(thistype.researchId, -UNLIMITED);
    }

    private void OnComplete( ){
      SetItemPosition(ARTIFACT_SCEPTEROFTHEQUEEN.item, GetRectCenterX(gg_rct_HighBourne), GetRectCenterY(gg_rct_HighBourne));
      RescueNeutralUnitsInRect(gg_rct_HighBourne, this.Holder.Player);
      SetPlayerTechResearched(this.Holder.Player, thistype.researchId, 1);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(thistype.researchId, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Return to the Fold", "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Stonemaul falls, it would be safe for them to come out.", "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2blp");
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_FEATHERMOON));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_STONEMAUL));
      this.AddQuestItem(QuestItemAnyUnitInRect.create(gg_rct_HighBourne, "Dire Maul", true));
      ;;
    }


    private static void OnInit( ){
      //Make the Shen)dralar starting units invulnerable
      group tempGroup = CreateGroup();
      unit u;
      GroupEnumUnitsInRect(tempGroup, gg_rct_HighBourne, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          SetUnitInvulnerable(u, true);
        }
        GroupRemoveUnit(tempGroup, u);
      }
    }

  }
}
