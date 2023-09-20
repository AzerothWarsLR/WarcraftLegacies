using System.Text.RegularExpressions;
using AutoMapper.Internal;
using Launcher.Extensions;
using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations
{
  public sealed class ControlPointNameMapMigration : IMapMigration
  {
    /// <inheritdoc />
    public void Migrate(Map map, ObjectDatabase objectDatabase)
    {
      var unitSkins = map.UnitSkinObjectData?.BaseUnits.Concat(map.UnitSkinObjectData.NewUnits);
      if (unitSkins == null)
        return;

      const int textNameId = 1835101794;
      foreach (var unitSkin in unitSkins)
      {
        var textNameModification = unitSkin.GetDataModification(textNameId);
        if (textNameModification == null) 
          continue;
        
        var textName = textNameModification.ValueAsString;
        if (textName.Contains("gold/min"))
          unitSkin.Modifications[textNameId].Value = Regex.Replace(textName, @"(.*) \(.*gold/min\)", "$1");
      }
    }
  }
}