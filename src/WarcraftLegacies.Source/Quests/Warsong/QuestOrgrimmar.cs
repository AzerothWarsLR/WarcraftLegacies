using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestOrgrimmar : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    private const int RequiredResearchId = Constants.UPGRADE_R05O_FORTIFIED_HULLS_WARSONG;

    public QuestOrgrimmar(Rectangle rescueRect) : base("To Tame a Land",
      "This new continent is ripe for the taking. If the Horde is to survive, a new city needs to be built.",
      "ReplaceableTextures\\CommandButtons\\BTNFortress.blp")
    {
      AddObjective(new ObjectiveResearch(RequiredResearchId, Constants.UNIT_O02S_FORTRESS_WARSONG_T3));
      AddObjective(new ObjectiveExpire(1500));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R05R");

      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "Control of all units in Orgrimmar, able to train Varok and Azerite Siege Engines";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all units in Orgrimmar, able to train Varok and Azerite Siege Engines";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\OrgrimmarTheme.mp3");
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <inheritdoc/>
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(RequiredResearchId, 1);
    }
  }
}