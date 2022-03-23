using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

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
    public static Artifact? ArtifactScytheofelune { get; private set; }
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
      Artifact tempArtifact = 0;

      ArtifactCrownstormwind = Artifact.create(CreateItem(FourCC(I002), DUMMY_X, DUMMY_Y));
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("n021")), ArtifactCrownstormwind.item); //Hogger

      ArtifactEyeofsargeras = Artifact.create(CreateItem(FourCC(I003), DUMMY_X, DUMMY_Y)); //Eye of Sargeras
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("n04O_1571, ARTIFACT_HOLDER_ABIL")) //Doom Guard
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("n04O")), ArtifactEyeofsargeras.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00H), DUMMY_X, DUMMY_Y)); //Sulfuras
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("N00D_1457, ARTIFACT_HOLDER_ABIL")) //Ragnaros
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("N00D")), tempArtifact.item);
      tempArtifact.TitanforgedAbility = FourCC(A0VN);

      ArtifactHelmofdomination = Artifact.create(CreateItem(FourCC(I01Y), DUMMY_X, DUMMY_Y)); //Helm of Domination
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("u000_0649, ARTIFACT_HOLDER_ABIL")) //Frozen Throne
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("u000")), ArtifactHelmofdomination.item);

      ArtifactCrownlordaeron = Artifact.create(CreateItem(FourCC(I001), DUMMY_X, DUMMY_Y)); //Crown of Lordaeron
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nemi_0019, ARTIFACT_HOLDER_ABIL")) //King Terenas
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nemi")), ArtifactCrownlordaeron.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00D), DUMMY_X, DUMMY_Y)); //Shalamayne
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("n021")), tempArtifact.item); //Hogger

      tempArtifact = Artifact.create(CreateItem(FourCC(klmm), DUMMY_X, DUMMY_Y)); //Killmaim
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("H00E_1728, ARTIFACT_HOLDER_ABIL")) //Ramzes the Horror
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("H00E")), tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I004), -1480, -2240)); //The Doomhammer

      tempArtifact = Artifact.create(CreateItem(FourCC(I01V), -10330, 2105)); //Gorehowl

      ArtifactTrolkalar = Artifact.create(CreateItem(FourCC(I01O), DUMMY_X, DUMMY_Y)); //Trol)kalar
      ArtifactTrolkalar.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactTrolkalar.setDescription("Stormwind Quest");
      ArtifactTrolkalar.TitanforgedAbility = FourCC(A0VM);

      ArtifactScepterofthequeen = Artifact.create(CreateItem(FourCC(I00I), DUMMY_X, DUMMY_Y));
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("n085_2846, ARTIFACT_HOLDER_ABIL")) //The Atheneum
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("n085")), ArtifactScepterofthequeen.item);

      ArtifactBookofmedivh = Artifact.create(CreateItem(FourCC(I006), DUMMY_X, DUMMY_Y)); //Book of Medivh
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nbsm_1188, ARTIFACT_HOLDER_ABIL")) //Book of Medivh Pedestal
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nbsm")), ArtifactBookofmedivh.item);

      ArtifactSkullofguldan = Artifact.create(CreateItem(FourCC(I007), 21886, -25219)); //Skull of Gul)dan
      ArtifactSkullofguldan.setDescription("Illidan Quest");

      ArtifactZinrokh = Artifact.create(CreateItem(FourCC(I016), DUMMY_X, DUMMY_Y)); //Zin)rokh
      ArtifactZinrokh.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactZinrokh.setDescription("Assembled from its fragments");
      ArtifactZinrokh.TitanforgedAbility = FourCC(A0VM);

      tempArtifact = Artifact.create(CreateItem(FourCC(I01M), DUMMY_X, DUMMY_Y)); //Bronze Demon Soul Fragment
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O024_0567, ARTIFACT_HOLDER_ABIL")) //Ukorz
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O024")), tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I01L), DUMMY_X, DUMMY_Y)); //Black Demon Soul Fragment
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("o04E")), tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I01J), DUMMY_X, DUMMY_Y)); //Red Demon Soul Fragment
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O023_0517, ARTIFACT_HOLDER_ABIL")) //Jin)do
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O023")), tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I01I), DUMMY_X, DUMMY_Y)); //Blue Demon Soul Fragment
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O02C_2437, ARTIFACT_HOLDER_ABIL")) //Gal)darah
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O02C")), tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I01K), DUMMY_X, DUMMY_Y)); //Green Demon Soul Fragment
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O00O")), tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(arsh), DUMMY_X, DUMMY_Y)); //Shroud of Nozdormuru
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O025_3426, ARTIFACT_HOLDER_ABIL")) //Occulus
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O025")), tempArtifact.item);

      ArtifactDrektharsspellbook = Artifact.create(CreateItem(FourCC(dtsb), DUMMY_X, DUMMY_Y)); //Drek)thar)s Spellbook
      ArtifactDrektharsspellbook.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactDrektharsspellbook.setDescription("Frostwolf Quest");

      ArtifactSoulgem = Artifact.create(CreateItem(FourCC(gsou), DUMMY_X, DUMMY_Y));
      ArtifactSoulgem.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactSoulgem.setDescription("DalaranFourCC(s Quest");
      ArtifactSoulgem.falseX = -14269;
      ArtifactSoulgem.falseY = 22281;

      ArtifactGhanir = Artifact.create(CreateItem(FourCC(I00C), DUMMY_X, DUMMY_Y)); //G)hanir
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nbwd_0737, ARTIFACT_HOLDER_ABIL")) //Barrow Den
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nbwd")), ArtifactGhanir.item);

      ArtifactHornofcenarius = Artifact.create(CreateItem(FourCC(cnhn), DUMMY_X, DUMMY_Y));
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nhcn_2597, ARTIFACT_HOLDER_ABIL")) //Horn of Cenarius Pedestal
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nhcn")), ArtifactHornofcenarius.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(kgal), DUMMY_X, DUMMY_Y)); //Keg of Thunderwater
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("hmtm")), tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00J), DUMMY_X, DUMMY_Y)); //Felo)melorn
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("O00O")), tempArtifact.item); //Zuljin
      tempArtifact.TitanforgedAbility = FourCC(A0VN);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00K), DUMMY_X, DUMMY_Y)); //Essence
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("n03T")), tempArtifact.item); //Murmur

      ArtifactCrowneasternkingdoms = Artifact.create(CreateItem(FourCC(I00U), DUMMY_X, DUMMY_Y));
      ArtifactCrowneasternkingdoms.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactCrowneasternkingdoms.setDescription("Stormwind && Lordaeron Quest");

      ArtifactCrowntriumvirate = Artifact.create(CreateItem(FourCC(I011), DUMMY_X, DUMMY_Y));
      ArtifactCrowntriumvirate.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactCrowntriumvirate.setDescription("Draenei Quest");

      ArtifactScytheofelune = Artifact.create(CreateItem(FourCC(I00R), DUMMY_X, DUMMY_Y));
      UnitAddAbility(PreplacedUnitSystem.GetUnitByUnitType(FourCC("Hgam_1450, ARTIFACT_HOLDER_ABIL")) //Arugal
      UnitAddItem(PreplacedUnitSystem.GetUnitByUnitType(FourCC("Hgam")), ArtifactScytheofelune.item); //Arugal

      ArtifactThunderfury = Artifact.create(CreateItem(FourCC(I00Z), DUMMY_X, DUMMY_Y));
      ArtifactThunderfury.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactThunderfury.setDescription("Twilight HammerFourCC(s Quest");
      ArtifactThunderfury.falseX = -1649;
      ArtifactThunderfury.falseY = 7628;

      ArtifactLivingshadow = Artifact.create(CreateItem(FourCC(odef), DUMMY_X, DUMMY_Y));
      ArtifactLivingshadow.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactLivingshadow.setDescription("LordaeronFourCC(s Quest");
      ArtifactLivingshadow.falseX = -19525;
      ArtifactLivingshadow.falseY = -5192;

      ArtifactAshbringer = Artifact.create(CreateItem(FourCC(I012), DUMMY_X, DUMMY_Y));
      ArtifactAshbringer.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactAshbringer.setDescription("LordaeronFourCC(s Quest");
      ArtifactAshbringer.falseX = 10569;
      ArtifactAshbringer.falseY = -5280;

      ArtifactXalatath = Artifact.create(CreateItem(FourCC(I015), DUMMY_X, DUMMY_Y));
      ArtifactXalatath.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactXalatath.setDescription("Black EmpireFourCC(s Quest");
      ArtifactXalatath.falseX = 7121;
      ArtifactXalatath.falseY = 10000;

      ArtifactDemonsoul = Artifact.create(CreateItem(FourCC(I01A), DUMMY_X, DUMMY_Y));
      ArtifactDemonsoul.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactDemonsoul.setDescription("Ahn'qiraj's Quest");
      ArtifactDemonsoul.falseX = 12508;
      ArtifactDemonsoul.falseY = -11437;
    }
  }
}