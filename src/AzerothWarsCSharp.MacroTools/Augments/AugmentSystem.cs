using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   public static class AugmentSystem
   {
      private static readonly List<Augment> Augments = new();

      /// <summary>
      /// Gets a random <see cref="Augment"/>.
      /// The result is weighted based on particular attributes of the provided <see cref="player"/>.
      /// </summary>
      public static Augment GetRandom(player whichPlayer)
      {
         return Augments[GetRandomInt(0, Augments.Count - 1)];
      }
      
      public static void Register(Augment augment)
      {
         Augments.Add(augment);
      }
   }
}