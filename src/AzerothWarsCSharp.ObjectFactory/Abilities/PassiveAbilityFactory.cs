using War3Api.Object;

namespace AzerothWarsCSharp.ObjectFactory.Abilities
{
  public abstract class PassiveAbilityFactory<T> : AbilityFactory<T> where T : Ability
  {
    protected override void ApplyIcons(T ability)
    {
      ability.ArtIconNormal = @$"ReplaceableTextures\PassiveButtons\PASBTN{Icon}.blp";
      ability.ArtIconResearch = @$"ReplaceableTextures\CommandButtons\BTN{Icon}.blp";
    }

    protected override void ApplyCore(T ability)
    {
    }
  }
}