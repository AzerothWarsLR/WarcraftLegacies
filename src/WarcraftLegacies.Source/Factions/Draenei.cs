using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.Powers;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Draenei : Faction
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;

    /// <inheritdoc />
    public Draenei(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("The Exodar", PLAYER_COLOR_NAVY, "|cff000080",
      @"ReplaceableTextures\CommandButtons\BTNBOSSVelen.blp")
    {
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
      StartingGold = 200;
      StartingLumber = 700;
      ControlPointDefenderUnitTypeId = Constants.UNIT_U008_CONTROL_POINT_DEFENDER_DRAENEI;
      IntroText = @"You are playing as the exiled |cff000080Draenei|r.

You begin on Azuremyst Island, amid the wreckage of your flight from the Burning Legion.

Further inland your Night-elf allies will need your help against the Orcish Horde, quickly build your base and gain entry to the Exodar.

The Exodar is a mighty fortress-base with the ability to move around the map, but it will take a long time to repair.";
    }
    
    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      RegisterQuests();
      RegisterPowers();
    }

    private void RegisterObjectLimits()
    {
      ModObjectLimit(FourCC("o02P"), Faction.UNLIMITED); //Crystal Hall
      ModObjectLimit(FourCC("o050"), Faction.UNLIMITED); //Metropolis
      ModObjectLimit(FourCC("o051"), Faction.UNLIMITED); //Divine Citadel
      ModObjectLimit(FourCC("o058"), Faction.UNLIMITED); //Altar of Light
      ModObjectLimit(FourCC("o052"), Faction.UNLIMITED); //Ceremonial Altar
      ModObjectLimit(FourCC("o053"), Faction.UNLIMITED); //Smithery
      ModObjectLimit(FourCC("o054"), Faction.UNLIMITED); //Astral Sanctum
      ModObjectLimit(FourCC("o055"), Faction.UNLIMITED); //Crystal Spire
      ModObjectLimit(FourCC("o056"), 48); //Arcane Well
      ModObjectLimit(FourCC("o057"), Faction.UNLIMITED); //Vaults of Relic
      ModObjectLimit(FourCC("u00U"), Faction.UNLIMITED); //Crystal Protector
      ModObjectLimit(FourCC("u01Q"), Faction.UNLIMITED); //Crystal Protector improved
      ModObjectLimit(FourCC("o059"), Faction.UNLIMITED); //Improved Ancient Protector
      ModObjectLimit(FourCC("o05U"), Faction.UNLIMITED); //Lightforged Gateway

      ModObjectLimit(FourCC("o05A"), Faction.UNLIMITED); //Wisp
      ModObjectLimit(FourCC("o05B"), Faction.UNLIMITED); //Defender
      ModObjectLimit(FourCC("h09T"), Faction.UNLIMITED); //Rangari
      ModObjectLimit(FourCC("e01K"), 3); //Polybolos
      ModObjectLimit(FourCC("o05D"), Faction.UNLIMITED); //Elementalist
      ModObjectLimit(FourCC("o05C"), Faction.UNLIMITED); //Luminarch
      ModObjectLimit(FourCC("h09R"), 6); //Vindicator
      ModObjectLimit(FourCC("nmdr"), Faction.UNLIMITED); //Elekk
      ModObjectLimit(FourCC("h09U"), 4); //Elekk Knight
      ModObjectLimit(FourCC("u02H"), 6); //Nether Ray

      ModObjectLimit(FourCC("n0BJ"), 6); //Sharpshooter
      ModObjectLimit(FourCC("n0BP"), 4); //Juggernaut
      ModObjectLimit(FourCC("n0BM"), 8); //Nether Ray

      //Ships
      ModObjectLimit(FourCC("etrs"), Faction.UNLIMITED); //Night Elf Transport Ship
      ModObjectLimit(FourCC("h0AU"), Faction.UNLIMITED); // Scout
      ModObjectLimit(FourCC("h0AV"), Faction.UNLIMITED); // Frigate
      ModObjectLimit(FourCC("h0B1"), Faction.UNLIMITED); // Fireship
      ModObjectLimit(FourCC("h057"), Faction.UNLIMITED); // Galley
      ModObjectLimit(FourCC("h0B4"), Faction.UNLIMITED); // Boarding
      ModObjectLimit(FourCC("h0BA"), Faction.UNLIMITED); // Juggernaut
      ModObjectLimit(FourCC("h0B8"), 6); // Bombard

      ModObjectLimit(FourCC("H09S"), 1); //Maraad
      ModObjectLimit(FourCC("E01I"), 1); //Velen
      ModObjectLimit(FourCC("E01J"), 1); //Nobundo
      ModObjectLimit(FourCC("H09M"), 1); //Adal

      ModObjectLimit(FourCC("R078"), Faction.UNLIMITED); //Elementalist training
      ModObjectLimit(FourCC("R07C"), Faction.UNLIMITED); //Luminarch training
    }

    private void RegisterQuests()
    {
      throw new System.NotImplementedException();
    }

    private void RegisterPowers()
    {
      var dummyPower = new DummyPower("Crystallization",
        "Arcane Wells placed directly near Divine Citadels will generate mana for them over time. You can then convert that mana into units. The maximum number of Arcane Well around a Divine Citadel is 12 if placed optimally",
        "ManaGem.blp");
      AddPower(dummyPower);
    }
  }
}