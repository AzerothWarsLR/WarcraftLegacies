namespace WarcraftLegacies.Source.GameLogic.Mmd;

/// <summary>
/// Combines a player's raw MMD stats into a single overall performance score.
/// </summary>
public static class MmdScoring
{
  private const float HeroKillWeight = 50f;
  private const float HeroDeathWeight = -30f;
  private const float HeroDamageDealtWeight = 0.01f;
  private const float HeroDamageTakenWeight = -0.005f;
  private const float HeroReviveWeight = 10f;

  private const float UnitKillWeight = 2f;
  private const float UnitLostWeight = -1f;
  private const float DamageToUnitsWeight = 0.005f;
  private const float DamageToHeroesWeight = 0.01f;
  private const float DamageTakenUnitsWeight = -0.002f;
  private const float DamageTakenHeroesWeight = -0.005f;

  private const float CpCaptureWeight = 20f;
  private const float CpValueControlledWeight = 1f;

  private const float CpMinutesOwnedWeight = 0.05f;
  private const float CapitalDestroyedWeight = 100f;

  private const float TurnSurvivedWeight = 1f;

  public static float Compute(MmdPlayerStats stats)
  {
    return stats.HeroKills * HeroKillWeight
         + stats.HeroDeaths * HeroDeathWeight
         + stats.HeroDamageDealt * HeroDamageDealtWeight
         + stats.HeroDamageTaken * HeroDamageTakenWeight
         + stats.HeroRevives * HeroReviveWeight
         + stats.UnitsKilled * UnitKillWeight
         + stats.UnitsLost * UnitLostWeight
         + stats.DamageToUnits * DamageToUnitsWeight
         + stats.DamageToHeroes * DamageToHeroesWeight
         + stats.DamageTakenUnits * DamageTakenUnitsWeight
         + stats.DamageTakenHeroes * DamageTakenHeroesWeight
         + stats.CpCaptures * CpCaptureWeight
         + stats.CpValueControlled * CpValueControlledWeight
         + stats.CpMinutesOwned * CpMinutesOwnedWeight
         + stats.CapitalsDestroyed.Count * CapitalDestroyedWeight
         + stats.TurnsSurvived * TurnSurvivedWeight;
  }
}
