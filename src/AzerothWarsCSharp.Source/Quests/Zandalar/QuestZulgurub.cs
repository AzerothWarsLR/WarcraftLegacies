using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestZulgurub : QuestData
  {
    private static readonly int ZulgurubResearch = FourCC("R02M");
    private static readonly int TrollShrineId = FourCC("o04X");
    private static readonly int RavagerId = FourCC("o021");

    protected override string CompletionPopup =>
      "Zul'gurub has fallen. The Gurubashi trolls lend their might to the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "300 gold and the ability to train " + GetObjectName(RavagerId) + "s from the " +
      GetObjectName(TrollShrineId);

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, ZulgurubResearch, 1);
      this.Holder.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 300);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ZulgurubResearch, Faction.UNLIMITED);
    }

    public QuestZulgurub() : base("Heart of Hakkar",
      "The Gurubashi trolls of Zul'Gurub follow the sacred Heart of Hakkar, hidden within their shrine. Capture it to gain their loyalty.",
      "ReplaceableTextures\\CommandButtons\\BTNTrollRavager.blp")
    {
      AddQuestItem(new ObjectiveControlLegend(LegendNeutral.LegendZulgurub, false));
    }
  }
}