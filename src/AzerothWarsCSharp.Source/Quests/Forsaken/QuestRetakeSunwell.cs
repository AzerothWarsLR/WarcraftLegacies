using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestRetakeSunwell : QuestData
  {
    public QuestRetakeSunwell()
    {
      thistype this = thistype.allocate("Retaking the Sunwell",
        "Even in undeath, the SunwellFourCC("s energy to the Forsaken banshees
          .Reclaim it to bolster their vitality", "ReplaceableTextures\\CommandButtons\\BTNGhost.blp");
      AddQuestItem(new QuestItemControlLegend(LegendQuelthalas.LegendSunwell, false));
      AddQuestItem(new QuestItemControlLegend(LegendForsaken.LegendNathanos, false));
    }


    protected override string CompletionPopup => "Sylvanas && all the Banshee Hall units gain 500 bonus hit points";

    protected override string CompletionDescription =>
      "Sylvanas && her Banshees will be empowered with 500 additional hitpoints each";

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, FourCC("R07V"), 1);
    }
  }
}