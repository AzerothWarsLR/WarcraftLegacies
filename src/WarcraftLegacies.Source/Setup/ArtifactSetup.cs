using MacroTools;
using MacroTools.ArtifactSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup
{
  public static class ArtifactSetup
  {
    private const float DummyX = 20195;
    private const float DummyY = 24177;

    public static Artifact? ArtifactGhanir { get; private set; }
    public static Artifact? ArtifactSkullofguldan { get; private set; }
    public static Artifact? ArtifactCrownlordaeron { get; private set; }
    public static Artifact? ArtifactCrownstormwind { get; private set; }
    public static Artifact? ArtifactHelmofdomination { get; private set; }
    public static Artifact? ArtifactDrektharsspellbook { get; private set; }
    public static Artifact? ArtifactScepterofthequeen { get; private set; }
    public static Artifact? BookOfMedivh { get; private set; }
    public static Artifact? ArtifactSoulgem { get; private set; }
    public static Artifact? ArtifactHornofcenarius { get; private set; }
    public static Artifact? ArtifactEyeofsargeras { get; private set; }
    public static Artifact? ArtifactCrowneasternkingdoms { get; private set; }
    public static Artifact? ArtifactCrowntriumvirate { get; private set; }
    public static Artifact? ArtifactTrolkalar { get; private set; }
    public static Artifact? ArtifactDemonsoul { get; private set; }
    public static Artifact? ArtifactThunderfury { get; private set; }
    public static Artifact? ArtifactLivingshadow { get; private set; }
    public static Artifact? ArtifactAshbringer { get; private set; }
    public static Artifact? ArtifactXalatath { get; private set; }
    public static Artifact? ArtifactZinrokh { get; private set; }
    public static Artifact? ScytheOfElune { get; private set; }
    public static Artifact? AzureFragment { get; private set; }
    public static Artifact? EmeraldFragment { get; private set; }
    public static Artifact? RubyFragment { get; private set; }
    public static Artifact? ObsidianFragment { get; private set; }
    public static Artifact? BronzeFragment { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Artifact tempArtifact;

      ArtifactCrownstormwind = new Artifact(CreateItem(FourCC("I002"), DummyX, DummyY));
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("n021")), ArtifactCrownstormwind.Item); //Hogger
      ArtifactManager.Register(ArtifactCrownstormwind);

      ArtifactEyeofsargeras = new Artifact(CreateItem(FourCC("I003"), DummyX, DummyY));
      var doomguard = preplacedUnitSystem.GetUnit(FourCC("n04O"), new Point(-10028.1f, -23598.7f));
      UnitAddAbility(doomguard, Artifact.ArtifactHolderAbilId);
      UnitAddItem(doomguard, ArtifactEyeofsargeras.Item);
      ArtifactManager.Register(ArtifactEyeofsargeras);

      tempArtifact = new Artifact(CreateItem(FourCC("I00H"), DummyX, DummyY)); //Sulfuras
      UnitAddAbility(preplacedUnitSystem.GetUnit(FourCC("N00D_1457")), Artifact.ArtifactHolderAbilId); //Ragnaros
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("N00D")), tempArtifact.Item);
      tempArtifact.TitanforgedAbility = FourCC("A0VN");
      ArtifactManager.Register(tempArtifact);

      ArtifactHelmofdomination = new Artifact(CreateItem(FourCC("I01Y"), DummyX, DummyY)); //Helm of Domination
      UnitAddAbility(preplacedUnitSystem.GetUnit(FourCC("u000_0649")), Artifact.ArtifactHolderAbilId); //Frozen Throne
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("u000")), ArtifactHelmofdomination.Item);
      ArtifactManager.Register(ArtifactHelmofdomination);

      ArtifactCrownlordaeron = new Artifact(CreateItem(FourCC("I001"), DummyX, DummyY)); //Crown of Lordaeron
      UnitAddAbility(preplacedUnitSystem.GetUnit(FourCC("nemi_0019")), Artifact.ArtifactHolderAbilId); //King Terenas
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("nemi")), ArtifactCrownlordaeron.Item);
      ArtifactManager.Register(ArtifactCrownlordaeron);

      tempArtifact = new Artifact(CreateItem(FourCC("I00D"), DummyX, DummyY)); //Shalamayne
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("n021")), tempArtifact.Item); //Hogger
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("klmm"), DummyX, DummyY)); //Killmaim
      UnitAddAbility(preplacedUnitSystem.GetUnit(FourCC("H00E_1728")),
        Artifact.ArtifactHolderAbilId); //Ramzes the Horror
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("H00E")), tempArtifact.Item);
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I004"), -1480, -2240)); //The Doomhammer
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(Constants.ITEM_I01V_GOREHOWL, -10330, 2105));
      ArtifactManager.Register(tempArtifact);

      ArtifactTrolkalar = new Artifact(CreateItem(FourCC("I01O"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "Stormwind Quest",
        TitanforgedAbility = FourCC("A0VM")
      };
      ArtifactManager.Register(ArtifactTrolkalar);

      ArtifactScepterofthequeen = new Artifact(CreateItem(FourCC("I00I"), DummyX, DummyY));
      UnitAddAbility(preplacedUnitSystem.GetUnit(FourCC("n085_2846")), Artifact.ArtifactHolderAbilId); //The Atheneum
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("n085")), ArtifactScepterofthequeen.Item);
      ArtifactManager.Register(ArtifactScepterofthequeen);

      BookOfMedivh = new Artifact(CreateItem(FourCC("I006"), DummyX, DummyY)); //Book of Medivh
      UnitAddAbility(preplacedUnitSystem.GetUnit(FourCC("nbsm_1188")),
        Artifact.ArtifactHolderAbilId); //Book of Medivh Pedestal
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("nbsm")), BookOfMedivh.Item);
      ArtifactManager.Register(BookOfMedivh);

      ArtifactSkullofguldan = new Artifact(CreateItem(FourCC("I007"), 21886, -25219))
      {
        LocationDescription = "Illidan Quest"
      };
      ArtifactManager.Register(ArtifactSkullofguldan);

      ArtifactZinrokh = new Artifact(CreateItem(FourCC("I016"), DummyX, DummyY))
      {
        TitanforgedAbility = FourCC("A0VM")
      };

      BronzeFragment = new Artifact(CreateItem(Constants.ITEM_I01M_BRONZE_FRAGMENT, DummyX, DummyY));
      UnitAddAbility(preplacedUnitSystem.GetUnit(Constants.UNIT_O024_CHIEFTAN_OF_THE_SANDFURY_TRIBE_CREEP_ZUL_FARRAK), Artifact.ArtifactHolderAbilId);
      UnitAddItem(preplacedUnitSystem.GetUnit(Constants.UNIT_O024_CHIEFTAN_OF_THE_SANDFURY_TRIBE_CREEP_ZUL_FARRAK), BronzeFragment.Item);
      ArtifactManager.Register(BronzeFragment);

      ObsidianFragment = new Artifact(CreateItem(Constants.ITEM_I01L_OBSIDIAN_FRAGMENT, DummyX, DummyY));
      UnitAddItem(preplacedUnitSystem.GetUnit(Constants.UNIT_O04E_BONESEER_TROLL), ObsidianFragment.Item);
      ArtifactManager.Register(ObsidianFragment);

      RubyFragment = new Artifact(CreateItem(Constants.ITEM_I01J_RUBY_FRAGMENT, DummyX, DummyY));
      UnitAddAbility(preplacedUnitSystem.GetUnit(Constants.UNIT_O023_WITCH_DOCTOR_OF_THE_GURUBIAN_TRIBE_CREEP_ZUL_GURUB), Artifact.ArtifactHolderAbilId); //Jin)do
      UnitAddItem(preplacedUnitSystem.GetUnit(Constants.UNIT_O023_WITCH_DOCTOR_OF_THE_GURUBIAN_TRIBE_CREEP_ZUL_GURUB), RubyFragment.Item);
      ArtifactManager.Register(RubyFragment);

      AzureFragment = new Artifact(CreateItem(Constants.ITEM_I01I_AZURE_FRAGMENT, DummyX, DummyY));
      UnitAddAbility(preplacedUnitSystem.GetUnit(Constants.UNIT_O02C_HIGH_PROPHET_OF_AKALI_CREEP_ZUL_DRAK), Artifact.ArtifactHolderAbilId);
      UnitAddItem(preplacedUnitSystem.GetUnit(Constants.UNIT_O02C_HIGH_PROPHET_OF_AKALI_CREEP_ZUL_DRAK), AzureFragment.Item);
      ArtifactManager.Register(AzureFragment);

      EmeraldFragment = new Artifact(CreateItem(Constants.ITEM_I01K_EMERALD_FRAGMENT, DummyX, DummyY));
      UnitAddItem(preplacedUnitSystem.GetUnit(Constants.UNIT_O00O_CHIEFTAN_OF_THE_AMANI_TRIBE_CREEP_ZUL_AMAN), EmeraldFragment.Item);
      ArtifactManager.Register(EmeraldFragment);

      tempArtifact = new Artifact(CreateItem(FourCC("arsh"), DummyX, DummyY)); //Shroud of Nozdormuru
      UnitAddAbility(preplacedUnitSystem.GetUnit(FourCC("O025_3426")), Artifact.ArtifactHolderAbilId); //Occulus
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("O025")), tempArtifact.Item);
      ArtifactManager.Register(tempArtifact);

      ArtifactDrektharsspellbook = new Artifact(CreateItem(FourCC("dtsb"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "Frostwolf Quest"
      };
      ArtifactManager.Register(ArtifactDrektharsspellbook);

      ArtifactSoulgem = new Artifact(CreateItem(FourCC("gsou"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "DalaranFourCC(s Quest",
        FalsePosition = new Point(-14269, 22282)
      };
      ArtifactManager.Register(ArtifactSoulgem);

      ArtifactGhanir = new Artifact(CreateItem(FourCC("I00C"), DummyX, DummyY)); //G)hanir
      UnitAddAbility(preplacedUnitSystem.GetUnit(FourCC("nbwd_0737")), Artifact.ArtifactHolderAbilId); //Barrow Den
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("nbwd")), ArtifactGhanir.Item);
      ArtifactManager.Register(ArtifactGhanir);

      ArtifactHornofcenarius = new Artifact(CreateItem(FourCC("cnhn"), DummyX, DummyY));
      UnitAddAbility(preplacedUnitSystem.GetUnit(FourCC("nhcn_2597")),
        Artifact.ArtifactHolderAbilId); //Horn of Cenarius Pedestal
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("nhcn")), ArtifactHornofcenarius.Item);
      ArtifactManager.Register(ArtifactHornofcenarius);

      tempArtifact = new Artifact(CreateItem(FourCC("kgal"), DummyX, DummyY)); //Keg of Thunderwater
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("hmtm"), new Point(15109, -895)), tempArtifact.Item);
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I00J"), DummyX, DummyY)); //Felo)melorn
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("O00O")), tempArtifact.Item); //Zuljin
      tempArtifact.TitanforgedAbility = FourCC("A0VN");
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I00K"), DummyX, DummyY)); //Essence
      UnitAddItem(preplacedUnitSystem.GetUnit(FourCC("n03T")), tempArtifact.Item); //Murmur
      ArtifactManager.Register(tempArtifact);

      ArtifactCrowneasternkingdoms = new Artifact(CreateItem(FourCC("I00U"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "Stormwind and Lordaeron Quest"
      };
      ArtifactManager.Register(ArtifactCrowneasternkingdoms);

      ArtifactCrowntriumvirate = new Artifact(CreateItem(FourCC("I011"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "Draenei Quest"
      };
      ArtifactManager.Register(ArtifactCrowntriumvirate);

      ArtifactThunderfury = new Artifact(CreateItem(FourCC("I00Z"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "Twilight Hammer's Quest",
        FalsePosition = new Point(-1649, 7628)
      };
      ArtifactManager.Register(ArtifactThunderfury);

      ArtifactLivingshadow = new Artifact(CreateItem(FourCC("odef"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "Lordaeron's Quest",
        FalsePosition = new Point(-19525, -5192)
      };
      ArtifactManager.Register(ArtifactLivingshadow);

      ArtifactAshbringer = new Artifact(CreateItem(FourCC("I012"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "Lordaeron's Quest",
        FalsePosition = new Point(10569, -5280)
      };
      ArtifactManager.Register(ArtifactAshbringer);

      ArtifactXalatath = new Artifact(CreateItem(FourCC("I015"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "Black Empire's Quest",
        FalsePosition = new Point(7121, 10000)
      };
      ArtifactManager.Register(ArtifactXalatath);

      ArtifactDemonsoul = new Artifact(CreateItem(FourCC("I01A"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "Ahn'qiraj's Quest",
        FalsePosition = new Point(12508, -11437)
      };
      ArtifactManager.Register(ArtifactDemonsoul);

      ScytheOfElune = new Artifact(CreateItem(Constants.ITEM_I00R_SCYTHE_OF_ELUNE, DummyX, DummyX));
      var worgenBloodShamanHero = preplacedUnitSystem.GetUnit(Constants.UNIT_O038_WORGEN_BLOOD_SHAMAN_WORGEN_HERO,
        new Point(5410.7f, 2499.0f));
      UnitAddAbility(worgenBloodShamanHero, Artifact.ArtifactHolderAbilId);
      UnitAddItem(worgenBloodShamanHero, ScytheOfElune.Item);
      ArtifactManager.Register(ScytheOfElune);
    }
  }
}