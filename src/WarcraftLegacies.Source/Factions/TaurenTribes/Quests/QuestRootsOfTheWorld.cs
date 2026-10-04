using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.TaurenTribes.Powers;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

public sealed class QuestRootsOfTheWorld : QuestData
{
  private readonly RootsOfTheWorld _power;

  public QuestRootsOfTheWorld(List<Capital> worldTrees, RootsOfTheWorld power) : base(
    "Roots of the World",
    "Three great World Trees still stand on Azeroth: Nordrassil atop Mount Hyjal, Shaladrassil in Val'sharah and the Great Tree of Seradane in the Hinterlands. Their roots run deeper than any war. Should the Tauren hold all three at once, the Earth Mother will bind them together.",
    @"ReplaceableTextures\CommandButtons\BTNTeleportation.blp")
  {
    foreach (var worldTree in worldTrees)
    {
      AddObjective(new ObjectiveOwnCapital(worldTree));
    }

    _power = power;
  }

  public override string RewardFlavour =>
    "The roots of the three World Trees have joined beneath the earth. Wherever the Tauren hold a World Tree, the Earth Mother will carry them to another.";

  protected override string RewardDescription =>
    "You gain the Roots of the World Power, which lets your World Trees send your units between each other";

  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.AddPower(_power);
    completingFaction.Player?.DisplayPowerAcquired(_power);
  }
}
