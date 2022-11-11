using War3Api.Object;

namespace WarcraftLegacies.ObjectFactory.Abilities
{
  public abstract class AutocastAbilityFactory<T> : ActiveAbilityFactory<T> where T : Ability
  {
    protected override void ApplyIcons(T ability)
    {
      ability.ArtIconNormal = @$"ReplaceableTextures\CommandButtons\BTN{Icon}On.blp";
      ability.ArtIconTurnOff = @$"ReplaceableTextures\CommandButtons\BTN{Icon}Off.blp";
      ability.ArtIconResearch = @$"ReplaceableTextures\CommandButtons\BTN{Icon}On.blp";
    }

    public AutocastAbilityFactory() : base()
    {

    }
  }
}