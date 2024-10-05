namespace WarcraftLegacies.Source.Quests.Skywall
{
  /// <summary>
  /// Specifies how many of each unit type to spawn during the Invasion.
  /// </summary>
  public sealed class InvasionArmySummonParameter
  {
    /// <summary>How many of this unit to spawn.</summary>
    public int SummonCount { get; }
    
    /// <summary>What type of unit to spawn.</summary>
    public int SummonUnitTypeId { get; }

    public InvasionArmySummonParameter(int summonCount, int summonUnitTypeId)
    {
      SummonCount = summonCount;
      SummonUnitTypeId = summonUnitTypeId;
    }
  }
}