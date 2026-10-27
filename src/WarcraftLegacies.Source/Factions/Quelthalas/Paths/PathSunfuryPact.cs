using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Quelthalas.Paths;

/// <summary>With the Sunwell lost, Kael'thas swears the Sunfury to Kil'jaeden in exchange for a new source of power.</summary>
public sealed class PathSunfuryPact : FactionPath
{
  private readonly SunfuryPactTransformation _transformation;

  public PathSunfuryPact(SunfuryPactTransformation transformation)
  {
    _transformation = transformation;
    Name = "The Sunfury: The Burning Legion";
    IconName = "FelKaelthas";
    Description = "The Sunwell has fallen, and its loss gnaws at every elf of Quel'thalas. Prince Kael'thas, desperate to sate his people's hunger, swears himself to Kil'jaeden the Deceiver. Those who follow him become the Sunfury and leave for Tempest Keep, abandoning what remains of the homeland to the Alliance and joining the Burning Legion.";
    AddRequirement(new ObjectiveCapitalLost(AllLegends.Quel.Sunwell) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.Legion;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
