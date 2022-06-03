using System.Collections.Generic;
using System.Linq;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Mechanics.TwilightHammer
{
  public sealed class PowerCorruptWorker : Power
  {
    private readonly PeriodicTrigger<CorruptWorkerPeriodicAction> _corruptWorkerPeriodicTrigger;
    private Continent _activeContinent = null!;

    /// <summary>
    /// Periodically corrupts a random uncorrupted worker in one of the specified continents.
    /// </summary>
    /// <param name="period">How frequently to corrupt workers.</param>
    /// <param name="continents">The continents in which workers can be corrupted.</param>
    public PowerCorruptWorker(float period, IEnumerable<Continent> continents)
    {
      _corruptWorkerPeriodicTrigger = new PeriodicTrigger<CorruptWorkerPeriodicAction>(period);
      ActiveContinent = continents.First();
      IconName = "Charm";
      Name = "Corrupt Workers";
      Description = "Corrupt some workers";
    }

    public Continent ActiveContinent
    {
      get => _activeContinent;
      set
      {
        foreach (var action in _corruptWorkerPeriodicTrigger.Actions)
        {
          action.Continent = value;
        }

        _activeContinent = value;
      }
    }

    public override void OnAdd(player whichPlayer)
    {
      _corruptWorkerPeriodicTrigger.Add(new CorruptWorkerPeriodicAction(whichPlayer, ActiveContinent));
    }

    public override void OnRemove(player whichPlayer)
    {
      foreach (var periodicAction in _corruptWorkerPeriodicTrigger.Actions)
        periodicAction.Active = false;
    }
  }
}