 using AzerothWarsCSharp.Source.Main.Libraries;
 using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

 library ArtifactMenu initializer OnInit requires Artifact, Persons, Faction

  
    private float        BACKDROP_WIDTH = 07;
    private float        BACKDROP_HEIGHT = 037;
    private float        Y_OFFSET_TOP = 0025         ;//How much space to push the artifact representations in from the top
    private float        Y_OFFSET_BOT = 005         ;//How much space to push the artifact representations in from the bottom
    private float        BOTTOM_BUTTON_X_OFFSET = 002;
    private float        BOTTOM_BUTTON_Y_OFFSET = 0015;
    private float        TOOLTIP_WIDTH = 025;
    private float        TOOLTIP_HEIGHT = 01;

    private int     COLUMN_COUNT = 5;
    private int     ROW_COUNT = 3;

    private float        BOX_WIDTH = 013;
    private float        BOX_HEIGHT = 0086;

    framehandle ArtifactMenuLauncher
    framehandle ArtifactMenuBackdrop
    framehandle ArtifactMenuExit
  

  private static void LoadToc(string s ){
    if (!BlzLoadTOCFile(s)){
      BJDebugMsg("Failed to Load TOC: "+s);
    }
  }


    static thistype[] pageArray
    static int[] activePageId        //-1 means no page is active. Indexed per player
    int id

    framehandle backdrop
    framehandle title
    framehandle pageNumber
    framehandle exitButton
    framehandle nextButton
    framehandle prevButton
    trigger nextTrigger = null;
    trigger prevTrigger = null;
    trigger exitTrigger = null;

    static void exitButtonClick( ){
      int pId = GetPlayerId(GetTriggerPlayer());
      if (thistype.activePageId[pId] > -1){
        if (GetLocalPlayer() == GetTriggerPlayer()){
          BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]].backdrop, false);
        }
        thistype.activePageId[pId] = -1;
      }
    }

    static void nextButtonClick( ){
      int pId = GetPlayerId(GetTriggerPlayer());
      if (thistype.activePageId[pId]> -1 && thistype.pageArray[thistype.activePageId[pId] + 1] != 0){
        if (GetLocalPlayer() == GetTriggerPlayer()){
          BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]].backdrop, false);
          BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]+ 1].backdrop, true);
        }
        thistype.activePageId[pId]= thistype.activePageId[pId]+ 1
      }
    }

    static void prevButtonClick( ){
      int pId = GetPlayerId(GetTriggerPlayer());
      if (thistype.activePageId[pId]> -1 && thistype.pageArray[thistype.activePageId[pId] - 1] != 0){
        if (GetLocalPlayer() == GetTriggerPlayer()){
            BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]].backdrop, false);
            BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]- 1].backdrop, true);
        }
      }
      thistype.activePageId[pId]= thistype.activePageId[pId]- 1
    }

    void destroy( ){
      DestroyTrigger(this.nextTrigger);
      DestroyTrigger(this.prevTrigger);
      DestroyTrigger(this.exitTrigger);

      BlzDestroyFrame(this.prevButton);
      BlzDestroyFrame(this.nextButton);
      BlzDestroyFrame(this.exitButton);
      BlzDestroyFrame(this.title);
      BlzDestroyFrame(this.pageNumber);
      BlzDestroyFrame(this.backdrop);

      this.deallocate();
    }

    void destroyNextButton( ){
      BlzDestroyFrame(this.nextButton);
      this.nextButton = null;
    }

    void destroyPrevButton( ){
      BlzDestroyFrame(this.prevButton);
      this.prevButton = null;
    }

    void createNextButton( ){
      this.nextButton = BlzCreateFrame("ScriptDialogButton", this.backdrop, 0, 0);
      BlzFrameSetPoint(this.nextButton, FRAMEPOINT_BOTTOMRIGHT, this.backdrop, FRAMEPOINT_BOTTOMRIGHT, -BOTTOM_BUTTON_X_OFFSET, BOTTOM_BUTTON_Y_OFFSET);
      BlzFrameSetSize(this.nextButton, 009, 0037);
      BlzFrameSetText(this.nextButton, "Next");

      this.nextTrigger = CreateTrigger();
      BlzTriggerRegisterFrameEvent(this.nextTrigger, this.nextButton, FRAMEEVENT_CONTROL_CLICK);
      TriggerAddAction(this.nextTrigger,  thistype.nextButtonClick);
    }

    void createPrevButton( ){
      this.prevButton = BlzCreateFrame("ScriptDialogButton", this.backdrop, 0, 0);
      BlzFrameSetPoint(this.prevButton, FRAMEPOINT_BOTTOMLEFT, this.backdrop, FRAMEPOINT_BOTTOMLEFT, BOTTOM_BUTTON_X_OFFSET, BOTTOM_BUTTON_Y_OFFSET);
      BlzFrameSetSize(this.prevButton, 009, 0037);
      BlzFrameSetText(this.prevButton, "Previous");

      this.prevTrigger = CreateTrigger();
      BlzTriggerRegisterFrameEvent(this.prevTrigger, this.prevButton, FRAMEEVENT_CONTROL_CLICK);
      TriggerAddAction(this.prevTrigger,  thistype.prevButtonClick);
    }

     ArtifactMenuPage (int id ){


      //Allocate ID
      thistype.pageArray[id] = this;
      this.id = id;

      //Create the backdrop window on the main UI
      this.backdrop = BlzCreateFrame("ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0, 0);
      BlzFrameSetSize(this.backdrop, BACKDROP_WIDTH, BACKDROP_HEIGHT);
      BlzFrameSetAbsPoint(this.backdrop, FRAMEPOINT_CENTER, 04, 038);
      BlzFrameSetVisible(this.backdrop, false);

      //Create title for this page
      this.title = BlzCreateFrame("ArtifactMenuTitle", this.backdrop, 0, 0);
      BlzFrameSetPoint(this.title, FRAMEPOINT_CENTER, this.backdrop, FRAMEPOINT_TOP, 00, -0025);
      BlzFrameSetText(this.title, "Artifacts");

      //Create page number for this page
      this.pageNumber = BlzCreateFrame("ArtifactMenuTitle", this.backdrop, 0, 0);
      BlzFrameSetPoint(this.pageNumber, FRAMEPOINT_CENTER, this.backdrop, FRAMEPOINT_TOPRIGHT, -005, -0025);
      BlzFrameSetText(this.pageNumber, "Page " + I2S(this.id+1));

      //Create exit button for this page
      this.exitButton = BlzCreateFrame("ScriptDialogButton", this.backdrop, 0, 0);
      BlzFrameSetPoint(this.exitButton, FRAMEPOINT_BOTTOM, this.backdrop, FRAMEPOINT_BOTTOM, 00, BOTTOM_BUTTON_Y_OFFSET);
      BlzFrameSetSize(this.exitButton, 009, 0037);
      BlzFrameSetText(this.exitButton, "Exit");
      this.exitTrigger = CreateTrigger();
      BlzTriggerRegisterFrameEvent(this.exitTrigger, this.exitButton, FRAMEEVENT_CONTROL_CLICK);
      TriggerAddAction(this.exitTrigger,  thistype.exitButtonClick);

      //Add previous and next buttons
      if (thistype.pageArray[this.id - 1] != 0){
        this.createPrevButton();
        thistype.pageArray[this.id - 1].createNextButton();
      }

      if (thistype.pageArray[this.id + 1] != 0){
        this.createNextButton();
      }

      ;;
    }

    static void onInit( ){
        int i = 0;
        while(true){
        if ( i > MAX_PLAYERS){ break; }
          thistype.activePageId[i] = -1;
          i = i + 1;
        }
    }



    static thistype[] repsById

    static Table repsByPingButton                //ArtifactRepresentations indexed by handle IDs of ping button frames
    Artifact whichArtifact
    int id = 0;
    int x = 0;
    int y = 0;
    int z = 0   ;//Position referring to page placement
    int artifactStatus  //Refer to Artifact.j for possible values
    framehandle box
    framehandle icon
    framehandle title
    framehandle text
    framehandle pingButton
    trigger pingTrigger
    ArtifactMenuPage parentPage = 0;

    void setText(string s ){
      BlzFrameSetText(this.text, s);
    }

    void setOwner(Person p ){
      if (p != 0){
        this.setText("Owned by|n" + p.Faction.prefixCol + p.Faction.Name + "|r");
      }
    }

    void setArtifactStatus(int i ){
      if (i == ARTIFACT_STATUS_UNIT){
        BlzFrameSetVisible(this.text, true);
        BlzFrameSetVisible(this.pingButton, false);
      }else if (i == ARTIFACT_STATUS_GROUND){
        BlzFrameSetVisible(this.text, false);
        BlzFrameSetVisible(this.pingButton, true);
      }else if (i == ARTIFACT_STATUS_SPECIAL){
        BlzFrameSetVisible(this.text, false);
        BlzFrameSetVisible(this.pingButton, true);
      }else if (i == ARTIFACT_STATUS_HIDDEN){
        BlzFrameSetVisible(this.text, true);
        BlzFrameSetVisible(this.pingButton, false);
      }
    }

    void destroy( ){
      BlzDestroyFrame(this.text);
      BlzDestroyFrame(this.pingButton);
      BlzDestroyFrame(this.icon);
      BlzDestroyFrame(this.title);
      BlzDestroyFrame(this.box);
      thistype.repsByPingButton[GetHandleId(this.pingButton)] = 0;

      DestroyTrigger(this.pingTrigger);

      this.deallocate();
    }

    static void pingButtonClick( ){
      ArtifactRepresentation whichArtifactRep = thistype.repsByPingButton[GetHandleId(BlzGetTriggerFrame())];

      if (GetLocalPlayer() == GetTriggerPlayer()){
        whichArtifactRep.whichArtifact.ping(GetTriggerPlayer());
      }
    }

     ArtifactRepresentation (Artifact whichArtifact ){

      int i = 0;
      int idMod = 0 ;//Used in xyz calculation
      float boxSpacingX = (BACKDROP_WIDTH - BOX_WIDTH*COLUMN_COUNT)/(COLUMN_COUNT+1)                                 ;//How much horizontal space to leave between every box
      float boxSpacingY = (BACKDROP_HEIGHT - Y_OFFSET_TOP - Y_OFFSET_BOT - BOX_HEIGHT*ROW_COUNT) / (ROW_COUNT+1)     ;//How much vertical space to leave between every box

      this.whichArtifact = whichArtifact;

      while(true){
      if ( thistype.repsById[i] == 0){ break; }
        i = i + 1;
      }
      thistype.repsById[i] = this;
      thistype.repsByArtifact[whichArtifact] = this;
      this.id = i;

      //Determine x, y and z positions based on id
      this.z = this.id / (COLUMN_COUNT * ROW_COUNT);
      idMod = this.id - (this.z * COLUMN_COUNT * ROW_COUNT);
      this.y = idMod / COLUMN_COUNT;
      this.x = ModuloInteger(this.id, COLUMN_COUNT);

      //Determine which page to place on based on z value, and create it if it does not exist
      if (ArtifactMenuPage.pageArray[this.z] == 0){
        this.parentPage = ArtifactMenuPage.create(this.z);
      }else {
        this.parentPage = ArtifactMenuPage.pageArray[this.id];
      }

      //Create black box encompassing the representation
      this.box = BlzCreateFrame("ArtifactItemBox", ArtifactMenuPage.pageArray[this.z].backdrop, 0, 0);
      BlzFrameSetSize(this.box, BOX_WIDTH, BOX_HEIGHT);
      BlzFrameSetPoint(this.box, FRAMEPOINT_TOPLEFT, ArtifactMenuPage.pageArray[this.z].backdrop, FRAMEPOINT_TOPLEFT, BOX_WIDTH * this.x + boxSpacingX * (this.x + 1), -(Y_OFFSET_TOP + (BOX_HEIGHT * this.y + boxSpacingY * (this.y + 1))));

      //Create icon in the box
      this.icon = BlzCreateFrameByType("BACKDROP", "ArtifactIcon", this.box, "", 0);
      BlzFrameSetSize(this.icon, 004, 004);
      BlzFrameSetPoint(this.icon, FRAMEPOINT_LEFT, this.box, FRAMEPOINT_LEFT, 0015, -00090);
      BlzFrameSetTexture(this.icon, BlzGetItemIconPath(whichArtifact.item), 0, true);

      //Create title of artifact at top of box
      this.title = BlzCreateFrame("ArtifactItemTitle", this.box, 0, 0);
      BlzFrameSetText(this.title, GetItemName(whichArtifact.item));
      BlzFrameSetPoint(this.title, FRAMEPOINT_CENTER, this.box, FRAMEPOINT_CENTER, 00, 00255);
      BlzFrameSetSize(this.title, BOX_WIDTH - 004, 00);

      //Create description text of artifact
      this.text = BlzCreateFrame("ArtifactItemOwnerText", this.box, 0, 0);
      BlzFrameSetPoint(this.text, FRAMEPOINT_TOPLEFT, this.icon, FRAMEPOINT_TOPRIGHT, 0007, 0);
      BlzFrameSetPoint(this.text, FRAMEPOINT_BOTTOMLEFT, this.icon, FRAMEPOINT_BOTTOMRIGHT, 0007, 0);
      BlzFrameSetPoint(this.text, FRAMEPOINT_RIGHT, this.box, FRAMEPOINT_RIGHT, -0007, 0);

      //Create ping button of artifact
      this.pingButton = BlzCreateFrame("ScriptDialogButton", this.box, 0, 0);
      BlzFrameSetSize(this.pingButton, 0062, 0027);
      BlzFrameSetPoint(this.pingButton, FRAMEPOINT_LEFT, this.box, FRAMEPOINT_LEFT, 0057, -00090);
      BlzFrameSetText(this.pingButton, "Ping");
      BlzFrameSetVisible(this.pingButton, false);
      this.pingTrigger = CreateTrigger();
      BlzTriggerRegisterFrameEvent(this.pingTrigger, this.pingButton, FRAMEEVENT_CONTROL_CLICK);
      TriggerAddAction(this.pingTrigger,  thistype.pingButtonClick);
      thistype.repsByPingButton[GetHandleId(this.pingButton)] = this;

      ;;
    }

    static void onInit( ){
      thistype.repsByPingButton = Table.create();
    }



  private static void ArtifactLauncherClick( ){
    int pId = 0;
    pId = GetPlayerId(GetTriggerPlayer());
    if (ArtifactMenuPage.activePageId[pId]> -1){
      ArtifactMenuPage.exitButtonClick();
    }else {
      if (GetLocalPlayer() == GetTriggerPlayer()){
        BlzFrameSetVisible(ArtifactMenuPage.pageArray[0].backdrop, true);
      }
      ArtifactMenuPage.activePageId[pId]= 0
    }
    BlzFrameSetEnable(ArtifactMenuLauncher, false);
    BlzFrameSetEnable(ArtifactMenuLauncher, true);
  }

  private static void CreateArtifactLauncher( ){
    trigger trig = null;
    framehandle artifactMenuTitle = null;

    //Create the launcher button on the main UI
    ArtifactMenuLauncher = BlzCreateFrame("ScriptDialogButton", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI,0), 0, 0);
    BlzFrameSetSize(ArtifactMenuLauncher, 020, 0025);
    BlzFrameSetAbsPoint(ArtifactMenuLauncher, FRAMEPOINT_CENTER, 00, 056);
    BlzFrameSetText(ArtifactMenuLauncher, "Artifacts");
    trig = CreateTrigger();
    BlzTriggerRegisterFrameEvent(trig, ArtifactMenuLauncher, FRAMEEVENT_CONTROL_CLICK);
    TriggerAddAction(trig,  ArtifactLauncherClick);
  }

  private static void OnArtifactOwnerChanged( ){
    ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setOwner(GetTriggerArtifact().owningPerson);
  }

  private static void OnArtifactCreated( ){
    ArtifactRepresentation.create(GetTriggerArtifact());
    ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setArtifactStatus(GetTriggerArtifact().status);
  }

  private static void OnArtifactDestroyed( ){
    ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].destroy();
  }

  private static void OnArtifactStatusChanged( ){
    ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setArtifactStatus(GetTriggerArtifact().status);
  }

  private static void OnArtifactFactionChanged( ){
    ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setOwner(GetTriggerArtifact().owningPerson);
  }

  private static void OnArtifactCarrierOwnerChanged( ){
    ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setOwner(GetTriggerArtifact().owningPerson);
  }

  private static void OnArtifactDescriptionChanged( ){
    ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setText(GetTriggerArtifact().description);
  }

  private static void OnInit( ){
    trigger trig = null;
    int i = 0;
    LoadToc("war3mapImported\\ArtifactSystem.toc");
    LoadToc("ui\\framedef\\framedef.toc");

    CreateArtifactLauncher();
    ArtifactMenuPage.create(0);

    //Create trigger to notice an artifact being created
    trig = CreateTrigger();
    OnArtifactCreate.register(trig);
    TriggerAddCondition(trig, ( OnArtifactCreated));

    //Create trigger to notice an artifact having its owner changed
    trig = CreateTrigger();
    OnArtifactOwnerChange.register(trig);
    TriggerAddCondition(trig, ( OnArtifactOwnerChanged));

    //Create trigger to notice an artifact being destroyed
    trig = CreateTrigger();
    OnArtifactDestroy.register(trig);
    TriggerAddCondition(trig, ( OnArtifactDestroyed));

    //Create trigger to notice an artifact having its status changed
    trig = CreateTrigger();
    OnArtifactStatusChange.register(trig);
    TriggerAddCondition(trig, ( OnArtifactStatusChanged));

    //Create trigger to notice an artifact having its owner)s faction change
    trig = CreateTrigger();
    OnArtifactFactionChange.register(trig);
    TriggerAddCondition(trig, ( OnArtifactFactionChanged));

    //Create trigger to notice an artifact having its carriers owner change
    trig = CreateTrigger();
    OnArtifactCarrierOwnerChange.register(trig);
    TriggerAddCondition(trig, ( OnArtifactCarrierOwnerChanged));

    //Create trigger to notice an artifact having its description changed
    trig = CreateTrigger();
    OnArtifactDescriptionChange.register(trig);
    TriggerAddCondition(trig, ( OnArtifactDescriptionChanged));
  }

}
