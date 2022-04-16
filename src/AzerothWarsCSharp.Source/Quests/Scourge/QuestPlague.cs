using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestPlague : QuestData
  {
    public QuestPlague() : base("Plague of Undeath",
      "You can unleash a devastating zombifying plague across the lands of Lordaeron. Once it's started, you can type -off to deactivate Cauldron Zombie spawns. Type -end to stop citizens from turning into zombies.",
      "ReplaceableTextures\\CommandButtons\\BTNPlagueBarrel.blp")
    {
      AddQuestItem(new QuestItemEitherOf(
        new QuestItemResearch(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, FourCC("u000")),
        new QuestItemTime(960)));
      AddQuestItem(new QuestItemTime(660));
      Global = true;
    }

    protected override string CompletionPopup =>
      "The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies.";

    protected override string RewardDescription => "A plague is unleashed upon the lands of Lordaeron";

    protected override void OnComplete()
    {
      Holder.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(FourCC("u000"), Faction.UNLIMITED);
    }
  }
}