using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames
{
  public delegate void OnClickAction(player triggerPlayer);
  
  public sealed class Button : Frame
  {
    private readonly trigger _onClickTrigger;
    
    public OnClickAction OnClick
    {
      init
      {
        _onClickTrigger = CreateTrigger();
        BlzTriggerRegisterFrameEvent(_onClickTrigger, _handle, FRAMEEVENT_MOUSE_UP);
        TriggerAddAction(_onClickTrigger, () => value(GetTriggerPlayer()));
      }
    }

    public string Text
    {
      get => BlzFrameGetText(_handle);
      set => BlzFrameSetText(_handle, value);
    }

    public Button(string name, framehandle parent, int priority = 0, int createContext = 0) : base(name, parent, priority, createContext)
    {
    }

    public Button(string name, Frame parent, int priority = 0, int createContext = 0) : base(name, parent, priority, createContext)
    {
    }

    public Button(string name, Frame parent, int createContext = 0) : base(name, parent, createContext)
    {
    }

    public Button(string typeName, string name, Frame parent, string inherits = null, int createContext = 0) : base(typeName, name, parent, inherits, createContext)
    {
    }

    ~Button()
    {
      DestroyTrigger(_onClickTrigger);
    }
  }
}