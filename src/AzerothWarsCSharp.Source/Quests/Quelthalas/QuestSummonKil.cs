using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestSummonKil : QuestData
  {
    private static readonly int RitualId = FourCC("A0R7");

    private Global()
    {
      return true;
    }

    public QuestSummonKil()
    {
      thistype this = thistype.allocate("The Great Deceiver",
        "The greater demon Kil'jaeden has been scheming for aeons. Will kael finally be the one to summon him && consume Azeroth?",
        "ReplaceableTextures\\CommandButtons\\BTNKiljaedin.blp");
      AddQuestItem(new QuestItemChannelRect(Regions.KaelSunwellChannel, "The Sunwell", LegendQuelthalas.LegendKael, 180.Rect, 270));
    }

    protected override string CompletionPopup => "The greater demon Kil'jaeden has been summoned to Azeroth";

    protected override string RewardDescription => "The hero Kil'jaeden";


    private bool operator

    protected override void OnComplete()
    {
      UnitRemoveAbilityBJ(FourCC("A0R7"), LegendQuelthalas.LegendKael.Unit);
      LEGEND_KILJAEDEN.Spawn(QuelthalasSetup.FactionQuelthalas.Player, GetRectCenterX(Regions.Sunwell),
        GetRectCenterY(gg_rct_Sunwell).Rect, 244);
    }
  }
}