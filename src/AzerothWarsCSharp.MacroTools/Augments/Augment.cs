using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   /// <summary>
   /// A selectable option that gives a particular bonus to a <see cref="Faction"/>.
   /// </summary>
   public abstract class Augment
   {
      public string IconName { get; init; } = "";
      
      public string IconPath => $@"ReplaceableTextures\CommandButtons\BTN{IconName}.blp";

      public string Name { get; init; } = "DefaultName";

      public string Description { get; init; } = "DefaultDescription";

      public abstract float GetWeight(player whichPlayer);
      
      /// <summary>
      /// Occurs when the <see cref="Augment"/> is added to a <see cref="player"/>.
      /// </summary>
      public abstract void OnAdd(Faction whichFaction);
   }
}