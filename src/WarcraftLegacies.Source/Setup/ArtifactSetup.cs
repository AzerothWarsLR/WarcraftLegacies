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
    PreplacedWidgets.Units.Get(FourCC("n021")).AddItem(CrownOfStormwind.Item); //Hogger
    ArtifactManager.Register(CrownOfStormwind);

    ScarabGong = new Artifact(item.Create(FourCC("ISGC"), DummyX, DummyY)); //Scarab Gong
    PreplacedWidgets.Units.Get(FourCC("nJTR")).AddItem(ScarabGong.Item); //Scarab Gong
    ArtifactManager.Register(ScarabGong);

    EyeOfSargeras = new Artifact(item.Create(ITEM_I003_EYE_OF_SARGERAS, -77.9f, 10910.4f));
    ArtifactManager.Register(EyeOfSargeras);

    HelmOfDomination = new Artifact(item.Create(FourCC("I01Y"), DummyX, DummyY)); //Helm of Domination
    PreplacedWidgets.Units.Get(FourCC("u000_0649")).AddAbility(Artifact.ArtifactHolderAbilId); //Frozen Throne
    PreplacedWidgets.Units.Get(FourCC("u000")).AddItem(HelmOfDomination.Item);
    ArtifactManager.Register(HelmOfDomination);

    CrownOfLordaeron = new Artifact(item.Create(FourCC("I001"), DummyX, DummyY)); //Crown of Lordaeron
    PreplacedWidgets.Units.Get(FourCC("nemi_0019")).AddAbility(Artifact.ArtifactHolderAbilId); //King Terenas
    PreplacedWidgets.Units.Get(FourCC("nemi")).AddItem(CrownOfLordaeron.Item);
    ArtifactManager.Register(CrownOfLordaeron);

    var tempArtifact = new Artifact(item.Create(FourCC("klmm"), DummyX, DummyY)); //Killmaim
    PreplacedWidgets.Units.Get(UNIT_H0BD_RAMZES_THE_HORROR_CREEP_DESOLACE).AddAbility(Artifact.ArtifactHolderAbilId); //Ramzes the Horror
    PreplacedWidgets.Units.Get(UNIT_H0BD_RAMZES_THE_HORROR_CREEP_DESOLACE).AddItem(tempArtifact.Item);
    ArtifactManager.Register(tempArtifact);

    ScepterOfTheQueen = new Artifact(item.Create(FourCC("I00I"), DummyX, DummyY));
    PreplacedWidgets.Units.Get(FourCC("n085_2846")).AddAbility(Artifact.ArtifactHolderAbilId); //The Atheneum
    PreplacedWidgets.Units.Get(FourCC("n085")).AddItem(ScepterOfTheQueen.Item);
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

    EssenceofMurmur = new Artifact(item.Create(FourCC("I00K"), DummyX, DummyY)); //Essence
    PreplacedWidgets.Units.Get(FourCC("n03T")).AddItem(EssenceofMurmur.Item); //Murmur
    ArtifactManager.Register(EssenceofMurmur);

    EmeraldFragment = new Artifact(item.Create(ITEM_I01K_EMERALD_FRAGMENT, DummyX, DummyY));
    PreplacedWidgets.Units.Get(UNIT_O06Z_ZUL_JIN_CREEP_ZUL_AMAN).AddItem(EmeraldFragment.Item);
    ArtifactManager.Register(EmeraldFragment);

    tempArtifact = new Artifact(item.Create(FourCC("arsh"), DummyX, DummyY)); //Shroud of Nozdormuru
    PreplacedWidgets.Units.Get(UNIT_O070_OCCULUS_CREEP_CAVERNS).AddAbility(Artifact.ArtifactHolderAbilId); //Occulus
    PreplacedWidgets.Units.Get(UNIT_O070_OCCULUS_CREEP_CAVERNS).AddItem(tempArtifact.Item);
    ArtifactManager.Register(tempArtifact);

    HornOfCenarius = new Artifact(item.Create(FourCC("cnhn"), DummyX, DummyY));
    PreplacedWidgets.Units.Get(FourCC("nhcn_2597")).AddAbility(Artifact.ArtifactHolderAbilId); //Horn of Cenarius Pedestal
    PreplacedWidgets.Units.Get(FourCC("nhcn")).AddItem(HornOfCenarius.Item);
    ArtifactManager.Register(HornOfCenarius);

    tempArtifact = new Artifact(item.Create(FourCC("kgal"), DummyX, DummyY)); //Keg of Thunderwater
    PreplacedWidgets.Units.GetClosest(FourCC("hmtm"), 15109, -895).AddItem(tempArtifact.Item);
    ArtifactManager.Register(tempArtifact);

    SunwellVial = new Artifact(item.Create(ITEM_I018_VIAL_OF_THE_SUNWELL, DummyX, DummyX));
    var sunwell = PreplacedWidgets.Units.Get(UNIT_N001_THE_SUNWELL_QUELTHALAS_OTHER);
    sunwell.AddAbility(Artifact.ArtifactHolderAbilId);
    sunwell.AddItem(SunwellVial.Item);
    ArtifactManager.Register(SunwellVial);
  }
}
