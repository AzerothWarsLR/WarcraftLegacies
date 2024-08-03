using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.BlackEmpire
{
  public sealed class QuestWorldStone : QuestData
  {
    private readonly LegendaryHero _nzoth;
    private const int SkillPoints = 2;
    
    /// <inheritdoc/>
    public override string RewardFlavour =>
      "With the shamans obliterated, my tendrils will reach every corner of this world";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"N'zoth gains {SkillPoints} skill points";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestWarOfTheShiftingSand"/> class.
    /// </summary>
    public QuestWorldStone(LegendaryHero nzoth, Capital thunderbluff, Capital orgrimmar) : base("The World Stone",
      "The Horde shamans, through rituals, are preventing me from expanding through the earth. I will need to destroy the seats of their power",
      @"ReplaceableTextures\CommandButtons\BTNCthunIcon.blp")
    {
      _nzoth = nzoth;
      AddObjective(new ObjectiveControlCapital(thunderbluff, false));
      AddObjective(new ObjectiveKillUnit(orgrimmar.Unit));
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction) => UnitModifySkillPoints(_nzoth.Unit, SkillPoints);
  }
}