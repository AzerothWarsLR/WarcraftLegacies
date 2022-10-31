//When Black Temple is destroyed, Stormwind can train Khadgar.

using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Stormwind
{
  public sealed class QuestKhadgar : QuestData
  {
    private static readonly int HeroId = FourCC("H05Y");

    public QuestKhadgar() : base("Keeper of the Eternal Watch",
      "At the end of the Second War, Khadgar remained in Draenor to seal the Dark Portal, effectively ending the conflict. He has been stranded deep in Outland ever since.",
      "ReplaceableTextures\\CommandButtons\\BTNMageWC2blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendFelHorde.LegendBlacktemple, false));
      ResearchId = FourCC("R016");
      ;
      ;
    }


    protected override string CompletionPopup =>
      "Khadgar has been freed from his confines under the Black Temple, and he is now free to serve the Kingdom of Stormwind.";

    protected override string RewardDescription => "You can summon Khadgar from the Altar of Kings";

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(HeroId, 1);
    }
  }
}