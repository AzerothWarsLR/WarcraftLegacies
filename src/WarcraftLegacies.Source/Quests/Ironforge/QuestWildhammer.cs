using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Ironforge
{
  public sealed class QuestWildhammer : QuestData
  {
    private static readonly int HeroId = FourCC("H028");

    public QuestWildhammer() : base("Wildhammer Alliance",
      "The Wildhammer dwarves roam freely over the peaks of the Hinterlands. An audience with Magni himself might earn their cooperation.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroGriffonWarrior.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendIronforge.LegendMagni, Regions.Aerie_Peak, "Aerie Peak"));
      ResearchId = FourCC("R01C");
    }


    protected override string CompletionPopup =>
      "Magni has spoken with Falstad Wildhammer and secured an alliance with the Wildhammer Clan.";

    protected override string RewardDescription =>
      "You gain control of Aerie Peak and you can train the hero Falstad Wildhammer from the Altar of Fortitude";

    protected override void OnComplete(Faction completingFaction)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in region to Ironforge
      GroupEnumUnitsInRect(tempGroup, Regions.Aerie_Peak.Rect, null);
      while (true)
      {
        unit u = FirstOfGroup(tempGroup);
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) u.Rescue(completingFaction.Player);
        GroupRemoveUnit(tempGroup, u);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
      whichFaction.ModObjectLimit(HeroId, 1);
    }
  }
}