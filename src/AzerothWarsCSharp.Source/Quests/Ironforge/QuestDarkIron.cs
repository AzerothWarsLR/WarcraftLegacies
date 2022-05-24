using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
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
      AddObjective(new ObjectiveLegendInRect(LegendIronforge.LegendMagni, Regions.Shadowforge_gate,
        "Shadowforge"));
      ResearchId = FourCC("R01A");
    }

    protected override string CompletionPopup =>
      "The peace talk were succesful, The Dark Iron will join the Dwarven Empire.";

    protected override string RewardDescription =>
      "You gain control of Shadowforge City and can train the hero Dagran Thaurassian from the Altar of Fortitude";

    protected override void OnComplete(Faction completingFaction)
    {
      group tempGroup = CreateGroup();
      //Transfer all Neutral Passive units in region to Ironforge
      GroupEnumUnitsInRect(tempGroup, Regions.Shadowforge_City.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) u.Rescue(completingFaction.Player);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(HeroId, 1);
    }
  }
}