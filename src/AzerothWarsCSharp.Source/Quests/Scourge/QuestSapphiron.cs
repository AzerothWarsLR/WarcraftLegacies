using AzerothWarsCSharp.MacroTools.Factions;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestSapphiron : QuestData
  {
    private static readonly int SapphironId = FourCC("ubdd");
    private static readonly int SapphironResearch = FourCC("R025");
    
    public QuestSapphiron(unit sapphiron) : base("Sapphiron", "Kill Sapphiron the Blue Dragon to have Kel'Tuzad reanimate her as a Frost Wyrm. Sapphiron can be found in Northrend.", "ReplaceableTextures\\CommandButtons\\BTNFrostWyrm.blp")
    {
      AddQuestItem(new QuestItemKillUnit(sapphiron));
      AddQuestItem(new QuestItemControlLegend(LegendScourge.LegendKelthuzad, false));
    }
    
    protected override string CompletionPopup =>
      "Sapphiron has been slain, and has been reanimated as a mighty Frost Wyrm under the command of the Scourge.";

    protected override string RewardDescription => "The demihero Sapphiron";

    protected override void OnComplete()
    {
      CreateUnit(Holder.Player, SapphironId, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()),
        GetUnitFacing(GetTriggerUnit()));
      SetPlayerTechResearched(Holder.Player, SapphironResearch, 1);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(SapphironResearch, Faction.UNLIMITED);
    }
  }
}