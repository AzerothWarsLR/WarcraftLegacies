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
    public static Artifact? ArtifactBookofmedivh { get; private set; }
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

    public static void Setup()
    {
      Artifact tempArtifact;

      ArtifactCrownstormwind = new Artifact(CreateItem(FourCC("I002"), DummyX, DummyY));
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("n021")), ArtifactCrownstormwind.Item); //Hogger
      ArtifactManager.Register(ArtifactCrownstormwind);

      ArtifactEyeofsargeras = new Artifact(CreateItem(FourCC("I003"), DummyX, DummyY));
      var doomguard = PreplacedUnitSystem.GetUnit(FourCC("n04O"), new Point(-10028.1f, -23598.7f));
      UnitAddAbility(doomguard, Artifact.ArtifactHolderAbilId);
      UnitAddItem(doomguard, ArtifactEyeofsargeras.Item);
      ArtifactManager.Register(ArtifactEyeofsargeras);

      tempArtifact = new Artifact(CreateItem(FourCC("I00H"), DummyX, DummyY)); //Sulfuras
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("N00D_1457")), Artifact.ArtifactHolderAbilId); //Ragnaros
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("N00D")), tempArtifact.Item);
      tempArtifact.TitanforgedAbility = FourCC("A0VN");
      ArtifactManager.Register(tempArtifact);

      ArtifactHelmofdomination = new Artifact(CreateItem(FourCC("I01Y"), DummyX, DummyY)); //Helm of Domination
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("u000_0649")), Artifact.ArtifactHolderAbilId); //Frozen Throne
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("u000")), ArtifactHelmofdomination.Item);
      ArtifactManager.Register(ArtifactHelmofdomination);

      ArtifactCrownlordaeron = new Artifact(CreateItem(FourCC("I001"), DummyX, DummyY)); //Crown of Lordaeron
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("nemi_0019")), Artifact.ArtifactHolderAbilId); //King Terenas
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("nemi")), ArtifactCrownlordaeron.Item);
      ArtifactManager.Register(ArtifactCrownlordaeron);

      tempArtifact = new Artifact(CreateItem(FourCC("I00D"), DummyX, DummyY)); //Shalamayne
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("n021")), tempArtifact.Item); //Hogger
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("klmm"), DummyX, DummyY)); //Killmaim
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("H00E_1728")),
        Artifact.ArtifactHolderAbilId); //Ramzes the Horror
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("H00E")), tempArtifact.Item);
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I004"), -1480, -2240)); //The Doomhammer
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I01V"), -10330, 2105)); //Gorehowl
      ArtifactManager.Register(tempArtifact);

      ArtifactTrolkalar = new Artifact(CreateItem(FourCC("I01O"), DummyX, DummyY))
      {
        LocationType = ArtifactLocationType.Hidden,
        LocationDescription = "Stormwind Quest",
        TitanforgedAbility = FourCC("A0VM")
      };
      ArtifactManager.Register(ArtifactTrolkalar);

      ArtifactScepterofthequeen = new Artifact(CreateItem(FourCC("I00I"), DummyX, DummyY));
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("n085_2846")), Artifact.ArtifactHolderAbilId); //The Atheneum
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("n085")), ArtifactScepterofthequeen.Item);
      ArtifactManager.Register(ArtifactScepterofthequeen);

      ArtifactBookofmedivh = new Artifact(CreateItem(FourCC("I006"), DummyX, DummyY)); //Book of Medivh
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("nbsm_1188")),
        Artifact.ArtifactHolderAbilId); //Book of Medivh Pedestal
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("nbsm")), ArtifactBookofmedivh.Item);
      ArtifactManager.Register(ArtifactBookofmedivh);

      ArtifactSkullofguldan = new Artifact(CreateItem(FourCC("I007"), 21886, -25219))
      {
        LocationDescription = "Illidan Quest"
      };
      ArtifactManager.Register(ArtifactSkullofguldan);

      ArtifactZinrokh = new Artifact(CreateItem(FourCC("I016"), DummyX, DummyY))
      {
        TitanforgedAbility = FourCC("A0VM")
      };

      tempArtifact = new Artifact(CreateItem(FourCC("I01M"), DummyX, DummyY)); //Bronze Demon Soul Fragment
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("O024_0567")), Artifact.ArtifactHolderAbilId); //Ukorz
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O024")), tempArtifact.Item);
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I01L"), DummyX, DummyY)); //Black Demon Soul Fragment
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("o04E")), tempArtifact.Item);
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I01J"), DummyX, DummyY)); //Red Demon Soul Fragment
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("O023_0517")), Artifact.ArtifactHolderAbilId); //Jin)do
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O023")), tempArtifact.Item);
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I01I"), DummyX, DummyY)); //Blue Demon Soul Fragment
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("O02C_2437")), Artifact.ArtifactHolderAbilId); //Gal)darah
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O02C")), tempArtifact.Item);
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I01K"), DummyX, DummyY)); //Green Demon Soul Fragment
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O00O")), tempArtifact.Item);
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("arsh"), DummyX, DummyY)); //Shroud of Nozdormuru
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("O025_3426")), Artifact.ArtifactHolderAbilId); //Occulus
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O025")), tempArtifact.Item);
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
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("nbwd_0737")), Artifact.ArtifactHolderAbilId); //Barrow Den
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("nbwd")), ArtifactGhanir.Item);
      ArtifactManager.Register(ArtifactGhanir);

      ArtifactHornofcenarius = new Artifact(CreateItem(FourCC("cnhn"), DummyX, DummyY));
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("nhcn_2597")),
        Artifact.ArtifactHolderAbilId); //Horn of Cenarius Pedestal
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("nhcn")), ArtifactHornofcenarius.Item);
      ArtifactManager.Register(ArtifactHornofcenarius);

      tempArtifact = new Artifact(CreateItem(FourCC("kgal"), DummyX, DummyY)); //Keg of Thunderwater
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("hmtm"), new Point(15109, -895)), tempArtifact.Item);
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I00J"), DummyX, DummyY)); //Felo)melorn
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O00O")), tempArtifact.Item); //Zuljin
      tempArtifact.TitanforgedAbility = FourCC("A0VN");
      ArtifactManager.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I00K"), DummyX, DummyY)); //Essence
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("n03T")), tempArtifact.Item); //Murmur
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
    }
  }
}