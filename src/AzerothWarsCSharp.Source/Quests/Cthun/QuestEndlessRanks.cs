using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Cthun
{
  public sealed class QuestEndlessRanks : QuestData
  {
    protected override string CompletionPopup => "The Gates of Ahn'qiraj can now be opened";

    protected override string RewardDescription => "Enable the Gates of Ahn'qiraj to be opened";
    
    public QuestEndlessRanks() : base("The Endless Army",
      "Before opening the Gates of Ahn'qiraj, the armies of C'thunn need to darken the sky and shake the earth itself.",
      "ReplaceableTextures\\CommandButtons\\BTNSwarm.blp")
    {
      AddObjective(new ObjectiveTrain(FourCC("n06I"), FourCC("o00R"), 24));
      AddObjective(new ObjectiveTrain(FourCC("u013"), FourCC("o00R"), 6));
      AddObjective(new ObjectiveTrain(FourCC("o02N"), FourCC("u01H"), 24));
      AddObjective(new ObjectiveTrain(FourCC("n05V"), FourCC("u01G"), 12));
      AddObjective(new ObjectiveTrain(FourCC("n060"), FourCC("u01G"), 12));
      AddObjective(new ObjectiveTrain(FourCC("h01K"), FourCC("u01H"), 8));
      ResearchId = FourCC("R07D");
    }
  }
}