using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// Proudmoore captial ship starts locked. Boralus and Dazar'Alor must be captured to unlock it.
  /// </summary>
  public sealed class QuestUnlockShip : QuestData
  {
    private readonly unit _proudmooreCapitalShip;
    private readonly List<unit> _rescueUnits = new();
    private readonly Rectangle _rescueRect;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestUnlockShip"/> class.
    /// </summary>
    /// <param name="rescueRect">All units in this area will be made neutral, then rescued when the quest is completed.</param>
    /// <param name="proudmooreCapitalShip">starts invulnerable and unusable. Made usuable and vulnerable when the quest is completed.</param>
    public QuestUnlockShip(Rectangle rescueRect, unit proudmooreCapitalShip) : base("The Zandalar Menace",
      "The Troll Empire of Zandalar is a danger to the safety of Kul'tiras and the Alliance. Before setting sail, we must eliminate them.",
      "ReplaceableTextures\\CommandButtons\\BTNGalleonIcon.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendNeutral.Dazaralor, false));
      AddObjective(new ObjectiveControlLegend(LegendKultiras.LegendBoralus, true));
      _proudmooreCapitalShip = proudmooreCapitalShip;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      _rescueRect = rescueRect;
    }

    /// <inheritdoc/>
    protected override string FailurePopup =>
      "Boralus has fallen, but Katherine and Daelin have escaped on the Proudmoore Capital Ship with a handful of Survivors.";

    /// <inheritdoc/>
    protected override string PenaltyDescription =>
      "You lose everything you control, but you gain Katherine and Daelin Proudmoore at the Proudmoore Capital Ship.";

    /// <inheritdoc/>
    protected override string CompletionPopup => "The Proudmoore Capital Ship is now ready to set sail!";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Unpause the Proudmoore capital ship and unlocks the buildings inside.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
      {
        completingFaction.Player.RescueGroup(_rescueUnits);
        _proudmooreCapitalShip.Rescue(completingFaction.Player);
      }
      else
      {
        Player(bj_PLAYER_NEUTRAL_VICTIM).RescueGroup(_rescueUnits);
        _proudmooreCapitalShip.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
      _proudmooreCapitalShip.Pause(false);
      KultirasSetup.Kultiras?.Player?.SetTeam(TeamSetup.Alliance);
      ZandalarSetup.Zandalar?.Player?.SetTeam(TeamSetup.Horde);
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      LegendKultiras.LegendKatherine.StartingXp = GetHeroXP(LegendKultiras.LegendKatherine.Unit);
      completingFaction.Obliterate();
      if (completingFaction.Player != null)
      {
        LegendKultiras.LegendKatherine.ForceCreate(completingFaction.Player, new Point(_rescueRect.Center.X, _rescueRect.Center.Y), 110);
        LegendKultiras.LegendAdmiral.ForceCreate(completingFaction.Player, new Point(_rescueRect.Center.X, _rescueRect.Center.Y), 110);
        if (GetLocalPlayer() == completingFaction.Player)
          SetCameraPosition(_rescueRect.Center.X, _rescueRect.Center.Y);
        completingFaction.Player.RescueGroup(_rescueUnits);
        completingFaction.Player.AddGold(500);
        completingFaction.Player.AddLumber(2000);
        _proudmooreCapitalShip.Rescue(completingFaction.Player);
      }
      else
      {
        _proudmooreCapitalShip.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
      _proudmooreCapitalShip.Pause(false); 
      IssuePointOrder(_proudmooreCapitalShip, "move", Regions.SouthshoreUnlock.Center.X, Regions.SouthshoreUnlock.Center.Y);
      KultirasSetup.Kultiras?.Player?.SetTeam(TeamSetup.Alliance);
      ZandalarSetup.Zandalar?.Player?.SetTeam(TeamSetup.Horde);
    }
  }
}