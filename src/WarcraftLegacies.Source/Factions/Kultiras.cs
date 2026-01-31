using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.PreplacedWidgetsSystem;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.KulTiras;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class Kultiras : Faction
{
  private readonly unit _proudmooreCapitalShip;

  /// <inheritdoc />
  public Kultiras()
    : base("Kul'tiras", playercolor.Emerald, @"ReplaceableTextures\CommandButtons\BTNProudmoore.blp")
  {
    TraditionalTeam = TeamSetup.SouthAlliance;
    _proudmooreCapitalShip = PreplacedWidgets.Units.Get(UNIT_H05V_PROUDMOORE_FLAGSHIP_KULTIRAS);
    StartingGold = 200;
    ControlPointDefenderUnitTypeId = UNIT_H09W_CONTROL_POINT_DEFENDER_KULTIRAS;
    IntroText = $"You are playing as the maritime {PrefixCol}Kingdom of Kul Tiras|r.\n\n" +
                "You begin on Balor Island, separated from your main forces in Kul Tiras. Unite your forces by eliminating your enemies in Tiragarde, Drustvar, and Stormsong Valley.\n\n" +
                "Stormwind is preparing for an invasion through the Dark Portal in the South. Muster the Admiralty and assist them, or risk losing your strongest ally.";

    GoldMines = new List<unit>
    {
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), 4585, -13038)
    };
    Nicknames = new List<string>
    {
      "kt",
      "kul",
      "kultiras"
    };

    RegisterFactionDependentInitializer<Frostwolf>(RegisterDialogue);
    ProcessObjectInfo(KultirasObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    var questBoralus = new QuestBoralus(Regions.Kultiras, AllLegends.Kultiras.LegendKatherine);
    StartingQuest = AddQuest(questBoralus);
    AddQuest(new QuestUnlockShip(Regions.ShipAmbient, _proudmooreCapitalShip, AllLegends.Kultiras.LegendAdmiral,
      questBoralus));
    AddQuest(new QuestOldHatreds(AllLegends.Kultiras.LegendAdmiral));
    AddQuest(new QuestWestfallOutpost(Regions.StranglethornBaseBuild));
    AddQuest(new QuestHighBank(Regions.HighbankUnlock, AllLegends.Kultiras.LegendKatherine));
    AddQuest(new QuestBeyondPortal(AllLegends.FelHorde.HellfireCitadel,
      AllLegends.FelHorde.KilsorrowFortress));
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quelthalas.Sunwell, Artifacts.SunwellVial));
  }

  private void RegisterDialogue(Frostwolf frostwolf)
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest20x\D20Proudmoore05",
            "I must admit, you orcs are more tenacious than I remembered. I thought you savages would have turned on each other by now.",
            "Daelin Proudmoore"),
          new Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest20x\D20Thrall06",
            "This is not the Horde you remember, old man. We have no interest in conquest or murder. We have paid for our sins of our forebears in blood.",
            "Thrall"),
          new Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest20x\D20Proudmoore07",
            "Can your blood atone for genocide, orc? Your Horde killed countless innocents with its rampage across Stormwind and Lordaeron. Do you really think you can just sweep all that away and cast aside your guilt so easily? No, your kind will never change, and I will never stop fighting you.",
            "Daelin Proudmoore"))
        , new Faction[]
        {
          this,
          frostwolf
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Kultiras.LegendAdmiral, AllLegends.Frostwolf.Thrall)
        }));
  }
}
