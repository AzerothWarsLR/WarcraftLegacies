using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Factions;

namespace WarcraftLegacies.Source.Setup;

public sealed class PlayerSetup
{
  private readonly AllLegendSetup _allLegendSetup;
  private readonly ArtifactSetup _artifactSetup;

  public PlayerSetup(AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup)
  {
    _allLegendSetup = allLegendSetup;
    _artifactSetup = artifactSetup;
  }

  public void Setup()
  {
    SetupPlayer(player.Create(1), new Stormwind(_allLegendSetup, _artifactSetup));
    SetupPlayer(player.Create(2), new Quelthalas(_allLegendSetup));
    SetupPlayer(player.Create(3), new Scourge(_allLegendSetup, _artifactSetup));
    SetupPlayer(player.Create(4), new Ironforge(_allLegendSetup, _artifactSetup));
    SetupPlayer(player.Create(6), new FelHorde(_allLegendSetup, _artifactSetup));
    player.Create(7).GetPlayerData().SetTeam(TeamSetup.NorthAlliance);
    player.Create(0).GetPlayerData().SetTeam(TeamSetup.Kalimdor);
    SetupPlayer(player.Create(8), new Skywall(_allLegendSetup));
    SetupPlayer(player.Create(9), new Lordaeron(_allLegendSetup, _artifactSetup));
    SetupPlayer(player.Create(11), new Druids(_allLegendSetup, _artifactSetup));
    SetupPlayer(player.Create(12), new BlackEmpire(_allLegendSetup));
    SetupPlayer(player.Create(16), new Ahnqiraj(_allLegendSetup));
    player.Create(18).GetPlayerData().SetTeam(TeamSetup.Kalimdor);
    player.Create(15).GetPlayerData().SetTeam(TeamSetup.Outland);
    SetupPlayer(player.Create(22), new Kultiras(_allLegendSetup, _artifactSetup));
    SetupPlayer(player.Create(23), new Legion(_allLegendSetup));
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
