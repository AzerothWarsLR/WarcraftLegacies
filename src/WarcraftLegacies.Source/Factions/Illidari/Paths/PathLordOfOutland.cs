using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Factions.Illidari.Paths;

/// <summary>Lets the Illidari take Magtheridon's throne once they kill him, bringing the Fel Horde to heel.</summary>
public sealed class PathLordOfOutland : FactionPath
{
  private const int EarliestTurn = 5;

  private readonly FelHordeFaction _felHorde;

  public PathLordOfOutland(FelHordeFaction felHorde, LegendaryHero magtheridon)
  {
    _felHorde = felHorde;
    Name = "Lord of Outland";
    IconName = "PitLord";
    Description = "Magtheridon lies broken at your feet, and Outland has a new master. The Fel Horde bows to Illidan, marching at his side under a lesser warlord and sending a share of its spoils to the Black Temple every turn.";
    AddRequirement(new ObjectiveTurn(EarliestTurn) { ShowsInQuestLog = false });
    AddRequirement(new ObjectiveLegendKilledBy(magtheridon, "the Illidari", IsIllidari) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    MagtheridonSuccession.Replace(_felHorde, new LegendaryHero("Fel Warlord")
    {
      UnitType = UNIT_N0Z1_SERVANT_OF_ILLIDAN_FEL
    });
    new OutlandTithe(_felHorde, faction).Start();
    var joinedTeam = BringFelHordeToHeel(faction);
    TakenOutcome = joinedTeam
      ? Loc.Format("{felHorde} lost Magtheridon, joined {illidari}'s team and pays it {percent}% of its income.",
        ("{felHorde}", _felHorde.ColoredName), ("{illidari}", faction.ColoredName), ("{percent}", OutlandTithe.Percent.ToString()))
      : Loc.Format("{felHorde} lost Magtheridon and pays {illidari} {percent}% of its income.",
        ("{felHorde}", _felHorde.ColoredName), ("{illidari}", faction.ColoredName), ("{percent}", OutlandTithe.Percent.ToString()));
  }

  /// <summary>Moves the Fel Horde onto the Illidari's team if there is room, returning whether it moved.</summary>
  private bool BringFelHordeToHeel(Faction illidari)
  {
    var felHordePlayer = _felHorde.Player;
    var illidariPlayer = illidari.Player;
    if (felHordePlayer == null || illidariPlayer == null)
    {
      return false;
    }

    var illidariTeam = illidariPlayer.GetPlayerData().Team;
    if (illidariTeam == null || !TeamChanges.HasRoomFor(illidariTeam, felHordePlayer))
    {
      return false;
    }

    TeamChanges.Move(felHordePlayer, illidariTeam);
    return true;
  }

  private bool IsIllidari(player whichPlayer)
  {
    var illidari = Faction?.Player;
    return illidari != null && (whichPlayer == illidari || TeamChanges.AreTeammates(whichPlayer, illidari));
  }
}
