using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestClosePortal : QuestData
  {
    private Global()
    {
      return true;
    }

    public QuestClosePortal() : base("Seal the Dark Portal",
      "The Dark Portal has been a menace to the Kingdom of Stormwind for decades, it is time to end the menace once && for all.",
      "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp")
    {
      AddQuestItem(new QuestItemChannelRect(Regions.ClosePortal, "The Dark Portal", LEGEND_KHADGAR, 480.Rect, 270));
      ;
      ;
    }

    protected override string CompletionPopup => "Khadgar has closed the Dark Portal definately";

    protected override string CompletionDescription => "Close the Dark Portal from both sides";


    bool operator

    protected override void OnComplete()
    {
      RemoveUnit(gg_unit_n036_2719);
      RemoveUnit(gg_unit_n036_2720);
      RemoveUnit(gg_unit_n036_1065);

      RemoveUnit(gg_unit_n036_0778);
      RemoveUnit(gg_unit_n036_3291);
      RemoveUnit(gg_unit_n036_3292);

      RemoveUnit(gg_unit_n05J_3375);
      RemoveUnit(gg_unit_n05J_3370);
    }
  }
}