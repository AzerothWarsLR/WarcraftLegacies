using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestWarsongHold : QuestData
  {
    private static readonly int ResearchId = FourCC("R06G");
    private static readonly int AbilityId = FourCC("A0DZ");

    public QuestWarsongHold() : base("Warsong Hold",
      "The far-off land of Northrend is the new home of the traitor shaman Ner'zhul. The Warsong must land its forces on its shores in order to end the existential threat he now represents.",
      "ReplaceableTextures\\CommandButtons\\BTNTuskaarBrown.blp")
    {
      AddQuestItem(new QuestItemResearch(ResearchId, FourCC("o02T")));
    }

    protected override string CompletionPopup =>
      "The Warsong Clan has sail for the icy shores of Northrend and up a formidable encampment at Borean Tundra.";

    protected override string RewardDescription => "A new base at Borean Tundra in Northrend";

    protected override void OnComplete()
    {
      unit boreanTundra = ControlPointManager.GetFromUnitType(FourCC("n00G")).Unit;
      KillNeutralHostileUnitsInRadius(GetUnitX(boreanTundra), GetUnitY(boreanTundra), 2300);
      //Spawn the base
      SetUnitOwner(boreanTundra, Holder.Player, true);
      unit warsongHold = CreateStructureForced(Holder.Player, FourCC("o02S"), -7648, 15456, 270, 192);
      BlzSetUnitName(warsongHold, "Warsong Hold");
      BlzSetUnitMaxHP(warsongHold, 4000);
      SetUnitLifePercentBJ(warsongHold, 100);
      UnitAddAbility(warsongHold, AbilityId);
      CreateStructureForced(Holder.Player, FourCC("n03E"), -7296, 15680, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o01T"), -7456, 15008, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o028"), -7808, 16512, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o028"), -7296, 16000, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o028"), -7424, 16192, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o028"), -6656, 15616, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o028"), -6912, 15744, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("n08E"), -829943, 1611051, 1850517 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o02Q"), -8512, 15936, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("n08E"), -85136, 1617106, 1126743 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o01S"), -8192, 16576, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o02M"), -8048254, 1642775, -07628738 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o02M"), -8065816, 1578813, -008624744 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o028"), -7936, 16768, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o02T"), -6752, 14880, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("odes"), -863319, 1501282, -1101598 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o020"), -6976, 15552, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("n03E"), -8064, 15360, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("n03E"), -8320, 16000, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o02M"), -7086232, 1574921, 1348478 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("n03E"), -7808, 16128, 4712389 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("orai"), -7319426, 1513472, 0467489 * bj_RADTODEG, 128);
      CreateStructureForced(Holder.Player, FourCC("o02T"), -8672, 15328, 4712389 * bj_RADTODEG, 128);
      Holder.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}