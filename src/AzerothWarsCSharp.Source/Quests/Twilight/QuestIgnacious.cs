using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestIgnacious : QuestData
  {
    public QuestIgnacious() : base("Gift of the Firelord",
      "Destroying the Dwarf great forge will please the Great Elemental Lord, Ragnaros.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroAvatarOfFlame.blp")
    {
      AddObjective(new ObjectiveLegendDead(LegendIronforge.LegendGreatforge));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0AA"))));
      ResearchId = Constants.UPGRADE_R07Q_QUEST_COMPLETED_GIFT_OF_THE_FIRELORD;
    }

    protected override string CompletionPopup => "The great Ragnaros has ascended one of our shamans.";

    //Todo: specify altar name
    protected override string RewardDescription => "You can summon Ignacious from the Altar";
  }
}