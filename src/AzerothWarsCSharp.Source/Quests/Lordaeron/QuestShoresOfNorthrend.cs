using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; 

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
      "Crown Prince Arthas, and what remains of his forces, have landed on the shores of Northrend and established a base camp.";

    protected override string RewardDescription =>
      "A new base near Dragonblight in Northrend, and Arthas revives there";

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

      CreateStructureForced(Holder.Player, FourCC("h01C"), -5133152, 1667969, (float)(4757993 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("nmrk"), 1280, 16064, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hctw"), -640, 16576, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hbar"), -256, 16832, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("halt"), 416, 16416, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hpea"), 8187402, 1686473, (float)(6156587 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hpea"), 6240182, 1672541, (float)(4578159 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hgtw"), -960, 15872, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hdes"), 5826755, 1551292, (float)(43173 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hshy"), 800, 15776, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hcas"), -512, 15744, (float)(4712389 * MathEx.DEG_TO_RAD), 512);
      CreateStructureForced(Holder.Player, FourCC("hbla"), 672, 16928, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hfoo"), 7711509, 1606429, (float)(06401012 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hgtw"), -448, 16128, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hwtw"), 704, 17152, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hhou"), -1088, 16576, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("h035"), -928, 16736, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hfoo"), -1744257, 1663117, (float)(3987584 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hfoo"), -3887579, 1687145, (float)(4113693 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hfoo"), -5615654, 1652154, (float)(602386 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hdes"), 2519047, 1556937, (float)(533097 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hbla"), 800, 16288, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hgtw"), 1472, 16384, (float)(4712389 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("hkni"), 8933604, 1617558, (float)(4130178 * MathEx.DEG_TO_RAD), 256);
      CreateStructureForced(Holder.Player, FourCC("nchp"), -9312155, 1655475, (float)(5458206 * MathEx.DEG_TO_RAD), 256);
      Holder.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}