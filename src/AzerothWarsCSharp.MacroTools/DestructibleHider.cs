using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools
{
  public static class DestructibleHider
  {
    //==== CONFIGURABLES ====
    private const float INTERVAL = 0.10f; //Update interval in seconds.

    //[in multiplayer, the camera positions will only get updated every 005-01 seconds, so setting it to a lower value than 005 makes no sense]
    //[update frequency can be much higher in single player mode!]
    private const int
      DRAW_DISTANCE =
        3072; //the radius around the camera target in which the tiles are considered visible; should be about the same as sight radius (not diameter) of the camera; for 3d cams, use the FarZ value

    //Use multiples of 1024 for maximum efficiency on square division. Recommended value: 5120
    private const int TILE_RESOLUTION = 12; //amount of tiles spread over DRAW_DISTANCE
    private const int TILESIZE = DRAW_DISTANCE / TILE_RESOLUTION;


    //-> Recommended value: 8-12
    //==== END OF CONFIGURABLES ====

    private static readonly hashtable Hash = InitHashtable();
    private static int _columns;
    private static int _rows;
    private static int _lastrow;
    private static int _lastcolumn;
    private static int _lastid;
    private static float _mapMinX;
    private static float _mapMinY;


    private static bool Filt()
    {
      return true;
    }

    public static void Register(destructable d)
    {
      var id = R2I((GetDestructableY(d) - _mapMinY) / TILESIZE) * _columns +
               R2I((GetDestructableX(d) - _mapMinX) / TILESIZE);
      var count = LoadInteger(Hash, id, 0) + 1;
      SaveInteger(Hash, id, 0, count);
      SaveDestructableHandle(Hash, id, count, d);
      ShowDestructable(d, LoadBoolean(Hash, id, -1)); //match visibility state
      SaveInteger(Hash, GetHandleId(d), 0, count); //store the list position for fast lookup
    }

    public static void Unregister(destructable d)
    {
      var id = R2I((GetDestructableY(d) - _mapMinY) / TILESIZE) * _columns +
               R2I((GetDestructableX(d) - _mapMinX) / TILESIZE);
      var count = LoadInteger(Hash, id, 0);
      var a = LoadInteger(Hash, GetHandleId(d), 0);

      if (a < count)
      {
        destructable temp = LoadDestructableHandle(Hash, id, count);
        SaveDestructableHandle(Hash, id, a, temp);
        SaveInteger(Hash, GetHandleId(temp), 0, a); //update list position
      }

      RemoveSavedHandle(Hash, id, count); //clean up the deserted slot
      SaveInteger(Hash, id, 0, count - 1);
      FlushChildHashtable(Hash, GetHandleId(d)); //clean up list position
      ShowDestructable(d, true); //make sure its shown again in case it was hidden
    }

    private static void Autoregister()
    {
      destructable d = GetEnumDestructable();
      var id = R2I((GetDestructableY(d) - _mapMinY) / TILESIZE) * _columns +
               R2I((GetDestructableX(d) - _mapMinX) / TILESIZE);
      var count = LoadInteger(Hash, id, 0) + 1;
      SaveInteger(Hash, id, 0, count);
      SaveDestructableHandle(Hash, id, count, d);
      ShowDestructable(d, false); //initially hide everything
      SaveInteger(Hash, GetHandleId(d), 0, count); //store the list position for fast lookup
    }

    private static void EnumGrid(int x1, int x2, int y1, int y2, bool show)
    {
      var a = x1;
      while (true)
      {
        var b = y1;
        if (a > x2) break;

        while (true)
        {
          if (b > y2) break;

          var id = b * _columns + a;
          SaveBoolean(Hash, id, -1, show);
          var count = LoadInteger(Hash, id, 0);
          var j = 0;
          while (true)
          {
            if (j >= count) break;

            j = j + 1;
          }

          b = b + 1;
        }

        a = a + 1;
      }
    }

    private static void ChangeTiles(int r, int c, int lr, int lc)
    {
      var aminX = c - TILE_RESOLUTION;
      var amaxX = c + TILE_RESOLUTION;
      var aminY = r - TILE_RESOLUTION;
      var amaxY = r + TILE_RESOLUTION;
      var bminX = lc - TILE_RESOLUTION;
      var bmaxX = lc + TILE_RESOLUTION;
      var bminY = lr - TILE_RESOLUTION;
      var bmaxY = lr + TILE_RESOLUTION;
      //border safety:
      if (aminX < 0) aminX = 0;

      if (aminY < 0) aminY = 0;

      if (bminX < 0) bminX = 0;

      if (bminY < 0) bminY = 0;

      if (amaxX >= _columns) amaxX = _columns - 1;

      if (amaxY >= _rows) amaxX = _rows - 1;

      if (bmaxX >= _columns) bmaxX = _columns - 1;

      if (bmaxY >= _rows) bmaxX = _rows - 1;

      if (bmaxX < aminX || amaxX < bminX || bmaxY < aminY || amaxY < bminY)
      {
        EnumGrid(aminX, amaxX, aminY, amaxY, true);
        EnumGrid(bminX, bmaxX, bminY, bmaxY, false);
      }
      else
      {
        if (c >= lc)
        {
          if (c != lc)
          {
            EnumGrid(bmaxX + 1, amaxX, aminY, amaxY, true);
            EnumGrid(bminX, aminX - 1, bminY, bmaxY, false);
          }

          if (aminY < bminY)
          {
            EnumGrid(aminX, bmaxX, amaxY + 1, bmaxY, false);
            EnumGrid(aminX, bmaxX, aminY, bminY - 1, true);
          }
          else if (bminY < aminY)
          {
            EnumGrid(aminX, bmaxX, bmaxY + 1, amaxY, true);
            EnumGrid(aminX, bmaxX, bminY, aminY - 1, false);
          }
        }
        else
        {
          EnumGrid(aminX, bminX - 1, aminY, amaxY, true);
          EnumGrid(amaxX + 1, bmaxX, bminY, bmaxY, false);
          if (aminY < bminY)
          {
            EnumGrid(bminX, amaxX, aminY, bminY - 1, true);
            EnumGrid(bminX, amaxX, amaxY + 1, bmaxY, false);
          }
          else if (bminY < aminY)
          {
            EnumGrid(bminX, amaxX, bminY, aminY - 1, false);
            EnumGrid(bminX, amaxX, bmaxY + 1, amaxY, true);
          }
        }
      }
    }

    private static void Periodic()
    {
      var row = R2I((GetCameraTargetPositionY() - _mapMinY) / TILESIZE);
      var column = R2I((GetCameraTargetPositionX() - _mapMinX) / TILESIZE);
      var id = row * _columns + column;
      if (id == _lastid)
        //only check for tiles if the camera has left the last tile
        return;

      ChangeTiles(row, column, _lastrow, _lastcolumn);
      _lastrow = row;
      _lastcolumn = column;
      _lastid = id;
    }

    public static void Setup()
    {
      _mapMinX = GetRectMinX(bj_mapInitialPlayableArea);
      _mapMinY = GetRectMinY(bj_mapInitialPlayableArea);
      _lastrow = R2I((GetCameraTargetPositionY() - _mapMinY) / TILESIZE);
      _lastcolumn = R2I((GetCameraTargetPositionX() - _mapMinX) / TILESIZE);
      _rows = R2I((GetRectMaxY(bj_mapInitialPlayableArea) - _mapMinY) / TILESIZE) + 1;
      _columns = R2I((GetRectMaxX(bj_mapInitialPlayableArea) - _mapMinX) / TILESIZE) + 1;
      if (
        _lastcolumn <=
        _columns / 2) //to make sure the game starts with a full make-visible enum of all destructables on screen
        _lastcolumn = _columns - 1;
      else
        _lastcolumn = 0;

      if (_lastrow <= _rows / 2)
        _lastrow = _rows - 1;
      else
        _lastrow = 0;

      _lastid = _lastrow * _columns + _lastcolumn;
      EnumDestructablesInRect(bj_mapInitialPlayableArea, Filter(Filt), Autoregister);
      TimerStart(CreateTimer(), INTERVAL, true, Periodic);
      Periodic(); //to make sure the destructables on screen after the map loading process finishes are initially shown
    }
  }
}