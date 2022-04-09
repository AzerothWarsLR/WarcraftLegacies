using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestLiberateLordaeron : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R07P"); //This research is given when the quest is completed


    public QuestLiberateLordaeron() : base("Liberation of Lordaeron",
      "The lands of Lordaeron are overrun by corruption. Everything must be purged!",
      "ReplaceableTextures\\CommandButtons\\BTNNorthrendCastle.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendScarlet.LegendBrigitte, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01F"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n03P"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01H"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01M"))));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QuestResearchId;
      ;
      ;
    }


    protected override string CompletionPopup => "The lands of Lordaeron have been purged from Undeath && Corruption";

    protected override string RewardDescription =>
      "Enable to train Commander Goodchild && Isilien, Unlock New Hearthglen in Northrend && the Scarlet Harbor";

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.ScarletHarbor.Rect, Holder.Player);
      KillNeutralHostileUnitsInRadius(4152, 16521, 2300);
      KillNeutralHostileUnitsInRadius(-2190, 16803, 700);
      CreateStructureForced(Holder.Player, FourCC("h08J"), -5133152, 1667969, 4757993 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h086"), 1280, 16064, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h087"), -640, 16576, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h081"), -256, 16832, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h080"), 416, 16416, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hpea"), 8187402, 1686473, 6156587 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hpea"), 6240182, 1672541, 4578159 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h085"), -960, 15872, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hdes"), 5826755, 1551292, 43173 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hshy"), 800, 15776, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h07Z"), -512, 15744, 4712389 * bj_RADTODEG, 512);
      CreateStructureForced(Holder.Player, FourCC("h06G"), 672, 16928, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h08I"), 7711509, 1606429, 06401012 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h085"), -448, 16128, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h085"), 704, 17152, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h088"), -1088, 16576, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h083"), -928, 16736, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h08I"), -1744257, 1663117, 3987584 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h08I"), -3887579, 1687145, 4113693 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h08I"), -5615654, 1652154, 602386 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hdes"), 2519047, 1556937, 533097 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h097"), 800, 16288, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h085"), 1472, 16384, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h08L"), 8933604, 1617558, 4130178 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("no68"), -9312155, 1655475, 5458206 * bj_RADTODEG, 256);
    }
  }
}