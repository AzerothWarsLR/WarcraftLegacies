using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestSummonKil : QuestData
  {
    public QuestSummonKil() : base("The Great Deceiver",
      "The greater demon Kil'jaeden has been scheming for aeons. Will Kael finally be the one to summon him and consume Azeroth?",
      "ReplaceableTextures\\CommandButtons\\BTNKiljaedin.blp")
    {
      AddQuestItem(new QuestItemChannelRect(Regions.KaelSunwellChannel, "The Sunwell", LegendQuelthalas.LegendKael,
        180, 270));
      Global = true;
    }

    protected override string CompletionPopup => "The greater demon Kil'jaeden has been summoned to Azeroth";

    protected override string RewardDescription => "The hero Kil'jaeden";
    
    protected override void OnComplete()
    {
      UnitRemoveAbilityBJ(FourCC("A0R7"), LegendQuelthalas.LegendKael.Unit);
      LegendQuelthalas.LegendKiljaeden.Spawn(QuelthalasSetup.FactionQuelthalas.Player, Regions.Sunwell.Center.X,
        Regions.Sunwell.Center.Y, 244);
    }
  }
}