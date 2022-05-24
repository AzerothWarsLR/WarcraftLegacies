using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestJoinAllianceDruid : QuestData
  {
    public QuestJoinAllianceDruid() : base("Join the Alliance",
      "With a world ending threat happening, the Alliance has reached to the Night Elves to join them",
      "ReplaceableTextures\\CommandButtons\\BTNalliance.blp")
    {
      AddQuestItem(new ObjectiveCastSpell(FourCC("A0IG"), true));
    }
    
    protected override string CompletionPopup => "The Druids have joined the Alliance";

    protected override string RewardDescription => "Join the Alliance team";
    
    protected override void OnComplete()
    {
      UnitRemoveAbility(LegendDruids.LegendMalfurion.Unit, FourCC("A0IG"));
      Holder.Team = TeamSetup.Alliance;
    }
  }
}