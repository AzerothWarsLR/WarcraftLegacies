using System.Collections.Generic;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  public sealed class QuestThunderBluff : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestThunderBluff(PreplacedUnitSystem preplacedUnitSystem, rect rescueRect) : base("The Long March",
      "The Tauren have been wandering for too long. The plains of Mulgore would offer respite from this endless journey.",
      "ReplaceableTextures\\CommandButtons\\BTNCentaurKhan.blp")
    {
      AddObjective(new ObjectiveUnitIsDead(preplacedUnitSystem.GetUnit(FourCC("ncnk"), Regions.ThunderBluff.Center)));
      AddObjective(new ObjectiveAnyUnitInRect(Regions.ThunderBluff, "Thunder Bluff", true));
      AddObjective(new ObjectiveExpire(1455));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R05I");

      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      Required = true;
    }

    //todo: bad flavour
    protected override string CompletionPopup => "The long march of the Tauren clans has ended, and they have joined forces with the Horde.";

    protected override string RewardDescription => "Control of Thunder Bluff";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\TaurenTheme.mp3");
    }
  }
}