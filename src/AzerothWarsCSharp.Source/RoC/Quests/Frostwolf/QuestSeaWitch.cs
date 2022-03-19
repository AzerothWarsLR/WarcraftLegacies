//Frostwolf kills the Sea Witch. Thrall gets some boats to leave the Darkspear Isles.
//Presently this ONLY deals with the final component of the event. The rest is done in GUI.

using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Frostwolf
{
  public class QuestSeaWitch{

  
    private weathereffect Storm;
    private const int QUEST_RESEARCH_ID = FourCC(R05H);
  


    protected override string CompletionPopup => 
      return "The sea witch ZarFourCC(jira has been slain. Thrall && Vol)jin can now sail.";
    }

    protected override string CompletionDescription => 
      return "Gain control of all neutral units on the Darkspear Isles && teleport to shore";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_EchoUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      Person killingPerson = Person.ByHandle(GetOwningPlayer(GetKillingUnit()));
      group tempGroup = CreateGroup();
      unit u;
      //Transfer control of all passive units on island and teleport all Frostwolf units to shore
      RescueNeutralUnitsInRect(gg_rct_CairneStart, this.Holder.Player);
      GroupEnumUnitsInRect(tempGroup, gg_rct_Darkspear_Island, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, this.Holder.Player);
        }
        if (GetOwningPlayer(u) == FACTION_FROSTWOLF.Player && IsUnitType(u, UNIT_TYPE_STRUCTURE) == false){
          SetUnitPosition(u, GetRandomReal(GetRectMinX(gg_rct_ThrallLanding), GetRectMaxX(gg_rct_ThrallLanding)), GetRandomReal(GetRectMinY(gg_rct_ThrallLanding), GetRectMaxY(gg_rct_ThrallLanding)));
        }
        GroupRemoveUnit(tempGroup, u);
      }
      DestroyGroup(tempGroup);
      RemoveWeatherEffectBJ(Storm);
      CreateUnits(this.Holder.Player, FourCC(opeo), -1818, -2070, 270, 3);
      RescueNeutralUnitsInRect(gg_rct_EchoUnlock, this.Holder.Player);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Riders on the Storm", "Warchief Thrall && his forces have been shipwrecked on the Darkspear Isles. Kill the Sea Witch there to give them a chance to rebuild their fleet && escape.", "ReplaceableTextures\\CommandButtons\\BTNGhost.blp");
      this.AddQuestItem(QuestItemKillUnit.create(LEGEND_SEAWITCH.Unit));
      this.AddQuestItem(QuestItemExpire.create(600));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }

    private static void onInit( ){
      Storm = AddWeatherEffect(gg_rct_Darkspear_Island, FourCC(RAhr));
      EnableWeatherEffect(Storm, true);
    }


  }
}
