

    /*
        by Zwiebelchen      v13










            However, there are some rules you need to consider, in order to make your map work without desyncs in multiplayer:







            API:

                private static boolean filt ){


                    - example:
                        private static boolean filt ){

                        }



            Optional:








    */


    //==== CONFIGURABLES ====
    private const float INTERVAL = 010 ;//Update interval in seconds.
                                         //[in multiplayer, the camera positions will only get updated every 005-01 seconds, so setting it to a lower value than 005 makes no sense]
                                         //[update frequency can be much higher in single player mode!]
    private const int DRAW_DISTANCE = 3072 ;//the radius around the camera target in which the tiles are considered visible; should be about the same as sight radius (not diameter) of the camera; for 3d cams, use the FarZ value
                                                 //Use multiples of 1024 for maximum efficiency on square division. Recommended value: 5120
    private const int TILE_RESOLUTION = 12 ;//amount of tiles spread over DRAW_DISTANCE


                                        //-> Recommended value: 8-12
    //==== END OF CONFIGURABLES ====

    private hashtable hash = InitHashtable();
    private var columns = 0;
    private var rows = 0;
    private var lastrow = 0;
    private var lastcolumn = 0;
    private var lastid = 0;
    private float mapMinX = 0;
    private float mapMinY = 0;
    private const int TILESIZE = DRAW_DISTANCE/TILE_RESOLUTION;


private static boolean filt( ){

return true;
}



    var count = LoadInteger(hash, id, 0)+1;
    SaveInteger(hash, id, 0, count);


    SaveInteger(hash, GetHandleId(d), 0, count) ;//store the list position for fast lookup
}



    int count = LoadInteger(hash, id, 0);
    int a = LoadInteger(hash, GetHandleId(d), 0);

    if (a < count){ //move the last in list up to this slot


        SaveInteger(hash, GetHandleId(temp), 0, a) ;//update list position
        temp = null;
    }
    RemoveSavedHandle(hash, id, count) ;//clean up the deserted slot
    SaveInteger(hash, id, 0, count-1);
    FlushChildHashtable(hash, GetHandleId(d)) ;//clean up list position

}

private static void autoregister( ){


    var count = LoadInteger(hash, id, 0)+1;
    SaveInteger(hash, id, 0, count);


    SaveInteger(hash, GetHandleId(d), 0, count) ;//store the list position for fast lookup
    d = null;
}

private static void EnumGrid(int x1, int x2, int y1, int y2, boolean show ){
    var a = x1;
    int b;
    int j;
    int id;
    int count;
    while(true){
        b = y1;
        if ( a > x2){ break; }
        while(true){
            if ( b > y2){ break; }
            id = b*columns+a;
            SaveBoolean(hash, id, -1, show);
            count = LoadInteger(hash, id, 0);
            j = 0;
            while(true){
                if ( j >= count){ break; }
                j = j + 1;

            }
            b = b + 1;
        }
        a = a + 1;
    }
}

private static void ChangeTiles(int r, int c, int lr, int lc ){
    var AminX = c-TILE_RESOLUTION;
    var AmaxX = c+TILE_RESOLUTION;
    var AminY = r-TILE_RESOLUTION;
    var AmaxY = r+TILE_RESOLUTION;
    var BminX = lc-TILE_RESOLUTION;
    var BmaxX = lc+TILE_RESOLUTION;
    var BminY = lr-TILE_RESOLUTION;
    var BmaxY = lr+TILE_RESOLUTION;
    //border safety:
    if (AminX < 0){
        AminX = 0;
    }
    if (AminY < 0){
        AminY = 0;
    }
    if (BminX < 0){
        BminX = 0;
    }
    if (BminY < 0){
        BminY = 0;
    }
    if (AmaxX >= columns){
        AmaxX = columns-1;
    }
    if (AmaxY >= rows){
        AmaxX = rows-1;
    }
    if (BmaxX >= columns){
        BmaxX = columns-1;
    }
    if (BmaxY >= rows){
        BmaxX = rows-1;
    }

    if (BmaxX < AminX || AmaxX < BminX || BmaxY < AminY || AmaxY < BminY){
        EnumGrid(AminX, AmaxX, AminY, AmaxY, true);
        EnumGrid(BminX, BmaxX, BminY, BmaxY, false);
    }else {
        if (c >= lc){
            if (c != lc){
                EnumGrid(BmaxX+1, AmaxX, AminY, AmaxY, true);
                EnumGrid(BminX, AminX-1, BminY, BmaxY, false);
            }
            if (AminY < BminY){
                EnumGrid(AminX, BmaxX, AmaxY+1, BmaxY, false);
                EnumGrid(AminX, BmaxX, AminY, BminY-1, true);
            }else if (BminY < AminY){
                EnumGrid(AminX, BmaxX, BmaxY+1, AmaxY, true);
                EnumGrid(AminX, BmaxX, BminY, AminY-1, false);
            }
        }else {
            EnumGrid(AminX, BminX-1, AminY, AmaxY, true);
            EnumGrid(AmaxX+1, BmaxX, BminY, BmaxY, false);
            if (AminY < BminY){
                EnumGrid(BminX, AmaxX, AminY, BminY-1, true);
                EnumGrid(BminX, AmaxX, AmaxY+1, BmaxY, false);
            }else if (BminY < AminY){
                EnumGrid(BminX, AmaxX, BminY, AminY-1, false);
                EnumGrid(BminX, AmaxX, BmaxY+1, AmaxY, true);
            }
        }
    }
}

private static void periodic( ){
    var row = R2I((GetCameraTargetPositionY()-mapMinY)/TILESIZE);
    var column = R2I((GetCameraTargetPositionX()-mapMinX)/TILESIZE);
    var id = row*columns + column;
    if (id == lastid){ //only check for tiles if the camera has left the last tile
        return;
    }
    ChangeTiles(row, column, lastrow, lastcolumn);
    lastrow = row;
    lastcolumn = column;
    lastid = id;
}

private static void init( ){
    mapMinX = GetRectMinX(bj_mapInitialPlayableArea);
    mapMinY = GetRectMinY(bj_mapInitialPlayableArea);
    lastrow = R2I((GetCameraTargetPositionY()-mapMinY)/TILESIZE);
    lastcolumn = R2I((GetCameraTargetPositionX()-mapMinX)/TILESIZE);
    rows = R2I((GetRectMaxY(bj_mapInitialPlayableArea)-mapMinY)/TILESIZE)+1;
    columns = R2I((GetRectMaxX(bj_mapInitialPlayableArea)-mapMinX)/TILESIZE)+1;

        lastcolumn = columns-1;
    }else {
        lastcolumn = 0;
    }
    if (lastrow <= rows/2){
        lastrow = rows-1;
    }else {
        lastrow = 0;
    }
    lastid = lastrow*columns + lastcolumn;

    TimerStart(CreateTimer(), INTERVAL, true,  periodic);

}

}
