using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestThelsamar : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestThelsamar(Rectangle rescueRect) : base("Murloc Menace",
      "A vile group of Murloc is terrorizing Thelsamar. Destroy them!",
      "ReplaceableTextures\\CommandButtons\\BTNMurlocNightCrawler.blp")
    {
      AddObjective(new ObjectiveKillUnit(PreplacedUnitSystem.GetUnit(FourCC("N089")))); //Murloc
      AddObjective(new ObjectiveExpire(1435));
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup => "The Murlocs have been defeated, Thelsamar will join your cause.";

    protected override string RewardDescription => "Control of all units in Thelsamar";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}