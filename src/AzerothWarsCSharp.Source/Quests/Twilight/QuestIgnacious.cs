using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestIgnacious : QuestData{

  
    private static readonly int ResearchId = FourCC("R07Q");
  


    protected override string CompletionPopup => "The great Ragnaros has ascended one of our shamans.";

    protected override string CompletionDescription => "You can summon Ignacious from the Altar";


    public  QuestIgnacious ( ){
      thistype this = thistype.allocate("Gift of the Firelord", "Destroying the Dwarf great forge will please the Great Elemental Lord, Ragnaros.", "ReplaceableTextures\\CommandButtons\\BTNHeroAvatarOfFlame.blp");
      AddQuestItem(new QuestItemLegendDead(LEGEND_GREATFORGE));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0AA"))));
      base.ResearchId = ResearchId;
      ;;
    }


  }
}
