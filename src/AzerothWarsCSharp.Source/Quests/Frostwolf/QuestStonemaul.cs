using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.Extensions;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestStonemaul : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestStonemaul(Rectangle rescueRect) : base("The Chieftain's Challenge",
      "The Ogres of Stonemaul follow the strongest, slay the Chieftain to gain control of the base.",
      "ReplaceableTextures\\CommandButtons\\BTNOneHeadedOgre.blp")
    {
      AddObjective(new ObjectiveKillUnit(PreplacedUnitSystem.GetUnit(FourCC("noga")))); //Korgall
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n022"))));
      AddObjective(new ObjectiveExpire(1505));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R03S");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      Required = true;
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Stonemaul has been liberated, and its military is now free to assist the Frostwolf Clan.";

    protected override string RewardDescription => "Control of all units in Stonemaul and 3000 lumber";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 3000);
    }
  }
}