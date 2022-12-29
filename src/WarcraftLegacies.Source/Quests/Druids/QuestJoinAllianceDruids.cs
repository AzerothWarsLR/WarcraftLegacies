using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common; 

namespace WarcraftLegacies.Source.Quests.Druids
{
  public sealed class QuestJoinAllianceDruid : QuestData
  {
    public QuestJoinAllianceDruid() : base("Join the Alliance",
      "With a world ending threat happening, the Alliance has reached to the Night Elves to join them",
      "ReplaceableTextures\\CommandButtons\\BTNalliance.blp")
    {
      AddObjective(new ObjectiveCastSpell(FourCC("A0IG"), true));
    }
    
    protected override string CompletionPopup => "The Druids have joined the Alliance";

    protected override string RewardDescription => "Join the Alliance team";
    
    protected override void OnComplete(Faction completingFaction)
    {
      UnitRemoveAbility(LegendDruids.LegendMalfurion.Unit, FourCC("A0IG"));
      completingFaction.Player?.SetTeam(TeamSetup.Alliance);
    }
  }
}