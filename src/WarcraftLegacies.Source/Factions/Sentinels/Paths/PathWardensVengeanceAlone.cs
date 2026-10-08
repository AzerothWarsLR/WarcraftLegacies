using MacroTools.Factions;
using WarcraftLegacies.Source.Objectives.MetaBased;

namespace WarcraftLegacies.Source.Factions.Sentinels.Paths;

/// <summary>
/// The Sentinels leave the Night Elves and hunt Illidan on their own.
/// </summary>
public sealed class PathWardensVengeanceAlone : PathWardensVengeance
{
  public PathWardensVengeanceAlone(ObjectiveTriggered illidanReturned) : base(illidanReturned)
  {
    Name = "Wardens' Vengeance: Alone";
    Description = "Maiev will not fight beside the Betrayer, and trusts no one else to bring him to justice. Leave the Night Elves and hunt him alone.";
    CanGoSolo = true;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
  }
}
