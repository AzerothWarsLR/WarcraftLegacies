using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.User_Interface
{
  public class ArtifactMenu
  {
    private float _backdropWidth = 07;
    private float _backdropHeight = 037;
    private float _yOffsetTop = 0025; //How much space to push the artifact representations in from the top
    private float _yOffsetBot = 005; //How much space to push the artifact representations in from the bottom
    private float _bottomButtonXOffset = 002;
    private float _bottomButtonYOffset = 0015;
    private float _tooltipWidth = 025;
    private float _tooltipHeight = 01;

    private var _columnCount = 5;
    private var _rowCount = 3;

    private float _boxWidth = 013;
    private float _boxHeight = 0086;

    framehandle ArtifactMenuLauncher
    framehandle ArtifactMenuBackdrop
    framehandle ArtifactMenuExit


    private static void LoadToc(string s)
    {
      if (!BlzLoadTOCFile(s))
      {
        BJDebugMsg("Failed to Load TOC: " + s);
      }
    }


    static thistype[] PageArray
    static int[] ActivePageId //-1 means no page is active. Indexed per player
    int Id

    framehandle Backdrop
    framehandle Title
    framehandle PageNumber
    framehandle ExitButton
    framehandle NextButton
    framehandle PrevButton
    trigger _nextTrigger = null;
    trigger _prevTrigger = null;
    trigger _exitTrigger = null;

    static void ExitButtonClick()
    {
      var pId = GetPlayerId(GetTriggerPlayer());
      if (thistype.activePageId[pId] > -1)
      {
        if (GetLocalPlayer() == GetTriggerPlayer())
        {
          BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]].backdrop, false);
        }

        thistype.activePageId[pId] = -1;
      }
    }

    static void NextButtonClick()
    {
      var pId = GetPlayerId(GetTriggerPlayer());
      if (thistype.activePageId[pId] > -1 && thistype.pageArray[thistype.activePageId[pId] + 1] != 0)
      {
        if (GetLocalPlayer() == GetTriggerPlayer())
        {
          BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]].backdrop, false);
          BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId] + 1].backdrop, true);
        }

        thistype.activePageId[pId] = thistype.activePageId[pId] + 1
      }
    }

    static void PrevButtonClick()
    {
      var pId = GetPlayerId(GetTriggerPlayer());
      if (thistype.activePageId[pId] > -1 && thistype.pageArray[thistype.activePageId[pId] - 1] != 0)
      {
        if (GetLocalPlayer() == GetTriggerPlayer())
        {
          BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]].backdrop, false);
          BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId] - 1].backdrop, true);
        }
      }

      thistype.activePageId[pId] = thistype.activePageId[pId] - 1
    }

    void Destroy()
    {
      DestroyTrigger(_nextTrigger);
      DestroyTrigger(_prevTrigger);
      DestroyTrigger(_exitTrigger);

      BlzDestroyFrame(this.PrevButton);
      BlzDestroyFrame(this.NextButton);
      BlzDestroyFrame(this.ExitButton);
      BlzDestroyFrame(this.title);
      BlzDestroyFrame(this.PageNumber);
      BlzDestroyFrame(this.Backdrop);

      this.deallocate();
    }

    void DestroyNextButton()
    {
      BlzDestroyFrame(this.NextButton);
      this.NextButton = null;
    }

    void DestroyPrevButton()
    {
      BlzDestroyFrame(this.PrevButton);
      this.PrevButton = null;
    }

    void CreateNextButton()
    {
      this.NextButton = BlzCreateFrame("ScriptDialogButton", this.Backdrop, 0, 0);
      BlzFrameSetPoint(this.NextButton, FRAMEPOINT_BOTTOMRIGHT, this.Backdrop, FRAMEPOINT_BOTTOMRIGHT,
        -_bottomButtonXOffset, _bottomButtonYOffset);
      BlzFrameSetSize(this.NextButton, 009, 0037);
      BlzFrameSetText(this.NextButton, "Next");

      _nextTrigger = CreateTrigger();
      BlzTriggerRegisterFrameEvent(_nextTrigger, this.NextButton, FRAMEEVENT_CONTROL_CLICK);
      TriggerAddAction(_nextTrigger, thistype.nextButtonClick);
    }

    void CreatePrevButton()
    {
      this.PrevButton = BlzCreateFrame("ScriptDialogButton", this.Backdrop, 0, 0);
      BlzFrameSetPoint(this.PrevButton, FRAMEPOINT_BOTTOMLEFT, this.Backdrop, FRAMEPOINT_BOTTOMLEFT,
        _bottomButtonXOffset, _bottomButtonYOffset);
      BlzFrameSetSize(this.PrevButton, 009, 0037);
      BlzFrameSetText(this.PrevButton, "Previous");

      _prevTrigger = CreateTrigger();
      BlzTriggerRegisterFrameEvent(_prevTrigger, this.PrevButton, FRAMEEVENT_CONTROL_CLICK);
      TriggerAddAction(_prevTrigger, thistype.prevButtonClick);
    }

    ArtifactMenuPage(int id)
    {
      //Allocate ID
      thistype.pageArray[id] = this;
      this.Id = id;

      //Create the backdrop window on the main UI
      this.Backdrop = BlzCreateFrame("ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0, 0);
      BlzFrameSetSize(this.Backdrop, _backdropWidth, _backdropHeight);
      BlzFrameSetAbsPoint(this.Backdrop, FRAMEPOINT_CENTER, 04, 038);
      BlzFrameSetVisible(this.Backdrop, false);

      //Create title for this page
      this.title = BlzCreateFrame("ArtifactMenuTitle", this.Backdrop, 0, 0);
      BlzFrameSetPoint(this.title, FRAMEPOINT_CENTER, this.Backdrop, FRAMEPOINT_TOP, 00, -0025);
      BlzFrameSetText(this.title, "Artifacts");

      //Create page number for this page
      this.PageNumber = BlzCreateFrame("ArtifactMenuTitle", this.Backdrop, 0, 0);
      BlzFrameSetPoint(this.PageNumber, FRAMEPOINT_CENTER, this.Backdrop, FRAMEPOINT_TOPRIGHT, -005, -0025);
      BlzFrameSetText(this.PageNumber, "Page " + I2S(this.Id + 1));

      //Create exit button for this page
      this.ExitButton = BlzCreateFrame("ScriptDialogButton", this.Backdrop, 0, 0);
      BlzFrameSetPoint(this.ExitButton, FRAMEPOINT_BOTTOM, this.Backdrop, FRAMEPOINT_BOTTOM, 00, _bottomButtonYOffset);
      BlzFrameSetSize(this.ExitButton, 009, 0037);
      BlzFrameSetText(this.ExitButton, "Exit");
      _exitTrigger = CreateTrigger();
      BlzTriggerRegisterFrameEvent(_exitTrigger, this.ExitButton, FRAMEEVENT_CONTROL_CLICK);
      TriggerAddAction(_exitTrigger, thistype.exitButtonClick);

      //Add previous and next buttons
      if (thistype.pageArray[this.Id - 1] != 0)
      {
        CreatePrevButton();
        thistype.pageArray[this.Id - 1].createNextButton();
      }

      if (thistype.pageArray[this.Id + 1] != 0)
      {
        CreateNextButton();
      }

      ;
      ;
    }

    static void OnInit()
    {
      var i = 0;
      while (true)
      {
        if (i > MAX_PLAYERS)
        {
          break;
        }

        thistype.activePageId[i] = -1;
        i = i + 1;
      }
    }


    static thistype[] RepsById

    static Table RepsByPingButton //ArtifactRepresentations indexed by handle IDs of ping button frames
    Artifact WhichArtifact
    var _id = 0;
    var _x = 0;
    var _y = 0;
    var _z = 0; //Position referring to page placement
    int ArtifactStatus //Refer to Artifact.j for possible values
    framehandle Box
    framehandle Icon
    framehandle Title
    framehandle Text
    framehandle PingButton
    trigger PingTrigger
    ArtifactMenuPage _parentPage = 0;

    void SetText(string s)
    {
      BlzFrameSetText(this.Text, s);
    }

    void SetOwner(Person p)
    {
      if (p != 0)
      {
        SetText("Owned by|n" + p.Faction.prefixCol + p.Faction.Name + "|r");
      }
    }

    void SetArtifactStatus(int i)
    {
      if (i == ARTIFACT_STATUS_UNIT)
      {
        BlzFrameSetVisible(this.Text, true);
        BlzFrameSetVisible(this.PingButton, false);
      }
      else if (i == ARTIFACT_STATUS_GROUND)
      {
        BlzFrameSetVisible(this.Text, false);
        BlzFrameSetVisible(this.PingButton, true);
      }
      else if (i == ARTIFACT_STATUS_SPECIAL)
      {
        BlzFrameSetVisible(this.Text, false);
        BlzFrameSetVisible(this.PingButton, true);
      }
      else if (i == ARTIFACT_STATUS_HIDDEN)
      {
        BlzFrameSetVisible(this.Text, true);
        BlzFrameSetVisible(this.PingButton, false);
      }
    }

    void Destroy()
    {
      BlzDestroyFrame(this.Text);
      BlzDestroyFrame(this.PingButton);
      BlzDestroyFrame(this.Icon);
      BlzDestroyFrame(this.title);
      BlzDestroyFrame(this.Box);
      thistype.repsByPingButton[GetHandleId(this.PingButton)] = 0;

      DestroyTrigger(this.PingTrigger);

      this.deallocate();
    }

    static void PingButtonClick()
    {
      ArtifactRepresentation whichArtifactRep = thistype.repsByPingButton[GetHandleId(BlzGetTriggerFrame())];

      if (GetLocalPlayer() == GetTriggerPlayer())
      {
        whichArtifactRep.whichArtifact.ping(GetTriggerPlayer());
      }
    }

    ArtifactRepresentation(Artifact whichArtifact)
    {
      var i = 0;
      var idMod = 0; //Used in xyz calculation
      float boxSpacingX =
        (_backdropWidth - _boxWidth * _columnCount) /
        (_columnCount + 1); //How much horizontal space to leave between every box
      float boxSpacingY =
        (_backdropHeight - _yOffsetTop - _yOffsetBot - _boxHeight * _rowCount) /
        (_rowCount + 1); //How much vertical space to leave between every box

      this.WhichArtifact = whichArtifact;

      while (true)
      {
        if (thistype.repsById[i] == 0)
        {
          break;
        }

        i = i + 1;
      }

      thistype.repsById[i] = this;
      thistype.repsByArtifact[whichArtifact] = this;
      this.Id = i;

      //Determine x, y and z positions based on id
      _z = this.Id / (_columnCount * _rowCount);
      idMod = this.Id - (_z * _columnCount * _rowCount);
      _y = idMod / _columnCount;
      _x = ModuloInteger(this.Id, _columnCount);

      //Determine which page to place on based on z value, and create it if it does not exist
      if (ArtifactMenuPage.pageArray[_z] == 0)
      {
        _parentPage = ArtifactMenuPage.create(_z);
      }
      else
      {
        _parentPage = ArtifactMenuPage.pageArray[this.Id];
      }

      //Create black box encompassing the representation
      this.Box = BlzCreateFrame("ArtifactItemBox", ArtifactMenuPage.pageArray[_z].backdrop, 0, 0);
      BlzFrameSetSize(this.Box, _boxWidth, _boxHeight);
      BlzFrameSetPoint(this.Box, FRAMEPOINT_TOPLEFT, ArtifactMenuPage.pageArray[_z].backdrop, FRAMEPOINT_TOPLEFT,
        _boxWidth * _x + boxSpacingX * (_x + 1),
        -(_yOffsetTop + (_boxHeight * _y + boxSpacingY * (_y + 1))));

      //Create icon in the box
      this.Icon = BlzCreateFrameByType("BACKDROP", "ArtifactIcon", this.Box, "", 0);
      BlzFrameSetSize(this.Icon, 004, 004);
      BlzFrameSetPoint(this.Icon, FRAMEPOINT_LEFT, this.Box, FRAMEPOINT_LEFT, 0015, -00090);
      BlzFrameSetTexture(this.Icon, BlzGetItemIconPath(whichArtifact.item), 0, true);

      //Create title of artifact at top of box
      this.title = BlzCreateFrame("ArtifactItemTitle", this.Box, 0, 0);
      BlzFrameSetText(this.title, GetItemName(whichArtifact.item));
      BlzFrameSetPoint(this.title, FRAMEPOINT_CENTER, this.Box, FRAMEPOINT_CENTER, 00, 00255);
      BlzFrameSetSize(this.title, _boxWidth - 004, 00);

      //Create description text of artifact
      this.Text = BlzCreateFrame("ArtifactItemOwnerText", this.Box, 0, 0);
      BlzFrameSetPoint(this.Text, FRAMEPOINT_TOPLEFT, this.Icon, FRAMEPOINT_TOPRIGHT, 0007, 0);
      BlzFrameSetPoint(this.Text, FRAMEPOINT_BOTTOMLEFT, this.Icon, FRAMEPOINT_BOTTOMRIGHT, 0007, 0);
      BlzFrameSetPoint(this.Text, FRAMEPOINT_RIGHT, this.Box, FRAMEPOINT_RIGHT, -0007, 0);

      //Create ping button of artifact
      this.PingButton = BlzCreateFrame("ScriptDialogButton", this.Box, 0, 0);
      BlzFrameSetSize(this.PingButton, 0062, 0027);
      BlzFrameSetPoint(this.PingButton, FRAMEPOINT_LEFT, this.Box, FRAMEPOINT_LEFT, 0057, -00090);
      BlzFrameSetText(this.PingButton, "Ping");
      BlzFrameSetVisible(this.PingButton, false);
      this.PingTrigger = CreateTrigger();
      BlzTriggerRegisterFrameEvent(this.PingTrigger, this.PingButton, FRAMEEVENT_CONTROL_CLICK);
      TriggerAddAction(this.PingTrigger, thistype.pingButtonClick);
      thistype.repsByPingButton[GetHandleId(this.PingButton)] = this;

      ;
      ;
    }

    static void OnInit()
    {
      thistype.repsByPingButton = Table.create();
    }


    private static void ArtifactLauncherClick()
    {
      var pId = 0;
      pId = GetPlayerId(GetTriggerPlayer());
      if (ArtifactMenuPage.activePageId[pId] > -1)
      {
        ArtifactMenuPage.exitButtonClick();
      }
      else
      {
        if (GetLocalPlayer() == GetTriggerPlayer())
        {
          BlzFrameSetVisible(ArtifactMenuPage.pageArray[0].backdrop, true);
        }

        ArtifactMenuPage.activePageId[pId] = 0
      }

      BlzFrameSetEnable(ArtifactMenuLauncher, false);
      BlzFrameSetEnable(ArtifactMenuLauncher, true);
    }

    private static void CreateArtifactLauncher()
    {
      trigger trig = null;
      framehandle artifactMenuTitle = null;

      //Create the launcher button on the main UI
      ArtifactMenuLauncher = BlzCreateFrame("ScriptDialogButton", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0, 0);
      BlzFrameSetSize(ArtifactMenuLauncher, 020, 0025);
      BlzFrameSetAbsPoint(ArtifactMenuLauncher, FRAMEPOINT_CENTER, 00, 056);
      BlzFrameSetText(ArtifactMenuLauncher, "Artifacts");
      trig = CreateTrigger();
      BlzTriggerRegisterFrameEvent(trig, ArtifactMenuLauncher, FRAMEEVENT_CONTROL_CLICK);
      TriggerAddAction(trig, ArtifactLauncherClick);
    }

    private static void OnArtifactOwnerChanged()
    {
      ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setOwner(GetTriggerArtifact().owningPerson);
    }

    private static void OnArtifactCreated()
    {
      ArtifactRepresentation.create(GetTriggerArtifact());
      ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setArtifactStatus(GetTriggerArtifact().status);
    }

    private static void OnArtifactDestroyed()
    {
      ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].destroy();
    }

    private static void OnArtifactStatusChanged()
    {
      ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setArtifactStatus(GetTriggerArtifact().status);
    }

    private static void OnArtifactFactionChanged()
    {
      ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setOwner(GetTriggerArtifact().owningPerson);
    }

    private static void OnArtifactCarrierOwnerChanged()
    {
      ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setOwner(GetTriggerArtifact().owningPerson);
    }

    private static void OnArtifactDescriptionChanged()
    {
      ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setText(GetTriggerArtifact().description);
    }

    public static void Setup()
    {
      trigger trig = null;
      var i = 0;
      LoadToc("war3mapImported\\ArtifactSystem.toc");
      LoadToc("ui\\framedef\\framedef.toc");

      CreateArtifactLauncher();
      ArtifactMenuPage.create(0);

      //Create trigger to notice an artifact being created
      trig = CreateTrigger();
      OnArtifactCreate.register(trig);
      TriggerAddCondition(trig, (OnArtifactCreated));

      //Create trigger to notice an artifact having its owner changed
      trig = CreateTrigger();
      OnArtifactOwnerChange.register(trig);
      TriggerAddCondition(trig, (OnArtifactOwnerChanged));

      //Create trigger to notice an artifact being destroyed
      trig = CreateTrigger();
      OnArtifactDestroy.register(trig);
      TriggerAddCondition(trig, (OnArtifactDestroyed));

      //Create trigger to notice an artifact having its status changed
      trig = CreateTrigger();
      OnArtifactStatusChange.register(trig);
      TriggerAddCondition(trig, (OnArtifactStatusChanged));

      //Create trigger to notice an artifact having its owner)s faction change
      trig = CreateTrigger();
      OnArtifactFactionChange.register(trig);
      TriggerAddCondition(trig, (OnArtifactFactionChanged));

      //Create trigger to notice an artifact having its carriers owner change
      trig = CreateTrigger();
      OnArtifactCarrierOwnerChange.register(trig);
      TriggerAddCondition(trig, (OnArtifactCarrierOwnerChanged));

      //Create trigger to notice an artifact having its description changed
      trig = CreateTrigger();
      OnArtifactDescriptionChange.register(trig);
      TriggerAddCondition(trig, (OnArtifactDescriptionChanged));
    }
  }
}