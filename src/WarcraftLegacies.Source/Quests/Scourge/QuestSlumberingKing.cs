using MacroTools.Extensions;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestSlumberingKing : QuestData
  {
    private readonly ObjectiveAnyEnemyUnitInRects _anyEnemyUnitInRectsObjective;

    /// <inheritdoc />
    public QuestSlumberingKing() : base("The Slumbering King",
      "Ner'zhul commands the undead hordes from his throne atop Icecrown, waiting patiently for the inevitable day that interlopers will come to invade his frozen lands.",
      @"ReplaceableTextures\CommandButtons\BTNAnimateDead.blp")
    {
      _anyEnemyUnitInRectsObjective = new ObjectiveAnyEnemyUnitInRects(new[]
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
      }, "Northrend");
      AddObjective(_anyEnemyUnitInRectsObjective);
      ResearchId = Constants.UPGRADE_R04V_QUEST_COMPLETED_THE_SLUMBERING_KING;
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      $"{_anyEnemyUnitInRectsObjective.CompletingUnit?.OwningPlayer().GetFaction()?.Name} has encroached on the shores of Northrend. Soon they will feel the biting chill of death.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Learn to cast Frost Nova and Animate Dead from the Frozen Throne";
  }
}