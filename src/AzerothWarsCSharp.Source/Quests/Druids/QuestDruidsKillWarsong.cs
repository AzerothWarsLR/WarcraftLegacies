using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public class QuestDruidsKillWarsong{

  
    private const int UNITTYPE_ID = FourCC(e012) ;//Siege Ancient
    private const int RESEARCH_ID = FourCC(R05A) ;//Research enabling Siege Ancient
  


    protected override string CompletionPopup => 
      return "The Warsong presence on Kalimdor has been eliminated. The sacred lands are safe from their hatchets.";
    }

    protected override string CompletionDescription => 
      return "Learn to train " + GetObjectName(UNITTYPE_ID) + "s";
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(this.Holder.Player, UNITTYPE_ID, "You can now train Siege Ancients at the Ancient of War.");
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(UNITTYPE_ID, 6) ;//Siege Ancient
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Enemies at the Gate", "Arriving from another planet && across the seas of Azeroth, the Orcs of the Warsong Clan have arrived to ravage the wilderness && consume its bounty. They must be stopped.", "ReplaceableTextures\\CommandButtons\\BTNHellScream.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_STONEMAUL));
      ;;
    }


  }
}
