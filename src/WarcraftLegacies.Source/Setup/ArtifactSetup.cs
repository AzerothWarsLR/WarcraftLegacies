using MacroTools.ArtifactSystem;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Responsible for setting up and storing all <see cref="Artifact"/>s.
/// </summary>
public sealed class ArtifactSetup
{
  private const float DummyX = 20195;
  private const float DummyY = 24177;

  /// <summary>
  /// The Crown of Stormwind.
  /// </summary>
  public Artifact CrownOfStormwind { get; }

  /// <summary>
  /// The Scarab Gong.
  /// </summary>
  public Artifact ScarabGong { get; }

  /// <summary>
  /// The Crown of Lordaeron.
  /// </summary>
  public Artifact CrownOfLordaeron { get; }

  /// <summary>
  /// The Helm of Domination worn by the Lich King.
  /// </summary>
  public Artifact HelmOfDomination { get; }

  /// <summary>
  /// Azshara's Scepter.
  /// </summary>
  public Artifact ScepterOfTheQueen { get; }

  /// <summary>
  /// Powerful tome left behind by the Guardian Medivh.
  /// </summary>
  public Artifact BookOfMedivh { get; }

  /// <summary>
  /// Essence of a powerful voidlord.
  /// </summary>
  public Artifact EssenceofMurmur { get; }

  /// <summary>
  /// Horn that can be used to call a bunch of wisps.
  /// </summary>
  public Artifact HornOfCenarius { get; }

  /// <summary>
  /// A remnant of the Titan Sargeras.
  /// </summary>
  public Artifact EyeOfSargeras { get; }

  /// <summary>
  /// A fragment of Zin'rokh.
  /// </summary>
  public Artifact AzureFragment { get; }

  /// <summary>
  /// A fragment of Zin'rokh.
  /// </summary>
  public Artifact EmeraldFragment { get; }

  /// <summary>
  /// A fragment of Zin'rokh.
  /// </summary>
  public Artifact RubyFragment { get; }

  /// <summary>
  /// A fragment of Zin'rokh.
  /// </summary>
  public Artifact ObsidianFragment { get; }

  /// <summary>
  /// A fragment of Zin'rokh.
  /// </summary>
  public Artifact BronzeFragment { get; }

  public Artifact SunwellVial { get; set; }


