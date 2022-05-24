using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestStratholme : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestStratholme(Rectangle rescueRect) : base("Blackrock and Roll",
      "The Blackrock clan has taken over Alterac, they must be eliminated for the safety of Lordaeron",
      "ReplaceableTextures\\CommandButtons\\BTNChaosBlademaster.blp")
    {
      AddObjective(new ObjectiveKillUnit(PreplacedUnitSystem.GetUnit(FourCC("o00B")))); //Jubei
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n019"))));
      AddObjective(new ObjectiveUpgrade(FourCC("hcas"), FourCC("htow")));
      AddObjective(new ObjectiveExpire(1470));
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Stratholme has been liberated, and its military is now free to assist the Kingdom of Lordaeron.";

    protected override string RewardDescription => "Control of all units in Stratholme";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      LegendLordaeron.LegendArthas.AddUnitDependency(LegendLordaeron.LegendStratholme.Unit);
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      LegendLordaeron.LegendArthas.AddUnitDependency(LegendLordaeron.LegendStratholme.Unit);
    }
  }
}