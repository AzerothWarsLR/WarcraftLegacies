using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  /// <summary>
  /// Arthas ascends to become the Lich King.
  /// </summary>
  public sealed class QuestLichKingArthas : QuestData
  {
    private readonly unit _utgardeKeep;
    private readonly Artifact _helmOfDomination;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestLichKingArthas"/> class.
    /// </summary>
    /// <param name="utgardeKeep"></param>
    /// <param name="helmOfDomination"></param>
    public QuestLichKingArthas(unit utgardeKeep, Artifact helmOfDomination) : base("The Ascension",
      "From within the depths of the Frozen Throne, the Lich King Ner'zhul cries out for his champion. Release the Helm of Domination from its confines and merge its power with that of the Scourge's greatest Death Knight.",
      "ReplaceableTextures\\CommandButtons\\BTNRevenant.blp")
    {
      _utgardeKeep = utgardeKeep;
      _helmOfDomination = helmOfDomination;
      AddObjective(new ObjectiveControlLegend(LegendScourge.Arthas, false));
      AddObjective(new ObjectiveLegendLevel(LegendScourge.Arthas, 12));
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R07X_MAKE_ARTHAS_THE_LICH_KING_SCOURGE, FourCC("u000")));
      AddObjective(new ObjectiveLegendInRect(LegendScourge.Arthas, Regions.LichKing, "Icecrown Citadel"));
      Global = true;
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Arthas has ascended the Frozen Throne itself and shattered Ner'zhul's frozen prison. Ner'zhul and Arthas are now joined, body and soul, into one being: the god-like Lich King.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Arthas becomes the Lich King, but the Frozen Throne loses its abilities";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      PlayThematicMusic("Sound\\Music\\mp3Music\\LichKingTheme.mp3");
      
      LegendScourge.LegendLichking.DeathMessage =
        "Icecrown Citadel been razed. Unfortunately, the Lich King has already vacated his unholy throne.";
      LegendScourge.LegendLichking.Hivemind = false;
      LegendScourge.LegendLichking.Unit?
        .RemoveAbility(Constants.ABILITY_A0W8_RECALL_FROZEN_THRONE)
        .RemoveAbility(Constants.ABILITY_A0L3_ANIMATE_DEAD_RED_THE_FROZEN_THRONE)
        .RemoveAbility(Constants.ABILITY_A001_FROST_EXPLOSION_RED_THE_FROZEN_THRONE)
        .SetMaximumMana(0)
        .SetName("Icecrown Citadel");
      
      LegendScourge.Arthas.UnitType = Constants.UNIT_N023_LORD_OF_THE_SCOURGE_SCOURGE;
      LegendScourge.Arthas.PermaDies = true;
      LegendScourge.Arthas.Hivemind = true;
      LegendScourge.Arthas.DeathMessage =
        "The great Lich King has been destroyed. With no central mind to command them, the forces of the Undead have gone rogue.";

      LegendScourge.Arthas.Unit?
        .SetLifePercent(100)
        .SetManaPercent(100)
        .AddItemSafe(_helmOfDomination.Item);
      
      _utgardeKeep.Rescue(ScourgeSetup.Scourge.Player);
    }
  }
}