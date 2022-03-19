using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup
{
  public static class ArtifactSetup
  {
    private const float DUMMY_X = 20195;
    private const float DUMMY_Y = 24177;

    public static Artifact? artifactGhanir;
    public static Artifact? artifactSkullofguldan;
    public static Artifact? artifactCrownlordaeron;
    public static Artifact? artifactCrownstormwind;
    public static Artifact? artifactHelmofdomination;
    public static Artifact? artifactDrektharsspellbook;
    public static Artifact? artifactScepterofthequeen;
    public static Artifact? artifactScytheofelune;
    public static Artifact? artifactBookofmedivh;
    public static Artifact? artifactSoulgem;
    public static Artifact? artifactHornofcenarius;
    public static Artifact? artifactEyeofsargeras;
    public static Artifact? artifactCrowneasternkingdoms;
    public static Artifact? artifactCrowntriumvirate;
    public static Artifact? artifactTrolkalar;
    public static Artifact? artifactDemonsoul;
    public static Artifact? artifactThunderfury;
    public static Artifact? artifactLivingshadow;
    public static Artifact? artifactAshbringer;
    public static Artifact? artifactXalatath;
    public static Artifact? artifactZinrokh;

    public static void Setup()
    {
      Artifact tempArtifact = 0;

      artifactCrownstormwind = Artifact.create(CreateItem(FourCC(I002), DUMMY_X, DUMMY_Y));
      UnitAddItem(gg_unit_n021_2624, artifactCrownstormwind.item); //Hogger

      artifactEyeofsargeras = Artifact.create(CreateItem(FourCC(I003), DUMMY_X, DUMMY_Y)); //Eye of Sargeras
      UnitAddAbility(gg_unit_n04O_1571, ARTIFACT_HOLDER_ABIL_ID); //Doom Guard
      UnitAddItem(gg_unit_n04O_1571, artifactEyeofsargeras.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00H), DUMMY_X, DUMMY_Y)); //Sulfuras
      UnitAddAbility(gg_unit_N00D_1457, ARTIFACT_HOLDER_ABIL_ID); //Ragnaros
      UnitAddItem(gg_unit_N00D_1457, tempArtifact.item);
      tempArtifact.TitanforgedAbility = FourCC(A0VN);

      artifactHelmofdomination = Artifact.create(CreateItem(FourCC(I01Y), DUMMY_X, DUMMY_Y)); //Helm of Domination
      UnitAddAbility(gg_unit_u000_0649, ARTIFACT_HOLDER_ABIL_ID); //Frozen Throne
      UnitAddItem(gg_unit_u000_0649, artifactHelmofdomination.item);

      artifactCrownlordaeron = Artifact.create(CreateItem(FourCC(I001), DUMMY_X, DUMMY_Y)); //Crown of Lordaeron
      UnitAddAbility(gg_unit_nemi_0019, ARTIFACT_HOLDER_ABIL_ID); //King Terenas
      UnitAddItem(gg_unit_nemi_0019, artifactCrownlordaeron.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00D), DUMMY_X, DUMMY_Y)); //Shalamayne
      UnitAddItem(gg_unit_n021_2624, tempArtifact.item); //Hogger

      tempArtifact = Artifact.create(CreateItem(FourCC(klmm), DUMMY_X, DUMMY_Y)); //Killmaim
      UnitAddAbility(gg_unit_H00E_1728, ARTIFACT_HOLDER_ABIL_ID); //Ramzes the Horror
      UnitAddItem(gg_unit_H00E_1728, tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I004), -1480, -2240)); //The Doomhammer

      tempArtifact = Artifact.create(CreateItem(FourCC(I01V), -10330, 2105)); //Gorehowl

      artifactTrolkalar = Artifact.create(CreateItem(FourCC(I01O), DUMMY_X, DUMMY_Y)); //Trol)kalar
      artifactTrolkalar.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactTrolkalar.setDescription("Stormwind Quest");
      artifactTrolkalar.TitanforgedAbility = FourCC(A0VM);

      artifactScepterofthequeen = Artifact.create(CreateItem(FourCC(I00I), DUMMY_X, DUMMY_Y));
      UnitAddAbility(gg_unit_n085_2846, ARTIFACT_HOLDER_ABIL_ID); //The Atheneum
      UnitAddItem(gg_unit_n085_2846, artifactScepterofthequeen.item);

      artifactBookofmedivh = Artifact.create(CreateItem(FourCC(I006), DUMMY_X, DUMMY_Y)); //Book of Medivh
      UnitAddAbility(gg_unit_nbsm_1188, ARTIFACT_HOLDER_ABIL_ID); //Book of Medivh Pedestal
      UnitAddItem(gg_unit_nbsm_1188, artifactBookofmedivh.item);

      artifactSkullofguldan = Artifact.create(CreateItem(FourCC(I007), 21886, -25219)); //Skull of Gul)dan
      artifactSkullofguldan.setDescription("Illidan Quest");

      artifactZinrokh = Artifact.create(CreateItem(FourCC(I016), DUMMY_X, DUMMY_Y)); //Zin)rokh
      artifactZinrokh.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactZinrokh.setDescription("Assembled from its fragments");
      artifactZinrokh.TitanforgedAbility = FourCC(A0VM);

      tempArtifact = Artifact.create(CreateItem(FourCC(I01M), DUMMY_X, DUMMY_Y)); //Bronze Demon Soul Fragment
      UnitAddAbility(gg_unit_O024_0567, ARTIFACT_HOLDER_ABIL_ID); //Ukorz
      UnitAddItem(gg_unit_O024_0567, tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I01L), DUMMY_X, DUMMY_Y)); //Black Demon Soul Fragment
      UnitAddItem(gg_unit_o04E_1559, tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I01J), DUMMY_X, DUMMY_Y)); //Red Demon Soul Fragment
      UnitAddAbility(gg_unit_O023_0517, ARTIFACT_HOLDER_ABIL_ID); //Jin)do
      UnitAddItem(gg_unit_O023_0517, tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I01I), DUMMY_X, DUMMY_Y)); //Blue Demon Soul Fragment
      UnitAddAbility(gg_unit_O02C_2437, ARTIFACT_HOLDER_ABIL_ID); //Gal)darah
      UnitAddItem(gg_unit_O02C_2437, tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I01K), DUMMY_X, DUMMY_Y)); //Green Demon Soul Fragment
      UnitAddItem(gg_unit_O00O_1933, tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(arsh), DUMMY_X, DUMMY_Y)); //Shroud of Nozdormuru
      UnitAddAbility(gg_unit_O025_3426, ARTIFACT_HOLDER_ABIL_ID); //Occulus
      UnitAddItem(gg_unit_O025_3426, tempArtifact.item);

      artifactDrektharsspellbook = Artifact.create(CreateItem(FourCC(dtsb), DUMMY_X, DUMMY_Y)); //Drek)thar)s Spellbook
      artifactDrektharsspellbook.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactDrektharsspellbook.setDescription("Frostwolf Quest");

      artifactSoulgem = Artifact.create(CreateItem(FourCC(gsou), DUMMY_X, DUMMY_Y));
      artifactSoulgem.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactSoulgem.setDescription("DalaranFourCC(s Quest");
      artifactSoulgem.falseX = -14269;
      artifactSoulgem.falseY = 22281;

      artifactGhanir = Artifact.create(CreateItem(FourCC(I00C), DUMMY_X, DUMMY_Y)); //G)hanir
      UnitAddAbility(gg_unit_nbwd_0737, ARTIFACT_HOLDER_ABIL_ID); //Barrow Den
      UnitAddItem(gg_unit_nbwd_0737, artifactGhanir.item);

      artifactHornofcenarius = Artifact.create(CreateItem(FourCC(cnhn), DUMMY_X, DUMMY_Y));
      UnitAddAbility(gg_unit_nhcn_2597, ARTIFACT_HOLDER_ABIL_ID); //Horn of Cenarius Pedestal
      UnitAddItem(gg_unit_nhcn_2597, artifactHornofcenarius.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(kgal), DUMMY_X, DUMMY_Y)); //Keg of Thunderwater
      UnitAddItem(gg_unit_hmtm_2086, tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00J), DUMMY_X, DUMMY_Y)); //Felo)melorn
      UnitAddItem(gg_unit_O00O_1933, tempArtifact.item); //Zuljin
      tempArtifact.TitanforgedAbility = FourCC(A0VN);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00K), DUMMY_X, DUMMY_Y)); //Essence
      UnitAddItem(gg_unit_n03T_0555, tempArtifact.item); //Murmur

      artifactCrowneasternkingdoms = Artifact.create(CreateItem(FourCC(I00U), DUMMY_X, DUMMY_Y));
      artifactCrowneasternkingdoms.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactCrowneasternkingdoms.setDescription("Stormwind && Lordaeron Quest");

      artifactCrowntriumvirate = Artifact.create(CreateItem(FourCC(I011), DUMMY_X, DUMMY_Y));
      artifactCrowntriumvirate.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactCrowntriumvirate.setDescription("Draenei Quest");

      artifactScytheofelune = Artifact.create(CreateItem(FourCC(I00R), DUMMY_X, DUMMY_Y));
      UnitAddAbility(gg_unit_Hgam_1450, ARTIFACT_HOLDER_ABIL_ID); //Arugal
      UnitAddItem(gg_unit_Hgam_1450, artifactScytheofelune.item); //Arugal

      artifactThunderfury = Artifact.create(CreateItem(FourCC(I00Z), DUMMY_X, DUMMY_Y));
      artifactThunderfury.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactThunderfury.setDescription("Twilight HammerFourCC(s Quest");
      artifactThunderfury.falseX = -1649;
      artifactThunderfury.falseY = 7628;

      artifactLivingshadow = Artifact.create(CreateItem(FourCC(odef), DUMMY_X, DUMMY_Y));
      artifactLivingshadow.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactLivingshadow.setDescription("LordaeronFourCC(s Quest");
      artifactLivingshadow.falseX = -19525;
      artifactLivingshadow.falseY = -5192;

      artifactAshbringer = Artifact.create(CreateItem(FourCC(I012), DUMMY_X, DUMMY_Y));
      artifactAshbringer.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactAshbringer.setDescription("LordaeronFourCC(s Quest");
      artifactAshbringer.falseX = 10569;
      artifactAshbringer.falseY = -5280;

      artifactXalatath = Artifact.create(CreateItem(FourCC(I015), DUMMY_X, DUMMY_Y));
      artifactXalatath.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactXalatath.setDescription("Black EmpireFourCC(s Quest");
      artifactXalatath.falseX = 7121;
      artifactXalatath.falseY = 10000;

      artifactDemonsoul = Artifact.create(CreateItem(FourCC(I01A), DUMMY_X, DUMMY_Y));
      artifactDemonsoul.setStatus(ARTIFACT_STATUS_HIDDEN);
      artifactDemonsoul.setDescription("Ahn'qiraj)s Quest");
      artifactDemonsoul.falseX = 12508;
      artifactDemonsoul.falseY = -11437;
    }
  }
}