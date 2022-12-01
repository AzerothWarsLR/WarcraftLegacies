using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  /// <summary>
  /// Kill the Lich King to gain Alexandros Mograine as a Hero.
  /// </summary>
  public sealed class QuestMograine : QuestData
  {
    private const int AltarId = Constants.UNIT_HALT_ALTAR_OF_KINGS;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestMograine"/> class.
    /// </summary>
    public QuestMograine() : base("The Exile",
      "The Lich King, looming over Northrend from Icecrown's peak, is the greatest threat Lordaeron has ever faced. He must be destroyed.",
      "ReplaceableTextures\\CommandButtons\\BTNAlexandros.blp")
    {
      AddObjective(new ObjectiveTime(720));
      ResearchId = Constants.UPGRADE_R06P_QUEST_COMPLETED_THE_EXILE_LORDAERON;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. Alexandros Mograine gains recognition as a champion of the war, and prepares himself to aid Lordaeron in future conflicts in a greater capacity.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"You can summon Alexandros Mograine from the {GetObjectName(AltarId)}";
  }
}