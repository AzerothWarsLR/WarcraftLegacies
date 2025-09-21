using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.BlackEmpire;


public sealed class QuestBladeoftheBlackEmpire : QuestData
{

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestBladeoftheBlackEmpire"/> class.
  /// </summary>
  public QuestBladeoftheBlackEmpire(Rectangle area) : base("The Blade of the Black Empire",
    "An ancient blade from the time of the Black Empire itself. The Dagger has a mind of its own and tries to corrupt whoever wields it. It has been lost to time.",
    @"ReplaceableTextures\CommandButtons\BTNmidnightGS.blp")
  {
    AddObjective(new ObjectiveControlLevel(UNIT_N00P_THE_ABYSS, 20));
    _anyUnitInRect = new ObjectiveAnyUnitInRect(area, "The Abyss", false);
    AddObjective(_anyUnitInRect);
  }

  private readonly ObjectiveAnyUnitInRect _anyUnitInRect;
  /// <inheritdoc />
  public override string RewardFlavour => "I have found the Blade of the Black Empire.";

  /// <inheritdoc />
  protected override string RewardDescription => "The Blade of the Black Empire appears near The Abyss";

  protected override void OnComplete(Faction whichFaction)
  {
    var xalatath = new Artifact(item.Create(ITEM_I015_XAL_ATATH_BLADE_OF_THE_BLACK_EMPIRE, -3986, 2100))
    {
      TitanforgedAbility = ABILITY_A0VM_TITANFORGED_9_STRENGTH
    };
    ArtifactManager.Register(xalatath);

    _anyUnitInRect.CompletingUnit?.AddItemSafe(xalatath.Item);
  }
}
