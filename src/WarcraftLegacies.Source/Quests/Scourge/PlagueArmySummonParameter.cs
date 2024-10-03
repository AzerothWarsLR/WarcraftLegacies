namespace WarcraftLegacies.Source.Quests.Scourge.Plague
{
  /// <summary>
  /// Specifies how many of each unit type to spawn during the Plague.
  /// </summary>
  public sealed class PlagueArmySummonParameter
  {
    /// <summary>How many of this unit to spawn.</summary>
    public int SummonCount { get; }
    
    /// <summary>What type of unit to spawn.</summary>
    public int SummonUnitTypeId { get; }

    public PlagueArmySummonParameter(int summonCount, int summonUnitTypeId)
    {
      SummonCount = summonCount;
      SummonUnitTypeId = summonUnitTypeId;
    }
  }
}