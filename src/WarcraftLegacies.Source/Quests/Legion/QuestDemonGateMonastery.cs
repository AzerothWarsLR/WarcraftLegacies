using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestDemonGateMonastery : QuestData
  {
    private static readonly int DemongateId = FourCC("n081");


    private readonly ObjectiveKillUnit _objectiveKillMonastery;

    public QuestDemonGateMonastery(PreplacedUnitSystem preplacedUnitSystem) : base("A Scarlet Rift",
      "The energies surrounding the Scarlet Monastery are extraordinary. Destroy this bastion of light to fabricate a Demon Gate in its place.",
      "ReplaceableTextures\\CommandButtons\\BTNMaskOfDeath.blp")
    {
      _objectiveKillMonastery = new ObjectiveKillUnit(preplacedUnitSystem.GetUnit(FourCC("h00T")));
      AddObjective(_objectiveKillMonastery);
    }

    protected override string CompletionPopup =>
      "The great Scarlet Monastery has fallen, and from its ashes rises an even greater Demon Gate.";

    protected override string RewardDescription => "A new Demon Gate at the Monastery's location";

    protected override void OnComplete(Faction completingFaction)
    {
      CreateUnit(completingFaction.Player, DemongateId, GetUnitX(_objectiveKillMonastery.Target),
        GetUnitY(_objectiveKillMonastery.Target), 270);
      var monastery = Regions.ScarletMonastery.Rect;
      SetDoodadAnimationRect(monastery, FourCC("YObb"), "hide", false);
      SetDoodadAnimationRect(monastery, FourCC("ZSab"), "hide", false);
      SetDoodadAnimationRect(monastery, FourCC("YOsw"), "hide", false);
      SetDoodadAnimationRect(monastery, FourCC("LOsm"), "show", false);
      SetDoodadAnimationRect(monastery, FourCC("YOlp"), "hide", false);
      SetDoodadAnimationRect(monastery, FourCC("ZCv2"), "hide", false);
      SetDoodadAnimationRect(monastery, FourCC("ZCv1"), "hide", false);
      SetDoodadAnimationRect(monastery, FourCC("ZCv1"), "show", false);
    }
  }
}