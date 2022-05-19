using System;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestSummonLegion : QuestData
  {
    private static readonly int RitualId = FourCC("A00J");

    public QuestSummonLegion() : base("Under the Burning Sky",
      "The greater forces of the Burning Legion lie in wait in the vast expanse of the Twisting Nether. Use the Book of Medivh to tear open a hole in space-time, and visit the full might of the Legion upon Azeroth.",
      "ReplaceableTextures\\CommandButtons\\BTNArchimonde.blp")
    {
      AddQuestItem(new QuestItemCastSpell(RitualId, false));
      ResearchId = FourCC("R04B");
      Global = true;
    }

    protected override string CompletionPopup => "Tremble, mortals, and despair. Doom has come to this world.";

    protected override string RewardDescription =>
      "The hero Archimonde, control of all units in the Twisting Nether, and learn to train Greater Demons";


    protected override void OnAdd()
    {
      if (Holder.UndefeatedResearch == 0)
        throw new Exception(Holder.Name + " has no presence research. QuestSummonLegion won't work.");
    }
  }
}