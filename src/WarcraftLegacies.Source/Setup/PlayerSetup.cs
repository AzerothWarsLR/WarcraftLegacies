using System;
using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions;

namespace WarcraftLegacies.Source.Setup;

public static class PlayerSetup
{
  public static void Setup()
  {
    SetupPlayer(player.Create(1), new Stormwind());
    SetupPlayer(player.Create(2), new Quelthalas());
    SetupPlayer(player.Create(3), new Scourge());
    SetupPlayer(player.Create(4), new Ironforge());
    SetupPlayer(player.Create(6), new FelHorde());
    player.Create(7).GetPlayerData().SetTeam(TeamSetup.NorthAlliance);
    player.Create(0).GetPlayerData().SetTeam(TeamSetup.Kalimdor);
    SetupPlayer(player.Create(8), new Skywall());
    SetupPlayer(player.Create(9), new Lordaeron());
    SetupPlayer(player.Create(11), new Druids());
    SetupPlayer(player.Create(12), new BlackEmpire());
    SetupPlayer(player.Create(16), new Ahnqiraj());
    player.Create(18).GetPlayerData().SetTeam(TeamSetup.Kalimdor);
    player.Create(15).GetPlayerData().SetTeam(TeamSetup.Outland);
    SetupPlayer(player.Create(22), new Kultiras());
    SetupPlayer(player.Create(23), new Legion());
  }


  private static void SetupPlayer(player player, Faction faction)
  {
    var traditionalTeam = faction.TraditionalTeam;
    if (traditionalTeam != null)
    {
      player.GetPlayerData().SetTeam(traditionalTeam);
    }
    else
    {
      throw new InvalidOperationException($"{player.Name}'s {nameof(Faction)} doesn't have a {nameof(Faction.TraditionalTeam)}.");
    }

    player.GetPlayerData().Faction = faction;
    FactionManager.Register(faction);
  }
}
