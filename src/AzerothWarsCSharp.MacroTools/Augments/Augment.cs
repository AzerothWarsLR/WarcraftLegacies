using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   /// <summary>
   /// A selectable option that gives a particular bonus to a <see cref="Faction"/>.
   /// </summary>
   public abstract class Augment
   {
      private readonly string? _iconName;

      protected string IconName
      {
         get => _iconName ?? "Peasant";
         init
         {
            _iconName = value;
            IconPath = $@"ReplaceableTextures\CommandButtons\BTN{IconName}.blp";
         }
      }

      public string? IconPath { get; protected init; }

      public string Name { get; init; } = "DefaultName";

      public string Description { get; init; } = "DefaultDescription";

      public abstract float GetWeight(player whichPlayer);
      
      /// <summary>
      /// Occurs when the <see cref="Augment"/> is added to a <see cref="player"/>.
      /// </summary>
      public abstract void OnAdd(Faction whichFaction);
   }
}