using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests
{
  /// <summary>
  /// The Tomb of Sargeras starts closed, and can be opened by completing this quest.
  /// </summary>
  public sealed class QuestTombOfSargeras : QuestData
  {
    private readonly unit _tombOfSargerasEntrance;
    private readonly Rectangle _tombOfSargerasInteriorEntrance;
    private readonly unit _guldanRemains;
    private readonly ObjectiveHeroWithLevelReachRect _enterTombOfSargerasRegion;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTombOfSargeras"/> class.
    /// </summary>
    /// <param name="tombOfSargerasEntrance"></param>
    /// <param name="tombOfSargerasInteriorEntrance"></param>
    /// <param name="guldanRemains"></param>
    public QuestTombOfSargeras(unit tombOfSargerasEntrance, Rectangle tombOfSargerasInteriorEntrance, unit guldanRemains) : base("Tomb of Sargeras",
      "When the Guardian Aegwynn defeated the fallen Titan Sargeras, she sealed his corpse within the temple that would come to be known as the Tomb of Sargeras. It lies still there, tempting those with the ambition to seize the power that remains within.",
      @"ReplaceableTextures\CommandButtons\BTNUnholyFrenzy.blp")
    {
      _tombOfSargerasEntrance = tombOfSargerasEntrance;
      _tombOfSargerasInteriorEntrance = tombOfSargerasInteriorEntrance;
      _guldanRemains = guldanRemains;
      AddObjective(new ObjectiveTime(900));
      _enterTombOfSargerasRegion = new ObjectiveHeroWithLevelReachRect(10, Regions.Sargeras_Entrance, "the Tomb of Sargeras' entrance");
      AddObjective(_enterTombOfSargerasRegion);
      Global = true;
    }
    
    /// <inheritdoc />
    protected override string RewardDescription => "The Tomb of Sargeras opens";

    /// <inheritdoc />
    protected override string CompletionPopup => $"The Tomb of Sargeras has been opened by {_enterTombOfSargerasRegion.EnteredRegionUnitName}";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      _tombOfSargerasEntrance.SetWaygateDestination(_tombOfSargerasInteriorEntrance.Center);
      SetUnitAnimation(_guldanRemains, "decay flesh");
    }
  }
}