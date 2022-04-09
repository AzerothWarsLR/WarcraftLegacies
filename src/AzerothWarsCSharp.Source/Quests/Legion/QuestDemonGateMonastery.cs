using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

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
      _questItemKillMonastery = new QuestItemKillUnit(PreplacedUnitSystem.GetUnitByUnitType(FourCC("h00T")));
      AddQuestItem(_questItemKillMonastery);
    }

    protected override string CompletionPopup =>
      "The great Scarlet Monastery has fallen, && from its ashes rises an even greater Demon Gate.";

    protected override string RewardDescription => "A new Demon Gate at the MonasteryFourCC(s location";

    protected override void OnComplete()
    {
      CreateUnit(Holder.Player, DemongateId, GetUnitX(_questItemKillMonastery.Target),
        GetUnitY(_questItemKillMonastery.Target), 270);
      var monastery = Regions.ScarletMonastery.Rect;
      SetDoodadAnimationRectBJ("hide", FourCC("YObb"), monastery);
      SetDoodadAnimationRectBJ("hide", FourCC("ZSab"), monastery);
      SetDoodadAnimationRectBJ("hide", FourCC("YOsw"), monastery);
      SetDoodadAnimationRectBJ("show", FourCC("LOsm"), monastery);
      SetDoodadAnimationRectBJ("hide", FourCC("YOlp"), monastery);
      SetDoodadAnimationRectBJ("hide", FourCC("ZCv2"), monastery);
      SetDoodadAnimationRectBJ("hide", FourCC("ZCv1"), monastery);
      SetDoodadAnimationRectBJ("show", FourCC("ZCv1"), monastery);
    }
  }
}