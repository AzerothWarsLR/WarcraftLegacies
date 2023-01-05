using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests
{
  /// <summary>
  /// Any player owns the rag pedestal, cast a spell on it, and has a high level hero.
  /// </summary>
  public sealed class QuestRagnaros : QuestData
  {
    private readonly unit _ragnarosSummoningPedestal;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRagnaros"/> class.
    /// </summary>
    public QuestRagnaros(unit ragnarosSummmoningPedestal) : base("Lord of the Firelands",
      "Ragnaros hides within the Elemental Plane known as the Firelands. Outside Shadowforge City, the Dark Iron dwarves have been trying to summon him forth into Azeroth. Their efforts until now have proved ineffective, but we could succeed where they have not.",
      @"ReplaceableTextures\CommandButtons\BTNHeroAvatarOfFlame.blp")
    {
      AddObjective(new ObjectiveCastSpellFromUnit(Constants.ABILITY_A0PY_SUMMON_RAGNAROS_ALL, ragnarosSummmoningPedestal));
      _ragnarosSummoningPedestal = ragnarosSummmoningPedestal.MakeCapturable();
      AddObjective(new ObjectiveHeroWithLevelInRect(12, Regions.RagnarosSummon, "The Portal to the Firelands"));
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Ragnaros is summoned near the Blackrock Depths, and can be slain to acquire Sulfuras";

    /// <inheritdoc/>
    protected override string CompletionPopup => "Ragnaros, the Elemental Lord of Fire, has been forcibly called forth into Azeroth. The air smolders with his arrival, and Blackrock Mountain erupts in raging infernos that can be seen for miles.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      var ragnarosSummonPoint = new Point(12332, -10597);
      LegendNeutral.Ragnaros.ForceCreate(Player(PLAYER_NEUTRAL_AGGRESSIVE), ragnarosSummonPoint, 320);
      AddSpecialEffect(@"Abilities\Spells\Other\BreathOfFire\BreathOfFireMissile.mdl", ragnarosSummonPoint.X,
        ragnarosSummonPoint.Y)
        .SetScale(2)
        .SetLifespan(1);
      _ragnarosSummoningPedestal.Kill();
    }
  }
}