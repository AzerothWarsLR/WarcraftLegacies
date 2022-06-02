using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.DialogueSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class DialogueSetup
  {
    public static void Setup()
    {
      try
      {
        DialogueManager.Add(new Dialogue(
          objectives: new[]
          {
            new ObjectiveLegendDead(LegendScourge.LegendKelthuzad)
          },
          soundFile: @"Sound\Dialogue\HumanCampaign\Human04\H04Kelthuzad28.flac",
          caption:
          "Naive fool. My death will make little difference in the long run. For now, the scourging of this land... begins.",
          speaker: "Kel'thuzad",
          audience: new[]
          {
            ScourgeSetup.FactionScourge,
            LordaeronSetup.FactionLordaeron,
          }
        ));

        DialogueManager.Add(new Dialogue(
          objectives: new[]
          {
            new ObjectiveStartSpell(Constants.ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS, false,
              LegendScourge.LegendKelthuzad)
          },
          soundFile: @"Sound\Dialogue\UndeadCampaign\Undead08\U08Kelthuzad18.flac",
          caption: "Come forth, Lord Archimonde! Enter this world, and let us bask in your power!",
          speaker: "Kel'thuzad"
        ));

        DialogueManager.Add(new Dialogue(
          objectives: new[]
          {
            new ObjectiveControlLegend(LegendDruids.LegendCenarius, false)
            {
              EligibleFactions = new List<Faction>()
              {
                DruidsSetup.factionDruids
              }
            }
          },
          soundFile: @"Sound\Dialogue\OrcCampaign\Orc05\U05Cenarius01.flac",
          caption: "Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?",
          speaker: "Cenarius",
          audience: new[]
          {
            SentinelsSetup.Sentinels,
            DruidsSetup.factionDruids,
            FrostwolfSetup.FACTION_FROSTWOLF,
            WarsongSetup.FACTION_WARSONG
          }
        ));

        DialogueManager.Add(new Dialogue(
          objectives: new[]
          {
            new ObjectiveControlLegend(LegendNeutral.LegendFountainofblood, false)
            {
              EligibleFactions = new List<Faction>
              {
                WarsongSetup.FACTION_WARSONG
              }
            },
            new ObjectiveControlLegend(LegendWarsong.LegendGrom, false)
            {
              EligibleFactions = new List<Faction>
              {
                WarsongSetup.FACTION_WARSONG
              }
            }
          },
          soundFile: @"Sound\Dialogue\OrcCampaign\Orc05\U05Grom26.flac",
          caption:
          "Yes! I feel the power once again! Come, my warriors; drink from the dark waters, and you will be reborn!",
          speaker: "Grom Hellscream",
          audience: new[]
          {
            WarsongSetup.FACTION_WARSONG
          }
        ));
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}