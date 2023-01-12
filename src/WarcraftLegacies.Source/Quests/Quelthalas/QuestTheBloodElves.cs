using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.Powers;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Quelthalas
{
  /// <summary>
  /// Quel'thalas either wins or loses their duel to get Blood Mages and some other stuff.
  /// </summary>
  public sealed class QuestTheBloodElves : QuestData
  {
    private readonly Rectangle _secondChanceRect;
    private const int QuestResearchId = Constants.UPGRADE_R04Q_QUEST_COMPLETED_THE_BLOOD_ELVES_QUEL_THALAS;
    private const int UnittypeId = Constants.UNIT_N048_BLOOD_MAGE_QUEL_THALAS;
    private const int BuildingId = Constants.UNIT_N0A2_CONSORTIUM_QUEL_THALAS_MAGIC;
    private const int HeroId = Constants.UNIT_HKAL_PRINCE_OF_QUEL_THALAS_QUEL_THALAS;
    private const int GoldOnFail = 500;
    private const int LumberOnFail = 750;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTheBloodElves"/> class.
    /// </summary>
    /// <param name="secondChanceRect">Units in this area start invulnerable and become rescued when the quest is failed.</param>
    public QuestTheBloodElves(Rectangle secondChanceRect) : base("The Blood Elves",
      "The Elves of Quel'thalas have a deep reliance on the Sunwell's magic. Without it, they would have to turn to darker magicks to sate themselves.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroBloodElfPrince.blp")
    {
      _secondChanceRect = secondChanceRect;
      AddObjective(new ObjectiveControlCapital(LegendNeutral.DraktharonKeep, false));
      AddObjective(new ObjectiveControlLevel(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N030_DRAK_THARON_KEEP_30GOLD_MIN), 15));
      AddObjective(new ObjectiveControlCapital(LegendQuelthalas.LegendSunwell, true));
      Required = true;
    }

    /// <inheritdoc />
    protected override string PenaltyFlavour =>
      "The Sunwell has fallen. The survivors escape to Dalaran and name themselves the Blood Elves in remembrance of their fallen people.";

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "The Legion Nexus has been obliterated. A group of ambitious mages seize the opportunity to study the demons' magic, becoming the first Blood Mages.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Learn to train {GetObjectName(UnittypeId)}s from the Consortium, and you can summon Prince Kael'thas from the Altar of Prowess";

    /// <inheritdoc />
    protected override string PenaltyDescription =>
      $"You lose everything you control, but you gain Prince Kael'thas at the Dalaran Dungeons, you can train {GetObjectName(UnittypeId)}s from the Consortium, you gain the Mana Addiction power, and you receive 500 gold and 750 lumber";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, QuestResearchId, 1);
      completingFaction.Player?.DisplayUnitTypeAcquired(UnittypeId,
        $"You can now train {GetObjectName(UnittypeId)}s from the {GetObjectName(BuildingId)}.");
    }

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      LegendQuelthalas.LegendKael.StartingXp = GetHeroXP(LegendQuelthalas.LegendAnasterian.Unit);
      completingFaction.Obliterate();
      if (completingFaction.ScoreStatus == ScoreStatus.Defeated) 
        return;
      SetPlayerTechResearched(completingFaction.Player, QuestResearchId, 1);
      if (GetLocalPlayer() == completingFaction.Player)
        SetCameraPosition(_secondChanceRect.Center.X, _secondChanceRect.Center.Y);
      GrantPower(completingFaction);
      CreateSecondChanceUnits(completingFaction);
      completingFaction.Player?.AddGold(GoldOnFail);
      completingFaction.Player?.AddLumber(LumberOnFail);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(QuestResearchId, Faction.UNLIMITED);
      whichFaction.ModObjectLimit(UnittypeId, 6);
      whichFaction.ModObjectLimit(HeroId, 1);
    }

    private void CreateSecondChanceUnits(Faction whichFaction)
    {
      var whichPlayer = whichFaction.Player;
      if (whichPlayer == null)
        return;
      var spawn = _secondChanceRect.Center;
      GeneralHelpers.CreateUnits(whichPlayer, Constants.UNIT_U00J_ARCANE_WAGON_QUEL_THALAS, spawn.X, spawn.Y, 270, 2);
      GeneralHelpers.CreateUnits(whichPlayer, Constants.UNIT_N048_BLOOD_MAGE_QUEL_THALAS, spawn.X, spawn.Y, 270, 6);
      GeneralHelpers.CreateUnits(whichPlayer, Constants.UNIT_HHES_SWORDSMAN_QUEL_THALAS, spawn.X, spawn.Y, 270, 12);
      GeneralHelpers.CreateUnits(whichPlayer, Constants.UNIT_NHEA_RANGER_QUEL_THALAS, spawn.X, spawn.Y, 270, 12);
      LegendQuelthalas.LegendKael.StartingXp = GetHeroXP(LegendQuelthalas.LegendAnasterian.Unit);
      LegendQuelthalas.LegendKael.ForceCreate(whichPlayer, _secondChanceRect.Center, 270);
      UnitAddItem(LegendQuelthalas.LegendKael.Unit,
        CreateItem(Constants.ITEM_I00M_SUMMON_ELVEN_WORKERS, GetUnitX(LegendQuelthalas.LegendKael.Unit),
          GetUnitY(LegendQuelthalas.LegendKael.Unit)));
    }
    
    private static void GrantPower(Faction whichFaction)
    {
      var manaAddiction = new UnitsStealMana(0.35f)
      {
        IconName = "ManaShield",
        Name = "Mana Addiction"
      };
      whichFaction.AddPower(manaAddiction);
      whichFaction.Player?.DisplayPowerAcquired(manaAddiction);
    }
  }
}