namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>Helps change the level of an aura that gives a bonus to its own unit.</summary>
public static class AuraLevel
{
  /// <summary>Sets an aura's level so that its bonus updates straight away; auras otherwise keep the previous level's bonus.</summary>
  public static void SetLevel(unit whichUnit, int abilityId, int level, int maximumLevel)
  {
    if (whichUnit.GetAbilityLevel(abilityId) == 0)
    {
      whichUnit.AddAbility(abilityId);
    }

    whichUnit.SetAbilityLevel(abilityId, level);
    if (level < maximumLevel)
    {
      IncUnitAbilityLevel(whichUnit, abilityId);
      DecUnitAbilityLevel(whichUnit, abilityId);
    }
    else
    {
      DecUnitAbilityLevel(whichUnit, abilityId);
      IncUnitAbilityLevel(whichUnit, abilityId);
    }
  }
}
