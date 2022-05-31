using System.Collections.Generic;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  /// <summary>
  /// Manages the Black Empire's <see cref="BlackEmpirePortal"/>s, mainly by keeping track of which one needs to be opened next to progress.
  /// </summary>
  public static class BlackEmpirePortalManager
  {
    private static readonly Queue<BlackEmpirePortal> BlackEmpirePortals = new();

    /// <summary>
    /// The <see cref="BlackEmpirePortal"/> that the Black Empire should create next to further their quests.
    /// </summary>
    public static BlackEmpirePortal CurrentObjective => BlackEmpirePortals.Peek();

    /// <summary>
    /// Progresses the Black Empire's portal objective to the next one in the queue.
    /// </summary>
    public static void GoToNext()
    {
      BlackEmpirePortals.Dequeue();
    }

    /// <summary>
    /// Registers a number of <see cref="BlackEmpirePortal"/>s as needing to be opened.
    /// Their order in the collection will determine the order in which they must be opened.
    /// </summary>
    public static void RegisterPortals(IEnumerable<BlackEmpirePortal> blackEmpirePortals)
    {
      foreach (var portal in blackEmpirePortals)
      {
        BlackEmpirePortals.Enqueue(portal);
      }
    }
  }
}