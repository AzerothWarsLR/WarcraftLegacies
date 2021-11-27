library DestructableHider initializer init

    /*
        by Zwiebelchen      v1.3
    
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
                    
                private function filt returns boolean
                    - add custom filter code for the automatic enumeration of destructables on map init inside
                    - if all destructables should be added to the system, let it return true
                    - example:
                        private function filt returns boolean
                            return GetDestructableMaxLife(GetFilterDestructable()) == 1
                        endfunction
                        -> automaticly adds all destructables on the map with a maximum life of 1 on map init to the system
            
            
            Optional:
            
                public function register takes destructable returns nothing
                    - adds a destructable to the system, also hides/shows the destructable depending on the position of the camera
                
                public function unregister takes destructable returns nothing
                    - removes a destructable from the system, also unhides the destructable in case it was hidden
            
            
    */
    
globals
    //==== CONFIGURABLES ====
    private constant real INTERVAL = 0.10 //Update interval in seconds.
                                         //[in multiplayer, the camera positions will only get updated every 0.05-0.1 seconds, so setting it to a lower value than 0.05 makes no sense]
                                         //[update frequency can be much higher in single player mode!]
    private constant integer DRAW_DISTANCE = 3072 //the radius around the camera target in which the tiles are considered visible; should be about the same as sight radius (not diameter) of the camera; for 3d cams, use the FarZ value
                                                 //Use multiples of 1024 for maximum efficiency on square division. Recommended value: 5120
    private constant integer TILE_RESOLUTION = 12 //amount of tiles spread over DRAW_DISTANCE
                                        //- higher resolution = more overhead to incrementing loop variables, but less amounts of destructables checked when moving the camera
                                        //- lower resolution = less overhead to incrementing loop variables, but higher amounts of destructables checked when moving the camera
                                        //-> Recommended value: 8-12
    //==== END OF CONFIGURABLES ====
    
    private hashtable hash = InitHashtable()
    private integer columns = 0
    private integer rows = 0
    private integer lastrow = 0
    private integer lastcolumn = 0
    private integer lastid = 0
    private real mapMinX = 0
    private real mapMinY = 0
    private constant integer TILESIZE = DRAW_DISTANCE/TILE_RESOLUTION
endglobals

private function filt takes nothing returns boolean
return GetDestructableMaxLife(GetFilterDestructable()) == 1
return true
endfunction

public function register takes destructable d returns nothing
    local integer id = R2I((GetDestructableY(d)-mapMinY)/TILESIZE)*columns + R2I((GetDestructableX(d)-mapMinX)/TILESIZE)
    local integer count = LoadInteger(hash, id, 0)+1
    call SaveInteger(hash, id, 0, count)
    call SaveDestructableHandle(hash, id, count, d)
    call ShowDestructable(d, LoadBoolean(hash, id, -1)) //match visibility state
    call SaveInteger(hash, GetHandleId(d), 0, count) //store the list position for fast lookup
endfunction

public function unregister takes destructable d returns nothing
    local integer id = R2I((GetDestructableY(d)-mapMinY)/TILESIZE)*columns + R2I((GetDestructableX(d)-mapMinX)/TILESIZE)
    local integer count = LoadInteger(hash, id, 0)
    local integer a = LoadInteger(hash, GetHandleId(d), 0)
    local destructable temp
    if a < count then //move the last in list up to this slot
        set temp = LoadDestructableHandle(hash, id, count)
        call SaveDestructableHandle(hash, id, a, temp)
        call SaveInteger(hash, GetHandleId(temp), 0, a) //update list position
        set temp = null
    endif
    call RemoveSavedHandle(hash, id, count) //clean up the deserted slot
    call SaveInteger(hash, id, 0, count-1)
    call FlushChildHashtable(hash, GetHandleId(d)) //clean up list position
    call ShowDestructable(d, true) //make sure its shown again in case it was hidden
endfunction

private function autoregister takes nothing returns nothing
    local destructable d = GetEnumDestructable()
    local integer id = R2I((GetDestructableY(d)-mapMinY)/TILESIZE)*columns + R2I((GetDestructableX(d)-mapMinX)/TILESIZE)
    local integer count = LoadInteger(hash, id, 0)+1
    call SaveInteger(hash, id, 0, count)
    call SaveDestructableHandle(hash, id, count, d)
    call ShowDestructable(d, false) //initially hide everything
    call SaveInteger(hash, GetHandleId(d), 0, count) //store the list position for fast lookup
    set d = null
endfunction

