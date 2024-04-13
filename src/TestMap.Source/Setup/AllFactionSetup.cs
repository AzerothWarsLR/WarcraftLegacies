using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using TestMap.Source.Factions;

namespace TestMap.Source.Setup
{
  public static class AllFactionSetup
  {
    public static void Setup()
    {
      SetupPlayer(Player(0), new SpaceMarines());
    }
    
    private static void SetupPlayer(player player, Faction faction)
    {
      var traditionalTeam = faction.TraditionalTeam;
      if (traditionalTeam != null)
        player.SetTeam(traditionalTeam);
      else
        throw new InvalidOperationException($"{GetPlayerName(player)}'s {nameof(Faction)} doesn't have a {nameof(Faction.TraditionalTeam)}.");
      player.SetFaction(faction);
      FactionManager.Register(faction);
    }
  }
}