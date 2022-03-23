//Frostwolf kills the Sea Witch. Thrall gets some boats to leave the Darkspear Isles.
//Presently this ONLY deals with the final component of the event. The rest is done in GUI.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestSeaWitch : QuestData{

  
    private weathereffect Storm;
    private const int QUEST_RESEARCH_ID = FourCC("R05H");
  


    protected override string CompletionPopup => "The sea witch ZarFourCC("jira has been slain. Thrall && Vol")jin can now sail.";

    protected override string CompletionDescription => "Gain control of all neutral units on the Darkspear Isles && teleport to shore";

    private void OnFail( ){
      RescueNeutralUnitsInRect(Regions.EchoUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      Person killingPerson = Person.ByHandle(GetOwningPlayer(GetKillingUnit()));
      group tempGroup = CreateGroup();
      unit u;
      //Transfer control of all passive units on island and teleport all Frostwolf units to shore
      RescueNeutralUnitsInRect(Regions.CairneStart.Rect, Holder.Player);
      GroupEnumUnitsInRect(tempGroup, Regions.Darkspear_Island.Rect, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, Holder.Player);
        }
        if (GetOwningPlayer(u) == FACTION_FROSTWOLF.Player && IsUnitType(u, UNIT_TYPE_STRUCTURE) == false){
          SetUnitPosition(u, GetRandomReal(GetRectMinX(Regions.ThrallLanding), GetRectMaxX(gg_rct_ThrallLanding)), GetRandomReal(GetRectMinY(gg_rct_ThrallLanding).Rect, GetRectMaxY(gg_rct_ThrallLanding)));
        }
        GroupRemoveUnit(tempGroup, u);
      }
      DestroyGroup(tempGroup);
      RemoveWeatherEffectBJ(Storm);
      CreateUnits(Holder.Player, FourCC("opeo"), -1818, -2070, 270, 3);
      RescueNeutralUnitsInRect(Regions.EchoUnlock.Rect, Holder.Player);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Riders on the Storm", "Warchief Thrall && his forces have been shipwrecked on the Darkspear Isles. Kill the Sea Witch there to give them a chance to rebuild their fleet && escape.", "ReplaceableTextures\\CommandButtons\\BTNGhost.blp");
      AddQuestItem(new QuestItemKillUnit(LEGEND_SEAWITCH.Unit));
      AddQuestItem(new QuestItemExpire(600));
      ResearchId = QUEST_RESEARCH_ID;
      ;;
    }

    private static void onInit( ){
      Storm = AddWeatherEffect(Regions.Darkspear_Island.Rect, FourCC("RAhr"));
      EnableWeatherEffect(Storm, true);
    }


  }
}
