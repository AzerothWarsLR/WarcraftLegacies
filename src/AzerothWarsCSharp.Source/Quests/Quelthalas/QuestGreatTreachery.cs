using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.QuestSetup;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestGreatTreachery : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R075"); //This research is given when the quest is completed

    public QuestGreatTreachery() : base("The Great Treachery",
      "Kil'jaeden has approached Kael with an offer of power and salvation for his people. Only by accepting will his hunger for magic by satiated.",
      "ReplaceableTextures\\CommandButtons\\BTNFelKaelthas.blp")
    {
      AddQuestItem(new QuestItemCastSpell(FourCC("A0IF"), true));
      AddQuestItem(new QuestItemLegendLevel(LegendQuelthalas.legendKael, 6));
      ResearchId = QuestResearchId;
      Global = true;
    }

    protected override string CompletionPopup => "The Blood Elves have joined the Burning Legion";

    protected override string CompletionDescription =>
      "Unlock the summon Kil'jaeden quest and join the Burning Legion team";

    protected override void OnComplete()
    {
      QuelthalasQuestSetup.STAY_LOYAL.Progress = QuestProgress.Failed;
      UnitRemoveAbilityBJ(FourCC("A0IF"), LegendQuelthalas.legendKael.Unit);
      UnitRemoveAbilityBJ(FourCC("A0IK"), LegendQuelthalas.legendKael.Unit);
      RemoveUnit(LegendQuelthalas.legendLorthemar.Unit);
      QuelthalasSetup.FACTION_QUELTHALAS.ModObjectLimit(LegendQuelthalas.legendLorthemar.UnitType, -Faction.UNLIMITED);
      Holder.Team = TeamSetup.TeamLegion;
      QuelthalasQuestSetup.SUMMON_KIL.Progress = QuestProgress.Incomplete;
    }
  }
}