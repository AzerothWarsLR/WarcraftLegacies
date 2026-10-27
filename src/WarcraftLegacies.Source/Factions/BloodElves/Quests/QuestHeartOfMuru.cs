using MacroTools.Artifacts;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Factions.BloodElves.Quests;

/// <summary>Slay the naaru M'uru in Outland and take its heart.</summary>
public sealed class QuestHeartOfMuru : QuestData
{
  private const float MuruX = -133;
  private const float MuruY = -19530;
  private const float MuruFacing = 240;
  private const float SpireOffsetX = 250;
  private const float SpireOffsetY = 80;
  private const float SpireScale = 0.8f;
  private const string SpireModel = @"war3mapImported\DraeneiCrystalSpire V1_01.mdl";

  public QuestHeartOfMuru() : base("The Naaru's Heart",
    "The naaru M'uru lingers among the shattered crystals of Netherstorm, a being of pure Light. Kael'thas believes its radiance could sate his people's hunger at last, and perhaps open the way to something far greater.",
    @"ReplaceableTextures\CommandButtons\BTNAquaGem.blp")
  {
    var muru = unit.Create(player.NeutralAggressive, UNIT_N0Z3_M_URU_CREEP, MuruX, MuruY, MuruFacing);
    CreateSpire(MuruX - SpireOffsetX);
    CreateSpire(MuruX + SpireOffsetX);
    HeartOfMuru = new Artifact(item.Create(ITEM_I0WH_HEART_OF_M_URU, MuruX, MuruY));
    muru.AddItem(HeartOfMuru.Item);
    ArtifactManager.Register(HeartOfMuru);
    AddObjective(new ObjectiveKillUnit(muru));
  }

  /// <summary>The artifact M'uru drops when it dies.</summary>
  public Artifact HeartOfMuru { get; }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "M'uru's light gutters and fades. From its broken form, Kael'thas tears free a heart of pure Light, still thrumming with holy power.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    Loc.Format("Gain the artifact {artifact}", ("{artifact}", GetObjectName(ITEM_I0WH_HEART_OF_M_URU)));

  private static void CreateSpire(float x)
  {
    var spire = effect.Create(SpireModel, x, MuruY + SpireOffsetY);
    spire.Scale = SpireScale;
  }
}
