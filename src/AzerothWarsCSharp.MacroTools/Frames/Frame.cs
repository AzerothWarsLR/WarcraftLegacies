using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames
{
  public class Frame
  {
    private protected readonly framehandle _handle;
    private readonly List<Frame> _children = new();

    public void AddFrame(Frame frame)
    {
      _children.Add(frame);
    }

    public void RemoveFrame(Frame frame)
    {
      _children.Remove(frame);
    }

    public framehandle Handle => _handle;

    private float _height;
    public float Height
    {
      get => _height;
      set
      {
        _height = value;
        BlzFrameSetSize(_handle, _width, _height);
      }
    }

    private float _width;
    public float Width
    {
      get => _width;
      set
      {
        _width = value;
        BlzFrameSetSize(_handle, _width, _height);
      }
    }

    public bool Visible
    {
      get => BlzFrameIsVisible(_handle);
      set => BlzFrameSetVisible(_handle, value);
    }

    public string Texture
    {
      set => BlzFrameSetTexture(_handle, value, 0, true);
    }

    public void SetAbsPoint(framepointtype point, float x, float y)
    {
      BlzFrameSetAbsPoint(_handle, point, x, y);
    }
    
    public void SetPoint(framepointtype point, Frame relativeTo, framepointtype relativePoint, float x, float y)
    {
      BlzFrameSetPoint(_handle, point, relativeTo.Handle, relativePoint, x, y);
    }

    public Frame(string name, framehandle parent, int priority = 0, int createContext = 0)
    {
      _handle = BlzCreateFrame(name, parent, priority, createContext);
    }

    public Frame(string name, Frame parent, int priority = 0, int createContext = 0)
    {
      _handle = BlzCreateFrame(name, parent.Handle, priority, createContext);
    }

    public Frame(string name, Frame parent, int createContext = 0)
    {
      _handle = BlzCreateSimpleFrame(name, parent.Handle, createContext);
    }

    public Frame(string typeName, string name, Frame parent, string inherits = null, int createContext = 0)
    {
      _handle = BlzCreateFrameByType(typeName, name, parent._handle, inherits, createContext);
    }

    ~Frame()
    {
      BlzDestroyFrame(_handle);
    }
  }
}