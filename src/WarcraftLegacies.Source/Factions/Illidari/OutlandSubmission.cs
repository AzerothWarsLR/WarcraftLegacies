using MacroTools.Extensions;
using MacroTools.Factions;

namespace WarcraftLegacies.Source.Factions.Illidari;

/// <summary>The Fel Horde swears itself to the Illidari.</summary>
public static class OutlandSubmission
{
  /// <summary>
  /// Starts the Fel Horde's tithe to the Illidari and moves it onto their team if there is room, returning whether it
  /// moved.
  /// </summary>
  public static bool Submit(Faction felHorde, Faction illidari)
  {
    new OutlandTithe(felHorde, illidari).Start();
    var felHordePlayer = felHorde.Player;
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

  /// <summary>Whether <paramref name="killer"/> is an enemy of the Fel Horde other than the Illidari.</summary>
  public static bool IsEnemyOtherThanIllidari(Faction? felHorde, player killer)
  {
    var felHordePlayer = felHorde == null ? null : felHorde.Player;
    if (felHordePlayer != null && (killer == felHordePlayer || TeamChanges.AreTeammates(killer, felHordePlayer)))
    {
      return false;
    }

    if (!FactionManager.TryGetFactionByType<IllidariFaction>(out var illidari))
    {
      return true;
    }

    var illidariPlayer = illidari.Player;
    return illidariPlayer == null || (killer != illidariPlayer && !TeamChanges.AreTeammates(killer, illidariPlayer));
  }
}
