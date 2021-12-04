namespace AzerothWarsCSharp.MacroTools
{
  public abstract class QuestOutcome
  {
    internal Quest? ParentQuest { get; set; }
    
    protected Faction? ParentFaction => ParentQuest?.ParentFaction;
    
    /// <summary>
    /// Carry out this Outcome, by e.g. spawning a Footman at Northrend.
    /// </summary>
    public abstract void Fire();

    /// <summary>
    /// A description of what this Outcome does, e.g. "A Footman appears at Northrend."
    /// </summary>
    public string Description { get; set; } = "DefaultOutcomeText";
  }
}