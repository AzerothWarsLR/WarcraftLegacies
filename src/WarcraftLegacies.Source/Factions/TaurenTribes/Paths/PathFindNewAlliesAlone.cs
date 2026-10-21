using MacroTools.Factions;
using WarcraftLegacies.Source.Shared.Powers;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Paths;

/// <summary>The tauren trust no one after the orcs' betrayal, and stand alone with the Earth Mother's blessing.</summary>
public sealed class PathFindNewAlliesAlone : PathFindNewAllies
{
  private const float PowerBonus = 0.15f;

  public PathFindNewAlliesAlone()
  {
    Name = "Find New Allies: Stand Alone";
    Description = "The orcs have given themselves to the demons once more, and the tauren will trust no other people again. Stand alone on the plains of Mulgore, with the Earth Mother at your side.";
    CanGoSolo = true;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) =>
    faction.AddPower(new EmpoweredUnits(x => !x.IsUnitType(unittype.Structure), PowerBonus)
    {
      Name = "Earth Mother's Resolve",
      IconName = "SpiritWalkerAdeptTraining",
      DescriptionTemplate = "Standing alone, the tauren draw on the strength of the land. Your units deal {bonus}% more damage and take {reduction}% less damage."
    });
}
