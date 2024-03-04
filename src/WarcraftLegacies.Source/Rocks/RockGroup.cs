using System.Collections.Generic;

using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Rocks
{
  /// <summary>
  /// A group of rocks used to prevent players from accessing an area of the game before a certain time passes.
  /// </summary>
  public sealed class RockGroup
  {
    private readonly int _destructibleType;
    public float Expiry { get; }
    private readonly List<destructable> _rockGroup = new();

    public void Destroy()
    {
      foreach (var rock in _rockGroup)
      {
        RemoveDestructable(rock);
      }
    }
    
    private void AddRock()
    {
      var enumDestructable = GetEnumDestructable();
      if (GetDestructableTypeId(enumDestructable) != _destructibleType) return;
      _rockGroup.Add(enumDestructable);
      SetDestructableInvulnerable(enumDestructable, true);
    }
    
    public RockGroup(Rectangle area, int destructibleType, float expiry)
    {
      _destructibleType = destructibleType;
      Expiry = expiry;
      EnumDestructablesInRect(area.Rect, null, AddRock);
    }
  }
}