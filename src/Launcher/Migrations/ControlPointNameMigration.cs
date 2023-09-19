#nullable enable
using System.Collections.Generic;
using System.Linq;
using Launcher.Extensions;
using War3Net.Build;
using War3Net.Build.Object;

namespace Launcher.Migrations
{
  /// <summary>
  /// Renames all Control Points in the map such that their names contain how much gold they give.
  /// </summary>
  public sealed class ControlPointNameMigration
  {
    private Dictionary<string, int> _incomeByAbility = new()
    {
      { "B025", 8 },
      { "B050", 12 },
      { "B051", 16 },
      { "B052", 20 },
      { "B053", 24 },
      { "B054", 28 }
    };
    
    public void Migrate(Map map)
    {
      var unitSkins = map.UnitSkinObjectData?.BaseUnits.Concat(map.UnitSkinObjectData.NewUnits);

      if (unitSkins == null)
        return;
      
      foreach (var unitSkin in unitSkins)
        if (UnitIsControlPoint(unitSkin))
          RenameControlPoint(unitSkin);
    }

    private bool UnitIsControlPoint(SimpleObjectModification unitSkin)
    {
      const int abilitiesNormalKey = 1768055157;
      return _incomeByAbility.Keys.Any(x =>
        unitSkin.GetDataModification(abilitiesNormalKey)?.ValueAsString.Contains(x) == true);
    }
    
    private void RenameControlPoint(SimpleObjectModification unitSkin)
    {  
      throw new System.NotImplementedException();
    }
  }
}