using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Stormwind
{
  public sealed class QuestNethergarde : QuestData
  {
    public QuestNethergarde() : base("Nethergarde relief",
      "The nethergarde fort is holding down the Dark Portal, they will need to be reinforced soon!",
      "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionBarracks.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendStormwind.Varian, Regions.NethergardeUnlock, "Nethergarde"));
      AddObjective(new ObjectiveExpire(1440));
      AddObjective(new ObjectiveSelfExists());
    }

    protected override string CompletionPopup => "Varian has come to relieve the Nethergarde garrison.";

    protected override string RewardDescription => "You gain control of the Nethergarde base";

    private static void GrantNethergarde(player whichPlayer)
    {
      var tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Nethergarde
      GroupEnumUnitsInRect(tempGroup, Regions.NethergardeUnlock.Rect, null);
      var u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) u.Rescue(whichPlayer);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnFail(Faction completingFaction)
    {
      GrantNethergarde(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      GrantNethergarde(completingFaction.Player);
      StormwindSetup.Stormwind.ModObjectLimit(FourCC("h03F"), 1); //Reginald windsor
    }
  }
}