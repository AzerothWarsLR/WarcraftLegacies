using System;
using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Quelthalas.Paths;

/// <summary>With the Sunwell lost, Kael'thas leads the Blood Elves to Outland in search of a cure for their hunger.</summary>
public sealed class PathKaelsExodus : FactionPath
{
  private readonly KaelsExodusTransformation _transformation;
  private readonly Func<Team?> _getDestination;

  public PathKaelsExodus(KaelsExodusTransformation transformation, Func<Team?> getDestination)
  {
    _transformation = transformation;
    _getDestination = getDestination;
    Name = "Kael's Exodus";
    IconName = "HeroBloodElfPrince";
    Description = "The Sunwell has fallen, and its loss gnaws at every elf of Quel'thalas. Prince Kael'thas renames his people the Blood Elves, leaves the homeland to its old allies and leads them through the Dark Portal to Tempest Keep, seeking a new source of power.";
    AddRequirement(new ObjectiveCapitalLost(AllLegends.Quel.Sunwell) { ShowsInQuestLog = false });
    CanGoSolo = true;
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => _getDestination();

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
