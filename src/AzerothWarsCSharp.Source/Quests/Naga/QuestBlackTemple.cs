using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestBlackTemple : QuestData
  {
    public QuestBlackTemple() : base("The Lord of Outland",
      "The Fel Horde is weak and complacent. The Illidari will easily subjugate them into Illidan's service.",
      "ReplaceableTextures\\CommandButtons\\BTNMetamorphosis.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendFelHorde.LegendBlacktemple, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00R"))));
      AddQuestItem(new QuestItemResearch(FourCC("R063"), FourCC("n055")));
    }
    
    protected override string CompletionPopup =>
      "Illidan has killed Magtheridon && subjugated the Fel Horde, the Illidari grow strong.";

    protected override string RewardDescription => "The Fel Horde will join us and Magtheridon will die";

    protected override void OnComplete()
    {
      if (NagaSetup.FactionNaga.Team == TeamSetup.TeamNaga) FelHordeSetup.FactionFelHorde.Team = TeamSetup.TeamNaga;
      RemoveUnit(LegendFelHorde.LegendMagtheridon.Unit);
      FelHordeSetup.FactionFelHorde.ModObjectLimit(LegendFelHorde.LegendMagtheridon.UnitType, -Faction.UNLIMITED);
    }
  }
}