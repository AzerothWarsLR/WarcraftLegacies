using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.BansheesHost;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Forsaken;

/// <summary>Take Capital City to make the Undercity beneath it the Forsaken's home.</summary>
public sealed class QuestUndercity : QuestData
{
  private readonly ForsakenBases _bases;

  public QuestUndercity(Capital capitalPalace, ForsakenBases bases) : base("The Undercity",
    "Beneath the ruins of Capital City lie the royal crypts of Lordaeron. Seize the palace above them, and the Forsaken will have a home no master can take from them.",
    @"ReplaceableTextures\CommandButtons\BTNSacrificialPit.blp")
  {
    _bases = bases;
    AddObjective(new ObjectiveControlCapital(capitalPalace, false, true));
    AddObjective(new ObjectiveSelfExists());
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Forsaken descend into the catacombs beneath Capital City, and make the Undercity their home. In its depths, the dreadlord Varimathras takes up the work Putress began.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Gain a base inside the Capital Palace guarded by towers, and the palace trains your Acolytes and elites. Putress becomes Varimathras, keeping his experience and items";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    _bases.BuildUndercity();
    ReplacePutress(completingFaction);
    SylvanasDialogue.PlayUndercity(completingFaction);
    var owner = completingFaction.Player;
    if (owner != null)
    {
      owner.PlayMusicThematic(@"Sound\Music\mp3Music\Undercity.ogg");
    }
  }

  private static void ReplacePutress(Faction faction)
  {
    faction.ModObjectLimit(UNIT_U01O_GRAND_APOTHECARY_FORSAKEN, -1);
    faction.ModObjectLimit(UNIT_UVAR_ARCH_DREADLORD_FORSAKEN, 1);
    var owner = faction.Player;
    if (owner == null)
    {
      return;
    }

    foreach (var putress in GlobalGroup.EnumUnitsOfPlayer(owner))
    {
      if (putress.UnitType != UNIT_U01O_GRAND_APOTHECARY_FORSAKEN)
      {
        continue;
      }

      if (!putress.Alive)
      {
        putress.DropAllItems();
        putress.Dispose();
        continue;
      }

      var varimathras = unit.Create(owner, UNIT_UVAR_ARCH_DREADLORD_FORSAKEN, putress.X, putress.Y, putress.Facing);
      SetHeroXP(varimathras, GetHeroXP(putress), false);
      putress.TransferItems(varimathras);
      putress.Dispose();
    }
  }
}
