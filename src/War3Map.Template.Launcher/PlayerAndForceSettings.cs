using System.Linq;
using System.Numerics;
using War3Map.Template.Common.Constants;
using War3Net.Build.Common;
using War3Net.Build.Extensions;
using War3Net.Build.Info;

namespace War3Map.Template.Launcher
{
    internal static class PlayerAndForceSettings
    {
        public static void ApplyToMapInfo(MapInfo mapInfo)
        {
            // Create players
            var team0Players = new PlayerData[PlayerConstants.PlayerSlotCount];
            for (var i = 0; i < PlayerConstants.PlayerSlotCount; i++)
            {
                var playerData = new PlayerData();
                playerData.Id = i;
                playerData.Name = $"Player {i+1}";
                playerData.Controller = PlayerController.User;
                playerData.Race = PlayerRace.Human;
                playerData.StartPosition = new Vector2(0f, 0f);
                playerData.Flags = PlayerFlags.FixedStartPosition;
                playerData.AllyLowPriorityFlags = new Bitmask32();
                playerData.AllyHighPriorityFlags = new Bitmask32();

                team0Players[i] = playerData;
            }

            var team1Player = new PlayerData();
            team1Player.Id = 23;
            team1Player.Name = "Enemies";
            team1Player.Controller = PlayerController.Computer;
            team1Player.Race = PlayerRace.Orc;
            team1Player.StartPosition = new Vector2(0f, 0f);
            team1Player.Flags = PlayerFlags.FixedStartPosition;
            team1Player.AllyLowPriorityFlags = new Bitmask32();
            team1Player.AllyHighPriorityFlags = new Bitmask32();

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