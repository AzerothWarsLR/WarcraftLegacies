using WCSharp.W3MMD;

namespace WarcraftLegacies.Source.GameLogic.Mmd;

public static class MmdVariables
{
  public static readonly W3MmdIntVar hero_kills =
      W3Mmd.DefineInt("hero_kills", W3MmdGoalType.High, W3MmdSuggestionType.Leaderboard);

  public static readonly W3MmdIntVar hero_deaths =
      W3Mmd.DefineInt("hero_deaths", W3MmdGoalType.Low, W3MmdSuggestionType.None);

  public static readonly W3MmdFloatVar hero_damage_dealt =
      W3Mmd.DefineFloat("hero_damage_dealt", W3MmdGoalType.High, W3MmdSuggestionType.None);

  public static readonly W3MmdFloatVar hero_damage_taken =
      W3Mmd.DefineFloat("hero_damage_taken", W3MmdGoalType.Low, W3MmdSuggestionType.None);

  public static readonly W3MmdIntVar hero_revives =
      W3Mmd.DefineInt("hero_revives", W3MmdGoalType.Low, W3MmdSuggestionType.None);

  public static readonly W3MmdIntVar units_killed =
      W3Mmd.DefineInt("units_killed", W3MmdGoalType.High, W3MmdSuggestionType.Leaderboard);

  public static readonly W3MmdIntVar units_lost =
      W3Mmd.DefineInt("units_lost", W3MmdGoalType.Low, W3MmdSuggestionType.None);

  public static readonly W3MmdFloatVar damage_to_units =
      W3Mmd.DefineFloat("damage_to_units", W3MmdGoalType.High, W3MmdSuggestionType.None);

  public static readonly W3MmdFloatVar damage_to_heroes =
      W3Mmd.DefineFloat("damage_to_heroes", W3MmdGoalType.High, W3MmdSuggestionType.None);

  public static readonly W3MmdFloatVar damage_taken_units =
      W3Mmd.DefineFloat("damage_taken_units", W3MmdGoalType.Low, W3MmdSuggestionType.None);

  public static readonly W3MmdFloatVar damage_taken_heroes =
      W3Mmd.DefineFloat("damage_taken_heroes", W3MmdGoalType.Low, W3MmdSuggestionType.None);

  public static readonly W3MmdFloatVar gold_earned =
      W3Mmd.DefineFloat("gold_earned", W3MmdGoalType.High, W3MmdSuggestionType.None);

  public static readonly W3MmdFloatVar gold_spent =
      W3Mmd.DefineFloat("gold_spent", W3MmdGoalType.Low, W3MmdSuggestionType.None);

  public static readonly W3MmdFloatVar cp_minutes_owned =
      W3Mmd.DefineFloat("cp_minutes_owned", W3MmdGoalType.High, W3MmdSuggestionType.None);

  public static readonly W3MmdIntVar cp_captures =
      W3Mmd.DefineInt("cp_captures", W3MmdGoalType.High, W3MmdSuggestionType.Leaderboard);

  public static readonly W3MmdIntVar cp_value_controlled =
      W3Mmd.DefineInt("cp_value_controlled", W3MmdGoalType.High, W3MmdSuggestionType.None);

  public static readonly W3MmdEvent hero_kill_event =
      W3Mmd.DefineEvent("hero_kill", "{0} killed hero {1}", "Killer", "Victim");

  public static readonly W3MmdEvent unit_kill_event =
      W3Mmd.DefineEvent("unit_kill", "{0} killed unit {1}", "Killer", "Victim");

  public static readonly W3MmdEvent capital_destroyed_event =
      W3Mmd.DefineEvent("capital_destroyed", "{0} destroyed capital {1}", "Player", "Capital");

  public static readonly W3MmdEvent cp_capture_event =
      W3Mmd.DefineEvent("cp_capture", "{0} captured CP worth {1}", "Player", "Value");
}
