using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   /// <summary>
   /// A selectable option that gives a particular bonus to a <see cref="Faction"/>.
   /// </summary>
   public abstract class Augment
   {
      /// <summary>
      /// Occurs when the <see cref="Augment"/> is added to a <see cref="player"/>.
      /// </summary>
      public abstract void OnAdd(Faction whichFaction);
   }
}