using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.BansheesHost;
using WarcraftLegacies.Source.Factions.FallenPrince;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;

namespace WarcraftLegacies.Source.Factions.Dalaran.Paths;

/// <summary>
/// Once the north is lost, Jaina leads its survivors across the sea to Kalimdor and founds Theramore.
/// </summary>
public sealed class PathTheramore : FactionPath
{
  private readonly TheramoreTransformation _transformation;
  private readonly ObjectiveTriggered _northBroken;

  public PathTheramore(TheramoreTransformation transformation, Capital violetCitadel)
  {
    _transformation = transformation;
    Name = "Theramore";
    IconName = "Jaina";
    Description = "The north is lost. Jaina gathers what survivors she can and sails west across the sea, to build a new home for them on the shores of Kalimdor.";
    _northBroken = new ObjectiveTriggered("The North Alliance is broken: the Fallen Prince or the Banshee's Host has risen");
    AddRequirement(new ObjectiveEitherOf(_northBroken, new ObjectiveCapitalDead(violetCitadel),
      "The Fallen Prince or the Banshee's Host has risen, or the Violet Citadel has fallen")
    { ShowsInQuestLog = false });

    foreach (var faction in FactionManager.GetAllFactions())
    {
      CheckNorthBroken(faction);
    }

    FactionManager.FactionRegistered += CheckNorthBroken;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);

  private void CheckNorthBroken(Faction faction)
  {
    if (faction is FallenPrinceFaction || faction is BansheesHostFaction)
    {
      _northBroken.Trigger();
    }
  }
}
