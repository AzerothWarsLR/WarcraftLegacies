using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Factions.OrcishHorde;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.FelHorde.Paths;

/// <summary>
/// With Magtheridon slain by someone other than the Illidari, the Fel Horde is free of its demon master. It can throw off
/// the demons' blood and join the Horde, or stay with the Legion under a new warlord.
/// </summary>
public sealed class PathMaghar : FactionPath
{
  public PathMaghar(LegendaryHero magtheridon)
  {
    Name = "The Mag'har";
    IconName = "Thrall";
    Description = "Magtheridon is dead and his hold on the clans is broken. Cast off the demons' blood, follow a new warlord and join your brothers in the Horde as the Mag'har.";
    DeclineDescription = "Kargath keeps the clans loyal to the Legion, and a new warlord takes Magtheridon's place.";
    AddRequirement(new ObjectiveLegendKilledBy(magtheridon, "an enemy other than the Illidari", IsNotIllidari) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction)
  {
    if (!FactionManager.TryGetFactionByType<OrcishHordeFaction>(out var orcishHorde))
    {
      return null;
    }

    var orcishHordePlayer = orcishHorde.Player;
    return orcishHordePlayer == null ? null : orcishHordePlayer.GetPlayerData().Team;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    faction.Name = "Mag'har";
    MagtheridonSuccession.Replace(faction, new LegendaryHero("Mag'har Warlord")
    {
      UnitType = UNIT_N0Z2_MAG_HAR_CHIEFTAIN_FEL
    });
  }

  /// <inheritdoc />
  protected override void OnDeclined(Faction faction) =>
    MagtheridonSuccession.Replace(faction, new LegendaryHero("Mag'har Warlord")
    {
      UnitType = UNIT_N0Z2_MAG_HAR_CHIEFTAIN_FEL
    });

  private bool IsNotIllidari(player whichPlayer)
  {
    var felHordePlayer = Faction?.Player;
    if (felHordePlayer != null && (whichPlayer == felHordePlayer || TeamChanges.AreTeammates(whichPlayer, felHordePlayer)))
    {
      return false;
    }

    if (!FactionManager.TryGetFactionByType<IllidariFaction>(out var illidari))
    {
      return true;
    }

    var illidariPlayer = illidari.Player;
    return illidariPlayer == null || (whichPlayer != illidariPlayer && !TeamChanges.AreTeammates(whichPlayer, illidariPlayer));
  }
}
