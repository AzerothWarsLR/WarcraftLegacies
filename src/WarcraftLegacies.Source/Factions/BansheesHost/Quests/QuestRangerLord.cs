using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Quests;

/// <summary>Bring Sylvanas to Marris Stead and put down the wretched Nathanos, so he can be raised again in her service.</summary>
public sealed class QuestRangerLord : QuestData
{
  private const int TintRed = 120;
  private const int TintGreen = 150;
  private const int TintBlue = 120;

  /// <summary>Where Nathanos fell defending his family's farmstead.</summary>
  public static Rectangle MarrisStead { get; } = new(16700, 8500, 17100, 8900);

  public QuestRangerLord(LegendaryHero sylvanas) : base("The Ranger-Lord",
    "Nathanos Marris was the only human ever to earn the title of Ranger-Lord, trained by Sylvanas herself. He fell defending Marris Stead when the plague swept the east, and his body still wanders the fields as a wretched, mindless thing. Bring Sylvanas to Marris Stead and end his torment.",
    @"ReplaceableTextures\CommandButtons\BTNNathanosBlightcaller.blp")
  {
    var reachStead = new ObjectiveLegendReachRect(sylvanas, MarrisStead, "Marris Stead");
    AddObjective(reachStead);
    var center = MarrisStead.Center;
    var wretchedNathanos = new ObjectiveDefeatRisenFoe(reachStead, UNIT_H049_RANGER_LORD_FORSAKEN, "Wretched Nathanos",
      new Point(center.X, center.Y), 270);
    wretchedNathanos.FoeRisen += foe => foe.SetVertexColor(TintRed, TintGreen, TintBlue, 255);
    AddObjective(wretchedNathanos);
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Sylvanas stands over her fallen student and lays a hand on his brow. The Scourge took his mind; she gives it back. Nathanos rises again, his will bound to his Dark Lady alone.";

  /// <inheritdoc />
  protected override string RewardDescription => "Learn to train Nathanos Marris from the Altar";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction) =>
    completingFaction.ModObjectLimit(UNIT_H049_RANGER_LORD_FORSAKEN, 1);
}
