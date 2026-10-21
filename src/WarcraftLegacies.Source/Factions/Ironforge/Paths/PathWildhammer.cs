using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Ironforge.Paths;

/// <summary>When Ironforge or the South Alliance falls apart, the dwarves rally to Falstad at Aerie Peak.</summary>
public sealed class PathWildhammer : FactionPath
{
  private readonly WildhammerTransformation _transformation;
  private readonly ObjectiveTriggered _southBroken;
  private readonly TeamBreakWatch _southWatch;

  public PathWildhammer(WildhammerTransformation transformation)
  {
    _transformation = transformation;
    Name = "The Wildhammer";
    IconName = "HeroGriffonWarrior";
    Description = "The halls of Ironforge can no longer be held. Its dwarves take wing for Aerie Peak, where Falstad Wildhammer rallies them to fight on from the skies over the Hinterlands, beside the kingdoms of the north. Ironforge itself is left in the care of its allies.";
    _southBroken = new ObjectiveTriggered("The South Alliance is broken: Stormwind or Kul Tiras has left it or been defeated");
    AddRequirement(new ObjectiveEitherOf(_southBroken, new ObjectiveCapitalDead(AllLegends.Ironforge.GreatForge),
      "The Great Forge has fallen, or Stormwind or Kul Tiras has left the South Alliance or been defeated")
    { ShowsInQuestLog = false });

    _southWatch = new TeamBreakWatch(TeamSetup.SouthAlliance, x => x is StormwindFaction || x is KultirasFaction, _southBroken.Trigger);
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.NorthAlliance;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
