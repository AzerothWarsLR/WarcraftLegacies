using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

using static War3Api.Common; using static War3Api.Blizzard;

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
      AddQuestItem(new QuestItemControlLegend(LegendLordaeron.LegendArthas, false));
      AddQuestItem(new QuestItemLegendLevel(LegendLordaeron.LegendArthas, 12));
      AddQuestItem(new QuestItemResearch(FourCC("R07X"), FourCC("u000")));
      AddQuestItem(new QuestItemLegendInRect(LegendLordaeron.LegendArthas, Regions.LichKing.Rect, "Icecrown Citadel"));
      Global = true;
    }

    protected override string CompletionPopup =>
      "Arthas has ascended the Frozen Throne itself and shattered Ner'zhul's frozen prison. Ner'zhul and Arthas are now joined, body and soul, into one being: the god-like Lich King.";

    protected override string RewardDescription =>
      "Arthas becomes the Lich King, but the Frozen Throne loses its abilities";

    protected override void OnComplete()
    {
      PlayThematicMusicBJ("Sound\\Music\\mp3Music\\LichKingTheme.mp3");
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
      UnitAddItemSafe(LegendLordaeron.LegendArthas.Unit, ArtifactSetup.ArtifactHelmofdomination.Item);
      Holder.Team = TeamSetup.TeamScourge;
      UnitRescue(_utgardeKeep, ScourgeSetup.FactionScourge.Player);
      SetPlayerStateBJ(Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
    }
  }
}