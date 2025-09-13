using System.Collections.Generic;

namespace MacroTools.Frames
{
  public class Frame
  {
    private readonly List<Frame> _children = new();
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

    public Frame(string name, framehandle parent, int priority)
    {
      Handle = BlzCreateFrame(name, parent, priority, 0);
    }

    public Frame(string name, Frame parent, int priority)
    {
      Handle = BlzCreateFrame(name, parent.Handle, priority, 0);
    }

    /// <summary>
    /// Creates a Blizzard Simple Frame.
    /// </summary>
    /// /// <param name="name">The name of the frame definition to create.</param>
    /// <param name="parent">The parent which affects the child's position and visibility.</param>
    public Frame(string name, framehandle parent)
    {
      Handle = BlzCreateSimpleFrame(name, parent, 0);
    }

    /// <summary>
    /// Creates a Blizzard Simple Frame.
    /// </summary>
    /// <param name="name">The name of the frame definition to create.</param>
    /// <param name="parent">The parent which affects the child's position and visibility.</param>
    public Frame(string name, Frame parent)
    {
      Handle = BlzCreateSimpleFrame(name, parent.Handle, 0);
    }

    public Frame(string typeName, string name, Frame parent, string inherits = "")
    {
      Handle = BlzCreateFrameByType(typeName, name, parent.Handle, inherits, 0);
    }
  }
}