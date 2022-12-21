using System.Collections.Generic;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Ironforge
{
  public sealed class QuestGnomeregan : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R05Q");
    private readonly List<unit> _rescueUnits = new();

    public QuestGnomeregan(Rectangle rescueRect, PreplacedUnitSystem preplacedUnitSystem) : base("The City of Invention",
      "The people of Gnomeregan have long been unable to assist the Alliance in its wars due an infestation of troggs and Ice Trolls. Resolve their conflicts for them to gain their services.",
      "ReplaceableTextures\\CommandButtons\\BTNFlyingMachine.blp")
    {
      AddObjective(new ObjectiveKillUnit(preplacedUnitSystem.GetUnit(FourCC("nitw"), Regions.Gnomergan.Center))); //Ice Troll Warlord
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Gnomeregan has been literated, and its military is now free to assist Ironforge.";

    protected override string RewardDescription => "Control of all units in Gnomeregan";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, FourCC("R05Q"), 1);
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(QuestResearchId, 1);
    }
  }
}