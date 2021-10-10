using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public abstract class ActiveAbilityFactory<T> : AbilityFactory<T> where T : Ability
  {
    protected override void ApplyIcons(T ability)
    {
      ability.ArtIconNormal = @$"ReplaceableTextures\CommandButtons\BTN{Icon}.blp";
      ability.ArtIconResearch = @$"ReplaceableTextures\CommandButtons\BTN{Icon}.blp";
    }

    protected override void ApplyCore(T ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        //ability.StatsManaCost[i + 1] = i < ManaCost.Length ? ManaCost[i] : 0;
        //ability.StatsCooldown[i + 1] = i < Cooldown.Length ? Cooldown[i] : 0;
      }
    }

    /// <summary>
    /// How much mana the ability costs.
    /// </summary>
    public LeveledAbilityProperty<int> ManaCost { get; set; } = new("Mana cost");

    /// <summary>
    /// The time the unit with the ability has to wait before using the ability again.
    /// </summary>
    public LeveledAbilityProperty<int> Cooldown { get; set; } = new("Cooldown");
  }
}