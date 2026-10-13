using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Factions.OrcishHorde;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.FelHorde.Paths;

/// <summary>Lets the Fel Horde join the Horde once an enemy other than the Illidari kills Magtheridon for good.</summary>
public sealed class PathMaghar : FactionPath
{
  public PathMaghar(LegendaryHero magtheridon)
  {
    Name = "The Mag'har";
    IconName = "Thrall";
    Description = "Hellfire Citadel has fallen and Magtheridon with it. His hold on the clans is broken. Cast off the demons' blood, follow a new warlord and join your brothers in the Horde as the Mag'har.";
    DeclineDescription = "Kargath keeps the clans loyal to the Legion, and a Fel Warlord takes Magtheridon's place.";
    AddRequirement(new ObjectiveLegendKilledBy(magtheridon, "an enemy other than the Illidari", IsEnemyOtherThanIllidari, true) { ShowsInQuestLog = false });
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
    MagtheridonSuccession.Replace(faction, new LegendaryHero("Fel Warlord")
    {
      UnitType = UNIT_N0Z1_SERVANT_OF_THE_LEGION_FEL
    });

  private bool IsEnemyOtherThanIllidari(player killer) => OutlandSubmission.IsEnemyOtherThanIllidari(Faction, killer);
}
