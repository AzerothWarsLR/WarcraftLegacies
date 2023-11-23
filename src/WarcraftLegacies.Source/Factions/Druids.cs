using System.Collections.Generic;
using MacroTools;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using WarcraftLegacies.Source.Powers;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Druids : Faction
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;

    /// <inheritdoc />
    public Druids(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Druids", PLAYER_COLOR_BROWN, "|c004e2a04",
      @"ReplaceableTextures\CommandButtons\BTNFurion.blp")
    {
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
      UndefeatedResearch = FourCC("R06E");
      StartingGold = 200;
      StartingLumber = 700;
      CinematicMusic = "DarkAgents";
      ControlPointDefenderUnitTypeId = Constants.UNIT_E01Y_CONTROL_POINT_DEFENDER_DRUIDS;
      IntroText = @"You are playing as the ancient Druids of the Cenarion Circle.

You begin isolated in the deepest parts of Mount Hyjal near the World Tree.

The Horde is gathering to burn Ashenvale forest and the World Tree. Cenarius has emerged from his seclusion to stop them. 
Use him to awaken Malfurion from his slumber as soon as possible. 

Once awakened, use his Force of Nature to clear a path through the trees in Ashenvale.

Gather your forces and strike before the Horde can organize their efforts.";
      GoldMines = new List<unit>
      {
        preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-9200, 10742))
      };
      RegisterFactionDependentInitializer<Sentinels>(RegisterSentinelsDialogue);
    }

    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      RegisterQuests();
      RegisterDialogue();
      RegisterPowers();
    }

    private void RegisterObjectLimits()
    {
      ModObjectLimit(FourCC("etol"), Faction.UNLIMITED); //Tree of Life
      ModObjectLimit(FourCC("etoa"), Faction.UNLIMITED); //Tree of Ages
      ModObjectLimit(FourCC("etoe"), Faction.UNLIMITED); //Tree of Eternity
      ModObjectLimit(FourCC("emow"), Faction.UNLIMITED); //Moon Well
      ModObjectLimit(FourCC("eate"), Faction.UNLIMITED); //Altar of Elders
      ModObjectLimit(FourCC("eaoe"), Faction.UNLIMITED); //Ancient of Lore
      ModObjectLimit(FourCC("eaow"), Faction.UNLIMITED); //Ancient of Wind
      ModObjectLimit(FourCC("eaom"), Faction.UNLIMITED); //Ancient of war
      ModObjectLimit(FourCC("etrp"), Faction.UNLIMITED); //Ancient Protector
      ModObjectLimit(FourCC("e010"), Faction.UNLIMITED); //Hunter)s Hall
      ModObjectLimit(FourCC("e019"), Faction.UNLIMITED); //Ancient of Wonders
      ModObjectLimit(FourCC("eshy"), Faction.UNLIMITED); //Night Elf Shipyard
      ModObjectLimit(FourCC("e000"), Faction.UNLIMITED); //Improved Ancient Protector

      ModObjectLimit(FourCC("ewsp"), Faction.UNLIMITED); //Wisp
      ModObjectLimit(FourCC("edry"), Faction.UNLIMITED); //Dryad
      ModObjectLimit(FourCC("edot"), Faction.UNLIMITED); //Druid of the Talon
      ModObjectLimit(FourCC("emtg"), 12); //Mountain Giant
      ModObjectLimit(FourCC("efdr"), 6); //Faerie Dragon
      ModObjectLimit(FourCC("edoc"), Faction.UNLIMITED); //Druid of the Claw
      ModObjectLimit(FourCC("edcm"), Faction.UNLIMITED); //Druid of the Claw bear form
      ModObjectLimit(FourCC("e00N"), 6); //Keeper of the Grove
      ModObjectLimit(FourCC("n05H"), Faction.UNLIMITED); //Furbolg
      ModObjectLimit(FourCC("n065"), 6); //Green Dragon
      ModObjectLimit(Constants.UNIT_E012_SIEGE_ANCIENT_DRUIDS_ELITE, 6);

      //Ships
      ModObjectLimit(FourCC("etrs"), Faction.UNLIMITED); //Night Elf Transport Ship
      ModObjectLimit(FourCC("h0AU"), Faction.UNLIMITED); // Scout
      ModObjectLimit(FourCC("h0AV"), Faction.UNLIMITED); // Frigate
      ModObjectLimit(FourCC("h0B1"), Faction.UNLIMITED); // Fireship
      ModObjectLimit(FourCC("h057"), Faction.UNLIMITED); // Galley
      ModObjectLimit(FourCC("h0B4"), Faction.UNLIMITED); // Boarding
      ModObjectLimit(FourCC("h0BA"), Faction.UNLIMITED); // Juggernaut
      ModObjectLimit(FourCC("h0B8"), 6); // Bombard

      ModObjectLimit(FourCC("Ecen"), 1); //Cenarius
      ModObjectLimit(FourCC("E00H"), 1); //Cenarius
      ModObjectLimit(FourCC("E00K"), 1); //Tortolla
      ModObjectLimit(FourCC("Efur"), 1); //Furion
      ModObjectLimit(Constants.UNIT_E00A_ANCIENT_GUARDIAN_DRUIDS, 1);
      ModObjectLimit(Constants.UNIT_E00X_ELEMENTAL_GUARDIAN_DRUIDS_DEMI, 1);
      ModObjectLimit(Constants.UNIT_H04U_DEMIGOD_DRUIDS, 1);

      ModObjectLimit(FourCC("Redt"), Faction.UNLIMITED); //Druid of the Talon Adept Training
      ModObjectLimit(FourCC("Renb"), Faction.UNLIMITED); //Nature)s Blessing
      ModObjectLimit(FourCC("Rers"), Faction.UNLIMITED); //Resistant Skin
      ModObjectLimit(FourCC("Reuv"), Faction.UNLIMITED); //Ultravision
      ModObjectLimit(FourCC("Rews"), Faction.UNLIMITED); //Well Spring
      ModObjectLimit(FourCC("Redc"), Faction.UNLIMITED); //Druid of the Claw Adept Training
      ModObjectLimit(FourCC("R04E"), Faction.UNLIMITED); //Ysera)s Gift
      ModObjectLimit(FourCC("R02G"), Faction.UNLIMITED); //Emerald Flames
      ModObjectLimit(FourCC("R05X"), Faction.UNLIMITED); //Blessing of Ursoc
      ModObjectLimit(FourCC("R002"), Faction.UNLIMITED); //Blackwald Enhancement
      ModObjectLimit(FourCC("R00A"), Faction.UNLIMITED); //Improved Thorns
      ModObjectLimit(FourCC("R02T"), Faction.UNLIMITED); //Improved Moonwells
      ModObjectLimit(FourCC("R033"), Faction.UNLIMITED); //Limber Timber
      ModObjectLimit(FourCC("R046"), Faction.UNLIMITED); //Grasping Vines
      ModObjectLimit(FourCC("R047"), Faction.UNLIMITED); //Crippling Poison
      ModObjectLimit(FourCC("R048"), Faction.UNLIMITED); //Deadly Poison
      ModObjectLimit(FourCC("R008"), Faction.UNLIMITED); //Improved Natures FuryR015
      ModObjectLimit(FourCC("R015"), Constants.UPGRADE_R015_IMPROVED_MANA_FLARE_DRUIDS);
      ModObjectLimit(Constants.UPGRADE_R09V_STORM_CROW_FORM_DRUIDS, Faction.UNLIMITED);

      SetObjectLevel(Constants.UPGRADE_REWS_WELL_SPRING, 1);
    }

    private void RegisterQuests()
    {
      throw new System.NotImplementedException();
    }

    private void RegisterDialogue()
    {
      TriggeredDialogueManager.Add(new TriggeredDialogue(new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Satyr29",
            "Come no further, weakling!  Lord Tichondrius commanded us to kill anyone attempting to enter this place, and we shall.",
            "Satyr"),
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Furion30",
            "Patches wretches! It pains me that you once called yourselves Night Elves.",
            "Malfurion Stormrage")
        ), 
        new[] { this },
        new Objective[]
        {
          new ObjectiveUnitAlive(preplacedUnitSystem.GetUnit(Constants.UNIT_NSTH_SATYR_HELLCALLER, Regions.SatyrCamp.Center)),
          new ObjectiveLegendInRect(legendSetup.Druids.Malfurion, Regions.SatyrCamp, "Satyr camp")
        }));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\NightElfCampaign\NightElf03\N03Furion22",
          "The horn has sounded, and I have come as promised! I smell the stench of decay and corruption in our land. That angers me greatly.",
          "Malfurion Stormrage"),
        new[] { this },
        new Objective[]
        {
          new ObjectiveControlLegend(legendSetup.Druids.Malfurion, false)
          {
            EligibleFactions = new List<Faction>
            {
              this
            }
          }
        }));
    }
    
    private void RegisterPowers()
    {
      var worldTrees = new List<Capital>
      {
        _allLegendSetup.Druids.Nordrassil,
        _allLegendSetup.Neutral.Shaladrassil,
        _allLegendSetup.Druids.Vordrassil
      };
      AddPower(new Immortality(25, 45, worldTrees)
      {
        IconName = "ArcaneRessurection",
        Name = "Immortality",
        Effect = @"Abilities\Spells\Human\Heal\HealTarget.mdl",
        ResearchId = Constants.UPGRADE_YB01_IMMORTALITY_POWER_IS_ACTIVE
      });
    }
    
    private void RegisterSentinelsDialogue(Sentinels sentinels)
    {
      TriggeredDialogueManager.Add(new TriggeredDialogue(new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Furion01",
            "It has been a thousand years since I last looked up you, Tyrande. I thought of you every moment I roamed through the Emerald Dream.",
            "Malfurion Stormrage"), 
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Tyrande02",
            "My heart rejoices to see you again, Furion. But I would not have awakened you unless the need was urgent.",
            "Tyrande Whisperwind"), 
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Furion03",
            "In the Dream, I felt our land being corrupted, just as if it were my own body. You were right to awaken me.",
            "Malfurion Stormrage")
        ), 
        new Faction[] { this, sentinels },
        new[] { new ObjectiveLegendMeetsLegend(legendSetup.Druids.Malfurion, legendSetup.Sentinels.Tyrande) }));

      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\OrcCampaign\Orc05\O05Cenarius01",
          "Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?",
          "Cenarius"), new Faction[]
        {
          sentinels,
          this,
          frostwolf,
          warsong
        }, new[]
        {
          new ObjectiveControlLegend(legendSetup.Druids.Cenarius, false)
          {
            EligibleFactions = new List<Faction>
            {
              this
            }
          }
        }));

    }
  }
}