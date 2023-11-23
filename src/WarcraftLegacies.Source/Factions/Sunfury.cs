using System.Collections.Generic;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionChoices;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Quests.Quelthalas;
using WarcraftLegacies.Source.Quests.Sunfury;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Sunfury : Faction
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;

    /// <inheritdoc />
    public Sunfury(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Sunfury", PLAYER_COLOR_MAROON, "|cffff0000",
      @"ReplaceableTextures\CommandButtons\BTNBloodMage2.blp")
    {
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
      StartingGold = 200;
      StartingLumber = 700;
      CinematicMusic = "BloodElfTheme";
      FoodMaximum = 250;
      StartingCameraPosition = Regions.SunfuryStartingPosition.Center;
      StartingUnits = Regions.SunfuryStartingPosition.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
      ControlPointDefenderUnitTypeId = Constants.UNIT_N0BC_CONTROL_POINT_DEFENDER_QUELTHALAS;
      LearningDifficulty = FactionLearningDifficulty.Advanced;
      IntroText = @"You are playing as the power-hungry |cffff0000Sunfury|r.

You begin in Netherstorm, your first mission is to build three biodomes in the green areas protected by a bubble.
Unite with your fel ally to push through the Dark Portal and destroy Stormwind. 

Your main goal is to summon Kil'jaeden and destroy your enemies.";
      GoldMines = new List<unit>
      {
        preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(3295, -22670)),
        preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(2529, -19141))
      };
    }
        
    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      RegisterQuests();
      RegisterDialogue();
    }

    private void RegisterObjectLimits()
    {
      //Structures
      Sunfury.ModObjectLimit(FourCC("h02P"), UNLIMITED); //t1
      Sunfury.ModObjectLimit(FourCC("h0C4"), UNLIMITED); //t2
      Sunfury.ModObjectLimit(FourCC("h0C5"), UNLIMITED); //t3
      Sunfury.ModObjectLimit(FourCC("h0C7"), 3); //house
      Sunfury.ModObjectLimit(FourCC("h0C8"), UNLIMITED); //forge
      Sunfury.ModObjectLimit(FourCC("h0C9"), UNLIMITED); //barrack
      Sunfury.ModObjectLimit(FourCC("h0CB"), UNLIMITED); //magic
      Sunfury.ModObjectLimit(FourCC("h0CA"), UNLIMITED); //VOid Well
      Sunfury.ModObjectLimit(FourCC("h0CI"), UNLIMITED); //Tempest-Forge
      Sunfury.ModObjectLimit(FourCC("h0C6"), UNLIMITED); //Altar
      Sunfury.ModObjectLimit(FourCC("h0CC"), UNLIMITED); //Vault
      Sunfury.ModObjectLimit(FourCC("h0CD"), UNLIMITED); //Scout tower
      Sunfury.ModObjectLimit(FourCC("n0E0"), UNLIMITED); //Skyfury tower
      Sunfury.ModObjectLimit(FourCC("n0E1"), UNLIMITED); //improved skyfury tower
      Sunfury.ModObjectLimit(FourCC("N0DZ"), 1); //Fountain
      Sunfury.ModObjectLimit(FourCC("tp04"), UNLIMITED); //Alliance Shipyard

      //Units
      Sunfury.ModObjectLimit(FourCC("n0E2"), UNLIMITED); //worker
      Sunfury.ModObjectLimit(FourCC("n09S"), UNLIMITED); //Elven Warrior
      Sunfury.ModObjectLimit(FourCC("h0CF"), UNLIMITED); //Elven Ranger
      Sunfury.ModObjectLimit(FourCC("u02W"), 2); //Energy Wagon
      Sunfury.ModObjectLimit(FourCC("h0CH"), UNLIMITED); //Astromancer
      Sunfury.ModObjectLimit(FourCC("h0CG"), UNLIMITED); //Flamekeeper
      Sunfury.ModObjectLimit(Constants.UNIT_H0CE_BLOOD_KNIGHT_SQUIRE_SUNFURY, 12);
      Sunfury.ModObjectLimit(FourCC("n0E3"), 6); //Warlock
      Sunfury.ModObjectLimit(FourCC("n0E4"), 6); //Elven Ballista
      Sunfury.ModObjectLimit(FourCC("n0E8"), 3); //Skyship
      Sunfury.ModObjectLimit(FourCC("n0E7"), 6); //Bloodwarder
      Sunfury.ModObjectLimit(FourCC("e01B"), 6); //Arcane Annihilator
      Sunfury.ModObjectLimit(FourCC("n006"), 2); //Ancient of the Arcane

      //Ships
      Sunfury.ModObjectLimit(FourCC("hbot"), UNLIMITED); //Alliance Transport Ship
      Sunfury.ModObjectLimit(FourCC("h0AR"), UNLIMITED); //Alliance Scout
      Sunfury.ModObjectLimit(FourCC("h0AX"), UNLIMITED); //Alliance Frigate
      Sunfury.ModObjectLimit(FourCC("h0B3"), UNLIMITED); //Alliance Fireship
      Sunfury.ModObjectLimit(FourCC("h0B0"), UNLIMITED); //Alliance Galley
      Sunfury.ModObjectLimit(FourCC("h0B6"), UNLIMITED); //Alliance Boarding
      Sunfury.ModObjectLimit(FourCC("h0AN"), UNLIMITED); //Alliance Juggernaut
      Sunfury.ModObjectLimit(FourCC("h0B7"), 6); //Alliance Bombard

      //Demi-heroes
      Sunfury.ModObjectLimit(FourCC("H098"), 1); //Pathaleon
      Sunfury.ModObjectLimit(FourCC("U02V"), 1); //Solarian
      Sunfury.ModObjectLimit(FourCC("Hkal"), 1); //Kael
      Sunfury.ModObjectLimit(FourCC("U004"), 1); //Kil
      Sunfury.ModObjectLimit(Constants.UNIT_N0E5_VOID_REAVER_SUNFURY_DEMI, 1); //Void Reaver

      //Upgrades
      Sunfury.ModObjectLimit(Constants.UPGRADE_R09H_ASTROMANCER_MASTER_TRAINING_SUNFURY, UNLIMITED);
      Sunfury.ModObjectLimit(Constants.UPGRADE_R09G_FLAMEKEEPER_MASTER_TRAINING_SUNFURY, UNLIMITED);
      Sunfury.ModObjectLimit(Constants.UPGRADE_R09U_SEAL_OF_BLOOD_SUNFURY, UNLIMITED);
    }

    private void RegisterQuests()
    {
      var newQuest = sunfury.AddQuest(new QuestTempestKeep(Regions.TempestKeep, Regions.Biodome1, Regions.Biodome2, Regions.Biodome3));
      sunfury.StartingQuest = newQuest;

      sunfury.AddQuest(new QuestArea52(Regions.Area52Unlock));
      sunfury.AddQuest(new QuestUpperNetherstorm(Regions.UpperNetherstorm));
      sunfury.AddQuest(new QuestSolarian(artifactSetup.EssenceofMurmur));
      sunfury.AddQuest(new QuestSummonKil(allLegendSetup.Stormwind.StormwindKeep, allLegendSetup.Neutral.Karazhan, allLegendSetup.Quelthalas.Kael));
      sunfury.AddQuest(new QuestForgottenKnowledge());
      sunfury.AddQuest(new QuestWellOfEternity(preplacedUnitSystem, allLegendSetup.Quelthalas.Kiljaeden));
    }

    private void RegisterDialogue()
    {
      throw new System.NotImplementedException();
    }
  }
}