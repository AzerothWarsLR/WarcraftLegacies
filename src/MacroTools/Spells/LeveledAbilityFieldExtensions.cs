namespace MacroTools.Spells;

public static class LeveledAbilityFieldExtensions
{
  public static int GetValue(this LeveledAbilityField<int> field, int level)
    => field.Base + field.PerLevel * level;

  public static float GetValue(this LeveledAbilityField<float> field, int level)
    => field.Base + field.PerLevel * level;
}
