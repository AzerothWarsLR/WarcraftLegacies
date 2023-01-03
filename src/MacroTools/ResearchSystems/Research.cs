using static War3Api.Common;

namespace MacroTools.ResearchSystems
{
  /// <summary>
  /// Provides a wrapper for vanilla WC3 researches that can be used to give them additional effects.
  /// </summary>
  public abstract class Research
  {
    /// <summary>
    /// The ID of the Warcraft 3 research object.
    /// </summary>
    public int ResearchTypeId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Research"/> class.
    /// </summary>
    /// <param name="researchTypeId"></param>
    protected Research(int researchTypeId)
    {
      ResearchTypeId = researchTypeId;
    }
    
    /// <summary>
    /// Invoked when a player gains the research
    /// </summary>
    public abstract void OnResearch(player researchingPlayer);

    /// <summary>
    /// Invoked when a player loses the research.
    /// </summary>
    public abstract void OnUnresearch(player researchingPlayer);
  }
}