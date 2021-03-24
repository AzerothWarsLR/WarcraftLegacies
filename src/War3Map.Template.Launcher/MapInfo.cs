using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using War3Net.Build;
using War3Net.Build.Common;
using War3Net.Build.Environment;
using War3Net.Build.Extensions;
using War3Net.Build.Info;
using War3Net.Build.Providers;

namespace AzerothWarsCSharp.Launcher
{
  internal static class Info
  {
    public static MapInfo GetMapInfo()
    {
      var mapInfo = GetInfo();

      PlayerAndForceSettings.ApplyToMapInfo(mapInfo);

      return mapInfo;
    }

    public static MapInfo GetInfo(
        uint mapWidth = 64,
        uint mapHeight = 64,
        Tileset tileset = Tileset.LordaeronSummer,
        GamePatch gamePatch = GamePatch.v1_31_1)
    {
      if (gamePatch < GamePatch.v1_31_0)
      {
        throw new NotSupportedException();
      }

      var info = new MapInfo(MapInfoFormatVersion.Lua)
      {
      };

      info.MapVersion = 1;
      info.EditorVersion = 6072;
      info.GameVersion = gamePatch.ToVersion();

      info.MapName = "Just another Warcraft III map";
      info.MapAuthor = "Unknown";
      info.MapDescription = "Nondescript";
      info.RecommendedPlayers = "Any";

      const int DefaultLeftComplement = 6;
      const int DefaultRightComplement = 6;
      const int DefaultBottomComplement = 4;
      const int DefaultTopComplement = 8;
      const int DefaultHorizontalBoundsOffset = 4;
      const int DefaultVerticalBoundsOffset = 2;

      var horizontalOffset = (int)mapWidth / 2;
      var verticalOffset = (int)mapWidth / 2;

      info.CameraBounds = new Quadrilateral(
          -TerrainTile.TileWidth * (horizontalOffset - DefaultLeftComplement - DefaultHorizontalBoundsOffset),
          TerrainTile.TileWidth * (horizontalOffset - DefaultRightComplement - DefaultHorizontalBoundsOffset),
          TerrainTile.TileHeight * (verticalOffset - DefaultTopComplement - DefaultVerticalBoundsOffset),
          -TerrainTile.TileHeight * (verticalOffset - DefaultBottomComplement - DefaultVerticalBoundsOffset));
      info.CameraBoundsComplements = new RectangleMargins(DefaultLeftComplement, DefaultRightComplement, DefaultBottomComplement, DefaultTopComplement);
      info.PlayableMapAreaWidth = (int)mapWidth - info.CameraBoundsComplements.Left - info.CameraBoundsComplements.Right;
      info.PlayableMapAreaHeight = (int)mapHeight - info.CameraBoundsComplements.Bottom - info.CameraBoundsComplements.Top;

      info.MapFlags
          = MapFlags.UseItemClassificationSystem
          | MapFlags.ShowWaterWavesOnRollingShores
          | MapFlags.ShowWaterWavesOnCliffShores
          | MapFlags.MaskedAreasArePartiallyVisible
          | MapFlags.HasMapPropertiesMenuBeenOpened;

      info.Tileset = tileset;

      info.LoadingScreenBackgroundNumber = -1;
      info.LoadingScreenPath = string.Empty;
      info.LoadingScreenText = string.Empty;
      info.LoadingScreenTitle = string.Empty;
      info.LoadingScreenSubtitle = string.Empty;

      info.GameDataSet = GameDataSet.Unset;

      info.PrologueScreenPath = string.Empty;
      info.PrologueScreenText = string.Empty;
      info.PrologueScreenTitle = string.Empty;
      info.PrologueScreenSubtitle = string.Empty;

      info.FogStyle = FogStyle.Linear;
      info.FogStartZ = 3000f;
      info.FogEndZ = 5000f;
      info.FogDensity = 0.5f;
      info.FogColor = Color.Black;

      info.GlobalWeather = WeatherType.None;
      info.SoundEnvironment = string.Empty;
      info.LightEnvironment = 0;
      info.WaterTintingColor = Color.White;

      info.ScriptLanguage = ScriptLanguage.Lua;
      info.SupportedModes = SupportedModes.SD | SupportedModes.HD;
      info.GameDataVersion = GameDataVersion.TFT;

      var player0 = new PlayerData
      {
        Id = 0,
        Controller = PlayerController.User,
        Race = PlayerRace.Human,
        Flags = 0,
        Name = "Player 1",
        StartPosition = new Vector2(0f, 0f),
        AllyLowPriorityFlags = new Bitmask32(0),
        AllyHighPriorityFlags = new Bitmask32(0),
      };
      info.Players.Add(player0);

      var team0 = new ForceData
      {
        Flags = 0,
        Players = new Bitmask32(-1),
        Name = "Team 1",
      };
      info.Forces.Add(team0);

      return info;
    }

    public static MapEnvironment GetMapEnvironment(
        MapInfo mapInfo,
        TerrainType? initialTile = null,
        int initialCliffLevel = 2)
    {
      if (mapInfo is null)
      {
        throw new ArgumentNullException(nameof(mapInfo));
      }

      var tileset = mapInfo.Tileset;
      if (!initialTile.HasValue)
      {
        initialTile = TerrainTypeProvider.GetDefaultTerrainType(tileset);
      }

      var mapWidth = (uint)(mapInfo.PlayableMapAreaWidth + mapInfo.CameraBoundsComplements.Left + mapInfo.CameraBoundsComplements.Right);
      var mapHeight = (uint)(mapInfo.PlayableMapAreaHeight + mapInfo.CameraBoundsComplements.Bottom + mapInfo.CameraBoundsComplements.Top);

      var environment = new MapEnvironment(MapEnvironmentFormatVersion.Normal)
      {
        Tileset = tileset,
        TerrainTypes = TerrainTypeProvider.GetTerrainTypes(tileset).ToList(),
        CliffTypes = TerrainTypeProvider.GetCliffTypes(tileset).ToList(),
        Width = mapWidth,
        Height = mapHeight,
        Left = (TerrainTile.TileWidth * mapWidth) / -2f,
        Bottom = (TerrainTile.TileHeight * mapHeight) / -2f,
      };

      var initialTileTexture = environment.TerrainTypes.IndexOf(initialTile.Value);

      var edgeLeft = mapInfo.CameraBoundsComplements.Left;
      var edgeRight = mapWidth - mapInfo.CameraBoundsComplements.Right;
      var edgeBottom = mapInfo.CameraBoundsComplements.Bottom;
      var edgeTop = mapHeight - mapInfo.CameraBoundsComplements.Top;
      for (nint y = 0; y <= mapHeight; y++)
      {
        for (nint x = 0; x <= mapWidth; x++)
        {
          var tile = new TerrainTile
          {
            CliffLevel = initialCliffLevel,
            CliffTexture = 15,
            CliffVariation = 1,

            Height = 0,
            IsBlighted = false,
            IsBoundary = false,
            IsEdgeTile = x != mapWidth && y != mapHeight && (x < edgeLeft || x >= edgeRight || y < edgeBottom || y >= edgeTop),
            IsRamp = false,
            IsWater = false,
            Texture = initialTileTexture,
            Variation = 0,
            WaterHeight = 0
          };

          environment.TerrainTiles.Add(tile);
        }
      }

      return environment;
    }
  }
}