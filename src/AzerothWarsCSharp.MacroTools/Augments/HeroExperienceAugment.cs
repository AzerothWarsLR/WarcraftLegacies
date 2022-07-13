using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   public sealed class HeroExperienceAugment : Augment
   {
      private readonly Legend _legend;
      private readonly int _experience;

      public HeroExperienceAugment(Legend legend, int experience)
      {
         _legend = legend;
         _experience = experience;
         Name = $"Leadership: {legend.Name}";
         Description = $"{legend.Name} immediately gains {experience} experience.";
         IconPath = BlzGetAbilityIcon(legend.UnitType);
      }

      public override float GetWeight(player whichPlayer)
      {
         return _legend.OwningPlayer == whichPlayer ? 1 : 0;
      }

      public override void OnAdd(Faction whichFaction)
      {
         AddHeroXP(_legend.Unit, _experience, true);
      }
   }
}