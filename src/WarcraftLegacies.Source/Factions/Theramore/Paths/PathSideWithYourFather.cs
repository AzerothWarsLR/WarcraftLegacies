using System;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Theramore.Paths;

/// <summary>Daelin's fleet has landed: Jaina can rejoin her father and the Alliance, or stand with Thrall.</summary>
public sealed class PathSideWithYourFather : FactionPath
{
  private const float ChoiceDuration = 120;

  private readonly Faction _kultiras;
  private readonly Action<Faction> _onSideWithFather;
  private readonly Action<Faction> _onStandWithThrall;

  public PathSideWithYourFather(Faction kultiras, Action<Faction> onSideWithFather, Action<Faction> onStandWithThrall)
  {
    _kultiras = kultiras;
    _onSideWithFather = onSideWithFather;
    _onStandWithThrall = onStandWithThrall;
    Name = "Side with your Father";
    IconName = "Jaina";
    Description = "Your father's fleet has made landfall on Kalimdor, and he calls for you to come home. Break faith with Thrall and return to the Alliance at his side.";
    DeclineDescription = "Stand with Thrall. Theramore keeps faith with the Horde, and Jaina steels her people to face her father's fleet.";
    OfferDuration = ChoiceDuration;
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  public override bool IgnoresTeamChangeCooldown => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction)
  {
    var owner = faction.Player;
    var kultirasTeam = _kultiras.Player?.GetPlayerData().Team;
    if (owner == null || kultirasTeam == null)
    {
      return TeamSetup.NorthAlliance;
    }

    if (!TeamChanges.HasRoomFor(kultirasTeam, owner) && TeamChanges.HasRoomFor(TeamSetup.NorthAlliance, owner))
    {
      return TeamSetup.NorthAlliance;
    }

    return kultirasTeam;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _onSideWithFather(faction);

  /// <inheritdoc />
  protected override void OnDeclined(Faction faction) => _onStandWithThrall(faction);

  /// <inheritdoc />
  protected override void OnExpired(Faction faction) => _onStandWithThrall(faction);
}
