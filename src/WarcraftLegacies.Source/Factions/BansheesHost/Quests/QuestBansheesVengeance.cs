using MacroTools.Extensions;
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
  private const float WailLength = 1.33f;
  private const float DarKhanScale = 1.4f;
  private const int DarKhanLevel = 12;
  private const float DarKhanHealthFactor = 2;

  private readonly LegendaryHero _sylvanas;

  /// <summary>Where Sylvanas channels, on open ground beside Windrunner Spire.</summary>
  public static Rectangle ChannelSpot { get; } = new(16668, 13691, 16868, 13891);

  public QuestBansheesVengeance(Capital windrunnerSpire, LegendaryHero sylvanas) : base("The Banshee's Vengeance",
    "Dar'Khan Drathir opened the gates of Quel'Thalas to the Scourge and delivered Sylvanas to her death. Retake Windrunner Spire, and let Sylvanas call her betrayer back from the grave to face her.",
    @"ReplaceableTextures\CommandButtons\BTNBansheeRanger.blp")
  {
    _sylvanas = sylvanas;
    AddObjective(new ObjectiveControlCapital(windrunnerSpire, false));
    var channel = new ObjectiveChannelRect(ChannelSpot, "Windrunner Spire", sylvanas, ChannelDuration, ChannelFacing,
      null, "spell", WailLength);
    AddObjective(channel);
    var spawn = ChannelSpot.Center;
    var darKhan = new ObjectiveDefeatRisenFoe(channel, UNIT_H0CS_BETRAYER_OF_SILVERMOON_SUNFURY, "Dar'Khan Drathir",
      new Point(spawn.X + 250, spawn.Y - 250), 135);
    darKhan.FoeRisen += Empower;
    AddObjective(darKhan);
    ResearchId = UPGRADE_R10C_QUEST_COMPLETED_THE_BANSHEE_S_VENGEANCE_BANSHEESHOST;
  }

  private static void Empower(unit darKhan)
  {
    darKhan.SetScale(DarKhanScale, DarKhanScale, DarKhanScale);
    darKhan.SetLevel(DarKhanLevel, false);
    darKhan.MaxLife = (int)(darKhan.MaxLife * DarKhanHealthFactor);
    darKhan.Life = darKhan.MaxLife;
    darKhan.Mana = darKhan.MaxMana;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Dar'Khan falls for the last time at the feet of the woman he betrayed. Her vengeance taken, Sylvanas takes up her bow once more as the Dark Lady, and the Lich King's grip on her begins to slip.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Sylvanas becomes a Dark Ranger. The Banshee's Host can break free of the Lich King through the Rise of the Forsaken, and the Forsaken can research Dark Rangers";

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
