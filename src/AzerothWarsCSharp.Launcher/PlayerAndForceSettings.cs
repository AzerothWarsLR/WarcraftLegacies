using System.Linq;
using System.Numerics;
using AzerothWarsCSharp.Common.Constants;
using War3Net.Build.Common;
using War3Net.Build.Extensions;
using War3Net.Build.Info;

namespace AzerothWarsCSharp.Launcher
{
  internal static class PlayerAndForceSettings
  {
    public static void ApplyToMapInfo(MapInfo mapInfo)
    {
      // Create players
      var team0Players = new PlayerData[PlayerConstants.PlayerSlotCount];
      for (var i = 0; i < PlayerConstants.PlayerSlotCount; i++)
      {
        var playerData = new PlayerData
        {
          Id = i,
          Name = $"Player {i + 1}",
          Controller = PlayerController.User,
          Race = PlayerRace.Human,
          StartPosition = new Vector2(0f, 0f),
          Flags = PlayerFlags.FixedStartPosition,
          AllyLowPriorityFlags = new Bitmask32(),
          AllyHighPriorityFlags = new Bitmask32()
        };

        team0Players[i] = playerData;
      }

      var team1Player = new PlayerData
      {
        Id = 23,
        Name = "Enemies",
        Controller = PlayerController.Computer,
        Race = PlayerRace.Orc,
        StartPosition = new Vector2(0f, 0f),
        Flags = PlayerFlags.FixedStartPosition,
        AllyLowPriorityFlags = new Bitmask32(),
        AllyHighPriorityFlags = new Bitmask32()
      };

      // Add players to MapInfo
      mapInfo.Players.Clear();
      mapInfo.Players.AddRange(team0Players.Append(team1Player));

      // Create teams
      var team0 = new ForceData()
      {
        Name = "Team 1",
        Flags = ForceFlags.Allied | ForceFlags.ShareVision,
      };
      var team1 = new ForceData()
      {
        Name = "Team 2",
      };

      // Add players to teams
      team0.SetPlayers(team0Players);
      team1.SetPlayers(team1Player);

      // Add teams to MapInfo
      mapInfo.Forces.Clear();
      mapInfo.Forces.AddRange(new[] { team0, team1 });

      // Update map flags
      mapInfo.MapFlags |= MapFlags.UseCustomForces | MapFlags.FixedPlayerSettingsForCustomForces;
    }
  }
}