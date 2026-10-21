using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Dalaran.Paths;

/// <summary>With Gilneas City in Dalaran's hands, Genn Greymane raises the kingdom of Gilneas in its place.</summary>
public abstract class PathGilneas : FactionPath
{
  private readonly GilneasTransformation _transformation;

  protected PathGilneas(GilneasTransformation transformation)
  {
    _transformation = transformation;
    IconName = "Greymane";
    AddMustStayTrueRequirement(new ObjectiveControlCapital(AllLegends.Gilneas.GilneasCastle, false) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
