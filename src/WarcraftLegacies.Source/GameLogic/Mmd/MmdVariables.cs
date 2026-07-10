using WCSharp.W3MMD;

namespace WarcraftLegacies.Source.GameLogic.Mmd;

public static class MmdVariables
{
  public static W3MmdIntVar HeroKills = null!;
  public static W3MmdIntVar HeroDeaths = null!;
  public static W3MmdFloatVar HeroDamageDealt = null!;
  public static W3MmdFloatVar HeroDamageTaken = null!;
  public static W3MmdIntVar HeroRevives = null!;

  public static W3MmdIntVar UnitsKilled = null!;
  public static W3MmdIntVar UnitsLost = null!;
  public static W3MmdFloatVar DamageToUnits = null!;
  public static W3MmdFloatVar DamageToHeroes = null!;
  public static W3MmdFloatVar DamageTakenUnits = null!;
  public static W3MmdFloatVar DamageTakenHeroes = null!;

  public static W3MmdFloatVar GoldEarned = null!;
  public static W3MmdFloatVar GoldSpent = null!;

  public static W3MmdFloatVar CpMinutesOwned = null!;
  public static W3MmdIntVar CpCaptures = null!;
  public static W3MmdIntVar CpValueControlled = null!;

  public static W3MmdIntVar TurnsSurvived = null!;
  public static W3MmdFloatVar Score = null!;

  public static W3MmdEvent HeroKillEvent = null!;
  public static W3MmdEvent UnitKillEvent = null!;
  public static W3MmdEvent CapitalDestroyedEvent = null!;
  public static W3MmdEvent CpCaptureEvent = null!;

  public static bool Initialized;

  public static void Init()
  {
    if (Initialized)
    {
      return;
    }

    HeroKills = W3Mmd.DefineInt("hero_kills", W3MmdGoalType.High, W3MmdSuggestionType.Track);
    HeroDeaths = W3Mmd.DefineInt("hero_deaths", W3MmdGoalType.Low, W3MmdSuggestionType.Track);
    HeroDamageDealt = W3Mmd.DefineFloat("hero_damage_dealt", W3MmdGoalType.High, W3MmdSuggestionType.Track);
    HeroDamageTaken = W3Mmd.DefineFloat("hero_damage_taken", W3MmdGoalType.Low, W3MmdSuggestionType.Track);
    HeroRevives = W3Mmd.DefineInt("hero_revives", W3MmdGoalType.Low, W3MmdSuggestionType.Track);

    UnitsKilled = W3Mmd.DefineInt("units_killed", W3MmdGoalType.High, W3MmdSuggestionType.Track);
    UnitsLost = W3Mmd.DefineInt("units_lost", W3MmdGoalType.Low, W3MmdSuggestionType.Track);
    DamageToUnits = W3Mmd.DefineFloat("damage_to_units", W3MmdGoalType.High, W3MmdSuggestionType.Track);
    DamageToHeroes = W3Mmd.DefineFloat("damage_to_heroes", W3MmdGoalType.High, W3MmdSuggestionType.Track);
    DamageTakenUnits = W3Mmd.DefineFloat("damage_taken_units", W3MmdGoalType.Low, W3MmdSuggestionType.Track);
    DamageTakenHeroes = W3Mmd.DefineFloat("damage_taken_heroes", W3MmdGoalType.Low, W3MmdSuggestionType.Track);

    GoldEarned = W3Mmd.DefineFloat("gold_earned", W3MmdGoalType.High, W3MmdSuggestionType.Track);
    GoldSpent = W3Mmd.DefineFloat("gold_spent", W3MmdGoalType.Low, W3MmdSuggestionType.Track);

    CpMinutesOwned = W3Mmd.DefineFloat("cp_minutes_owned", W3MmdGoalType.High, W3MmdSuggestionType.Track);
    CpCaptures = W3Mmd.DefineInt("cp_captures", W3MmdGoalType.High, W3MmdSuggestionType.Track);
    CpValueControlled = W3Mmd.DefineInt("cp_value_controlled", W3MmdGoalType.High, W3MmdSuggestionType.Track);

    TurnsSurvived = W3Mmd.DefineInt("turns_survived", W3MmdGoalType.High, W3MmdSuggestionType.Track);
    Score = W3Mmd.DefineFloat("score", W3MmdGoalType.High, W3MmdSuggestionType.Track);

    HeroKillEvent = W3Mmd.DefineEvent("hero_kill", "{0} killed hero {1}", "Killer", "Victim");
    UnitKillEvent = W3Mmd.DefineEvent("unit_kill", "{0} killed unit {1}", "Killer", "Victim");
    CapitalDestroyedEvent = W3Mmd.DefineEvent("capital_destroyed", "{0} destroyed capital {1}", "Player", "Capital");
    CpCaptureEvent = W3Mmd.DefineEvent("cp_capture", "{0} captured CP worth {1}", "Player", "Value");

    Initialized = true;
  }
}
