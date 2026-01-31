using MacroTools.Artifacts;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Initializes and maintains references to all <see cref="Artifact"/>s.
/// </summary>
public static class Artifacts
{
  private const float DummyX = 20195;
  private const float DummyY = 24177;

  /// <summary>
  /// The Crown of Stormwind.
  /// </summary>
  public static Artifact CrownOfStormwind { get; }

  /// <summary>
  /// The Scarab Gong.
  /// </summary>
  public static Artifact ScarabGong { get; }

  /// <summary>
  /// The Crown of Lordaeron.
  /// </summary>
  public static Artifact CrownOfLordaeron { get; }

  /// <summary>
  /// The Helm of Domination worn by the Lich King.
  /// </summary>
  public static Artifact HelmOfDomination { get; }

  /// <summary>
  /// Azshara's Scepter.
  /// </summary>
  public static Artifact ScepterOfTheQueen { get; }

  /// <summary>
  /// Powerful tome left behind by the Guardian Medivh.
  /// </summary>
  public static Artifact BookOfMedivh { get; }

  /// <summary>
  /// Essence of a powerful voidlord.
  /// </summary>
  public static Artifact EssenceofMurmur { get; }

  /// <summary>
  /// Horn that can be used to call a bunch of wisps.
  /// </summary>
  public static Artifact HornOfCenarius { get; }

  /// <summary>
  /// A remnant of the Titan Sargeras.
  /// </summary>
  public static Artifact EyeOfSargeras { get; }

  /// <summary>
  /// A fragment of Zin'rokh.
  /// </summary>
  public static Artifact AzureFragment { get; }

  /// <summary>
  /// A fragment of Zin'rokh.
  /// </summary>
  public static Artifact EmeraldFragment { get; }

  /// <summary>
  /// A fragment of Zin'rokh.
  /// </summary>
  public static Artifact RubyFragment { get; }

  /// <summary>
  /// A fragment of Zin'rokh.
  /// </summary>
  public static Artifact ObsidianFragment { get; }

  /// <summary>
  /// A fragment of Zin'rokh.
  /// </summary>
  public static Artifact BronzeFragment { get; }

  public static Artifact SunwellVial { get; }

