using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Ironforge.Paths;

/// <summary>Once the Wildhammer are brought into the alliance, Ironforge's dwarves take up the Wildhammer banner.</summary>
public sealed class PathWildhammer : FactionPath
{
  private readonly WildhammerTransformation _transformation;

  public PathWildhammer(WildhammerTransformation transformation, QuestWildhammer wildhammerAlliance)
  {
    _transformation = transformation;
    Name = "The Wildhammer";
    IconName = "HeroGriffonWarrior";
    Description = "The Wildhammer have answered Ironforge's call. Falstad's clan and the dwarves of Khaz Modan unite under the Wildhammer banner and take to the skies on gryphon-back, beside the kingdoms of the north.";
    AddRequirement(new ObjectiveQuestComplete(wildhammerAlliance) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.NorthAlliance;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
