using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common; 

namespace WarcraftLegacies.Source.Quests.Zandalar
{
  public sealed class QuestGundrak : QuestData
  {
    private static readonly int GundrakResearch = FourCC("R02Q");
    private static readonly int WarlordId = FourCC("nftk");
    private static readonly int TrollShrineId = FourCC("o04X");
    
    protected override string CompletionPopup =>
      "Gundrak has fallen. The Drakkari trolls lend their might to the Zandalari.";

    protected override string RewardDescription =>
      $"300 gold and the ability to train {GetObjectName(WarlordId)}s from the {GetObjectName(TrollShrineId)}.";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, GundrakResearch, 1);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 300);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(GundrakResearch, Faction.UNLIMITED);
    }

    public QuestGundrak() : base("The Drakkari Fortress",
      "The Drakkari troll of Gundrak believe their fortress to be impregnable. Capture it to gain their loyalty.",
      "ReplaceableTextures\\CommandButtons\\BTNTerrorTroll.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendNeutral.Gundrak, false));
    }
  }
}