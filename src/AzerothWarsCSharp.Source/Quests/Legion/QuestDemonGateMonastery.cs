using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestDemonGateMonastery : QuestData
  {
    private static readonly int DemongateId = FourCC("n081");


    private readonly QuestItemKillUnit _questItemKillMonastery;

    public QuestDemonGateMonastery() : base("A Scarlet Rift",
      "The energies surrounding the Scarlet Monastery are extraordinary. Destroy this bastion of light to fabricate a Demon Gate in its place.",
      "ReplaceableTextures\\CommandButtons\\BTNMaskOfDeath.blp")
    {
      _questItemKillMonastery = new QuestItemKillUnit(PreplacedUnitSystem.GetUnit(FourCC("h00T")));
      AddQuestItem(_questItemKillMonastery);
    }

    protected override string CompletionPopup =>
      "The great Scarlet Monastery has fallen, and from its ashes rises an even greater Demon Gate.";

    protected override string RewardDescription => "A new Demon Gate at the MonasteryFourCC(s location";

    protected override void OnComplete()
    {
      CreateUnit(Holder.Player, DemongateId, GetUnitX(_questItemKillMonastery.Target),
        GetUnitY(_questItemKillMonastery.Target), 270);
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