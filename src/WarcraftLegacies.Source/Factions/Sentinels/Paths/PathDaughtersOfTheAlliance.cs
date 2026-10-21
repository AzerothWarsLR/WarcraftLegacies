using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Sentinels.Paths;

/// <summary>With the Druids gone or the Pact of Hyjal over, the Sentinels can join the Alliance.</summary>
public sealed class PathDaughtersOfTheAlliance : FactionPath
{
  private readonly ObjectiveTriggered _opened;

  public PathDaughtersOfTheAlliance()
  {
    Name = "Daughters of the Alliance";
    IconName = "PriestessOfTheMoon";
    Description = "The old order of Kalimdor has passed. Tyrande leads the Sentinels out of the forests to stand with the kingdoms of men and dwarves, as sworn members of the Alliance.";
    DeclineDescription = "The Sentinels keep their vigil among their own kin.";
    _opened = new ObjectiveTriggered("The Druids have fallen, or the Pact of Hyjal has ended") { ShowsInQuestLog = false };
    AddRequirement(_opened);
  }

  /// <summary>Offers the path.</summary>
  public void Open() => _opened.Trigger();

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction)
  {
    var smaller = TeamSetup.NorthAlliance.UndefeatedPlayerCount < TeamSetup.SouthAlliance.UndefeatedPlayerCount
      ? TeamSetup.NorthAlliance
      : TeamSetup.SouthAlliance;
    var larger = smaller == TeamSetup.NorthAlliance ? TeamSetup.SouthAlliance : TeamSetup.NorthAlliance;
    var owner = faction.Player;
    return owner != null && !TeamChanges.HasRoomFor(smaller, owner) && TeamChanges.HasRoomFor(larger, owner)
      ? larger
      : smaller;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
  }
}
