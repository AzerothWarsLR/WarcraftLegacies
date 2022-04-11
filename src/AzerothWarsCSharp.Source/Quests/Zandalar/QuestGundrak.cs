using AzerothWarsCSharp.MacroTools.Factions;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestGundrak : QuestData
  {
    private static readonly int GundrakResearch = FourCC("R02Q");
    private static readonly int WarlordId = FourCC("nftk");
    private static readonly int TrollShrineId = FourCC("o04X");


    protected override string CompletionPopup =>
      "Gundrak has fallen. The Drakkari trolls lend their might to the " + this.Holder.Team.Name;

    protected override string RewardDescription =>
      $"Control of Gundrak, 300 gold tribute and the ability to train {GetObjectName(WarlordId)}s from the {GetObjectName(TrollShrineId)}.";

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, GundrakResearch, 1);
      AdjustPlayerStateBJ(300, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(GundrakResearch, Faction.UNLIMITED);
    }

    public QuestGundrak() : base("The Drakkari Fortress",
      "The Drakkari troll of Gundrak believe their fortress to be impregnable. Capture it to gain their loyalty.",
      "ReplaceableTextures\\CommandButtons\\BTNTerrorTroll.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendGundrak, false));
    }
  }
}