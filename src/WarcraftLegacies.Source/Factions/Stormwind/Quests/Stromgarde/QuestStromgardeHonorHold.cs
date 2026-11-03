using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Stormwind.Quests.Stromgarde;

/// <summary>Stromgarde's take on Honor Hold, where Danath once led the Sons of Lothar.</summary>
public sealed class QuestStromgardeHonorHold : QuestData
{
  private const int BonusLevels = 2;

  private readonly QuestHonorHold _original;
  private readonly LegendaryHero _danath;

  public QuestStromgardeHonorHold(QuestHonorHold original, Capital hellfireCitadel, LegendaryHero danath) : base("Honor Hold",
    "Danath Trollbane once held Honor Hold with the Sons of Lothar, stranded in Outland after the Second War. His old comrades still hold out there in the shadow of Hellfire Citadel.",
    @"ReplaceableTextures\CommandButtons\BTNHumanBarracks.blp")
  {
    _original = original;
    _danath = danath;
    original.HandedOver = true;
    AddObjective(new ObjectiveCapitalDead(hellfireCitadel));
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Hellfire Citadel has fallen and Honor Hold rejoins the Alliance. Danath's old comrades rally to him once more.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all units at Honor Hold, and Danath Trollbane gains 2 levels";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    foreach (var unit in _original.RescueUnits)
    {
      unit.Rescue(player.NeutralAggressive);
    }
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner != null)
    {
      foreach (var unit in _original.RescueUnits)
      {
        unit.Rescue(owner);
      }
    }

    Regions.HonorHold.Rect.SetDoodadAnimation(FourCC("ISrb"), "hide", false);
    Regions.HonorHold.Rect.SetDoodadAnimation(FourCC("LSst"), "hide", false);
    Regions.HonorHold.Rect.SetDoodadAnimation(FourCC("CSra"), "unhide", false);

    var danath = _danath.Unit;
    if (danath != null)
    {
      danath.SetLevel(danath.HeroLevel + BonusLevels);
    }

    _original.Progress = QuestProgress.Complete;
  }
}
