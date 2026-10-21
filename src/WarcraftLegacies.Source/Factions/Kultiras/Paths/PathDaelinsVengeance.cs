using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Kultiras.Events;
using WarcraftLegacies.Source.Objectives.MetaBased;

namespace WarcraftLegacies.Source.Factions.Kultiras.Paths;

/// <summary>Once Theramore sides with the Horde, Kul Tiras can send Daelin's fleet to Kalimdor whenever it is ready.</summary>
public sealed class PathDaelinsVengeance : FactionPath
{
  private readonly DaelinsVengeanceEvent _vengeance;
  private readonly ObjectiveTriggered _theramoreJoinedHorde;

  public PathDaelinsVengeance(DaelinsVengeanceEvent vengeance)
  {
    _vengeance = vengeance;
    Name = "Daelin's Vengeance";
    IconName = "Proudmoore";
    Description = "Jaina has thrown in her lot with the orcs who slew her brother. The Lord Admiral will not suffer it. Muster the fleet and sail for Kalimdor, to drive the Horde into the sea and bring his daughter home.";
    DeclineDescription = "The fleet stays at anchor in Boralus, and Jaina is left to the company she has chosen.";
    _theramoreJoinedHorde = new ObjectiveTriggered("Theramore has joined the Horde") { ShowsInQuestLog = false };
    AddRequirement(_theramoreJoinedHorde);
  }

  /// <inheritdoc />
  public override bool ClosesOtherPaths => false;

  /// <summary>Offers the path, since Theramore has joined the Horde.</summary>
  public void Offer() => _theramoreJoinedHorde.Trigger();

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _vengeance.HappenNow(faction.ColoredName);

  /// <inheritdoc />
  protected override void OnDeclined(Faction faction) => _vengeance.Cancel();
}
