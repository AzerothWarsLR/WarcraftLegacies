using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests;

/// <summary>
/// Any player owns the rag pedestal, cast a spell on it, and has a high level hero.
/// </summary>
public sealed class QuestRagnaros : QuestData
{
  private readonly LegendaryHero _ragnaros;
  private readonly unit _ragnarosSummoningPedestal;
  private readonly ObjectiveHeroWithLevelInRect _heroInRectObjective;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestRagnaros"/> class.
  /// </summary>
  public QuestRagnaros(LegendaryHero ragnaros, unit ragnarosSummmoningPedestal) : base("Lord of the Firelands",
    "Ragnaros hides within the Elemental Plane known as the Firelands. Outside Shadowforge City, the Dark Iron dwarves have been trying to summon him forth into Azeroth. Their efforts until now have proved ineffective, but we could succeed where they have not.",
    @"ReplaceableTextures\CommandButtons\BTNHeroAvatarOfFlame.blp")
  {
    _ragnaros = ragnaros;
    ragnarosSummmoningPedestal.MakeCapturable();
    ragnarosSummmoningPedestal.SetOwner(player.NeutralPassive);
    ragnarosSummmoningPedestal.IsInvulnerable = true;
    _ragnarosSummoningPedestal = ragnarosSummmoningPedestal;

    _heroInRectObjective =
      new ObjectiveHeroWithLevelInRect(10, Regions.RagnarosSummon, "the Portal to the Firelands");
    AddObjective(_heroInRectObjective);
    PlayerUnitEvents.Register(UnitEvent.SpellEffect, OnCastSummonSpell, _ragnarosSummoningPedestal);
    IsFactionQuest = false;
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Ragnaros is summoned near the Blackrock Depths, and can be slain to acquire Sulfuras";

  /// <inheritdoc/>
  public override string RewardFlavour => $"{_heroInRectObjective.CompletingUnitName} has seized control of the portal to the Firelands, and can now summon Ragnaros.";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    _ragnarosSummoningPedestal.SetOwner(_heroInRectObjective.CompletingUnit.Owner ?? player.NeutralAggressive);
    _ragnarosSummoningPedestal.IsInvulnerable = false;
  }

  private void OnCastSummonSpell()
  {
    var ragnarosSummonPoint = new Point(12332, -10597);
    _ragnaros.ForceCreate(player.NeutralAggressive, ragnarosSummonPoint, 320);
    effect effect = effect.Create(@"Abilities\Spells\Other\BreathOfFire\BreathOfFireMissile.mdl", ragnarosSummonPoint.X, ragnarosSummonPoint.Y);
    effect.Scale = 2;
    EffectSystem.Add(effect, 1);
    _ragnarosSummoningPedestal.Kill();

    foreach (var player in Util.EnumeratePlayers())
    {
      player.DisplayLegendaryHeroSummoned(_ragnaros,
        "Ragnaros, the Elemental Lord of Fire, has been forcibly called forth into Azeroth. The air smolders with his arrival, and Blackrock Mountain erupts in raging infernos that can be seen for miles.");
    }
  }
}
