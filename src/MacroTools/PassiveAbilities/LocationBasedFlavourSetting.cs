using WCSharp.Shared.Data;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// Determines a units' flavour changes when near a particular location.
  /// </summary>
  public sealed class LocationBasedFlavourSetting
  {
    /// <summary>
    /// The name the unit gets when nearest the location.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// The skin the unit gets when nearest the location.
    /// </summary>
    public int AlternateUnitTypeId { get; }
    
    /// <summary>
    /// The location that the unit has to be nearest to to get these changes.
    /// </summary>
    public Point Location { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationBasedFlavourSetting"/> class.
    /// </summary>
    public LocationBasedFlavourSetting(string name, int alternateUnitTypeId, Point location)
    {
      Name = name;
      AlternateUnitTypeId = alternateUnitTypeId;
      Location = location;
    }
  }
}