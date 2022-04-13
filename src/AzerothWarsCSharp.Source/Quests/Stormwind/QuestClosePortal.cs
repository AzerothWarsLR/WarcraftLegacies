using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestClosePortal : QuestData
  {
    public QuestClosePortal() : base("Seal the Dark Portal",
      "The Dark Portal has been a menace to the Kingdom of Stormwind for decades, it is time to end the menace once and for all.",
      "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp")
    {
      AddQuestItem(new QuestItemChannelRect(Regions.ClosePortal, "The Dark Portal", LegendStormwind.LegendKhadgar, 480, 270));
      Global = true;
    }

    protected override string CompletionPopup => "Khadgar has closed the Dark Portal definately";

    protected override string RewardDescription => "Close the Dark Portal from both sides";

    protected override void OnComplete()
    {
      //Todo: uncomment the below
      // RemoveUnit(gg_unit_n036_2719);
      // RemoveUnit(gg_unit_n036_2720);
      // RemoveUnit(gg_unit_n036_1065);
      //
      // RemoveUnit(gg_unit_n036_0778);
      // RemoveUnit(gg_unit_n036_3291);
      // RemoveUnit(gg_unit_n036_3292);
      //
      // RemoveUnit(gg_unit_n05J_3375);
      // RemoveUnit(gg_unit_n05J_3370);
    }
  }
}