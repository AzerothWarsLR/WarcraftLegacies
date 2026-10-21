using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.QuestBased;

namespace WarcraftLegacies.Source.Factions.Legion.Quests;

/// <summary>Rewards whichever hero completes the summoning of the Burning Legion.</summary>
public sealed class QuestHeraldOfArchimonde : QuestData
{
  private const int StatGain = 15;
  private const int MaxHeroLevel = 20;
  private const int LevelTwoExperience = 400;
  private const int ExperiencePerLevelFactor = 200;
  private readonly ObjectiveOwnHeroSummonsLegion _summoning;

  public QuestHeraldOfArchimonde(QuestSummonLegion summonLegion, Faction legion) : base("Herald of Archimonde",
    "Archimonde will exalt whichever champion tears open the way for him. If one of your own heroes completes the summoning ritual of the Burning Legion, the Eredar lord's favour will be theirs.",
    @"ReplaceableTextures\CommandButtons\BTNArchimonde.blp")
  {
    _summoning = new ObjectiveOwnHeroSummonsLegion(summonLegion, legion);
    AddObjective(_summoning);
  }

  /// <inheritdoc />
  public override string RewardFlavour
  {
    get
    {
      var summoner = _summoning.Summoner;
      var heroName = summoner != null ? summoner.GetProperName() : Loc.Get("An unknown hero");
      return Loc.Format("{hero} has opened the way for Archimonde, and the Eredar lord grants his herald a measure of his own power.",
        ("{hero}", heroName));
    }
  }

  /// <inheritdoc />
  protected override string RewardDescription =>
    Loc.Format("The hero who completes the summoning permanently gains a level and {stat} Strength, Agility and Intelligence", ("{stat}", StatGain.ToString()));

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var summoner = _summoning.Summoner;
    if (summoner != null)
    {
      summoner.AddHeroAttributes(StatGain, StatGain, StatGain);
      GrantFullLevel(summoner);
    }
  }

  /// <summary>Raises the hero by one whole level, keeping its progress towards the next one.</summary>
  private static void GrantFullLevel(unit hero)
  {
    var level = hero.HeroLevel;
    if (level >= MaxHeroLevel)
    {
      return;
    }

    var levelStart = GetTotalExperience(level);
    var progress = (float)(hero.Experience - levelStart) / (GetTotalExperience(level + 1) - levelStart);
    var newLevel = level + 1;
    var newExperience = newLevel >= MaxHeroLevel
      ? GetTotalExperience(MaxHeroLevel)
      : GetTotalExperience(newLevel) + (int)(progress * (GetTotalExperience(newLevel + 1) - GetTotalExperience(newLevel)));
    hero.SetExperience(newExperience, true);
  }

  /// <summary>The total experience a hero needs to reach <paramref name="level"/>, using the map's experience curve.</summary>
  private static int GetTotalExperience(int level)
  {
    if (level <= 1)
    {
      return 0;
    }

    var experience = LevelTwoExperience;
    for (var i = 3; i <= level; i++)
    {
      experience += ExperiencePerLevelFactor * i;
    }

    return experience;
  }
}
