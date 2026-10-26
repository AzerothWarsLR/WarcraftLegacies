using MacroTools.Artifacts;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BloodElves.Quests;

/// <summary>Kael'thas uses the Heart of M'uru at the Sunwell to destroy the well and summon Kil'jaeden.</summary>
public sealed class QuestFallOfTheSunwell : QuestData
{
  private const int RequiredLevel = 10;
  private const int ChannelDuration = 180;
  private const float ChannelFacing = 90;

  private readonly LegendaryHero _kiljaeden;
  private readonly Capital _sunwell;
  private readonly Artifact _heartOfMuru;

  public QuestFallOfTheSunwell(LegendaryHero kael, LegendaryHero kiljaeden, Capital sunwell, Artifact heartOfMuru) : base(
    "The Fall of the Sunwell",
    "The Heart of M'uru holds enough holy light to tear open the Sunwell. If Kael'thas carries it there, its power would destroy what remains of the well and open a gateway for Kil'jaeden himself.",
    @"ReplaceableTextures\CommandButtons\BTNKiljaedin.blp")
  {
    _kiljaeden = kiljaeden;
    _sunwell = sunwell;
    _heartOfMuru = heartOfMuru;
    var level = new ObjectiveLegendLevel(kael, RequiredLevel);
    var hasHeart = new ObjectiveLegendHasArtifact(kael, heartOfMuru);
    AddObjective(level);
    AddObjective(hasHeart);
    AddObjective(new ObjectiveChannelRect(Regions.Sunwell, "the Sunwell", kael, ChannelDuration, ChannelFacing,
      "Summoning Kil'jaeden")
    {
      StartCondition = () => level.Progress == QuestProgress.Complete && hasHeart.Progress == QuestProgress.Complete
    });
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The heart of M'uru erupts in the depths of the Sunwell. What little remained of the well is consumed, and from the searing void it leaves behind, Kil'jaeden the Deceiver steps into Azeroth.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "The Heart of M'uru is consumed, the Sunwell is destroyed, and Kil'jaeden is summoned at the Sunwell under your control";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    if (ArtifactManager.GetFromTypeId(_heartOfMuru.Item.TypeId) == _heartOfMuru)
    {
      ArtifactManager.Destroy(_heartOfMuru);
    }

    DestroySunwell();
    var owner = completingFaction.Player;
    if (owner != null)
    {
      var spot = Regions.Sunwell.Center;
      PathBase.SummonLegend(_kiljaeden, owner, new Point(spot.X, spot.Y - 200));
    }
  }

  private void DestroySunwell()
  {
    var sunwell = _sunwell.Unit;
    if (sunwell == null || !sunwell.Alive)
    {
      return;
    }

    _sunwell.Essential = false;
    _sunwell.Capturable = false;
    sunwell.Kill();
    effect.Create(@"Abilities\Spells\Other\Doom\DoomDeath.mdl", sunwell.X, sunwell.Y).Dispose();
  }
}
