using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestCorruptArthas : QuestData{

  
    private static readonly int HeroId = FourCC("Uear");
    private static readonly int ResearchId = FourCC("R01K");
  


    protected override string CompletionPopup => "Having failed to protect his people, Arthas seizes the cursed runeblade Frostmourne as the instrument of his vengeance. The malevolence of the blade overwhelms him. Arthas is now a loyal Death Knight of the Scourge, && will soon become its greatest champion.";

    protected override string CompletionDescription => "You can train Arthas Menethil from the Altar of Darkness";

    protected override void OnComplete(){
      UnitDropAllItems(LEGEND_ARTHAS.Unit);
      RemoveUnit(LEGEND_ARTHAS.Unit);
      LEGEND_ARTHAS.Unit = null;
      LEGEND_ARTHAS.PlayerColor = PLAYER_COLOR_PURPLE;
      LEGEND_ARTHAS.StartingXp = 7000;
      LEGEND_ARTHAS.UnitType = FourCC("Uear");
      LEGEND_ARTHAS.ClearUnitDependencies();
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(ResearchId, UNLIMITED);
      Holder.ModObjectLimit(HeroId, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Culling", "When the city of Stratholme, Prince Arthas will abandon his people && join the Scourge as their champion.", "ReplaceableTextures\\CommandButtons\\BTNHeroDeathKnight.blp");
      AddQuestItem(new QuestItemLegendDead(LEGEND_STRATHOLME));
      this.AddQuestItem(new QuestItemEitherOf.create(QuestItemLegendDead.create(LEGEND_ARTHAS), QuestItemFactionDefeated(FACTION_LORDAERON)));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
