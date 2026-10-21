using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Ironforge.Paths;

/// <summary>With the Great Forge extinguished and Magni dead, Dagran Thaurissan claims the throne for the Dark Iron.</summary>
public abstract class PathDarkIron : FactionPath
{
  private readonly DarkIronTransformation _transformation;

  protected PathDarkIron(DarkIronTransformation transformation)
  {
    _transformation = transformation;
    IconName = "RPGDarkIron";
    AddRequirement(new ObjectiveCapitalDead(AllLegends.Ironforge.GreatForge) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
