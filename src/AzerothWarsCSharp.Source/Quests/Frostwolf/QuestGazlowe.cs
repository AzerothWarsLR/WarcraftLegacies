using AzerothWarsCSharp.MacroTools.Factions;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestGazlowe : QuestData
  {
    private static readonly int ResearchId = FourCC("R01F");
    private static readonly int HeroId = FourCC("Ntin");

    public QuestGazlowe() : base("Explosive Engineering",
      "The Horde needs engineering skills if (it is to thrive. The Goblins of Kezan could provide such expertise.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n04Z"))));
    }


    protected override string CompletionPopup => "With the Goblin homeland of Kezan now under " + Holder.Name +
                                                 " control, the goblin Gazlowe offers his services as an expert engineer, upgrading your Shredders with new weaponry.";

    protected override string RewardDescription =>
      "You can summon Gazlowe from the Altar of Storms, && Shredders learn to cast Pocket Factory, Saw Bombardment, && Emergency Repairs";

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(HeroId, 1);
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}