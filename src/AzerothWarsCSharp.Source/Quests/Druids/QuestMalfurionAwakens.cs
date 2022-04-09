using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestMalfurionAwakens : QuestData
  {
    private readonly List<unit> _moongladeUnits = new();

    public QuestMalfurionAwakens(Rectangle moonglade) : base("Awakening of Stormrage",
      "Ever since the War of the Ancients ten thousand years ago, Malfurion Stormrage and his druids have slumbered within the Barrow Den. Now, their help is required once again.",
      "ReplaceableTextures\\CommandButtons\\BTNFurion.blp")
    {
      AddQuestItem(new QuestItemAcquireArtifact(ArtifactSetup.ArtifactHornofcenarius));
      AddQuestItem(new QuestItemArtifactInRect(ArtifactSetup.ArtifactHornofcenarius, Regions.Moonglade.Rect, "The Barrow Den"));
      AddQuestItem(new QuestItemExpire(1440));
      AddQuestItem(new QuestItemSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(moonglade).EmptyToList())
      {
        SetUnitInvulnerable(unit, true);
        _moongladeUnits.Add(unit);
      }
    }
    
    protected override string CompletionPopup => "Malfurion has emerged from his deep slumber in the Barrow Den.";

    protected override string RewardDescription => "Gain the hero Malfurion and the artifact G'hanir";

    protected override void OnFail()
    {
      foreach (var unit in _moongladeUnits) UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _moongladeUnits) UnitRescue(unit, Holder.Player);
      if (LegendDruids.LegendMalfurion.Unit == null)
      {
        LegendDruids.LegendMalfurion.Spawn(Holder.Player, Regions.Moonglade.Center.X, Regions.Moonglade.Center.Y,
          270);
        SetHeroLevel(LegendDruids.LegendMalfurion.Unit, 3, false);
        UnitAddItemSafe(LegendDruids.LegendMalfurion.Unit, ArtifactSetup.ArtifactGhanir.Item);
      }
      else
      {
        SetItemPosition(ArtifactSetup.ArtifactGhanir.Item, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()));
      }
    }
  }
}