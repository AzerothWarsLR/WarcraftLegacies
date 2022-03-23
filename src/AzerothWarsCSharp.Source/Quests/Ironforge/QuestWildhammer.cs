using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestWildhammer : QuestData
  {
    private static readonly int HeroId = FourCC("H028");
    private static readonly int ResearchId = FourCC("R01C");

    public QuestWildhammer() : base("Wildhammer Alliance",
      "The Wildhammer dwarves roam freely over the peaks of the Hinterlands. An audience with Magni himself might earn their cooperation.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroGriffonWarrior.blp")
    {
      AddQuestItem(new QuestItemLegendInRect(LEGEND_MAGNI, Regions.AeriePeak.Rect, "Aerie Peak"));
      ;
      ;
    }


    protected override string CompletionPopup =>
      "Magni has spoken with Falstad Wildhammer && secured an alliance with the Wildhammer Clan.";

    protected override string CompletionDescription =>
      "You gain control of Aerie Peak && you can train the hero Falstad Wildhammer from the Altar of Fortitude";

    protected override void OnComplete()
    {
      group tempGroup = CreateGroup();
      unit u;


      //Transfer all Neutral Passive units in region to Ironforge
      GroupEnumUnitsInRect(tempGroup, Regions.AeriePeak.Rect, null);

      while (true)
      {
        u = FirstOfGroup(tempGroup);
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) UnitRescue(u, Holder.Player);
        GroupRemoveUnit(tempGroup, u);
      }

      DestroyGroup(tempGroup);
      tempGroup = null;
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, UNLIMITED);
      Holder.ModObjectLimit(HeroId, 1);
    }
  }
}