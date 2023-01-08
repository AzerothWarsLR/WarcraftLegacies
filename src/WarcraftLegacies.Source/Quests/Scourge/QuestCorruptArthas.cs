using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestCorruptArthas : QuestData
  {
    private static readonly int HeroId = FourCC("Uear");
    private static readonly int ResearchId = FourCC("R01K");

    public QuestCorruptArthas() : base("The Culling",
      "When the city of Stratholme falls, Prince Arthas will abandon his people and join the Scourge as their champion.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroDeathKnight.blp")
    {
      AddObjective(new ObjectiveCapitalDead(LegendLordaeron.Stratholme));
      AddObjective(new ObjectiveEitherOf(new ObjectiveLegendDead(LegendLordaeron.Arthas),
        new ObjectiveFactionDefeated(LordaeronSetup.Lordaeron)));
      AddObjective(new ObjectiveSelfExists());
      Required = true;
    }


    protected override string CompletionPopup =>
      "Having failed to protect his people, Arthas seizes the cursed runeblade Frostmourne as the instrument of his vengeance. The malevolence of the blade overwhelms him. Arthas is now a loyal Death Knight of the Scourge, and will soon become its greatest champion.";

    protected override string RewardDescription => "You can train Arthas Menethil from the Altar of Darkness";

    protected override void OnComplete(Faction completingFaction)
    {
      LegendLordaeron.Arthas.Unit.DropAllItems();
      RemoveUnit(LegendLordaeron.Arthas.Unit);
      LegendLordaeron.Arthas.Unit = null;
      LegendLordaeron.Arthas.PlayerColor = PLAYER_COLOR_PURPLE;
      LegendLordaeron.Arthas.StartingXp = 7000;
      LegendLordaeron.Arthas.UnitType = Constants.UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE;
      LegendLordaeron.Arthas.ClearUnitDependencies();
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
      whichFaction.ModObjectLimit(HeroId, 1);
    }
  }
}