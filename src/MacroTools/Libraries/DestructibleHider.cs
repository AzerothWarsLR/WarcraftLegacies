using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Shared.Data;


/*
        Original vJASS version by Zwiebelchen. Rewriten in C# by Savantic and the Warcraft Legacis team https://discord.gg/N49uHDAA
    
            Destructables create an enormous amount of overhead on warcraft III maps, almost the same as units, especially walkable destructables.
            Thus, a large amount of destructables creates a huge drop of FPS in the game, even on fast machines, due to the poor engine of WC3.
            This effect is fairly noticable at an amount of even less than 1000 destructables, which is reached very fast when using invisible platforms.
            Warcraft III automaticly hides units outside the screen to save performance, however it does not do so for destructables, for unknown reasons.
            
            The purpose of this fully automatic system is to hide all those destructables, that are currently not viewed anyway, to save a lot of processing time.
            To do that, the entire map is splitted into tiles of an editable size and all destructables within those tiles are stored into a table, to allow fast access.
            When a tile is viewed, all destructables on adjacent tiles will also be shown, so that moving the camera doesnt create ugly popup effects when the center of the view is on the edge of a tile.
            
            However, there are some rules you need to consider, in order to make your map work without desyncs in multiplayer:
            - never hide destructables units or players can interact with (attackable, selectable or destructable)
            - hiding destructables that block pathing is safe, as hiding the destructable will not change its pathing
            - hiding destructables that need to be enumed is safe; hidden destructables can be enumerated
            - hiding walkable platforms is also safe, as long as you dont get a location Z for a location placed on that destructable globally; this is not 100% safe anyway, as
              the returned value of GetLocationZ() is dependant on the render state of the destructable
            
            
            API:
                    
                private function filter returns boolean
                    - add custom filter code for the automatic enumeration of destructables on map init inside
                    - if all destructables should be added to the system, let it return true
                    - example:
                        private function filter returns boolean
                            return GetDestructableMaxLife(GetFilterDestructable()) == 1
                        endfunction
                        -> automaticly adds all destructables on the map with a maximum life of 1 on map init to the system
            
            
            Optional:
            
                public function register takes destructable returns nothing
                    - adds a destructable to the system, also hides/shows the destructable depending on the position of the camera
                
                public function unregister takes destructable returns nothing
                    - removes a destructable from the system, also unhides the destructable in case it was hidden
            
            
    */

namespace MacroTools.Libraries
{
  /// <summary>
  /// Responsible for hiding destructibles which are not within a player's view.
  /// </summary>
  public static class DestructibleHider
  {
    //==== CONFIGURABLES ====
    private const float Interval = 0.10f; //Update interval in seconds.
    //[in multiplayer, the camera positions will only get updated every 0.05-0.1 seconds, so setting it to a lower value than 0.05 makes no sense]
    //[update frequency can be much higher in single player mode!]
    private const int DrawDistance = 3072; //the radius around the camera target in which the tiles are considered visible; should be about the same as sight radius (not diameter) of the camera; for 3d cams, use the FarZ value
    //Use multiples of 1024 for maximum efficiency on square division. Recommended value: 5120
    private const int TileResolution = 12; //amount of tiles spread over DRAW_DISTANCE
    //- higher resolution = more overhead to incrementing loop variables, but less amounts of destructables checked when moving the camera
    //- lower resolution = less overhead to incrementing loop variables, but higher amounts of destructables checked when moving the camera
    //-> Recommended value: 8-12
    //==== END OF CONFIGURABLES ====
    private static readonly Dictionary<int, List<destructable>> DestructablesByTileId = new();
    private static readonly int Columns;
    private static int _lastid;
    private static readonly float MapMinX;
    private static readonly float MapMinY;
    private const int Tilesize = DrawDistance / TileResolution;
    
    private static bool Filter(destructable destructable) => 
      GetDestructableMaxLife(destructable) == 1;

    /// <summary>
    /// Constructor for the DestructibleHider
    /// </summary>
    static DestructibleHider()
    {
      MapMinX = GetRectMinX(Rectangle.WorldBounds.Rect);
      MapMinY = GetRectMinY(Rectangle.WorldBounds.Rect);
      Columns = GetColumn(GetRectMaxX(Rectangle.WorldBounds.Rect),MapMinX);
      TimerStart(CreateTimer(), Interval, true, Periodic);
    }

