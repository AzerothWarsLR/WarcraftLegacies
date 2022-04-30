using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge.Plague
{
  /// <summary>
  /// Specifies how many of each unit type to spawn during the Plague.
  /// </summary>
  public sealed class PlagueCauldronSummonParameter
  {
    /// <summary>
    /// How many of this unit to spawn around the Plague Cauldron.
    /// </summary>
    public int SummonCount { get; }
    
    /// <summary>
    /// What type of unit to spawn around the Plague Cauldron.
    /// </summary>
    public int SummonUnitTypeId { get; }
    
    /// <summary>
    /// If set, the summoned unit is given to this <see cref="Faction"/> instead of the <see cref="PlaguePower"/> holder.
    /// </summary>
    public Faction? FactionOverride { get; }
    
    public PlagueCauldronSummonParameter(int summonCount, int summonUnitTypeId, Faction? factionOverride = null)
    {
      SummonCount = summonCount;
      SummonUnitTypeId = summonUnitTypeId;
      FactionOverride = factionOverride;
    }
  }
}