using AzerothWarsCSharp.MacroTools.ControlPointSystem;
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
      AddObjective(new ObjectiveControlLegend(LegendFelHorde.LegendBlacktemple, false));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00R"))));
      AddObjective(new ObjectiveResearch(FourCC("R063"), FourCC("n055")));
    }

    protected override string CompletionPopup =>
      "Illidan has killed Magtheridon and subjugated the Fel Horde, the Illidari grow strong.";

    protected override string RewardDescription => "The Fel Horde will join us and Magtheridon will die";

    protected override void OnComplete(Faction completingFaction)
    {
      if (NagaSetup.FactionNaga.Player?.GetTeam() == TeamSetup.Naga) FelHordeSetup.FactionFelHorde.Player?.SetTeam(TeamSetup.Naga);
      RemoveUnit(LegendFelHorde.LegendMagtheridon.Unit);
      FelHordeSetup.FactionFelHorde.ModObjectLimit(LegendFelHorde.LegendMagtheridon.UnitType, -Faction.UNLIMITED);
    }
  }
}