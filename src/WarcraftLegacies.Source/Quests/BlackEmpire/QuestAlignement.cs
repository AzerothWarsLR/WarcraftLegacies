using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.BlackEmpire
{
  /// <summary>
  /// Capture control points to give Nzoth skilll points
  /// </summary>
  public sealed class QuestAlignement : QuestData
  {
    private readonly LegendaryHero _nzoth;
    private const int SkillPoints = 3;

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "My influence must spread further and further, bringing Nyalotha into this reality and making me ever stronger";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"N'zoth gains {SkillPoints} skill points";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestAlignement"/> class.
    /// </summary>
    public QuestAlignement(LegendaryHero nzoth) : base("Alignement",
      "I am still weak, and this reality is fading. I need to send my forces to all corners of the continent.",
      @"ReplaceableTextures\CommandButtons\BTNSilithid.blp")
    {
      _nzoth = nzoth;
      AddObjective(new ObjectiveControlLevel(UNIT_NLSE_TEMPLE_OF_AHN_QIRAJ, 10));
      AddObjective(new ObjectiveControlLevel(UNIT_N01U_STONETALON_PEAK, 5));
      AddObjective(new ObjectiveControlLevel(UNIT_N00P_THE_ABYSS, 4));
      AddObjective(new ObjectiveControlLevel(UNIT_N01P_NORDRASSIL, 3));
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction) => UnitModifySkillPoints(_nzoth.Unit, SkillPoints);
  }
}