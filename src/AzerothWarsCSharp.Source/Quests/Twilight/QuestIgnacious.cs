using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public class QuestIgnacious{

  
    private const int RESEARCH_ID = FourCC("R07Q");
  


    protected override string CompletionPopup => 
      return "The great Ragnaros has ascended one of our shamans.";
    }

    protected override string CompletionDescription => 
      return "You can summon Ignacious from the Altar";
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Gift of the Firelord", "Destroying the Dwarf great forge will please the Great Elemental Lord, Ragnaros.", "ReplaceableTextures\\CommandButtons\\BTNHeroAvatarOfFlame.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_GREATFORGE));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC("n0AA"))));
      this.ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
