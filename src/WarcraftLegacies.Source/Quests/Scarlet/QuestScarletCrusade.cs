using System.Collections.Generic;
using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Scarlet
{
  /// <summary>
  /// The Militia become the Scarlet Crusade, becoming much stronger but leaving the Alliance.
  /// </summary>
  public sealed class QuestScarletCrusade : QuestData
  {
    private static readonly int UnleashTheCrusadeResearchId = FourCC("R03P");
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _scarletMonastery;
    private readonly QuestData _sequel;

    public QuestScarletCrusade(Rectangle rescueRect, unit scarletMonastery, QuestData sequel) : base(
      "The Secret Cloister",
      "The Scarlet Monastery is the perfect place for the secret base of the Scarlet Crusade.",
      "ReplaceableTextures\\CommandButtons\\BTNDivine_Reckoning_Icon.blp")
    {
      _scarletMonastery = scarletMonastery;
      AddObjective(new ObjectiveResearch(UnleashTheCrusadeResearchId, FourCC("h00T")));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R03F_QUEST_COMPLETED_UNLEASH_THE_CRUSADE;
      Global = true;
      _sequel = sequel;

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "The Scarlet Monastery Hand is complete and ready to join the Alliance.";

    protected override string RewardDescription =>
      "Control of all units in the Scarlet Monastery and you will unally the alliance";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(KultirasSetup.Kultiras.Player,
        Constants.UPGRADE_R06V_SCARLET_CRUSADE_IS_UNLEASHED, 1);
      SetPlayerTechResearched(LordaeronSetup.Lordaeron.Player,
        Constants.UPGRADE_R06V_SCARLET_CRUSADE_IS_UNLEASHED, 1);
      SetPlayerTechResearched(ScarletSetup.ScarletCrusade.Player, Constants.UPGRADE_R086_PATH_CHOSEN, 1);
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player ?? Player(GetBJPlayerNeutralVictim()));
      WaygateActivate(_scarletMonastery, true);
      WaygateSetDestination(_scarletMonastery, Regions.ScarletMonastery.Center.X, Regions.ScarletMonastery.Center.Y);
      completingFaction.Player?.SetTeam(TeamSetup.ScarletCrusade);
      completingFaction.Name = "Scarlet";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNSaidan Dathrohan.blp";
      PlayThematicMusic("war3mapImported\\ScarletTheme.mp3");
      SetPlayerState(completingFaction.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
      completingFaction.AddQuest(_sequel);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(UnleashTheCrusadeResearchId, 1);
    }
  }
}