using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Powers;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Quelthalas
{
  public sealed class QuestTheBloodElves : QuestData
  {
    private const int QuestResearchId = Constants.UPGRADE_R04Q_QUEST_COMPLETED_THE_BLOOD_ELVES_QUEL_THALAS;
    private const int UnittypeId = Constants.UNIT_N048_BLOOD_MAGE_QUEL_THALAS;
    private const int BuildingId = Constants.UNIT_N0A2_CONSORTIUM_QUEL_THALAS;
    private const int HeroId = Constants.UNIT_HKAL_PRINCE_OF_QUEL_THALAS_QUEL_THALAS;

    private readonly List<unit> _secondChanceUnits = new();

    public QuestTheBloodElves(Rectangle secondChanceRect) : base("The Blood Elves",
      "The Elves of Quel'thalas have a deep reliance on the Sunwell's magic. Without it, they would have to turn to darker magicks to sate themselves.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroBloodElfPrince.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendNeutral.DraktharonKeep, false));
      AddObjective(new ObjectiveControlLegend(LegendQuelthalas.LegendAnasterian, true));
      AddObjective(new ObjectiveControlLegend(LegendQuelthalas.LegendSunwell, true));

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(secondChanceRect).EmptyToList())
      {
        ShowUnit(unit, false);
        SetUnitInvulnerable(unit, true);
        _secondChanceUnits.Add(unit);
      }

      Required = true;
    }

    /// <inheritdoc />
    protected override string FailurePopup =>
      "The Sunwell has fallen. The survivors escape to Dalaran and name themselves the Blood Elves in remembrance of their fallen people.";

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "The Legion Nexus has been obliterated. A group of ambitious mages seize the opportunity to study the demons' magic, becoming the first Blood Mages.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Learn to train {GetObjectName(UnittypeId)}s from the Consortium, and you can summon Prince Kael'thas from the Altar of Prowess";

    /// <inheritdoc />
    protected override string PenaltyDescription =>
      $"You lose everything you control, but you gain Prince Kael'thas at the Dalaran Dungeons, you can train {GetObjectName(UnittypeId)}s from the Consortium, and you gain the Mana Addiction power";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, QuestResearchId, 1);
      completingFaction.Player.DisplayUnitTypeAcquired(UnittypeId,
        $"You can now train {GetObjectName(UnittypeId)}s from the {GetObjectName(BuildingId)}.");
    }

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      LegendQuelthalas.LegendKael.StartingXp = GetHeroXP(LegendQuelthalas.LegendAnasterian.Unit);
      completingFaction.Obliterate();
      if (completingFaction.ScoreStatus == ScoreStatus.Defeated) return;
      foreach (var unit in _secondChanceUnits) unit.Rescue(completingFaction.Player);

      SetPlayerTechResearched(completingFaction.Player, QuestResearchId, 1);
      LegendQuelthalas.LegendKael.StartingXp = GetHeroXP(LegendQuelthalas.LegendAnasterian.Unit);
      LegendQuelthalas.LegendKael.ForceCreate(completingFaction.Player, new Point(-11410, 21975), 110);
      UnitAddItem(LegendQuelthalas.LegendKael.Unit,
        CreateItem(Constants.ITEM_I00M_SUMMON_ELVEN_WORKERS, GetUnitX(LegendQuelthalas.LegendKael.Unit),
          GetUnitY(LegendQuelthalas.LegendKael.Unit)));
      if (GetLocalPlayer() == completingFaction.Player)
        SetCameraPosition(Regions.BloodElfSecondChanceSpawn.Center.X, Regions.BloodElfSecondChanceSpawn.Center.Y);
      GrantPower(completingFaction);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(QuestResearchId, Faction.UNLIMITED);
      whichFaction.ModObjectLimit(UnittypeId, 6);
      whichFaction.ModObjectLimit(HeroId, 1);
    }

    private void GrantPower(Faction whichFaction)
    {
      whichFaction.AddPower(new UnitsStealMana(0.35f)
      {
        IconName = "ManaShield",
        Name = "Mana Addiction"
      });
    }
  }
}