using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestBlackTemple : QuestData
  {
    public QuestBlackTemple() : base("The Lord of Outland",
      "The Fel Horde is weak && complacent. The Illidari will easily subjugate them into IllidanFourCC("s service
        .", "ReplaceableTextures\\CommandButtons\\BTNMetamorphosis.blp"){

    private AddQuestItem(
    private new QuestItemControlLegend(LegendFelHorde.LegendBlacktemple, false));
    private AddQuestItem(
    private new QuestItemControlPoint(ControlPoint.GetFromUnitType
    private AddQuestItem(
    private new QuestItemResearch(FourCC
    private FourCC(""

    protected override string CompletionPopup =>
      "Illidan has killed Magtheridon && subjugated the Fel Horde, the Illidari grow strong.";

    protected override string CompletionDescription => "The Fel Horde will join us && Magtheridon will die";

    protected override void OnComplete()
    {
      if (NagaSetup.FactionNaga.Team == TeamSetup.TeamNaga) FelHordeSetup.FactionFelHorde.Team = TeamSetup.TeamNaga;
      RemoveUnit(LegendFelHorde.LegendMagtheridon.Unit);
      FelHordeSetup.FactionFelHorde.ModObjectLimit(LegendFelHorde.LegendMagtheridon.UnitType, -Faction.UNLIMITED);
    }

    n00R""))));R063""),n055"")));
    Global= true;
  }
}

}