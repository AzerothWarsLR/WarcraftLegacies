using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public class QuestSummonLegion{

  
    private const int RITUAL_ID = FourCC(A00J);
  


    private bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "Tremble, mortals, && despair. Doom has come to this world.";
    }

    protected override string CompletionDescription => 
      return "The hero Archimonde, control of all units in the Twisting Nether, && learn to train Greater Demons";
    }

    private void OnAdd( ){
      if (Holder.UndefeatedResearch == 0){
        BJDebugMsg("ERROR: " + Holder.Name + " has no presence research. QuestSummonLegion wonFourCC(t work");
      }
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Under the Burning Sky", "The greater forces of the Burning Legion lie in wait in the vast expanse of the Twisting Nether. Use the Book of Medivh to tear open a hole in space-time, && visit the full might of the Legion upon Azeroth.", "ReplaceableTextures\\CommandButtons\\BTNArchimonde.blp");
      this.AddQuestItem(QuestItemCastSpell.create(RITUAL_ID, false));
      this.ResearchId = FourCC(R04B);
      ;;
    }


  }
}
