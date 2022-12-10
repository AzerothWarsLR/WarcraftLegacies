using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Augments
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
      /// <param name="legendaryHero"></param>
      /// <param name="experience">The amount of experience to give to the <see cref="Legend"/> when this is selected.</param>
      public HeroExperienceAugment(LegendaryHero legendaryHero, int experience)
      {
         _legend = legendaryHero;
         _experience = experience;
         Name = $"Leadership: {legendaryHero.Name}";
         Description = $"{legendaryHero.Name} immediately gains {experience} experience.";
         IconPath = BlzGetAbilityIcon(legendaryHero.UnitType);
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