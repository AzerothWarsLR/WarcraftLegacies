using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;


namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// The unit changes its model and name depending on the region it's created in.
  /// </summary>
  public sealed class LocationBasedFlavourAbility : PassiveAbility
  {
    /// <summary>
    /// A list of settings that determine the models and names given to the unit when they are nearest the given location.
    /// </summary>
    public List<LocationBasedFlavourSetting>? LocationBasedFlavourSettings { get; init; }
    
    /// <inheritdoc />
    public LocationBasedFlavourAbility(int unitTypeId) : base(unitTypeId)
    {
    }

    /// <inheritdoc />
    public override void OnCreated(unit createdUnit)
    {
      if (LocationBasedFlavourSettings == null) 
        return;
      var unitPosition = createdUnit.GetPosition();
      var closestSetting = LocationBasedFlavourSettings.OrderByDescending(x =>
        WCSharp.Shared.Util.DistanceBetweenPoints(x.Location.X, x.Location.Y, unitPosition.X, unitPosition.Y)).Last();
      createdUnit.Name = closestSetting.Name;
      createdUnit.Skin = closestSetting.AlternateUnitTypeId;
    }
  }
}