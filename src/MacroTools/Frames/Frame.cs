using System.Collections.Generic;

namespace MacroTools.Frames;

public class Frame
{
  private readonly List<Frame> _children = new();
  private float _height;
  private float _width;

  protected framehandle Handle { get; }

  public Frame Parent
  {
    init => Handle.Parent = value.Handle;
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
      Handle.SetSize(_width, _height);
    }
  }

  public float Width
  {
    get => _width;
    set
    {
      _width = value;
      Handle.SetSize(_width, _height);
    }
  }

  public bool Visible
  {
    get => Handle.Visible;
    set => Handle.Visible = value;
  }

  public string Texture
  {
    set => Handle.SetTexture(value, 0, true);
  }

  public void SetAbsPoint(framepointtype point, float x, float y)
  {
    Handle.SetAbsPoint(point, x, y);
  }

  /// <summary>
  /// Sets the position of the <see cref="Frame"/> relative to a <see cref="framehandle"/>.
  /// </summary>
  public void SetPoint(framepointtype point, framehandle relativeTo, framepointtype relativePoint, float x, float y)
  {
    Handle.SetPoint(point, x, y, relativeTo, relativePoint);
  }

  /// <summary>
  /// Sets the position of the <see cref="Frame"/> relative to another <see cref="Frame"/>.
  /// </summary>
  public void SetPoint(framepointtype point, Frame relativeTo, framepointtype relativePoint, float x, float y)
  {
    Handle.SetPoint(point, x, y, relativeTo.Handle, relativePoint);
  }

  public void ClearAllPoints()
  {
    Handle.ClearPoints();
  }

  public Frame(string name, framehandle parent, int priority)
  {
    Handle = framehandle.Create(name, parent, priority, 0);
  }

  public Frame(string name, Frame parent, int priority)
  {
    Handle = framehandle.Create(name, parent.Handle, priority, 0);
  }

  /// <summary>
  /// Creates a Blizzard Simple Frame.
  /// </summary>
  /// /// <param name="name">The name of the frame definition to create.</param>
  /// <param name="parent">The parent which affects the child's position and visibility.</param>
  public Frame(string name, framehandle parent)
  {
    Handle = framehandle.CreateSimple(name, parent, 0);
  }

  /// <summary>
  /// Creates a Blizzard Simple Frame.
  /// </summary>
  /// <param name="name">The name of the frame definition to create.</param>
  /// <param name="parent">The parent which affects the child's position and visibility.</param>
  public Frame(string name, Frame parent)
  {
    Handle = framehandle.CreateSimple(name, parent.Handle, 0);
  }

  public Frame(string typeName, string name, Frame parent, string inherits = "")
  {
    Handle = framehandle.Create(typeName, name, parent.Handle, inherits, 0);
  }
}
