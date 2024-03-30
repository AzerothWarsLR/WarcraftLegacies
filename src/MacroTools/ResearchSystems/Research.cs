using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.ResearchSystems
{
  /// <summary>
  /// Provides a wrapper for vanilla WC3 researches that can be used to give them additional effects.
  /// </summary>
  public abstract class Research
  {
    /// <summary>
    /// A collection of <see cref="Research"/>es this <see cref="Research"/> is incompatible with.
    /// </summary>
    public IEnumerable<Research> IncompatibleWith = Array.Empty<Research>();

    /// <summary>
    /// The amount of gold the research costs. Unfortunately this is hard-coded.
    /// </summary>
    public int GoldCost { get; }

    /// <summary>
    /// The ID of the Warcraft 3 research object.
    /// </summary>
    public int ResearchTypeId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Research"/> class.
    /// </summary>
    protected Research(int researchTypeId, int goldCost)
    {
      ResearchTypeId = researchTypeId;
      GoldCost = goldCost;
    }

    /// <summary>
    /// Invoked when a player gains the research
    /// </summary>
    public abstract void OnResearch(player researchingPlayer);

    /// <summary>
    /// Invoked when the <see cref="Research"/> is registered.
    /// </summary>
    public virtual void OnRegister()
    {
    }

    /// <summary>
    /// Unresearches the research and returns all gold spent on it.
    /// </summary>
    /// <param name="researchingPlayer"></param>
    /// <param name="unresearch">If true, the research will be unresearched for the player as well.</param>
    public void Refund(player researchingPlayer, bool unresearch = true)
    {
      researchingPlayer.DisplayRefundedResearch(ResearchTypeId);
      researchingPlayer.AddGold(GoldCost);
      if (unresearch)
        researchingPlayer.SetObjectLevel(ResearchTypeId, Math.Min(0, researchingPlayer.GetObjectLimit(ResearchTypeId)));
    }
  }
}