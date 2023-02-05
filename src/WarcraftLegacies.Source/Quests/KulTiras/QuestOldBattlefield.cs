using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <inheritdoc/>
  public sealed class QuestOldBattlefield : QuestData
  {
    private readonly LegendaryHero _proudmoore;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBeyondPortal"/> class.
    /// </summary>
    public QuestOldBattlefield(LegendaryHero proudmoore) : base("Old Battlefields",
      "The memories of old battles still haunt Daelin Proudmoore",
      "ReplaceableTextures\\CommandButtons\\BTNProudmoore.blp")
    {
      _proudmoore = proudmoore;
      AddObjective(new ObjectiveLegendInRect(proudmoore, Regions.NethergardeUnlock, "Nethergarde, the door to Outland"));
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "Daelin will rise up to challenge the orcs coming from the Dark Portal one more time";

    /// <inheritdoc/>
    protected override string RewardDescription => "Daelin Proudmoore gains 5000 experience";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction) =>
      _proudmoore.Unit?.AddExperience(5000);
  }
}