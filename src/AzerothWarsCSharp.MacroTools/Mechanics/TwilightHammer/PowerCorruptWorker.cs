using System.Collections.Generic;
using System.Linq;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.TwilightHammer
{
  public sealed class PowerCorruptWorker : Power
  {
    private readonly PeriodicTrigger<CorruptWorkerPeriodicAction> _corruptWorkerPeriodicTrigger = new(1.0f);
    private Continent _activeContinent = null!;

    public PowerCorruptWorker(IEnumerable<Continent> activeContinent)
    {
      ActiveContinent = activeContinent.First();
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