using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Factions.Illidari.Paths;

/// <summary>Lets the Illidari take Magtheridon's throne once they kill him, bringing the Fel Horde to heel.</summary>
public sealed class PathLordOfOutland : FactionPath
{
  private const int EarliestTurn = 5;

  private readonly FelHordeFaction _felHorde;
  private readonly ChainedMagtheridon _chainedMagtheridon;

  public PathLordOfOutland(FelHordeFaction felHorde, LegendaryHero magtheridon, ChainedMagtheridon chainedMagtheridon)
  {
    _felHorde = felHorde;
    _chainedMagtheridon = chainedMagtheridon;
    Name = "Lord of Outland";
    IconName = "PitLord";
    Description = "Magtheridon lies broken at your feet, and Outland has a new master. He is bound in chains outside Hellfire Citadel, and the Fel Horde bows to Illidan, marching at his side and sending a share of its spoils to the Black Temple every turn.";
    AddRequirement(new ObjectiveTurn(EarliestTurn) { ShowsInQuestLog = false });
    AddRequirement(new ObjectiveLegendKilledBy(magtheridon, "the Illidari", IsIllidari) { ShowsInQuestLog = false });
  }

  /// <summary>Completes once this path is taken.</summary>
  public ObjectiveTriggered Taken { get; } = new("Claim Magtheridon's throne as Lord of Outland");

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    _chainedMagtheridon.Chain();
    Taken.Trigger();
    var joinedTeam = OutlandSubmission.Submit(_felHorde, faction);
    TakenOutcome = joinedTeam
      ? Loc.Format("{felHorde} saw Magtheridon chained, joined {illidari}'s team and pays it {percent}% of its income.",
        ("{felHorde}", _felHorde.ColoredName), ("{illidari}", faction.ColoredName), ("{percent}", OutlandTithe.Percent.ToString()))
      : Loc.Format("{felHorde} saw Magtheridon chained and pays {illidari} {percent}% of its income.",
        ("{felHorde}", _felHorde.ColoredName), ("{illidari}", faction.ColoredName), ("{percent}", OutlandTithe.Percent.ToString()));
  }

  private bool IsIllidari(player whichPlayer)
  {
    var illidari = Faction?.Player;
    return illidari != null && (whichPlayer == illidari || TeamChanges.AreTeammates(whichPlayer, illidari));
  }
}
