using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestEnemyEncroachment : QuestData
  {
    
    /// <inheritdoc />
    public QuestEnemyEncroachment(Faction faction) : base("Enemy Encroachment", "Hostile forces have stepped foot onto Northrend! The Frozen Throne will have to employ new powers to defend against these interlopers", @"ReplaceableTextures\CommandButtons\BTNAnimateDead.blp")
    {
      AddObjective(new ObjectiveAnyEnemyUnitInRects(new[]
      {
        Regions.Storm_Peaks,
        Regions.Central_Northrend,
        Regions.The_Basin,
        Regions.Ice_Crown,
        Regions.Fjord,
        Regions.Eastern_Northrend,
        Regions.Far_Eastern_Northrend,
        Regions.Coldarra,
        Regions.Borean_Tundra,
        Regions.IcecrownShipyard
      },faction, "Northrend", false));
      ResearchId = Constants.UPGRADE_R08L_DEACTIVATED;
    }
    
    protected override string RewardFlavour => "Frozen Throne can now use Frost Nova and Animate Dead spells to defend Northrend from invaders.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Frozen Throne gets Frost Nova and Animate Dead spells";
  }
}