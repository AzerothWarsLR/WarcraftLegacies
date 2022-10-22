using System.Collections.Generic;
using System.Linq;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Mechanics.Goblins
{
   /// <summary>
   /// When this unit is trained, it removes itself and creates an Oil Platform at one of the eligible oil locations instead.
   /// </summary>
   public sealed class OilRigConstructor : UnitEffect
   {
      private readonly List<Point> _oilLocations;
      
      public override void OnTrained()
      {
         var spawnLocation = _oilLocations[GetRandomInt(0, _oilLocations.Count - 1)];
         CreateUnit(GetOwningPlayer(GetTriggerUnit()), Constants.UNIT_O04R_OIL_PLATFORM_GOBLIN, spawnLocation.X, spawnLocation.Y, 0);
         if (GetOwningPlayer(GetTrainedUnit()) == GetLocalPlayer())
         {
            PingMinimap(spawnLocation.X, spawnLocation.Y, 10);
         }
         _oilLocations.Remove(spawnLocation);
      }

      /// <summary>
      /// Creates an <see cref="OilRigConstructor"/>.
      /// </summary>
      /// <param name="unitTypeId">The unit type of the constructed unit.</param>
      /// <param name="oilLocations">Locations where the actual oil platform may be created.</param>
      public OilRigConstructor(int unitTypeId, IEnumerable<Point> oilLocations) : base(unitTypeId)
      {
         _oilLocations = oilLocations.ToList();
      }
   }
}