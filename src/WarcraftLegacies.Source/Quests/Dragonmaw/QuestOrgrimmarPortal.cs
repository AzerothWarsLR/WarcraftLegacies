using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Dragonmaw
{
  /// <summary>
  /// Dragonmaw opens a portal to Orgrimmar.
  /// </summary>
  public sealed class QuestOrgrimmarPortal : QuestData
  {
    private readonly unit _waygateOrgrimmar;
    private readonly unit _waygateDragonmawPort;
    private readonly destructable _dragonmawGate;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestOrgrimmarPortal"/> class.
    /// </summary>
    /// <param name="dragonmawGate">Starts invulnerable and gets opened when the quest is complete.</param>
    /// <param name="waygateOrgrimmar">Starts hidden and gets revealed when the quest is complete.</param>
    /// <param name="waygateDragonmawPort">Starts hidden and gets revealed when the quest is complete.</param>
    public QuestOrgrimmarPortal(destructable dragonmawGate, unit waygateOrgrimmar, unit waygateDragonmawPort) : base("The Reunification of the Horde", "The new Horde in Kalimdor has send a message to the Dragonmaw Clan to join them, Zuluhead will need to open a portal for his people to go through!", "ReplaceableTextures\\CommandButtons\\BTNPortal.blp")
    {
      _waygateOrgrimmar = waygateOrgrimmar;
      _waygateDragonmawPort = waygateDragonmawPort;
      _dragonmawGate = dragonmawGate.SetInvulnerable(true);
      AddObjective(new ObjectiveChannelRect(Regions.DragonmawPortal, "Dragonmaw Port", LegendFelHorde.LegendZuluhed, 180, 300));
      AddObjective(new ObjectiveControlLegend(LegendNeutral.LegendGrimbatol, false));
      AddObjective(new ObjectiveControlLegend(LegendFrostwolf.LegendOrgrimmar, false));
      waygateOrgrimmar.Show(false);
      waygateDragonmawPort.Show(false);
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Zuluhead has opened the portal to Orgrimmar. Hurry, it will collapse in 3 mins";

    /// <inheritdoc />
    protected override string RewardDescription => "Open a Portal between Dragonmaw Port and Orgrimmar";

    /// <inheritdoc />
    protected override void OnFail(Faction whichFaction) => _dragonmawGate.SetInvulnerable(false);

    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction)
    {
      _waygateOrgrimmar
        .Show(true)
        .SetWaygateDestination(Regions.DragonmawPortal.Center);
      _waygateDragonmawPort
        .Show(true)
        .SetWaygateDestination(Regions.OrgrimmarPortal.Center);
      
    }
  }
}