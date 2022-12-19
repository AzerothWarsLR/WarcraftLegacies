using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Ironforge
{
  public sealed class QuestDunMorogh : QuestData
  {
    public QuestDunMorogh(PreplacedUnitSystem preplacedUnitSystem) : base("Mountain Village",
      "A small troll skirmish is attacking Dun Morogh. Push them back!",
      "ReplaceableTextures\\CommandButtons\\BTNIceTrollShadowPriest.blp")
    {
      AddObjective(new ObjectiveKillUnit(preplacedUnitSystem.GetUnit(FourCC("nith"), Regions.DunmoroghAmbient2.Center))); //Troll
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n014"))));
      AddObjective(new ObjectiveExpire(1435));
      AddObjective(new ObjectiveSelfExists());
      Required = true;
    }

    protected override string CompletionPopup => "The Trolls have been defeated, Dun Morogh will join your cause.";

    protected override string RewardDescription => "Control of all units in Dun Morogh";

    private static void GrantDunMorogh(player whichPlayer)
    {
      var tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in DunMorogh
      GroupEnumUnitsInRect(tempGroup, Regions.DunmoroghAmbient2.Rect, null);
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
      GrantDunMorogh(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      GrantDunMorogh(completingFaction.Player);
    }
  }
}