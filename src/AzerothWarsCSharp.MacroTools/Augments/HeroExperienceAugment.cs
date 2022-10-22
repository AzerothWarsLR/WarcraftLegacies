using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   /// <summary>
   /// An <see cref="Augment"/> that instantly grants experience to a <see cref="Legend"/>.
   /// </summary>
   public sealed class HeroExperienceAugment : Augment
   {
      private readonly Legend _legend;
      private readonly int _experience;

      /// <summary>
      /// Initializes an instance of the <see cref="HeroExperienceAugment"/> class.
      /// </summary>
      /// <param name="legend">Thhe <see cref="Legend"/> to give experience to when this is selected.</param>
      /// <param name="experience">The amount of experience to give to the <see cref="Legend"/> when this is selected.</param>
      public HeroExperienceAugment(Legend legend, int experience)
      {
         _legend = legend;
         _experience = experience;
         Name = $"Leadership: {legend.Name}";
         Description = $"{legend.Name} immediately gains {experience} experience.";
         IconPath = BlzGetAbilityIcon(legend.UnitType);
      }

      /// <inheritdoc />
      public override float GetWeight(player whichPlayer)
      {
         return _legend.OwningPlayer == whichPlayer ? 1 : 0;
      }

      /// <inheritdoc />
      public override void OnAdd(Faction whichFaction)
      {
         AddHeroXP(_legend.Unit, _experience, true);
      }
   }
}