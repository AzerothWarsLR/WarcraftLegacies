using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  public sealed class QuestMurmur : QuestData
  {
    public QuestMurmur(PreplacedUnitSystem preplacedUnitSystem) : base("The Shadow Labyrinth",
      "The Void Lord Murmur is guarding the Shadow Labyrinth, if we defeat him, the Naga Lord Naj'entus will join us",
      "ReplaceableTextures\\CommandButtons\\BTNLordNaj.blp")
    {
      AddObjective(new ObjectiveUnitIsDead(preplacedUnitSystem.GetUnit(Constants.UNIT_N03T_MURMUR_MINIBOSS)));
      ResearchId = Constants.UPGRADE_R08W_QUEST_COMPLETED_THE_SHADOW_LABYRINTH;
    }

    protected override string CompletionPopup =>
      "Murmur has been defeated";

    protected override string RewardDescription => "The hero Naj'entus will join you!";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}