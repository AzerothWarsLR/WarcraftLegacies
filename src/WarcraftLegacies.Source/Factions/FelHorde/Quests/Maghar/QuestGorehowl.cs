using MacroTools.Artifacts;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.FelHorde.Quests.Maghar;

/// <summary>Garrosh claims his father's axe.</summary>
public sealed class QuestGorehowl : QuestData
{
  private readonly LegendaryHero _garrosh;

  public QuestGorehowl(LegendaryHero garrosh, Artifact gorehowl) : base("Gorehowl",
    "Grom Hellscream's axe sang in the battle that freed the orcs from Mannoroth's blood. In his son's hands it would sing again.",
    @"ReplaceableTextures\CommandButtons\BTNHellScream.blp")
  {
    _garrosh = garrosh;
    AddObjective(new ObjectiveLegendHasArtifact(garrosh, gorehowl));
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Garrosh lifts Gorehowl, and the axe howls as it did in his father's hands.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Garrosh gains 5 Strength, 5 Agility and 5 Intelligence";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    var garrosh = _garrosh.Unit;
    if (garrosh != null)
    {
      garrosh.AddHeroAttributes(5, 5, 5);
    }
  }
}
