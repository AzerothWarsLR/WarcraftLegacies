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
    private readonly int _acceptSpell;
    private readonly int _refuseSpell;
    private readonly ObjectiveEitherOf _choice;
    
    public QuestGreatTreachery(int acceptSpell, int refuseSpell) : base("The Great Treachery",
      "Kil'jaeden has approached Kael with an offer of power and salvation for his people. Only by accepting will his hunger for magic by satiated.",
      "ReplaceableTextures\\CommandButtons\\BTNFelKaelthas.blp")
    {
      _acceptSpell = acceptSpell;
      _refuseSpell = refuseSpell;
      _choice = new ObjectiveEitherOf(new ObjectiveCastSpell(acceptSpell, true),
        new ObjectiveCastSpell(refuseSpell, true));
      AddObjective(_choice);
      AddObjective(new ObjectiveLegendLevel(LegendQuelthalas.LegendKael, 6));
      ResearchId = Constants.UPGRADE_R075_QUEST_COMPLETED_THE_GREAT_TREACHERY;
      Global = true;
      Required = true;
    }

    protected override string CompletionPopup =>
      _choice.ObjectiveA.Progress == QuestProgress.Complete
        ? "The Blood Elves have joined the Burning Legion" : "The Blood Elves stay loyal to Illidan";

    protected override string RewardDescription => "If you accept, join the Burning Legion team and gain the ability to summon Kil'jaeden. If you refuse, stay allied to Illidan.";

    protected override void OnComplete(Faction completingFaction)
    {
      if (_choice.ObjectiveA.Progress == QuestProgress.Complete)
      {
        RemoveUnit(LegendQuelthalas.LegendLorthemar.Unit);
        completingFaction.ModObjectLimit(LegendQuelthalas.LegendLorthemar.UnitType, -Faction.UNLIMITED);
        completingFaction.Player?.SetTeam(TeamSetup.Legion);
        var summonKiljaedenQuest = new QuestSummonKil();
        completingFaction.AddQuest(summonKiljaedenQuest);
        summonKiljaedenQuest.DisplayDiscovered(completingFaction);
      }
      UnitRemoveAbility(LegendQuelthalas.LegendKael.Unit, _acceptSpell);
      UnitRemoveAbility(LegendQuelthalas.LegendKael.Unit, _refuseSpell);
    }
  }
}