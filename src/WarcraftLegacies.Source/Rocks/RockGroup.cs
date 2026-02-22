using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Rocks;

/// <summary>
/// A group of rocks used to prevent players from accessing an area of the game before a certain time passes.
/// </summary>
public sealed class RockGroup
{
  private readonly int _destructibleType;
  public int Expiry { get; }
  private readonly List<destructable> _rockGroup = new();

  public void Destroy()
  {
    foreach (var rock in _rockGroup)
    {
      rock.Dispose();
    }
  }

  private void AddRock()
  {
    var enumDestructable = GetEnumDestructable();
    if (enumDestructable.Type != _destructibleType)
    {
      return;
    }

    _rockGroup.Add(enumDestructable);
    enumDestructable.IsInvulnerable = true;
  }

  public RockGroup(Rectangle area, int destructibleType, int expiry = 0)
  {
    _destructibleType = destructibleType;
    Expiry = expiry;
    area.Rect.EnumerateDestructables(null, AddRock);
  }
}
