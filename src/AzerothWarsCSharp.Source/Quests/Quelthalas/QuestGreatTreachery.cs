using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using AzerothWarsCSharp.Source.Setup.QuestSetup;

using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestGreatTreachery : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R075"); //This research is given when the quest is completed

    public QuestGreatTreachery() : base("The Great Treachery",
      "Kil'jaeden has approached Kael with an offer of power and salvation for his people. Only by accepting will his hunger for magic by satiated.",
      "ReplaceableTextures\\CommandButtons\\BTNFelKaelthas.blp")
    {
      AddObjective(new ObjectiveCastSpell(FourCC("A0IF"), true));
      AddObjective(new ObjectiveLegendLevel(LegendQuelthalas.LegendKael, 6));
      ResearchId = QuestResearchId;
      Global = true;
    }

    protected override string CompletionPopup => "The Blood Elves have joined the Burning Legion";

    protected override string RewardDescription =>
      "Unlock the summon Kil'jaeden quest and join the Burning Legion team";

    protected override void OnComplete(Faction completingFaction)
    {
      QuelthalasQuestSetup.STAY_LOYAL.Progress = QuestProgress.Failed;
      UnitRemoveAbility(LegendQuelthalas.LegendKael.Unit, FourCC("A0IF"));
      UnitRemoveAbility(LegendQuelthalas.LegendKael.Unit, FourCC("A0IK"));
      RemoveUnit(LegendQuelthalas.LegendLorthemar.Unit);
      QuelthalasSetup.FactionQuelthalas.ModObjectLimit(LegendQuelthalas.LegendLorthemar.UnitType, -Faction.UNLIMITED);
      completingFaction.Team = TeamSetup.Legion;
      QuelthalasQuestSetup.SUMMON_KIL.Progress = QuestProgress.Incomplete;
    }
  }
}