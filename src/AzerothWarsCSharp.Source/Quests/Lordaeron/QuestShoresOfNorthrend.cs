using AzerothWarsCSharp.MacroTools.Factions;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestShoresOfNorthrend : QuestData
  {
    private static readonly int ResearchId = FourCC("R06F");

    public QuestShoresOfNorthrend() : base("Shores of Northrend", "Mal'ganis' citadel lies somewhere within the arctic wastes of the north. In order to assault the Dreadlord, Arthas must first establish a base camp at the shores of Northrend.", "ReplaceableTextures\\CommandButtons\\BTNHumanTransport.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendLordaeron.LegendArthas, true));
      AddQuestItem(new QuestItemLegendDead(LegendForsaken.LegendScholomance));
      AddQuestItem(new QuestItemResearch(ResearchId, FourCC("hshy")));
    }


    protected override string CompletionPopup =>
      "Crown Prince Arthas, && what remains of his forces, have landed on the shores of Northrend && established a base camp.";

    protected override string RewardDescription =>
      "A new base near Dragonblight in Northrend, && Arthas revives there";

    protected override void OnFail()
    {
      Holder.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    }

    protected override void OnComplete()
    {
      KillNeutralHostileUnitsInRadius(4152, 16521, 2300);
      KillNeutralHostileUnitsInRadius(-2190, 16803, 700);
      if (GetOwningPlayer(LegendLordaeron.LegendArthas.Unit) == Holder.Player)
      {
        ReviveHero(LegendLordaeron.LegendArthas.Unit, 400, 16102, true);
        BlzSetUnitFacingEx(LegendLordaeron.LegendArthas.Unit, 112);
      }

      CreateStructureForced(Holder.Player, FourCC("h01C"), -5133152, 1667969, 4757993 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("nmrk"), 1280, 16064, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hctw"), -640, 16576, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hbar"), -256, 16832, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("halt"), 416, 16416, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hpea"), 8187402, 1686473, 6156587 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hpea"), 6240182, 1672541, 4578159 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hgtw"), -960, 15872, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hdes"), 5826755, 1551292, 43173 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hshy"), 800, 15776, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hcas"), -512, 15744, 4712389 * bj_RADTODEG, 512);
      CreateStructureForced(Holder.Player, FourCC("hbla"), 672, 16928, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hfoo"), 7711509, 1606429, 06401012 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hgtw"), -448, 16128, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hwtw"), 704, 17152, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hhou"), -1088, 16576, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("h035"), -928, 16736, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hfoo"), -1744257, 1663117, 3987584 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hfoo"), -3887579, 1687145, 4113693 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hfoo"), -5615654, 1652154, 602386 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hdes"), 2519047, 1556937, 533097 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hbla"), 800, 16288, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hgtw"), 1472, 16384, 4712389 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("hkni"), 8933604, 1617558, 4130178 * bj_RADTODEG, 256);
      CreateStructureForced(Holder.Player, FourCC("nchp"), -9312155, 1655475, 5458206 * bj_RADTODEG, 256);
      Holder.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}