  static Artifacts()
  {
    CrownOfStormwind = new Artifact(item.Create(ITEM_I002_CROWN_OF_STORMWIND, DummyX, DummyY));
    AllPreplacedWidgets.Units.Get(UNIT_N021_HOGGER).AddItem(CrownOfStormwind.Item);
    ArtifactManager.Register(CrownOfStormwind);

    ScarabGong = new Artifact(item.Create(ITEM_ISGC_THE_SCARAB_GONG, DummyX, DummyY));
    AllPreplacedWidgets.Units.Get(UNIT_NJTR_JONATHAN_THE_REVELATOR).AddItem(ScarabGong.Item);
    ArtifactManager.Register(ScarabGong);

    EyeOfSargeras = new Artifact(item.Create(ITEM_I003_EYE_OF_SARGERAS, -77.9f, 10910.4f));
    ArtifactManager.Register(EyeOfSargeras);

    HelmOfDomination = new Artifact(item.Create(ITEM_I01Y_HELM_OF_DOMINATION, DummyX, DummyY));
    var tempUnit = AllPreplacedWidgets.Units.Get(UNIT_U000_FROZEN_THRONE_SCOURGE_MAIN);
    tempUnit.AddAbility(Artifact.ArtifactHolderAbilId);
    tempUnit.AddItem(HelmOfDomination.Item);
    ArtifactManager.Register(HelmOfDomination);

    CrownOfLordaeron = new Artifact(item.Create(ITEM_I001_CROWN_OF_LORDAERON, DummyX, DummyY));
    tempUnit = AllPreplacedWidgets.Units.Get(UNIT_NEMI_KING_TERENAS_MENETHIL_LORDAERON);
    tempUnit.AddAbility(Artifact.ArtifactHolderAbilId);
    tempUnit.AddItem(CrownOfLordaeron.Item);
    ArtifactManager.Register(CrownOfLordaeron);

    var tempArtifact = new Artifact(item.Create(ITEM_KLMM_KILLMAIM, DummyX, DummyY));
    tempUnit = AllPreplacedWidgets.Units.Get(UNIT_H0BD_RAMZES_THE_HORROR_CREEP_DESOLACE);
    tempUnit.AddAbility(Artifact.ArtifactHolderAbilId);
    tempUnit.AddItem(tempArtifact.Item);
    ArtifactManager.Register(tempArtifact);

    ScepterOfTheQueen = new Artifact(item.Create(ITEM_I00I_SCEPTER_OF_THE_QUEEN, DummyX, DummyY));
    tempUnit = AllPreplacedWidgets.Units.Get(UNIT_N085_THE_ATHENAEUM_SENTINELS_OTHER);
    tempUnit.AddAbility(Artifact.ArtifactHolderAbilId);
    tempUnit.AddItem(ScepterOfTheQueen.Item);
    ArtifactManager.Register(ScepterOfTheQueen);

    BookOfMedivh = new Artifact(item.Create(ITEM_I006_BOOK_OF_MEDIVH, DummyX, DummyY));
    ArtifactManager.Register(BookOfMedivh);

    BronzeFragment = new Artifact(item.Create(ITEM_I01M_BRONZE_FRAGMENT, DummyX, DummyY));
    tempUnit = AllPreplacedWidgets.Units.Get(UNIT_O06Y_UKORZ_CREEP_ZUL_FARRAK);
    tempUnit.AddAbility(Artifact.ArtifactHolderAbilId);
    tempUnit.AddItem(BronzeFragment.Item);
    ArtifactManager.Register(BronzeFragment);

    ObsidianFragment = new Artifact(item.Create(ITEM_I01L_OBSIDIAN_FRAGMENT, DummyX, DummyY));
    AllPreplacedWidgets.Units.Get(UNIT_NDTW_XU_BA).AddItem(ObsidianFragment.Item);
    ArtifactManager.Register(ObsidianFragment);

    RubyFragment = new Artifact(item.Create(ITEM_I01J_RUBY_FRAGMENT, DummyX, DummyY));
    tempUnit = AllPreplacedWidgets.Units.Get(UNIT_O06X_JIN_DO_CREEP_ZUL_GURUB);
    tempUnit.AddAbility(Artifact.ArtifactHolderAbilId);
    tempUnit.AddItem(RubyFragment.Item);
    ArtifactManager.Register(RubyFragment);

    AzureFragment = new Artifact(item.Create(ITEM_I01I_AZURE_FRAGMENT, DummyX, DummyY));
    tempUnit = AllPreplacedWidgets.Units.Get(UNIT_O06W_GAL_DARAH_CREEP_ZUL_DRAK);
    tempUnit.AddAbility(Artifact.ArtifactHolderAbilId);
    tempUnit.AddItem(AzureFragment.Item);
    ArtifactManager.Register(AzureFragment);

    EssenceofMurmur = new Artifact(item.Create(ITEM_I00K_ESSENCE_OF_MURMUR, DummyX, DummyY));
    AllPreplacedWidgets.Units.Get(UNIT_N03T_MURMUR_CREEP).AddItem(EssenceofMurmur.Item);
    ArtifactManager.Register(EssenceofMurmur);

    EmeraldFragment = new Artifact(item.Create(ITEM_I01K_EMERALD_FRAGMENT, DummyX, DummyY));
    AllPreplacedWidgets.Units.Get(UNIT_O06Z_ZUL_JIN_CREEP_ZUL_AMAN).AddItem(EmeraldFragment.Item);
    ArtifactManager.Register(EmeraldFragment);

    tempArtifact = new Artifact(item.Create(ITEM_ARSH_SHROUD_OF_NOZDORMU, DummyX, DummyY));
    tempUnit = AllPreplacedWidgets.Units.Get(UNIT_O070_OCCULUS_CREEP_CAVERNS);
    tempUnit.AddAbility(Artifact.ArtifactHolderAbilId);
    tempUnit.AddItem(tempArtifact.Item);
    ArtifactManager.Register(tempArtifact);

    HornOfCenarius = new Artifact(item.Create(ITEM_CNHN_HORN_OF_CENARIUS, DummyX, DummyY));
    tempUnit = AllPreplacedWidgets.Units.Get(UNIT_NHCN_HORN_OF_CENARIUS_PEDESTAL_CREEP);
    tempUnit.AddAbility(Artifact.ArtifactHolderAbilId);
    tempUnit.AddItem(HornOfCenarius.Item);
    ArtifactManager.Register(HornOfCenarius);

    tempArtifact = new Artifact(item.Create(ITEM_KGAL_KEG_OF_THUNDERWATER, DummyX, DummyY));
    AllPreplacedWidgets.Units.GetClosest(UNIT_HMTM_MORTAR_TEAM_IRONFORGE, 15109, -895).AddItem(tempArtifact.Item);
    ArtifactManager.Register(tempArtifact);

    SunwellVial = new Artifact(item.Create(ITEM_I018_VIAL_OF_THE_SUNWELL, DummyX, DummyX));
    tempUnit = AllPreplacedWidgets.Units.Get(UNIT_N001_THE_SUNWELL_QUELTHALAS_OTHER);
    tempUnit.AddAbility(Artifact.ArtifactHolderAbilId);
    tempUnit.AddItem(SunwellVial.Item);
    ArtifactManager.Register(SunwellVial);
  }

  public static void Setup()
  {
    // No-op used to force execution of the static constructor.
  }
}
