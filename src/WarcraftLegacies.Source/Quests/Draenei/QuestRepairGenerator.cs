using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;


namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// Bring the generator inside the Exodar to full health to make it more defensible
  /// </summary>
  public class QuestRepairGenerator : QuestData
  {
    /// <summary>
    /// 
    /// </summary>
    public QuestRepairGenerator() : base("Core of the Ship", "The broken core of the Exodar should be rebuilt, bringing us one step closer to making it usable again.", "ReplaceableTextures\\CommandButtons\\BTNArcaneEnergy.blp")
    {
      Required = true;
      AddObjective(new ObjectiveUnitReachesFullHealth(LegendDraenei.LegendExodarGenerator.Unit));

    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Exodar's core has been rebuilt - the Crystal Protectors around it now shield it from any harm.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "The Exodar Generator becomes invulnerable until all Crystal Protectors around it have been destroyed";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (LegendDraenei.LegendExodarGenerator.ProtectorCount > 0)
        LegendDraenei.LegendExodarGenerator.Unit?.SetInvulnerable(true);

    }
  }
}