  /// <summary>
  /// Sets up <see cref="ArtifactSetup"/>.
  /// </summary>
  public ArtifactSetup()
  {
    CrownOfStormwind = new Artifact(item.Create(FourCC("I002"), DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_N021_HOGGER).AddItem(CrownOfStormwind.Item);
    ArtifactManager.Register(CrownOfStormwind);

    ScarabGong = new Artifact(item.Create(FourCC("ISGC"), DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_NJTR_JONATHAN_THE_REVELATOR).AddItem(ScarabGong.Item);
    ArtifactManager.Register(ScarabGong);

    EyeOfSargeras = new Artifact(item.Create(ITEM_I003_EYE_OF_SARGERAS, -77.9f, 10910.4f));
    ArtifactManager.Register(EyeOfSargeras);

    HelmOfDomination = new Artifact(item.Create(FourCC("I01Y"), DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_U000_FROZEN_THRONE_SCOURGE_MAIN).AddAbility(Artifact.ArtifactHolderAbilId);
    PreplacedWidgets.Units.Get(UNIT_U000_FROZEN_THRONE_SCOURGE_MAIN).AddItem(HelmOfDomination.Item);
    ArtifactManager.Register(HelmOfDomination);

    CrownOfLordaeron = new Artifact(item.Create(FourCC("I001"), DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_NEMI_KING_TERENAS_MENETHIL_LORDAERON).AddAbility(Artifact.ArtifactHolderAbilId);
    PreplacedWidgets.Units.Get(UNIT_NEMI_KING_TERENAS_MENETHIL_LORDAERON).AddItem(CrownOfLordaeron.Item);
    ArtifactManager.Register(CrownOfLordaeron);

    var tempArtifact = new Artifact(item.Create(FourCC("klmm"), DummyX, DummyY)); //Killmaim
    PreplacedWidgets.Units.Get(UNIT_H0BD_RAMZES_THE_HORROR_CREEP_DESOLACE).AddAbility(Artifact.ArtifactHolderAbilId);
    PreplacedWidgets.Units.Get(UNIT_H0BD_RAMZES_THE_HORROR_CREEP_DESOLACE).AddItem(tempArtifact.Item);
    ArtifactManager.Register(tempArtifact);

    ScepterOfTheQueen = new Artifact(item.Create(FourCC("I00I"), DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_N085_THE_ATHENAEUM_SENTINELS_OTHER).AddAbility(Artifact.ArtifactHolderAbilId);
    PreplacedWidgets.Units.Get(UNIT_N085_THE_ATHENAEUM_SENTINELS_OTHER).AddItem(ScepterOfTheQueen.Item);
    ArtifactManager.Register(ScepterOfTheQueen);

    BookOfMedivh = new Artifact(item.Create(ITEM_I006_BOOK_OF_MEDIVH, DummyX, DummyY));
    ArtifactManager.Register(BookOfMedivh);

    BronzeFragment = new Artifact(item.Create(ITEM_I01M_BRONZE_FRAGMENT, DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_O06Y_UKORZ_CREEP_ZUL_FARRAK).AddAbility(Artifact.ArtifactHolderAbilId);
    PreplacedWidgets.Units.Get(UNIT_O06Y_UKORZ_CREEP_ZUL_FARRAK).AddItem(BronzeFragment.Item);
    ArtifactManager.Register(BronzeFragment);

    ObsidianFragment = new Artifact(item.Create(ITEM_I01L_OBSIDIAN_FRAGMENT, DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_NDTW_XU_BA).AddItem(ObsidianFragment.Item);
    ArtifactManager.Register(ObsidianFragment);

    RubyFragment = new Artifact(item.Create(ITEM_I01J_RUBY_FRAGMENT, DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_O06X_JIN_DO_CREEP_ZUL_GURUB).AddAbility(Artifact.ArtifactHolderAbilId); //Jin)do
    PreplacedWidgets.Units.Get(UNIT_O06X_JIN_DO_CREEP_ZUL_GURUB).AddItem(RubyFragment.Item);
    ArtifactManager.Register(RubyFragment);

    AzureFragment = new Artifact(item.Create(ITEM_I01I_AZURE_FRAGMENT, DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_O06W_GAL_DARAH_CREEP_ZUL_DRAK).AddAbility(Artifact.ArtifactHolderAbilId);
    PreplacedWidgets.Units.Get(UNIT_O06W_GAL_DARAH_CREEP_ZUL_DRAK).AddItem(AzureFragment.Item);
    ArtifactManager.Register(AzureFragment);

    EssenceofMurmur = new Artifact(item.Create(FourCC("I00K"), DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_N03T_MURMUR_CREEP).AddItem(EssenceofMurmur.Item);
    ArtifactManager.Register(EssenceofMurmur);

    EmeraldFragment = new Artifact(item.Create(ITEM_I01K_EMERALD_FRAGMENT, DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_O06Z_ZUL_JIN_CREEP_ZUL_AMAN).AddItem(EmeraldFragment.Item);
    ArtifactManager.Register(EmeraldFragment);

    tempArtifact = new Artifact(item.Create(FourCC("arsh"), DummyX, DummyY)); //Shroud of Nozdormuru
    PreplacedWidgets.Units.Get(UNIT_O070_OCCULUS_CREEP_CAVERNS).AddAbility(Artifact.ArtifactHolderAbilId);
    PreplacedWidgets.Units.Get(UNIT_O070_OCCULUS_CREEP_CAVERNS).AddItem(tempArtifact.Item);
    ArtifactManager.Register(tempArtifact);

    HornOfCenarius = new Artifact(item.Create(FourCC("cnhn"), DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_NHCN_HORN_OF_CENARIUS_PEDESTAL_CREEP).AddAbility(Artifact.ArtifactHolderAbilId);
    PreplacedWidgets.Units.Get(UNIT_NHCN_HORN_OF_CENARIUS_PEDESTAL_CREEP).AddItem(HornOfCenarius.Item);
    ArtifactManager.Register(HornOfCenarius);

    tempArtifact = new Artifact(item.Create(FourCC("kgal"), DummyX, DummyY)); //Keg of Thunderwater
    PreplacedWidgets.Units.GetClosest(UNIT_HMTM_MORTAR_TEAM_IRONFORGE, 15109, -895).AddItem(tempArtifact.Item);
    ArtifactManager.Register(tempArtifact);

    SunwellVial = new Artifact(item.Create(ITEM_I018_VIAL_OF_THE_SUNWELL, DummyX, DummyX));
    var sunwell = PreplacedWidgets.Units.Get(UNIT_N001_THE_SUNWELL_QUELTHALAS_OTHER);
    sunwell.AddAbility(Artifact.ArtifactHolderAbilId);
    sunwell.AddItem(SunwellVial.Item);
    ArtifactManager.Register(SunwellVial);
  }
}
