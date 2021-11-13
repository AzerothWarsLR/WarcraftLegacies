//using static War3Api.Common;
//using static War3Api.Blizzard;

//namespace AzerothWarsCSharp.Source.GameLogic
//{
//  /// <summary>
//  /// Hides destructibles from players that don't have their camera over them.
//  /// </summary>
//  public static class DestructibleHider
//  {
//    //==== CONFIGURABLES ====
//    private static readonly float INTERVAL = 0.10f;
//    private static readonly int DRAW_DISTANCE = 3072;
//    private static readonly int TILE_RESOLUTION = 12;
//    //==== END OF CONFIGURABLES ====

//    private static readonly hashtable hash = InitHashtable();
//    private static int columns = 0;
//    private static int rows = 0;
//    private static int lastrow = 0;
//    private static int lastcolumn = 0;
//    private static int lastid = 0;
//    private static float mapMinX = 0;
//    private static float mapMinY = 0;
//    private static readonly int TILESIZE = DRAW_DISTANCE / TILE_RESOLUTION;

//    public static void Initialize()
//    {
//      mapMinX = GetRectMinX(bj_mapInitialPlayableArea);
//      mapMinY = GetRectMinY(bj_mapInitialPlayableArea);
//      lastrow = R2I((GetCameraTargetPositionY() - mapMinY) / TILESIZE);
//      lastcolumn = R2I((GetCameraTargetPositionX() - mapMinX) / TILESIZE);
//      rows = R2I((GetRectMaxY(bj_mapInitialPlayableArea) - mapMinY) / TILESIZE) + 1;
//      columns = R2I((GetRectMaxX(bj_mapInitialPlayableArea) - mapMinX) / TILESIZE) + 1;
//      if (lastcolumn <= columns / 2)
//      { //to make sure the game starts with a full make-visible enum of all destructables on screen
//        lastcolumn = columns - 1;
//      }
//      else
//      {
//        lastcolumn = 0;
//      }
//      if (lastrow <= rows / 2)
//      {
//        lastrow = rows - 1;
//      }
//      else
//      {
//        lastrow = 0;
//      }
//      lastid = lastrow * columns + lastcolumn;
//      EnumDestructablesInRect(bj_mapInitialPlayableArea, Filter(Filt), Autoregister);
//      TimerStart(CreateTimer(), INTERVAL, true, Periodic);
//      Periodic(); //to make sure the destructables on screen after the map loading process finishes are initially shown
//    }

//    private static bool Filt()
//    {
//      return GetDestructableMaxLife(GetFilterDestructable()) == 1;
//    }

//    public static void Register(destructable d)
//    {
//      int id = R2I((GetDestructableY(d) - mapMinY) / TILESIZE) * columns + R2I((GetDestructableX(d) - mapMinX) / TILESIZE);
//      int count = LoadInteger(hash, id, 0) + 1;
//      SaveInteger(hash, id, 0, count);
//      SaveDestructableHandle(hash, id, count, d);
//      ShowDestructable(d, LoadBoolean(hash, id, -1)); //match visibility state
//      SaveInteger(hash, GetHandleId(d), 0, count); //store the list position for fast lookup
//    }

//    public static void Unregister(destructable d)
//    {
//      int id = R2I((GetDestructableY(d) - mapMinY) / TILESIZE) * columns + R2I((GetDestructableX(d) - mapMinX) / TILESIZE);
//      int count = LoadInteger(hash, id, 0);
//      int a = LoadInteger(hash, GetHandleId(d), 0);
//      destructable temp;
//      if (a < count)
//      { //move the last in list up to this slot
//        temp = LoadDestructableHandle(hash, id, count);
//        SaveDestructableHandle(hash, id, a, temp);
//        SaveInteger(hash, GetHandleId(temp), 0, a); //update list position
//      }
//      RemoveSavedHandle(hash, id, count); //clean up the deserted slot
//      SaveInteger(hash, id, 0, count - 1);
//      FlushChildHashtable(hash, GetHandleId(d)); //clean up list position
//      ShowDestructable(d, true); //make sure its shown again in case it was hidden
//    }

