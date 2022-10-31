using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Extensions;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestBoralus : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestBoralus(Rectangle rescueRect) : base("The City at Sea",
      "Proudmoore is stranded at sea. Rejoin Boralus to take control of the city.",
      "ReplaceableTextures\\CommandButtons\\BTNHumanShipyard.blp")
    {
      AddObjective(new ObjectiveResearch(FourCC("R04R"), FourCC("h06I")));
      AddObjective(new ObjectiveUpgrade(FourCC("h062"), FourCC("h062")));
      AddObjective(new ObjectiveExpire(900));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R00L");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }


    protected override string CompletionPopup =>
      "Kul'tiras has joined the war and its military is now free to assist the Alliance.";

    protected override string RewardDescription =>
      "Control of all units in Kul'tiras and enables Katherine Proodmoure to be trained at the altar";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\KultirasTheme.mp3");
    }
  }
}