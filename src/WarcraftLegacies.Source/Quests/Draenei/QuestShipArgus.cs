using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;


namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// Create a portal between Tempest Keep and Argus.
  /// </summary>
  public sealed class QuestShipArgus : QuestData
  {
    private readonly unit _outlandToArgusWaygate;
    private readonly unit _argusToOutlandWaygate;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestShipArgus"/> class.
    /// </summary>
    /// <param name="outlandToArgusWaygate">Starts hidden, and gets enabled as a waygate when the quest is complete.</param>
    /// <param name="argusToOutlandWaygate">Starts hidden, and gets enabled as a waygate when the quest is complete.</param>
    /// <param name="velen">Needs to be brought somewhere to complete the quest.</param>
    public QuestShipArgus(unit outlandToArgusWaygate, unit argusToOutlandWaygate, LegendaryHero velen) : base("Reconquering Tempest Keep",
      "Tempest Keep still has the power to open a portal Argus, but Velen needs to channel it",
      @"ReplaceableTextures\CommandButtons\BTNArcaneCastle.blp")
    {
      _outlandToArgusWaygate = outlandToArgusWaygate;
      _outlandToArgusWaygate.IsVisible = false;
      _argusToOutlandWaygate = argusToOutlandWaygate;
      _argusToOutlandWaygate.IsVisible = false;
      AddObjective(new ObjectiveChannelRect(Regions.TempestKeepSpawn, "Tempest Keep", velen, 180, 0));
      Global = true;
      Progress = QuestProgress.Undiscovered;
    }

    /// <inheritdoc />
    public override string RewardFlavour => "Velen has opened the portal to Argus";

    /// <inheritdoc />
    protected override string RewardDescription => "Open a Portal between Tempest Keep and Argus";
    
    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      _outlandToArgusWaygate.IsVisible = true;
      _outlandToArgusWaygate.WaygateActive = true;
      _outlandToArgusWaygate.WaygateDestinationX = Regions.TempestKeepSpawn.Center.X;
      _outlandToArgusWaygate.WaygateDestinationY = Regions.TempestKeepSpawn.Center.Y;
      _argusToOutlandWaygate.IsVisible = true;
      _argusToOutlandWaygate.WaygateActive = true;
      _argusToOutlandWaygate.WaygateDestinationX = Regions.OutlandToArgus.Center.X;
      _argusToOutlandWaygate.WaygateDestinationY = Regions.OutlandToArgus.Center.Y;
    }
  }
}