using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Objectives.QuestBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Paths;

/// <summary>Once the Dark Iron are brought back into the fold, Moira Thaurissan claims the throne of Ironforge for them.</summary>
public abstract class PathDarkIron : FactionPath
{
  private readonly DarkIronTransformation _transformation;

  protected PathDarkIron(DarkIronTransformation transformation, QuestDarkIron darkIronAlliance)
  {
    _transformation = transformation;
    IconName = "RPGDarkIron";
    AddRequirement(new ObjectiveQuestComplete(darkIronAlliance) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
