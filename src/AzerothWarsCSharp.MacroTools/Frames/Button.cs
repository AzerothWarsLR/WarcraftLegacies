using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames
{
  public delegate void OnClickAction(player triggerPlayer);

  public sealed class Button : Frame
  {
    private readonly TriggerWrapper _onClickTrigger;

    public Button(string name, framehandle parent, int priority = 0, int createContext = 0) : base(name, parent,
      priority, createContext)
    {
    }

    public Button(string name, Frame parent, int priority = 0, int createContext = 0) : base(name, parent, priority,
      createContext)
    {
    }

    public Button(string name, Frame parent, int createContext = 0) : base(name, parent, createContext)
    {
    }

    public Button(string typeName, string name, Frame parent, string inherits = null, int createContext = 0) : base(
      typeName, name, parent, inherits, createContext)
    {
    }

    public OnClickAction OnClick
    {
      init
      {
        _onClickTrigger = new TriggerWrapper();
        _onClickTrigger.RegisterFrameEvent(Handle, FRAMEEVENT_MOUSE_UP);
        _onClickTrigger.AddAction(() => value(GetTriggerPlayer()));
      }
    }

    public string Text
    {
      get => BlzFrameGetText(Handle);
      set => BlzFrameSetText(Handle, value);
    }
  }
}