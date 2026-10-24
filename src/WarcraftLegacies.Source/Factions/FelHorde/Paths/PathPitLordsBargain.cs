using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.FelHorde.Paths;

/// <summary>
/// Lets the Fel Horde swear itself to the Illidari once Magtheridon is killed for good, in return for Magtheridon
/// being brought back in chains for its heroes to free.
/// </summary>
public sealed class PathPitLordsBargain : FactionPath
{
  private readonly IllidariFaction _illidari;
  private readonly ChainedMagtheridon _chainedMagtheridon;

  public PathPitLordsBargain(IllidariFaction illidari, LegendaryHero magtheridon, ChainedMagtheridon chainedMagtheridon)
  {
    _illidari = illidari;
    _chainedMagtheridon = chainedMagtheridon;
    Name = "The Pit Lord's Bargain";
    IconName = "PitLord";
    Description = "Hellfire Citadel has fallen and Magtheridon with it, but a Pit Lord does not fade so easily. Swear the clans to Illidan, and the Betrayer's warlocks will drag Magtheridon back in chains outside Hellfire, where your heroes can free him. The Fel Horde will march beside the Illidari and send a share of its spoils to the Black Temple every turn.";
    AddRequirement(new ObjectiveLegendKilledBy(magtheridon, "an enemy other than the Illidari", IsEnemyOtherThanIllidari, true) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    _chainedMagtheridon.Chain();
    var joinedTeam = OutlandSubmission.Submit(faction, _illidari);
    TakenOutcome = joinedTeam
      ? Loc.Format("{felHorde} swore itself to {illidari}, joined its team and pays it {percent}% of its income.",
        ("{felHorde}", faction.ColoredName), ("{illidari}", _illidari.ColoredName), ("{percent}", OutlandTithe.Percent.ToString()))
      : Loc.Format("{felHorde} swore itself to {illidari} and pays it {percent}% of its income.",
        ("{felHorde}", faction.ColoredName), ("{illidari}", _illidari.ColoredName), ("{percent}", OutlandTithe.Percent.ToString()));
  }

  private bool IsEnemyOtherThanIllidari(player killer) => OutlandSubmission.IsEnemyOtherThanIllidari(Faction, killer);
}
