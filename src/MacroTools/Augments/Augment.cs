using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Augments
{
   /// <summary>
   /// A selectable option that gives a particular bonus to a <see cref="Faction"/>.
   /// </summary>
   public abstract class Augment
   {
      private readonly string? _iconName;

      /// <summary>
      /// The art icon name for the icon used to represent this <see cref="Augment"/>, e.g. "Peasant".
      /// </summary>
      protected string IconName
      {
         get => _iconName ?? "Peasant";
         init
         {
            _iconName = value;
            IconPath = $@"ReplaceableTextures\CommandButtons\BTN{IconName}.blp";
         }
      }

      /// <summary>
      /// The file name for the icon used to represent this <see cref="Augment"/>,
      /// e.g. "ReplaceableTextures\CommandButtons\BTNPeasant.blp".
      /// </summary>
      public string? IconPath { get; protected init; }

      /// <summary>
      /// A user-friendly name for this <see cref="Augment"/>.
      /// </summary>
      public string Name { get; init; } = "DefaultName";

      /// <summary>
      /// A user-friendly description for this <see cref="Augment"/>.
      /// </summary>
      public string Description { get; init; } = "DefaultDescription";

      /// <summary>
      /// Returns a weight affecting the probability of getting this <see cref="Augment"/> in a random draw.
      /// </summary>
      public abstract float GetWeight(player whichPlayer);
      
      /// <summary>
      /// Invoked when the <see cref="Augment"/> is added to a player.
      /// </summary>
      public abstract void OnAdd(Faction whichFaction);
   }
}