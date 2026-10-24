using MacroTools.Factions;
using MacroTools.Paths;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Powers;

namespace WarcraftLegacies.Source.Factions.Druids.Paths;

/// <summary>Lets the Druids sacrifice Nordrassil to stop Archimonde, becoming the weaker Cenarion Circle.</summary>
public sealed class PathNordrassilsSacrifice : FactionPath
{
  private const int ChannelSeconds = 60;
  private const float ArchimondeLifeLeft = 0.1f;

  private readonly QuestConsumeTree _consumeTree;

  public PathNordrassilsSacrifice(Faction legion, QuestConsumeTree consumeTree)
  {
    _consumeTree = consumeTree;
    Name = "Nordrassil's Sacrifice";
    IconName = "Tranquility";
    Description = "Archimonde drinks deep from the Well of Eternity beneath Nordrassil. Unleash the spirits of the World Tree to tear him apart, and let the tree burn with him. What remains of the druids carries on as the Cenarion Circle, diminished but unbroken.";
    AddMustStayTrueRequirement(new ObjectiveChannelTime(consumeTree.WorldTreeChannel, ChannelSeconds,
      "Archimonde has been draining the World Tree for 60 seconds")
    { ShowsInQuestLog = false });
    legion.QuestProgressChanged += args =>
    {
      if (args.Quest == consumeTree && consumeTree.Progress == QuestProgress.Complete)
      {
        Close();
      }
    };
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    _consumeTree.WorldTreeChannel.Close();
    _consumeTree.Progress = QuestProgress.Failed;
    StrikeArchimonde();
    faction.Name = "Cenarion Circle";
    RemoveImmortality(faction);
    WeakenCenarius();
    AllLegends.Druids.Cenarius.UnitChanged += _ => WeakenCenarius();
  }

  private static void StrikeArchimonde()
  {
    var archimonde = AllLegends.Legion.Archimonde.Unit;
    if (archimonde == null || !archimonde.Alive)
    {
      DestroyNordrassil();
      return;
    }

    WispSwarm.Start(archimonde, () =>
    {
      WoundArchimonde(archimonde);
      DestroyNordrassil();
    });
  }

  private static void WoundArchimonde(unit archimonde)
  {
    if (!archimonde.Alive)
    {
      return;
    }

    var maximumLife = archimonde.MaxLife;
    if (archimonde.Life > maximumLife * ArchimondeLifeLeft)
    {
      archimonde.Life = maximumLife * ArchimondeLifeLeft;
    }
  }

  private static void DestroyNordrassil()
  {
    var nordrassil = AllLegends.Druids.Nordrassil.Unit;
    if (nordrassil != null && nordrassil.Alive)
    {
      nordrassil.Kill();
    }
  }

  private static void RemoveImmortality(Faction faction)
  {
    var immortality = faction.GetPowerByType<Immortality>();
    if (immortality != null)
    {
      faction.RemovePower(immortality);
    }
  }

  private static void WeakenCenarius()
  {
    var cenarius = AllLegends.Druids.Cenarius.Unit;
    if (cenarius == null || !cenarius.Alive || cenarius.UnitType != UNIT_ECEN_DEMIGOD_OF_THE_NIGHT_ELVES_DRUIDS)
    {
      return;
    }

    cenarius.RemoveAbility(ABILITY_ACM2_SPELL_IMMUNITY_SPELL_IMMUNITY_DIVINE_ARMOR);
    cenarius.RemoveAbility(ABILITY_A0U0_MASTER_OF_NATURE_BROWN_CENARIUS);
  }
}
