using WCSharp.Shared.Data;

namespace MacroTools.ObjectiveSystem;

public sealed class NamedRectangle
{
  public string Name { get; }

  public Rectangle Rectangle { get; }

  public NamedRectangle(string name, Rectangle rectangle)
  {
    Name = name;
    Rectangle = rectangle;
  }
}
