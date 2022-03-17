public class ArtifactSetup{

  
    private const float DUMMY_X = 20195;
    private const float DUMMY_Y = 24177;

    Artifact ARTIFACT_GHANIR
    Artifact ARTIFACT_SKULLOFGULDAN
    Artifact ARTIFACT_CROWNLORDAERON
    Artifact ARTIFACT_CROWNSTORMWIND
    Artifact ARTIFACT_HELMOFDOMINATION
    Artifact ARTIFACT_DREKTHARSSPELLBOOK
    Artifact ARTIFACT_SCEPTEROFTHEQUEEN
    Artifact ARTIFACT_SCYTHEOFELUNE
    Artifact ARTIFACT_BOOKOFMEDIVH
    Artifact ARTIFACT_SOULGEM
    Artifact ARTIFACT_HORNOFCENARIUS
    Artifact ARTIFACT_EYEOFSARGERAS
    Artifact ARTIFACT_CROWNEASTERNKINGDOMS
    Artifact ARTIFACT_CROWNTRIUMVIRATE
    Artifact ARTIFACT_TROLKALAR
    Artifact ARTIFACT_DEMONSOUL
    Artifact ARTIFACT_THUNDERFURY
    Artifact ARTIFACT_LIVINGSHADOW
    Artifact ARTIFACT_ASHBRINGER
    Artifact ARTIFACT_XALATATH
    Artifact ARTIFACT_ZINROKH
  

  public static void OnInit( ){
    Artifact tempArtifact = 0;

    ARTIFACT_CROWNSTORMWIND = Artifact.create(CreateItem(FourCC(I002), DUMMY_X, DUMMY_Y));
    UnitAddItem(gg_unit_n021_2624, ARTIFACT_CROWNSTORMWIND.item)                      ;//Hogger

    ARTIFACT_EYEOFSARGERAS = Artifact.create(CreateItem(FourCC(I003), DUMMY_X, DUMMY_Y))    ;//Eye of Sargeras
    UnitAddAbility(gg_unit_n04O_1571, ARTIFACT_HOLDER_ABIL_ID)             ;//Doom Guard
    UnitAddItem(gg_unit_n04O_1571, ARTIFACT_EYEOFSARGERAS.item);

    tempArtifact = Artifact.create(CreateItem(FourCC(I00H), DUMMY_X, DUMMY_Y))    ;//Sulfuras
    UnitAddAbility(gg_unit_N00D_1457, ARTIFACT_HOLDER_ABIL_ID)             ;//Ragnaros
    UnitAddItem(gg_unit_N00D_1457, tempArtifact.item);
    tempArtifact.TitanforgedAbility = FourCC(A0VN);

    ARTIFACT_HELMOFDOMINATION = Artifact.create(CreateItem(FourCC(I01Y), DUMMY_X, DUMMY_Y))    ;//Helm of Domination
    UnitAddAbility(gg_unit_u000_0649, ARTIFACT_HOLDER_ABIL_ID)                          ;//Frozen Throne
    UnitAddItem(gg_unit_u000_0649, ARTIFACT_HELMOFDOMINATION.item);

    ARTIFACT_CROWNLORDAERON = Artifact.create(CreateItem(FourCC(I001), DUMMY_X, DUMMY_Y)) ;//Crown of Lordaeron
    UnitAddAbility(gg_unit_nemi_0019, ARTIFACT_HOLDER_ABIL_ID)                    ;//King Terenas
    UnitAddItem(gg_unit_nemi_0019, ARTIFACT_CROWNLORDAERON.item);

    tempArtifact = Artifact.create(CreateItem(FourCC(I00D), DUMMY_X, DUMMY_Y))    ;//Shalamayne
    UnitAddItem(gg_unit_n021_2624, tempArtifact.item)                      ;//Hogger

    tempArtifact = Artifact.create(CreateItem(FourCC(klmm), DUMMY_X, DUMMY_Y))    ;//Killmaim
    UnitAddAbility(gg_unit_H00E_1728, ARTIFACT_HOLDER_ABIL_ID)             ;//Ramzes the Horror
    UnitAddItem(gg_unit_H00E_1728, tempArtifact.item);

    tempArtifact = Artifact.create(CreateItem(FourCC(I004), -1480, -2240))     ;//The Doomhammer

    tempArtifact = Artifact.create(CreateItem(FourCC(I01V), -10330, 2105))     ;//Gorehowl

    ARTIFACT_TROLKALAR = Artifact.create(CreateItem(FourCC(I01O), DUMMY_X, DUMMY_Y))    ;//Trol)kalar
    ARTIFACT_TROLKALAR.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_TROLKALAR.setDescription("Stormwind Quest");
    ARTIFACT_TROLKALAR.TitanforgedAbility = FourCC(A0VM);

    ARTIFACT_SCEPTEROFTHEQUEEN = Artifact.create(CreateItem(FourCC(I00I), DUMMY_X, DUMMY_Y));
    UnitAddAbility(gg_unit_n085_2846, ARTIFACT_HOLDER_ABIL_ID)             ;//The Atheneum
    UnitAddItem(gg_unit_n085_2846, ARTIFACT_SCEPTEROFTHEQUEEN.item);

    ARTIFACT_BOOKOFMEDIVH = Artifact.create(CreateItem(FourCC(I006), DUMMY_X, DUMMY_Y))    ;//Book of Medivh
    UnitAddAbility(gg_unit_nbsm_1188, ARTIFACT_HOLDER_ABIL_ID)             ;//Book of Medivh Pedestal
    UnitAddItem(gg_unit_nbsm_1188, ARTIFACT_BOOKOFMEDIVH.item);

    ARTIFACT_SKULLOFGULDAN = Artifact.create(CreateItem(FourCC(I007), 21886, -25219))    ;//Skull of Gul)dan
    ARTIFACT_SKULLOFGULDAN.setDescription("Illidan Quest");

    ARTIFACT_ZINROKH = Artifact.create(CreateItem(FourCC(I016), DUMMY_X, DUMMY_Y))    ;//Zin)rokh
    ARTIFACT_ZINROKH.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_ZINROKH.setDescription("Assembled from its fragments");
    ARTIFACT_ZINROKH.TitanforgedAbility = FourCC(A0VM);

    tempArtifact = Artifact.create(CreateItem(FourCC(I01M), DUMMY_X, DUMMY_Y))    ;//Bronze Demon Soul Fragment
    UnitAddAbility(gg_unit_O024_0567, ARTIFACT_HOLDER_ABIL_ID)             ;//Ukorz
    UnitAddItem(gg_unit_O024_0567, tempArtifact.item);

    tempArtifact = Artifact.create(CreateItem(FourCC(I01L), DUMMY_X, DUMMY_Y))    ;//Black Demon Soul Fragment
    UnitAddItem(gg_unit_o04E_1559, tempArtifact.item);

    tempArtifact = Artifact.create(CreateItem(FourCC(I01J), DUMMY_X, DUMMY_Y))    ;//Red Demon Soul Fragment
    UnitAddAbility(gg_unit_O023_0517, ARTIFACT_HOLDER_ABIL_ID)             ;//Jin)do
    UnitAddItem(gg_unit_O023_0517, tempArtifact.item);

    tempArtifact = Artifact.create(CreateItem(FourCC(I01I), DUMMY_X, DUMMY_Y))    ;//Blue Demon Soul Fragment
    UnitAddAbility(gg_unit_O02C_2437, ARTIFACT_HOLDER_ABIL_ID)             ;//Gal)darah
    UnitAddItem(gg_unit_O02C_2437, tempArtifact.item);

    tempArtifact = Artifact.create(CreateItem(FourCC(I01K), DUMMY_X, DUMMY_Y))    ;//Green Demon Soul Fragment
    UnitAddItem(gg_unit_O00O_1933, tempArtifact.item);

    tempArtifact = Artifact.create(CreateItem(FourCC(arsh), DUMMY_X, DUMMY_Y))    ;//Shroud of Nozdormuru
    UnitAddAbility(gg_unit_O025_3426, ARTIFACT_HOLDER_ABIL_ID)             ;//Occulus
    UnitAddItem(gg_unit_O025_3426, tempArtifact.item);

    ARTIFACT_DREKTHARSSPELLBOOK = Artifact.create(CreateItem(FourCC(dtsb), DUMMY_X, DUMMY_Y))    ;//Drek)thar)s Spellbook
    ARTIFACT_DREKTHARSSPELLBOOK.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_DREKTHARSSPELLBOOK.setDescription("Frostwolf Quest");

    ARTIFACT_SOULGEM = Artifact.create(CreateItem(FourCC(gsou), DUMMY_X, DUMMY_Y));
    ARTIFACT_SOULGEM.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_SOULGEM.setDescription("DalaranFourCC(s Quest");
    ARTIFACT_SOULGEM.falseX = -14269;
    ARTIFACT_SOULGEM.falseY = 22281;

    ARTIFACT_GHANIR = Artifact.create(CreateItem(FourCC(I00C), DUMMY_X, DUMMY_Y))    ;//G)hanir
    UnitAddAbility(gg_unit_nbwd_0737, ARTIFACT_HOLDER_ABIL_ID)                ;//Barrow Den
    UnitAddItem(gg_unit_nbwd_0737, ARTIFACT_GHANIR.item);

    ARTIFACT_HORNOFCENARIUS = Artifact.create(CreateItem(FourCC(cnhn), DUMMY_X, DUMMY_Y));
    UnitAddAbility(gg_unit_nhcn_2597, ARTIFACT_HOLDER_ABIL_ID)             ;//Horn of Cenarius Pedestal
    UnitAddItem(gg_unit_nhcn_2597, ARTIFACT_HORNOFCENARIUS.item);

    tempArtifact = Artifact.create(CreateItem(FourCC(kgal), DUMMY_X, DUMMY_Y))    ;//Keg of Thunderwater
    UnitAddItem(gg_unit_hmtm_2086, tempArtifact.item);

    tempArtifact = Artifact.create(CreateItem(FourCC(I00J), DUMMY_X, DUMMY_Y))    ;//Felo)melorn
    UnitAddItem(gg_unit_O00O_1933, tempArtifact.item)                      ;//Zuljin
    tempArtifact.TitanforgedAbility = FourCC(A0VN);

    tempArtifact = Artifact.create(CreateItem(FourCC(I00K), DUMMY_X, DUMMY_Y))    ;//Essence
    UnitAddItem(gg_unit_n03T_0555, tempArtifact.item)                      ;//Murmur

    ARTIFACT_CROWNEASTERNKINGDOMS = Artifact.create(CreateItem(FourCC(I00U), DUMMY_X, DUMMY_Y));
    ARTIFACT_CROWNEASTERNKINGDOMS.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_CROWNEASTERNKINGDOMS.setDescription("Stormwind && Lordaeron Quest");

    ARTIFACT_CROWNTRIUMVIRATE = Artifact.create(CreateItem(FourCC(I011), DUMMY_X, DUMMY_Y));
    ARTIFACT_CROWNTRIUMVIRATE.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_CROWNTRIUMVIRATE.setDescription("Draenei Quest");

    ARTIFACT_SCYTHEOFELUNE = Artifact.create(CreateItem(FourCC(I00R), DUMMY_X, DUMMY_Y));
    UnitAddAbility(gg_unit_Hgam_1450, ARTIFACT_HOLDER_ABIL_ID)             ;//Arugal
    UnitAddItem(gg_unit_Hgam_1450, ARTIFACT_SCYTHEOFELUNE.item)            ;//Arugal

    ARTIFACT_THUNDERFURY = Artifact.create(CreateItem(FourCC(I00Z), DUMMY_X, DUMMY_Y));
    ARTIFACT_THUNDERFURY.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_THUNDERFURY.setDescription("Twilight HammerFourCC(s Quest");
    ARTIFACT_THUNDERFURY.falseX = -1649;
    ARTIFACT_THUNDERFURY.falseY = 7628;

    ARTIFACT_LIVINGSHADOW = Artifact.create(CreateItem(FourCC(odef), DUMMY_X, DUMMY_Y));
    ARTIFACT_LIVINGSHADOW.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_LIVINGSHADOW.setDescription("LordaeronFourCC(s Quest");
    ARTIFACT_LIVINGSHADOW.falseX = -19525;
    ARTIFACT_LIVINGSHADOW.falseY = -5192;

    ARTIFACT_ASHBRINGER = Artifact.create(CreateItem(FourCC(I012), DUMMY_X, DUMMY_Y));
    ARTIFACT_ASHBRINGER.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_ASHBRINGER.setDescription("LordaeronFourCC(s Quest");
    ARTIFACT_ASHBRINGER.falseX = 10569;
    ARTIFACT_ASHBRINGER.falseY = -5280;

    ARTIFACT_XALATATH = Artifact.create(CreateItem(FourCC(I015), DUMMY_X, DUMMY_Y));
    ARTIFACT_XALATATH.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_XALATATH.setDescription("Black EmpireFourCC(s Quest");
    ARTIFACT_XALATATH.falseX = 7121;
    ARTIFACT_XALATATH.falseY = 10000;

    ARTIFACT_DEMONSOUL = Artifact.create(CreateItem(FourCC(I01A), DUMMY_X, DUMMY_Y));
    ARTIFACT_DEMONSOUL.setStatus(ARTIFACT_STATUS_HIDDEN);
    ARTIFACT_DEMONSOUL.setDescription("AhnFourCC(Qiraj)s Quest");
    ARTIFACT_DEMONSOUL.falseX = 12508;
    ARTIFACT_DEMONSOUL.falseY = -11437;

  }

}
