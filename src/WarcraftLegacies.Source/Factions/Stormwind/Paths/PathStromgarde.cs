using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Ironforge;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Stormwind.Paths;

/// <summary>When Stormwind or the South Alliance falls apart, its survivors rally to the Trollbanes at Stromgarde.</summary>
public sealed class PathStromgarde : FactionPath
{
  private readonly StromgardeTransformation _transformation;
  private readonly ObjectiveTriggered _southBroken;
  private readonly TeamBreakWatch _southWatch;

  public PathStromgarde(StromgardeTransformation transformation)
  {
    _transformation = transformation;
    Name = "Stromgarde";
    IconName = "TheCaptain";
    Description = "Stormwind can no longer hold its kingdom. Its survivors march north to Stromgarde, where the Trollbanes still keep the oldest crown of men, and fight on beside the kingdoms of the north. Stormwind itself is left in the care of its allies.";
    _southBroken = new ObjectiveTriggered("The South Alliance is broken: Ironforge or Kul Tiras has left it or been defeated");
    AddRequirement(new ObjectiveEitherOf(_southBroken, new ObjectiveCapitalDead(AllLegends.Stormwind.StormwindKeep),
      "Stormwind Keep has fallen, or Ironforge or Kul Tiras has left the South Alliance or been defeated")
    { ShowsInQuestLog = false });

    _southWatch = new TeamBreakWatch(TeamSetup.SouthAlliance, x => x is IronforgeFaction || x is KultirasFaction, _southBroken.Trigger);
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.NorthAlliance;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
