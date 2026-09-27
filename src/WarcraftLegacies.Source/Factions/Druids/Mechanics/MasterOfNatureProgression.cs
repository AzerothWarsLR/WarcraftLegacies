using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Druids.Mechanics;

public static class MasterOfNatureProgression
{
  private static readonly int[] _heroLevelPerStage = { 1, 3, 5, 7 };

  public static void Setup(int abilityId, params int[] heroTypeIds)
  {
    foreach (var heroTypeId in heroTypeIds)
    {
      PlayerUnitEvents.Register(HeroTypeEvent.Levels, () => UpdateStage(@event.Unit, abilityId), heroTypeId);
    }
  }

  private static void UpdateStage(unit hero, int abilityId)
  {
    var stage = 0;
    foreach (var requiredLevel in _heroLevelPerStage)
    {
      if (hero.HeroLevel >= requiredLevel)
      {
        stage++;
      }
    }

    if (stage > 0 && hero.GetAbilityLevel(abilityId) != stage)
    {
      hero.SetAbilityLevel(abilityId, stage);
    }
  }
}