//    private static void Autoregister()
//    {
//      destructable d = GetEnumDestructable();
//      int id = R2I((GetDestructableY(d) - mapMinY) / TILESIZE) * columns + R2I((GetDestructableX(d) - mapMinX) / TILESIZE);
//      int count = LoadInteger(hash, id, 0) + 1;
//      SaveInteger(hash, id, 0, count);
//      SaveDestructableHandle(hash, id, count, d);
//      ShowDestructable(d, false); //initially hide everything
//      SaveInteger(hash, GetHandleId(d), 0, count); //store the list position for fast lookup
//    }

//    private static void EnumGrid(int x1, int x2, int y1, int y2, bool show)
//    {
//      for (int a = x1; a <= x2; a++)
//      {
//        for (var b = y1; b <= y2; b++)
//        {
//          var id = b * columns + a;
//          SaveBoolean(hash, id, -1, show);
//          int count = LoadInteger(hash, id, 0);
//          for (var j = 0; j < count; j++)
//          {
//            ShowDestructable(LoadDestructableHandle(hash, id, j), show);
//          }
//        }
//      }
//    }

//    private static void ChangeTiles(int r, int c, int lr, int lc)
//    {
//      int AminX = c - TILE_RESOLUTION;
//      int AmaxX = c + TILE_RESOLUTION;
//      int AminY = r - TILE_RESOLUTION;
//      int AmaxY = r + TILE_RESOLUTION;
//      int BminX = lc - TILE_RESOLUTION;
//      int BmaxX = lc + TILE_RESOLUTION;
//      int BminY = lr - TILE_RESOLUTION;
//      int BmaxY = lr + TILE_RESOLUTION;
//      //border safety:
//      if (AminX < 0)
//      {
//        AminX = 0;
//      }
//      if (AminY < 0)
//      {
//        AminY = 0;
//      }
//      if (BminX < 0)
//      {
//        BminX = 0;
//      }
//      if (BminY < 0)
//      {
//        BminY = 0;
//      }
//      if (AmaxX >= columns)
//      {
//        AmaxX = columns - 1;
//      }
//      if (AmaxY >= rows)
//      {
//        AmaxX = rows - 1;
//      }
//      if (BmaxX >= columns)
//      {
//        BmaxX = columns - 1;
//      }
//      if (BmaxY >= rows)
//      {
//        BmaxX = rows - 1;
//      }

//      if (BmaxX < AminX || AmaxX < BminX || BmaxY < AminY || AmaxY < BminY)
//      {
//        EnumGrid(AminX, AmaxX, AminY, AmaxY, true);
//        EnumGrid(BminX, BmaxX, BminY, BmaxY, false);
//      }
//      else if (c >= lc)
//      {
//        if (c != lc)
//        {
//          EnumGrid(BmaxX + 1, AmaxX, AminY, AmaxY, true);
//          EnumGrid(BminX, AminX - 1, BminY, BmaxY, false);
//        }
//        if (AminY < BminY)
//        {
//          EnumGrid(AminX, BmaxX, AmaxY + 1, BmaxY, false);
//          EnumGrid(AminX, BmaxX, AminY, BminY - 1, true);
//        }
//        else if (BminY < AminY)
//        {
//          EnumGrid(AminX, BmaxX, BmaxY + 1, AmaxY, true);
//          EnumGrid(AminX, BmaxX, BminY, AminY - 1, false);
//        }
//        else
//        {
//          EnumGrid(AminX, BminX - 1, AminY, AmaxY, true);
//          EnumGrid(AmaxX + 1, BmaxX, BminY, BmaxY, false);
//          if (AminY < BminY)
//          {
//            EnumGrid(BminX, AmaxX, AminY, BminY - 1, true);
//            EnumGrid(BminX, AmaxX, AmaxY + 1, BmaxY, false);
//          }
//          else if (BminY < AminY)
//          {
//            EnumGrid(BminX, AmaxX, BminY, AminY - 1, false);
//            EnumGrid(BminX, AmaxX, BmaxY + 1, AmaxY, true);
//          }
//        }
//      }
//    }


//    private static void Periodic()
//    {
//      int row = R2I((GetCameraTargetPositionY() - mapMinY) / TILESIZE);
//      int column = R2I((GetCameraTargetPositionX() - mapMinX) / TILESIZE);
//      int id = row * columns + column;
//      if (id == lastid)
//      { //only check for tiles if the camera has left the last tile
//        return;
//      }
//      ChangeTiles(row, column, lastrow, lastcolumn);
//      lastrow = row;
//      lastcolumn = column;
//      lastid = id;
//    }
//  }
//}