private function EnumGrid takes integer x1, integer x2, integer y1, integer y2, boolean show returns nothing
    local integer a = x1
    local integer b
    local integer j
    local integer id
    local integer count
    loop
        set b = y1
        exitwhen a > x2
        loop
            exitwhen b > y2
            set id = b*columns+a
            call SaveBoolean(hash, id, -1, show)
            set count = LoadInteger(hash, id, 0)
            set j = 0
            loop
                exitwhen j >= count
                set j = j + 1
                call ShowDestructable(LoadDestructableHandle(hash, id, j), show)
            endloop
            set b = b + 1
        endloop
        set a = a + 1
    endloop
endfunction

private function ChangeTiles takes integer r, integer c, integer lr, integer lc returns nothing
    local integer AminX = c-TILE_RESOLUTION
    local integer AmaxX = c+TILE_RESOLUTION
    local integer AminY = r-TILE_RESOLUTION
    local integer AmaxY = r+TILE_RESOLUTION
    local integer BminX = lc-TILE_RESOLUTION
    local integer BmaxX = lc+TILE_RESOLUTION
    local integer BminY = lr-TILE_RESOLUTION
    local integer BmaxY = lr+TILE_RESOLUTION
    //border safety:
    if AminX < 0 then
        set AminX = 0
    endif
    if AminY < 0 then
        set AminY = 0
    endif
    if BminX < 0 then
        set BminX = 0
    endif
    if BminY < 0 then
        set BminY = 0
    endif
    if AmaxX >= columns then
        set AmaxX = columns-1
    endif
    if AmaxY >= rows then
        set AmaxX = rows-1
    endif
    if BmaxX >= columns then
        set BmaxX = columns-1
    endif
    if BmaxY >= rows then
        set BmaxX = rows-1
    endif
    
    if BmaxX < AminX or AmaxX < BminX or BmaxY < AminY or AmaxY < BminY then
        call EnumGrid(AminX, AmaxX, AminY, AmaxY, true)
        call EnumGrid(BminX, BmaxX, BminY, BmaxY, false)
    else
        if c >= lc then
            if c != lc then
                call EnumGrid(BmaxX+1, AmaxX, AminY, AmaxY, true)
                call EnumGrid(BminX, AminX-1, BminY, BmaxY, false)
            endif
            if AminY < BminY then
                call EnumGrid(AminX, BmaxX, AmaxY+1, BmaxY, false)
                call EnumGrid(AminX, BmaxX, AminY, BminY-1, true)
            elseif BminY < AminY then
                call EnumGrid(AminX, BmaxX, BmaxY+1, AmaxY, true)
                call EnumGrid(AminX, BmaxX, BminY, AminY-1, false)
            endif
        else
            call EnumGrid(AminX, BminX-1, AminY, AmaxY, true)
            call EnumGrid(AmaxX+1, BmaxX, BminY, BmaxY, false)
            if AminY < BminY then
                call EnumGrid(BminX, AmaxX, AminY, BminY-1, true)
                call EnumGrid(BminX, AmaxX, AmaxY+1, BmaxY, false)
            elseif BminY < AminY then
                call EnumGrid(BminX, AmaxX, BminY, AminY-1, false)
                call EnumGrid(BminX, AmaxX, BmaxY+1, AmaxY, true)
            endif
        endif
    endif
endfunction

private function periodic takes nothing returns nothing
    local integer row = R2I((GetCameraTargetPositionY()-mapMinY)/TILESIZE)
    local integer column = R2I((GetCameraTargetPositionX()-mapMinX)/TILESIZE)
    local integer id = row*columns + column
    if id == lastid then //only check for tiles if the camera has left the last tile
        return
    endif
    call ChangeTiles(row, column, lastrow, lastcolumn)
    set lastrow = row
    set lastcolumn = column
    set lastid = id
endfunction

private function init takes nothing returns nothing
    set mapMinX = GetRectMinX(bj_mapInitialPlayableArea)
    set mapMinY = GetRectMinY(bj_mapInitialPlayableArea)
    set lastrow = R2I((GetCameraTargetPositionY()-mapMinY)/TILESIZE)
    set lastcolumn = R2I((GetCameraTargetPositionX()-mapMinX)/TILESIZE)
    set rows = R2I((GetRectMaxY(bj_mapInitialPlayableArea)-mapMinY)/TILESIZE)+1
    set columns = R2I((GetRectMaxX(bj_mapInitialPlayableArea)-mapMinX)/TILESIZE)+1
    if lastcolumn <= columns/2 then //to make sure the game starts with a full make-visible enum of all destructables on screen
        set lastcolumn = columns-1
    else
        set lastcolumn = 0
    endif
    if lastrow <= rows/2 then
        set lastrow = rows-1
    else
        set lastrow = 0
    endif
    set lastid = lastrow*columns + lastcolumn
    call EnumDestructablesInRect(bj_mapInitialPlayableArea, Filter(function filt), function autoregister)
    call TimerStart(CreateTimer(), INTERVAL, true, function periodic)
    call periodic() //to make sure the destructables on screen after the map loading process finishes are initially shown
endfunction

endlibrary