    private static int GetTileId(float x, float y)
    {
      return GetColumn(x,MapMinX) + Columns * GetRow(y,MapMinY);
    }
    
    private static int GetRow(float currentY, float mapMinY)
    {
      return (int)Math.Max(1,Math.Ceiling((currentY - mapMinY) / Tilesize));
    }
    
    private static int GetColumn(float currentX, float mapMinX)
    {
      return (int)Math.Max(1,Math.Ceiling((currentX - mapMinX) / Tilesize));
    }
    
    private static void Periodic()
    {
      var tileId = GetTileId(GetCameraTargetPositionX(),GetCameraTargetPositionY());
      if (tileId == _lastid) return; //only check for tiles if the camera has left the last tile
      LoadTiles(GetTilesInRadius(tileId,TileResolution).Except(GetTilesInRadius(_lastid,TileResolution)).ToList());
      UnloadTiles(GetTilesInRadius(_lastid,TileResolution).Except(GetTilesInRadius(tileId,TileResolution)).ToList());
      _lastid = tileId;
    }

    /// <summary>
    /// Add destructable to the DestructibleHider
    /// </summary>
    /// <param name="destructable"></param>
    public static void Register(destructable destructable)
    {
      if (!Filter(destructable)) return;
      var tileId = GetTileId(GetDestructableX(destructable),GetDestructableY(destructable));
      if (!DestructablesByTileId.ContainsKey(tileId))
        DestructablesByTileId[tileId] = new List<destructable>();
      DestructablesByTileId[tileId].Add(destructable);
    }
    
    /// <summary>
    /// Remove adestructable from the DestructibleHider
    /// </summary>
    /// <param name="destructable"></param>
    public static void Unregister(destructable destructable)
    {
      var tileId = GetTileId(GetDestructableX(destructable),GetDestructableY(destructable));
      if (!DestructablesByTileId.ContainsKey(tileId)) return;
      DestructablesByTileId[tileId].Remove(destructable);
    }

    private static List<int> GetTilesInRadius(int cameraTileId, int radius)
    {
      var tiles = new List<int> { cameraTileId };
      for (var i = 0; i < radius; i++)
      {
        if (DestructablesByTileId.ContainsKey(cameraTileId + i)) tiles.Add(cameraTileId + i);
        if (DestructablesByTileId.ContainsKey(cameraTileId - i)) tiles.Add(cameraTileId - i);
        if (DestructablesByTileId.ContainsKey(cameraTileId + Columns*i)) tiles.Add(cameraTileId + Columns*i);
        if (DestructablesByTileId.ContainsKey(cameraTileId - Columns*i)) tiles.Add(cameraTileId - Columns*i);

        for (var j = 0; j < radius; j++)
        {
          if (DestructablesByTileId.ContainsKey(cameraTileId + Columns*i + j)) tiles.Add(cameraTileId + Columns*i + j);
          if (DestructablesByTileId.ContainsKey(cameraTileId + Columns*i - j)) tiles.Add(cameraTileId + Columns*i - j);
          if (DestructablesByTileId.ContainsKey(cameraTileId - Columns*i + j)) tiles.Add(cameraTileId - Columns*i + j);
          if (DestructablesByTileId.ContainsKey(cameraTileId - Columns*i - j)) tiles.Add(cameraTileId - Columns*i - j);
        }
      }

      return tiles;
    }

    private static void LoadTiles(List<int> tiles)
    {
      foreach (var tileId in tiles)
      {
        if (!DestructablesByTileId.ContainsKey(tileId)) continue;
        foreach (var destructable in DestructablesByTileId[tileId])
        {
          ShowDestructable(destructable,true);
        }

      }
    }
    
    private static void UnloadTiles(List<int> tiles)
    {
      foreach (var tileId in tiles)
      {
        if (!DestructablesByTileId.ContainsKey(tileId)) continue;
        foreach (var destructable in DestructablesByTileId[tileId])
        {
          ShowDestructable(destructable,false);
        }
      }
    }
  }
}