using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Quests;

/// <summary>Retake Windrunner Spire and destroy Dar'Khan, turning Sylvanas into a Dark Ranger.</summary>
public sealed class QuestBansheesVengeance : QuestData
{
  private const int ChannelDuration = 30;
  private const float ChannelFacing = 270;

  private readonly LegendaryHero _sylvanas;

  public QuestBansheesVengeance(Capital windrunnerSpire, LegendaryHero sylvanas) : base("The Banshee's Vengeance",
    "Dar'Khan Drathir opened the gates of Quel'Thalas to the Scourge and delivered Sylvanas to her death. Retake Windrunner Spire, and let Sylvanas call her betrayer back from the grave to face her.",
    @"ReplaceableTextures\CommandButtons\BTNBansheeRanger.blp")
  {
    _sylvanas = sylvanas;
    AddObjective(new ObjectiveControlCapital(windrunnerSpire, false));
    var channel = new ObjectiveChannelRect(Regions.WindrunnerSpireUnlock, "Windrunner Spire", sylvanas, ChannelDuration,
      ChannelFacing);
    AddObjective(channel);
    var spawn = Regions.WindrunnerSpireUnlock.Center;
    AddObjective(new ObjectiveDefeatRisenFoe(channel, UNIT_H0CS_BETRAYER_OF_SILVERMOON_SUNFURY, "Dar'Khan Drathir",
      new Point(spawn.X, spawn.Y - 400), 90));
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Dar'Khan falls for the last time at the feet of the woman he betrayed. Her vengeance taken, Sylvanas takes up her bow once more as the Dark Lady, and the Lich King's grip on her begins to slip.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Sylvanas becomes a Dark Ranger, and the Banshee's Host can break free of the Lich King through the Rise of the Forsaken";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    _sylvanas.UnitType = UNIT_USYL_DARK_RANGER_FORSAKEN;
    var sylvanas = _sylvanas.Unit;
    if (sylvanas == null)
    {
      return;
    }

    sylvanas.Life = sylvanas.MaxLife;
    sylvanas.Mana = sylvanas.MaxMana;
    effect.Create(@"war3mapImported\Soul Beam Blue.mdx", sylvanas.X, sylvanas.Y).Dispose();
    effect.Create(@"Abilities\Spells\Undead\AnimateDead\AnimateDeadTarget.mdl", sylvanas.X, sylvanas.Y).Dispose();
  }
}
