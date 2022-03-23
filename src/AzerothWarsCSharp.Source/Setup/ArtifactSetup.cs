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
      UnitAddItem(gg_unit_n021_2624, ArtifactCrownstormwind.item); //Hogger

      ArtifactEyeofsargeras = Artifact.create(CreateItem(FourCC(I003), DUMMY_X, DUMMY_Y)); //Eye of Sargeras
      UnitAddAbility(gg_unit_n04O_1571, ARTIFACT_HOLDER_ABIL_ID); //Doom Guard
      UnitAddItem(gg_unit_n04O_1571, ArtifactEyeofsargeras.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00H), DUMMY_X, DUMMY_Y)); //Sulfuras
      UnitAddAbility(gg_unit_N00D_1457, ARTIFACT_HOLDER_ABIL_ID); //Ragnaros
      UnitAddItem(gg_unit_N00D_1457, tempArtifact.item);
      tempArtifact.TitanforgedAbility = FourCC(A0VN);

      ArtifactHelmofdomination = Artifact.create(CreateItem(FourCC(I01Y), DUMMY_X, DUMMY_Y)); //Helm of Domination
      UnitAddAbility(gg_unit_u000_0649, ARTIFACT_HOLDER_ABIL_ID); //Frozen Throne
      UnitAddItem(gg_unit_u000_0649, ArtifactHelmofdomination.item);

      ArtifactCrownlordaeron = Artifact.create(CreateItem(FourCC(I001), DUMMY_X, DUMMY_Y)); //Crown of Lordaeron
      UnitAddAbility(gg_unit_nemi_0019, ARTIFACT_HOLDER_ABIL_ID); //King Terenas
      UnitAddItem(gg_unit_nemi_0019, ArtifactCrownlordaeron.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00D), DUMMY_X, DUMMY_Y)); //Shalamayne
      UnitAddItem(gg_unit_n021_2624, tempArtifact.item); //Hogger

      tempArtifact = Artifact.create(CreateItem(FourCC(klmm), DUMMY_X, DUMMY_Y)); //Killmaim
      UnitAddAbility(gg_unit_H00E_1728, ARTIFACT_HOLDER_ABIL_ID); //Ramzes the Horror
      UnitAddItem(gg_unit_H00E_1728, tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I004), -1480, -2240)); //The Doomhammer

      tempArtifact = Artifact.create(CreateItem(FourCC(I01V), -10330, 2105)); //Gorehowl

      ArtifactTrolkalar = Artifact.create(CreateItem(FourCC(I01O), DUMMY_X, DUMMY_Y)); //Trol)kalar
      ArtifactTrolkalar.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactTrolkalar.setDescription("Stormwind Quest");
      ArtifactTrolkalar.TitanforgedAbility = FourCC(A0VM);

      ArtifactScepterofthequeen = Artifact.create(CreateItem(FourCC(I00I), DUMMY_X, DUMMY_Y));
      UnitAddAbility(gg_unit_n085_2846, ARTIFACT_HOLDER_ABIL_ID); //The Atheneum
      UnitAddItem(gg_unit_n085_2846, ArtifactScepterofthequeen.item);

      ArtifactBookofmedivh = Artifact.create(CreateItem(FourCC(I006), DUMMY_X, DUMMY_Y)); //Book of Medivh
      UnitAddAbility(gg_unit_nbsm_1188, ARTIFACT_HOLDER_ABIL_ID); //Book of Medivh Pedestal
      UnitAddItem(gg_unit_nbsm_1188, ArtifactBookofmedivh.item);

      ArtifactSkullofguldan = Artifact.create(CreateItem(FourCC(I007), 21886, -25219)); //Skull of Gul)dan
      ArtifactSkullofguldan.setDescription("Illidan Quest");

      ArtifactZinrokh = Artifact.create(CreateItem(FourCC(I016), DUMMY_X, DUMMY_Y)); //Zin)rokh
      ArtifactZinrokh.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactZinrokh.setDescription("Assembled from its fragments");
      ArtifactZinrokh.TitanforgedAbility = FourCC(A0VM);

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

      ArtifactDrektharsspellbook = Artifact.create(CreateItem(FourCC(dtsb), DUMMY_X, DUMMY_Y)); //Drek)thar)s Spellbook
      ArtifactDrektharsspellbook.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactDrektharsspellbook.setDescription("Frostwolf Quest");

      ArtifactSoulgem = Artifact.create(CreateItem(FourCC(gsou), DUMMY_X, DUMMY_Y));
      ArtifactSoulgem.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactSoulgem.setDescription("DalaranFourCC(s Quest");
      ArtifactSoulgem.falseX = -14269;
      ArtifactSoulgem.falseY = 22281;

      ArtifactGhanir = Artifact.create(CreateItem(FourCC(I00C), DUMMY_X, DUMMY_Y)); //G)hanir
      UnitAddAbility(gg_unit_nbwd_0737, ARTIFACT_HOLDER_ABIL_ID); //Barrow Den
      UnitAddItem(gg_unit_nbwd_0737, ArtifactGhanir.item);

      ArtifactHornofcenarius = Artifact.create(CreateItem(FourCC(cnhn), DUMMY_X, DUMMY_Y));
      UnitAddAbility(gg_unit_nhcn_2597, ARTIFACT_HOLDER_ABIL_ID); //Horn of Cenarius Pedestal
      UnitAddItem(gg_unit_nhcn_2597, ArtifactHornofcenarius.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(kgal), DUMMY_X, DUMMY_Y)); //Keg of Thunderwater
      UnitAddItem(gg_unit_hmtm_2086, tempArtifact.item);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00J), DUMMY_X, DUMMY_Y)); //Felo)melorn
      UnitAddItem(gg_unit_O00O_1933, tempArtifact.item); //Zuljin
      tempArtifact.TitanforgedAbility = FourCC(A0VN);

      tempArtifact = Artifact.create(CreateItem(FourCC(I00K), DUMMY_X, DUMMY_Y)); //Essence
      UnitAddItem(gg_unit_n03T_0555, tempArtifact.item); //Murmur

      ArtifactCrowneasternkingdoms = Artifact.create(CreateItem(FourCC(I00U), DUMMY_X, DUMMY_Y));
      ArtifactCrowneasternkingdoms.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactCrowneasternkingdoms.setDescription("Stormwind && Lordaeron Quest");

      ArtifactCrowntriumvirate = Artifact.create(CreateItem(FourCC(I011), DUMMY_X, DUMMY_Y));
      ArtifactCrowntriumvirate.setStatus(ARTIFACT_STATUS_HIDDEN);
      ArtifactCrowntriumvirate.setDescription("Draenei Quest");

      ArtifactScytheofelune = Artifact.create(CreateItem(FourCC(I00R), DUMMY_X, DUMMY_Y));
      UnitAddAbility(gg_unit_Hgam_1450, ARTIFACT_HOLDER_ABIL_ID); //Arugal
      UnitAddItem(gg_unit_Hgam_1450, ArtifactScytheofelune.item); //Arugal

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