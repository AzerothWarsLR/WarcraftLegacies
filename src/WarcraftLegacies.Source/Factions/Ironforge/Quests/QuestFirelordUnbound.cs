using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Shared;
using WCSharp.Effects;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>Dagran opens the way to the Firelands and binds Ragnaros to the Dark Iron.</summary>
public sealed class QuestFirelordUnbound : QuestData
{
  private const int RequiredLevel = 10;
  private const int ChannelDuration = 60;
  private const float ChannelFacing = 270;
  private static readonly Point _summonPoint = new(12332, -10597);

  private readonly LegendaryHero _ragnaros;

  public QuestFirelordUnbound(LegendaryHero dagran, LegendaryHero ragnaros, QuestData blackAnvil) : base("The Firelord Unbound",
    "The Sorcerer-Thane Thaurissan first called Ragnaros into Azeroth, and the Dark Iron have served the Firelord ever since. With the Black Anvil rekindled, Dagran can tear open the way to the Firelands and bind Ragnaros to our cause.",
    @"ReplaceableTextures\CommandButtons\BTNHeroAvatarOfFlame.blp")
  {
    _ragnaros = ragnaros;
    var anvil = new ObjectiveQuestComplete(blackAnvil);
    var level = new ObjectiveLegendLevel(dagran, RequiredLevel);
    AddObjective(anvil);
    AddObjective(level);
    AddObjective(new ObjectiveChannelRect(Regions.RagnarosSummon, "the Firelands portal", dagran, ChannelDuration, ChannelFacing,
      "Summoning Ragnaros")
    {
      StartCondition = () => anvil.Progress == QuestProgress.Complete && level.Progress == QuestProgress.Complete
    });
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Blackrock Mountain erupts as Ragnaros, the Firelord, tears his way into Azeroth. This time, he burns for the Dark Iron.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Gain control of Ragnaros, Lord of the Firelands, at the Firelands portal";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner == null)
    {
      return;
    }

    PathBase.SummonLegend(_ragnaros, owner, _summonPoint);
    _ragnaros.PermaDies = true;
    var fire = effect.Create(@"Abilities\Spells\Other\BreathOfFire\BreathOfFireMissile.mdl", _summonPoint.X, _summonPoint.Y);
    fire.Scale = 2;
    EffectSystem.Add(fire, 1);
    foreach (var whichPlayer in Util.EnumeratePlayers())
    {
      whichPlayer.DisplayLegendaryHeroSummoned(_ragnaros,
        "Ragnaros, the Elemental Lord of Fire, has been called forth by the Dark Iron. Blackrock Mountain erupts as the Firelord marches beneath their banners.");
    }
  }
}
