using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.TestSource.Setup;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Quests
{
  public sealed class ExampleQuestC : QuestData
  {
    private readonly Power _zerglingPower;
  
    public ExampleQuestC() : base("Free Zergling", "We really need a free Zergling.",
      "ReplaceableTextures\\CommandButtons\\BTNZergling.blp")
    {
      AddQuestItem(new QuestItemAcquireArtifact(ArtifactSetup.Killmaim));
      AddQuestItem(new QuestItemSelfExists());
      _zerglingPower = new DummyPower("Zerglings", "Spawn zerglings constantly.", "Zergling");
    }

    protected override string RewardDescription => "A free Zergling, and destroy Kelen's Dagger of Escape";
    protected override string CompletionPopup => "Congratulations on your free Zergling!";
    protected override string PenaltyDescription => "A hostile Peasant spawns";

    protected override void OnAdd()
    {
      Holder.AddPower(_zerglingPower);
    }

    protected override void OnFail()
    {
      CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), FourCC("hpea"), 0, 0, 0);
    }
  
    protected override void OnComplete()
    {
      CreateUnit(Holder.Player, FourCC("zzrg"), 0, 0, 0);
      Holder.RemovePower(_zerglingPower);
      Holder.Name = "Zerg";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNZergling.blp";

      //ArtifactManager.Destroy(ArtifactSetup.KelensDagger);
    }
  }
}