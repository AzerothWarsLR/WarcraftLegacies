using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames
{
  public class Frame : IDisposable
  {
    private readonly List<Frame> _children = new();
    private bool _disposed;
    private float _height;
    private float _width;

    protected framehandle Handle { get; }

    public Frame Parent
    {
      init => BlzFrameSetParent(Handle, value.Handle);
    }

    public void AddFrame(Frame frame)
    {
      _children.Add(frame);
    }

    public float Height
    {
      get => _height;
      set
      {
        _height = value;
        BlzFrameSetSize(Handle, _width, _height);
      }
    }
    
    public float Width
    {
      get => _width;
      set
      {
        _width = value;
        BlzFrameSetSize(Handle, _width, _height);
      }
    }

    public bool Visible
    {
      get => BlzFrameIsVisible(Handle);
      set => BlzFrameSetVisible(Handle, value);
    }

    public string Texture
    {
      set => BlzFrameSetTexture(Handle, value, 0, true);
    }

    public void SetAbsPoint(framepointtype point, float x, float y)
    {
      BlzFrameSetAbsPoint(Handle, point, x, y);
    }

    /// <summary>
    /// Sets the position of the <see cref="Frame"/> relative to a <see cref="framehandle"/>.
    /// </summary>
    public void SetPoint(framepointtype point, framehandle relativeTo, framepointtype relativePoint, float x, float y)
    {
      BlzFrameSetPoint(Handle, point, relativeTo, relativePoint, x, y);
    }
    
    /// <summary>
    /// Sets the position of the <see cref="Frame"/> relative to another <see cref="Frame"/>.
    /// </summary>
    public void SetPoint(framepointtype point, Frame relativeTo, framepointtype relativePoint, float x, float y)
    {
      BlzFrameSetPoint(Handle, point, relativeTo.Handle, relativePoint, x, y);
    }

    public void ClearAllPoints()
    {
      BlzFrameClearAllPoints(Handle);
    }

    public Frame(string name, framehandle parent, int priority, int createContext)
    {
      Handle = BlzCreateFrame(name, parent, priority, createContext);
    }

    public Frame(string name, Frame parent, int priority, int createContext)
    {
      Handle = BlzCreateFrame(name, parent.Handle, priority, createContext);
    }

    public Frame(string name, Frame parent, int createContext = 0)
    {
      Handle = BlzCreateSimpleFrame(name, parent.Handle, createContext);
    }

    public Frame(string typeName, string name, Frame parent, string inherits = "", int createContext = 0)
    {
      Handle = BlzCreateFrameByType(typeName, name, parent.Handle, inherits, createContext);
    }

    public void Dispose()
    {
      Dispose(true);
    }

    /// <summary>
    /// Unhooks all events from this class. Called when Dispose is called or the Frame is garbage collected.
    /// </summary>
    protected virtual void DisposeEvents() { }

    private void Dispose(bool disposing)
    {
      if (!_disposed)
      {
        _disposed = true;
        if (disposing)
        {
          DisposeEvents();
          foreach (var childFrame in _children)
          {
            childFrame.Dispose();
          }
          _children.Clear();
        }
        BlzDestroyFrame(Handle);
      }
    }
    
    ~Frame()
    {
      Dispose(false);
    }
  }
}