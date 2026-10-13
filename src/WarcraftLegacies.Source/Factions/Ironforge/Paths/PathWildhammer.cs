using System.Collections.Generic;
using MacroTools.Extensions;
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
  private readonly HashSet<player> _southPlayers = new();

  public PathWildhammer(WildhammerTransformation transformation)
  {
    _transformation = transformation;
    Name = "The Wildhammer";
    IconName = "HeroGriffonWarrior";
    Description = "Ironforge can no longer hold Khaz Modan. The dwarves rally to Falstad at Aerie Peak and fight on as the Wildhammer, taking to the skies over the Hinterlands beside the kingdoms of the north. Ironforge and the rest of Khaz Modan are left to the Alliance.";
    _southBroken = new ObjectiveTriggered("The South Alliance is broken: Stormwind or Kul Tiras has left it or been defeated");
    AddRequirement(new ObjectiveEitherOf(_southBroken, new ObjectiveCapitalDead(AllLegends.Ironforge.GreatForge),
      "The Great Forge has fallen, or Stormwind or Kul Tiras has left the South Alliance or been defeated")
    { ShowsInQuestLog = false });

    WatchSouthAlliance();
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.NorthAlliance;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);

  private void WatchSouthAlliance()
  {
    foreach (var faction in FactionManager.GetAllFactions())
    {
      if ((faction is StormwindFaction || faction is KultirasFaction) && faction.Player != null &&
          faction.Player.GetPlayerData().Team == TeamSetup.SouthAlliance)
      {
        _southPlayers.Add(faction.Player);
        faction.ScoreStatusChanged += _ => CheckSouthBroken();
      }
    }

    PlayerData.FactionChange += OnFactionChange;
    TeamChanges.OnAnyTeamChanged(CheckSouthBroken);
  }

  private void OnFactionChange(PlayerFactionChangeEventArgs args)
  {
    if (!_southPlayers.Contains(args.Player))
    {
      return;
    }

    var newFaction = args.Player.GetPlayerData().Faction;
    if (newFaction != null)
    {
      newFaction.ScoreStatusChanged += _ => CheckSouthBroken();
    }

    CheckSouthBroken();
  }

  private void CheckSouthBroken()
  {
    foreach (var southPlayer in _southPlayers)
    {
      var playerData = southPlayer.GetPlayerData();
      if (playerData.Faction == null || playerData.Faction.ScoreStatus == ScoreStatus.Defeated ||
          playerData.Team != TeamSetup.SouthAlliance)
      {
        _southBroken.Trigger();
        return;
      }
    }
  }
}
