using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestDarkIron : QuestData
  {
    private static readonly int HeroId = FourCC("H03G");

    public QuestDarkIron() : base("Dark Iron Alliance",
      "The Dark Iron dwarves are renegades. Bring Magni to their capital to open negotiations for an alliance.",
      "ReplaceableTextures\\CommandButtons\\BTNRPGDarkIron.blp")
    {
      AddQuestItem(new QuestItemLegendInRect(LegendIronforge.LegendMagni, Regions.Shadowforge_gate.Rect,
        "Shadowforge"));
      ResearchId = FourCC("R01A");
    }

    protected override string CompletionPopup =>
      "The peace talk were succesful, The Dark Iron will join the Dwarven Empire.";

    protected override string RewardDescription =>
      "You gain control of Shadowforge City && can train the hero Dagran Thaurassian from the Altar of Fortitude";

    protected override void OnComplete()
    {
      group tempGroup = CreateGroup();
      //Transfer all Neutral Passive units in region to Ironforge
      GroupEnumUnitsInRect(tempGroup, Regions.Shadowforge_City.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) UnitRescue(u, Holder.Player);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(HeroId, 1);
    }
  }
}