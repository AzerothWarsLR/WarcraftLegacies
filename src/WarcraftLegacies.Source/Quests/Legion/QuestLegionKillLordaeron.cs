using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestLegionKillLordaeron : QuestData
  {
    public QuestLegionKillLordaeron() : base("Token Resistance",
      "The Kingdom of Lordaeron must be eliminated to pave the way for the Legion's arrival.",
      "ReplaceableTextures\\CommandButtons\\BTNTichondrius.blp")
    {
      AddObjective(new ObjectiveCapitalDead(LegendLordaeron.CapitalPalace));
      AddObjective(new ObjectiveCapitalDead(LegendLordaeron.Stratholme));
      AddObjective(new ObjectiveCapitalDead(LegendLordaeron.TyrsHand));
    }

    protected override string CompletionPopup =>
      "The Kingdom of Lordaeron has fallen, eliminating Azeroth's vanguard against the Legion.";

    protected override string RewardDescription => "Tichondrius gains 15 Strength, Agility and Intelligence";

    protected override void OnComplete(Faction completingFaction)
    {
      LegendLegion.LEGEND_TICHONDRIUS.Unit?.DisplayHeroReward(15, 15, 15, 0);
      LegendLegion.LEGEND_TICHONDRIUS.Unit?.AddHeroAttributes(15, 15, 15);
    }
  }
}