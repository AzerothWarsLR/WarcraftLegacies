using System;
using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Druids;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.Ironforge;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Factions.Warsong;
using WarcraftLegacies.Source.Factions.Draenei;
using WarcraftLegacies.Source.Factions.Sentinels;
using WarcraftLegacies.Source.Factions.Frostwolf;
using WarcraftLegacies.Source.Factions.Zandalar;
using WarcraftLegacies.Source.Factions.Dalaran;

namespace WarcraftLegacies.Source.Setup;

public static class PlayerSetup
{
  public static void Setup()
  {
    SetupPlayer(player.Create(1), new StormwindFaction());
    SetupPlayer(player.Create(2), new QuelthalasFaction());
    SetupPlayer(player.Create(3), new ScourgeFaction());
    SetupPlayer(player.Create(4), new IronforgeFaction());
    SetupPlayer(player.Create(6), new FelHordeFaction());
    player.Create(7).GetPlayerData().SetTeam(TeamSetup.NorthAlliance);
    player.Create(0).GetPlayerData().SetTeam(TeamSetup.Kalimdor);
    SetupPlayer(player.Create(8), new WarsongFaction());
    SetupPlayer(player.Create(9), new LordaeronFaction());
    SetupPlayer(player.Create(11), new DruidsFaction());
    SetupPlayer(player.Create(13), new DraeneiFaction());
    SetupPlayer(player.Create(18), new SentinelsFaction());
    SetupPlayer(player.Create(0), new FrostwolfFaction());
    SetupPlayer(player.Create(17), new ZandalarFaction());
    player.Create(18).GetPlayerData().SetTeam(TeamSetup.Kalimdor);
    player.Create(15).GetPlayerData().SetTeam(TeamSetup.Outland);
    SetupPlayer(player.Create(22), new KultirasFaction());
    SetupPlayer(player.Create(23), new LegionFaction());
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
