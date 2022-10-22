using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestCorruptArthas : QuestData
  {
    private static readonly int HeroId = FourCC("Uear");
    private static readonly int ResearchId = FourCC("R01K");

    public QuestCorruptArthas() : base("The Culling",
      "When the city of Stratholme, Prince Arthas will abandon his people and join the Scourge as their champion.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroDeathKnight.blp")
    {
      AddObjective(new ObjectiveLegendDead(LegendLordaeron.LegendStratholme));
      AddObjective(new ObjectiveEitherOf(new ObjectiveLegendDead(LegendLordaeron.LegendArthas),
        new ObjectiveFactionDefeated(LordaeronSetup.Lordaeron)));
      AddObjective(new ObjectiveSelfExists());
      Required = true;
    }


    protected override string CompletionPopup =>
      "Having failed to protect his people, Arthas seizes the cursed runeblade Frostmourne as the instrument of his vengeance. The malevolence of the blade overwhelms him. Arthas is now a loyal Death Knight of the Scourge, and will soon become its greatest champion.";

    protected override string RewardDescription => "You can train Arthas Menethil from the Altar of Darkness";

    protected override void OnComplete(Faction completingFaction)
    {
      LegendLordaeron.LegendArthas.Unit.DropAllItems();
      RemoveUnit(LegendLordaeron.LegendArthas.Unit);
      LegendLordaeron.LegendArthas.Unit = null;
      LegendLordaeron.LegendArthas.PlayerColor = PLAYER_COLOR_PURPLE;
      LegendLordaeron.LegendArthas.StartingXp = 7000;
      LegendLordaeron.LegendArthas.UnitType = FourCC("Uear");
      LegendLordaeron.LegendArthas.ClearUnitDependencies();
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
      whichFaction.ModObjectLimit(HeroId, 1);
    }
  }
}