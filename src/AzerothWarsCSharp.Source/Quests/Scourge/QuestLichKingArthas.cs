using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestLichKingArthas : QuestData
  {
    private readonly unit _utgardeKeep;

    public QuestLichKingArthas(unit utgardeKeep) : base("The Ascension",
      "From within the depths of the Frozen Throne, the Lich King Ner'zhul cries out for his champion. Release the Helm of Domination from its confines and merge its power with that of the Scourge's greatest Death Knight.",
      "ReplaceableTextures\\CommandButtons\\BTNRevenant.blp")
    {
      _utgardeKeep = utgardeKeep;
      AddObjective(new ObjectiveControlLegend(LegendLordaeron.LegendArthas, false));
      AddObjective(new ObjectiveLegendLevel(LegendLordaeron.LegendArthas, 12));
      AddObjective(new ObjectiveResearch(FourCC("R07X"), FourCC("u000")));
      AddObjective(new ObjectiveLegendInRect(LegendLordaeron.LegendArthas, Regions.LichKing, "Icecrown Citadel"));
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
      LegendScourge.LegendLichking.PermaDies = false;
      LegendScourge.LegendLichking.Hivemind = false;
      UnitRemoveAbility(LegendScourge.LegendLichking.Unit, FourCC("A0W8"));
      UnitRemoveAbility(LegendScourge.LegendLichking.Unit, FourCC("A0L3"));
      UnitRemoveAbility(LegendScourge.LegendLichking.Unit, FourCC("A002"));
      UnitRemoveAbility(LegendScourge.LegendLichking.Unit, FourCC("A001"));
      BlzSetUnitMaxMana(LegendScourge.LegendLichking.Unit, 0);
      BlzSetUnitName(LegendScourge.LegendLichking.Unit, "Icecrown Citadel");
      LegendLordaeron.LegendArthas.UnitType = FourCC("N023");
      LegendLordaeron.LegendArthas.PermaDies = true;
      LegendLordaeron.LegendArthas.Hivemind = true;
      LegendLordaeron.LegendArthas.DeathMessage =
        "The great Lich King has been destroyed. With no central mind to command them, the forces of the Undead have gone rogue.";
      SetUnitState(LegendLordaeron.LegendArthas.Unit, UNIT_STATE_LIFE,
        GetUnitState(LegendLordaeron.LegendArthas.Unit, UNIT_STATE_MAX_LIFE));
      SetUnitState(LegendLordaeron.LegendArthas.Unit, UNIT_STATE_MANA,
        GetUnitState(LegendLordaeron.LegendArthas.Unit, UNIT_STATE_MAX_MANA));
      LegendLordaeron.LegendArthas.Unit.AddItemSafe(ArtifactSetup.ArtifactHelmofdomination.Item);
      completingFaction.Player?.SetTeam(TeamSetup.Scourge);
      _utgardeKeep.Rescue(ScourgeSetup.FactionScourge.Player);
      SetPlayerState(completingFaction.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
    }
  }
}