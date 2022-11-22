using System.Collections.Generic;
using System.Drawing;
using MacroTools.PassiveAbilitySystem;

namespace WarcraftLegacies.Source.PassiveAbilities
{
  /// <summary>
  /// The unit changes its model and name depending on the region it's created in.
  /// </summary>
  public sealed class FlavourBasedOnLocation : PassiveAbility
  {
    /// <summary>
    /// A list of settings that determine the models and names given to the unit when they are nearest the given location.
    /// </summary>
    public List<LocationBasedFlavourSetting>? LocationBasedFlavourSettings { get; init; }
    
    /// <inheritdoc />
    public FlavourBasedOnLocation(int unitTypeId) : base(unitTypeId)
    {
    }
  }
}