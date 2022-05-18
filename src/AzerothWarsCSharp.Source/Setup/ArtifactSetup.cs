using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class ArtifactSetup
  {
    private const float DUMMY_X = 20195;
    private const float DUMMY_Y = 24177;

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

      ArtifactCrownstormwind = new Artifact(CreateItem(FourCC("I002"), DUMMY_X, DUMMY_Y));
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("n021")), ArtifactCrownstormwind.Item); //Hogger
      ArtifactSystem.Register(ArtifactCrownstormwind);

      ArtifactEyeofsargeras = new Artifact(CreateItem(FourCC("I003"), DUMMY_X, DUMMY_Y));
      var doomguard = PreplacedUnitSystem.GetUnit(FourCC("n04O"), new Point(-10028.1f, -23598.7f));
      UnitAddAbility(doomguard, Artifact.ArtifactHolderAbilId);
      UnitAddItem(doomguard, ArtifactEyeofsargeras.Item);
      ArtifactSystem.Register(ArtifactEyeofsargeras);

      tempArtifact = new Artifact(CreateItem(FourCC("I00H"), DUMMY_X, DUMMY_Y)); //Sulfuras
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("N00D_1457")), Artifact.ArtifactHolderAbilId); //Ragnaros
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("N00D")), tempArtifact.Item);
      tempArtifact.TitanforgedAbility = FourCC("A0VN");
      ArtifactSystem.Register(tempArtifact);

      ArtifactHelmofdomination = new Artifact(CreateItem(FourCC("I01Y"), DUMMY_X, DUMMY_Y)); //Helm of Domination
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("u000_0649")), Artifact.ArtifactHolderAbilId); //Frozen Throne
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("u000")), ArtifactHelmofdomination.Item);
      ArtifactSystem.Register(ArtifactHelmofdomination);

      ArtifactCrownlordaeron = new Artifact(CreateItem(FourCC("I001"), DUMMY_X, DUMMY_Y)); //Crown of Lordaeron
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("nemi_0019")), Artifact.ArtifactHolderAbilId); //King Terenas
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("nemi")), ArtifactCrownlordaeron.Item);
      ArtifactSystem.Register(ArtifactCrownlordaeron);

      tempArtifact = new Artifact(CreateItem(FourCC("I00D"), DUMMY_X, DUMMY_Y)); //Shalamayne
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("n021")), tempArtifact.Item); //Hogger
      ArtifactSystem.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("klmm"), DUMMY_X, DUMMY_Y)); //Killmaim
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("H00E_1728")),
        Artifact.ArtifactHolderAbilId); //Ramzes the Horror
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("H00E")), tempArtifact.Item);
      ArtifactSystem.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I004"), -1480, -2240)); //The Doomhammer
      ArtifactSystem.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I01V"), -10330, 2105)); //Gorehowl
      ArtifactSystem.Register(tempArtifact);

      ArtifactTrolkalar = new Artifact(CreateItem(FourCC("I01O"), DUMMY_X, DUMMY_Y))
      {
        Status = ArtifactStatus.Hidden,
        Description = "Stormwind Quest",
        TitanforgedAbility = FourCC("A0VM")
      };
      ArtifactSystem.Register(ArtifactTrolkalar);

      ArtifactScepterofthequeen = new Artifact(CreateItem(FourCC("I00I"), DUMMY_X, DUMMY_Y));
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("n085_2846")), Artifact.ArtifactHolderAbilId); //The Atheneum
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("n085")), ArtifactScepterofthequeen.Item);
      ArtifactSystem.Register(ArtifactScepterofthequeen);

      ArtifactBookofmedivh = new Artifact(CreateItem(FourCC("I006"), DUMMY_X, DUMMY_Y)); //Book of Medivh
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("nbsm_1188")),
        Artifact.ArtifactHolderAbilId); //Book of Medivh Pedestal
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("nbsm")), ArtifactBookofmedivh.Item);
      ArtifactSystem.Register(ArtifactBookofmedivh);

      ArtifactSkullofguldan = new Artifact(CreateItem(FourCC("I007"), 21886, -25219))
      {
        Description = "Illidan Quest"
      };
      ArtifactSystem.Register(ArtifactSkullofguldan);

      ArtifactZinrokh = new Artifact(CreateItem(FourCC("I016"), DUMMY_X, DUMMY_Y))
      {
        TitanforgedAbility = FourCC("A0VM")
      };

      tempArtifact = new Artifact(CreateItem(FourCC("I01M"), DUMMY_X, DUMMY_Y)); //Bronze Demon Soul Fragment
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("O024_0567")), Artifact.ArtifactHolderAbilId); //Ukorz
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O024")), tempArtifact.Item);
      ArtifactSystem.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I01L"), DUMMY_X, DUMMY_Y)); //Black Demon Soul Fragment
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("o04E")), tempArtifact.Item);
      ArtifactSystem.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I01J"), DUMMY_X, DUMMY_Y)); //Red Demon Soul Fragment
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("O023_0517")), Artifact.ArtifactHolderAbilId); //Jin)do
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O023")), tempArtifact.Item);
      ArtifactSystem.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I01I"), DUMMY_X, DUMMY_Y)); //Blue Demon Soul Fragment
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("O02C_2437")), Artifact.ArtifactHolderAbilId); //Gal)darah
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O02C")), tempArtifact.Item);
      ArtifactSystem.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I01K"), DUMMY_X, DUMMY_Y)); //Green Demon Soul Fragment
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O00O")), tempArtifact.Item);
      ArtifactSystem.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("arsh"), DUMMY_X, DUMMY_Y)); //Shroud of Nozdormuru
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("O025_3426")), Artifact.ArtifactHolderAbilId); //Occulus
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O025")), tempArtifact.Item);
      ArtifactSystem.Register(tempArtifact);

      ArtifactDrektharsspellbook = new Artifact(CreateItem(FourCC("dtsb"), DUMMY_X, DUMMY_Y))
      {
        Status = ArtifactStatus.Hidden,
        Description = "Frostwolf Quest"
      };
      ArtifactSystem.Register(ArtifactDrektharsspellbook);

      ArtifactSoulgem = new Artifact(CreateItem(FourCC("gsou"), DUMMY_X, DUMMY_Y))
      {
        Status = ArtifactStatus.Hidden,
        Description = "DalaranFourCC(s Quest",
        FalsePosition = new Point(-14269, 22282)
      };
      ArtifactSystem.Register(ArtifactSoulgem);

      ArtifactGhanir = new Artifact(CreateItem(FourCC("I00C"), DUMMY_X, DUMMY_Y)); //G)hanir
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("nbwd_0737")), Artifact.ArtifactHolderAbilId); //Barrow Den
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("nbwd")), ArtifactGhanir.Item);
      ArtifactSystem.Register(ArtifactGhanir);

      ArtifactHornofcenarius = new Artifact(CreateItem(FourCC("cnhn"), DUMMY_X, DUMMY_Y));
      UnitAddAbility(PreplacedUnitSystem.GetUnit(FourCC("nhcn_2597")),
        Artifact.ArtifactHolderAbilId); //Horn of Cenarius Pedestal
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("nhcn")), ArtifactHornofcenarius.Item);
      ArtifactSystem.Register(ArtifactHornofcenarius);

      tempArtifact = new Artifact(CreateItem(FourCC("kgal"), DUMMY_X, DUMMY_Y)); //Keg of Thunderwater
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("hmtm"), new Point(15109, -895)), tempArtifact.Item);
      ArtifactSystem.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I00J"), DUMMY_X, DUMMY_Y)); //Felo)melorn
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("O00O")), tempArtifact.Item); //Zuljin
      tempArtifact.TitanforgedAbility = FourCC("A0VN");
      ArtifactSystem.Register(tempArtifact);

      tempArtifact = new Artifact(CreateItem(FourCC("I00K"), DUMMY_X, DUMMY_Y)); //Essence
      UnitAddItem(PreplacedUnitSystem.GetUnit(FourCC("n03T")), tempArtifact.Item); //Murmur
      ArtifactSystem.Register(tempArtifact);

      ArtifactCrowneasternkingdoms = new Artifact(CreateItem(FourCC("I00U"), DUMMY_X, DUMMY_Y))
      {
        Status = ArtifactStatus.Hidden,
        Description = "Stormwind and Lordaeron Quest"
      };
      ArtifactSystem.Register(ArtifactCrowneasternkingdoms);

      ArtifactCrowntriumvirate = new Artifact(CreateItem(FourCC("I011"), DUMMY_X, DUMMY_Y))
      {
        Status = ArtifactStatus.Hidden,
        Description = "Draenei Quest"
      };
      ArtifactSystem.Register(ArtifactCrowntriumvirate);

      ArtifactThunderfury = new Artifact(CreateItem(FourCC("I00Z"), DUMMY_X, DUMMY_Y))
      {
        Status = ArtifactStatus.Hidden,
        Description = "Twilight Hammer's Quest",
        FalsePosition = new Point(-1649, 7628)
      };
      ArtifactSystem.Register(ArtifactThunderfury);

      ArtifactLivingshadow = new Artifact(CreateItem(FourCC("odef"), DUMMY_X, DUMMY_Y))
      {
        Status = ArtifactStatus.Hidden,
        Description = "Lordaeron's Quest",
        FalsePosition = new Point(-19525, -5192)
      };
      ArtifactSystem.Register(ArtifactLivingshadow);

      ArtifactAshbringer = new Artifact(CreateItem(FourCC("I012"), DUMMY_X, DUMMY_Y))
      {
        Status = ArtifactStatus.Hidden,
        Description = "Lordaeron's Quest",
        FalsePosition = new Point(10569, -5280)
      };
      ArtifactSystem.Register(ArtifactAshbringer);

      ArtifactXalatath = new Artifact(CreateItem(FourCC("I015"), DUMMY_X, DUMMY_Y))
      {
        Status = ArtifactStatus.Hidden,
        Description = "Black Empire's Quest",
        FalsePosition = new Point(7121, 10000)
      };
      ArtifactSystem.Register(ArtifactXalatath);

      ArtifactDemonsoul = new Artifact(CreateItem(FourCC("I01A"), DUMMY_X, DUMMY_Y))
      {
        Status = ArtifactStatus.Hidden,
        Description = "Ahn'qiraj's Quest",
        FalsePosition = new Point(12508, -11437)
      };
      ArtifactSystem.Register(ArtifactDemonsoul);
    }
  }
}