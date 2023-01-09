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
  public sealed class QuestLichKingArthas : QuestData
  {
    private readonly unit _utgardeKeep;
    private readonly Artifact _helmOfDomination;

    public QuestLichKingArthas(unit utgardeKeep, Artifact helmOfDomination) : base("The Ascension",
      "From within the depths of the Frozen Throne, the Lich King Ner'zhul cries out for his champion. Release the Helm of Domination from its confines and merge its power with that of the Scourge's greatest Death Knight.",
      "ReplaceableTextures\\CommandButtons\\BTNRevenant.blp")
    {
      _utgardeKeep = utgardeKeep;
      _helmOfDomination = helmOfDomination;
      AddObjective(new ObjectiveControlLegend(LegendLordaeron.Arthas, false));
      AddObjective(new ObjectiveLegendLevel(LegendLordaeron.Arthas, 12));
      AddObjective(new ObjectiveResearch(FourCC("R07X"), FourCC("u000")));
      AddObjective(new ObjectiveLegendInRect(LegendLordaeron.Arthas, Regions.LichKing, "Icecrown Citadel"));
      Global = true;
      Required = true;
    }

    protected override string CompletionPopup =>
      "Arthas has ascended the Frozen Throne itself and shattered Ner'zhul's frozen prison. Ner'zhul and Arthas are now joined, body and soul, into one being: the god-like Lich King.";

    protected override string RewardDescription =>
      "Arthas becomes the Lich King, but the Frozen Throne loses its abilities";

    protected override void OnComplete(Faction completingFaction)
    {
      PlayThematicMusic("Sound\\Music\\mp3Music\\LichKingTheme.mp3");
      LegendScourge.LegendLichking.DeathMessage =
        "Icecrown Citadel been razed. Unfortunately, the Lich King has already vacated his unholy throne.";
      LegendScourge.LegendLichking.Hivemind = false;
      UnitRemoveAbility(LegendScourge.LegendLichking.Unit, FourCC("A0W8"));
      UnitRemoveAbility(LegendScourge.LegendLichking.Unit, FourCC("A0L3"));
      UnitRemoveAbility(LegendScourge.LegendLichking.Unit, FourCC("A002"));
      UnitRemoveAbility(LegendScourge.LegendLichking.Unit, FourCC("A001"));
      BlzSetUnitMaxMana(LegendScourge.LegendLichking.Unit, 0);
      BlzSetUnitName(LegendScourge.LegendLichking.Unit, "Icecrown Citadel");
      LegendLordaeron.Arthas.UnitType = FourCC("N023");
      LegendLordaeron.Arthas.PermaDies = true;
      LegendLordaeron.Arthas.Hivemind = true;
      LegendLordaeron.Arthas.DeathMessage =
        "The great Lich King has been destroyed. With no central mind to command them, the forces of the Undead have gone rogue.";
      SetUnitState(LegendLordaeron.Arthas.Unit, UNIT_STATE_LIFE,
        GetUnitState(LegendLordaeron.Arthas.Unit, UNIT_STATE_MAX_LIFE));
      SetUnitState(LegendLordaeron.Arthas.Unit, UNIT_STATE_MANA,
        GetUnitState(LegendLordaeron.Arthas.Unit, UNIT_STATE_MAX_MANA));
      LegendLordaeron.Arthas.Unit?.AddItemSafe(_helmOfDomination.Item);
      _utgardeKeep.Rescue(ScourgeSetup.Scourge.Player);
      SetPlayerState(completingFaction.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
    }
  }
}