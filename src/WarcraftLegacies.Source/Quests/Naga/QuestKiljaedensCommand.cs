using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.FactionMechanics.Scourge;
using WarcraftLegacies.Source.Objectives;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WarcraftLegacies.Source.Powers;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestKiljaedensCommand : QuestData
{
  private readonly Faction _scourge;
  private readonly Faction _druids;
  private readonly Faction _ahnQiraj;
  private readonly LegendaryHero _cthun;
  private readonly Capital _nordrassil;
  private readonly LegendaryHero _illidan;
  private Faction? _questTarget;
  private unit? _kiljaeden;

  public QuestKiljaedensCommand(Faction scourge, Faction druids, Faction ahnQiraj, LegendaryHero cthun,
    Capital nordrassil, LegendaryHero illidan) : base("Kil'jaeden's Command",
    "Before retreating to Outland, Illidan was visited by the demon lord Kil'jaeden, who demanded that he destroy the Legion's foes. The Deceiver has now come to claim his due, and this time he will not be denied.",
    @"ReplaceableTextures\CommandButtons\BTNKiljaedin.blp")
  {
    _scourge = scourge;
    _druids = druids;
    _ahnQiraj = ahnQiraj;
    _cthun = cthun;
    _nordrassil = nordrassil;
    _illidan = illidan;
    AddObjective(new ObjectiveExpire(3600, "Kil'jaeden's Command"));
    Knowledge = 15;
  }

  protected override string RewardDescription =>
    "You gain the Kil'jaeden's Cunning Power, which causes your units' magic and spell damage to execute enemies";

  protected override string PenaltyDescription => "Illidan loses 5 Strength, Agility, and Intelligence";

  /// <inheritdoc />
  public override string RewardFlavour
  {
    get
    {
      if (_questTarget == _scourge)
      {
        return "With the Frozen Throne now ruptured beyond repair, Kil'jaeden's concerns over the upstart Lich King have been put to rest. The Deceiver upholds his end of the bargain, and bestows unto the Illidari his gift.";
      }

      if (_questTarget == _ahnQiraj)
      {
        return "The Old God C'thun has excised from the world, ridding the Legion - and Azeroth - of an ancient threat. The Deceiver upholds his end of the bargain, and bestows unto the Illidari his gift.";
      }

      if (_questTarget == _druids)
      {
        return "In an act of fratricide, Illidan has defeated the Legion's ancient enemies and seized Nordrassil for Kil'jaeden. The Deceiver upholds his end of the bargain, and bestows unto the Illidari his gift.";
      }

      return "";
    }
  }

  /// <inheritdoc />
  public override string PenaltyFlavour =>
     "Illidan has failed to, or refused to, obey Kil'jaeden's command. For his disobedience, the Deceiver rips a portion of Illidan's power from his body, and turns his back to scheme elsewhere.";

  protected override void OnComplete(Faction whichFaction)
  {
    whichFaction.AddPower(new KiljaedensCunning(30));
    RemoveKiljaeden();
  }

  /// <inheritdoc />
  protected override void OnFail(Faction whichFaction)
  {
    _illidan.Unit?.AddHeroAttributes(-5, -5, -5);
    RemoveKiljaeden();
  }

  protected override void OnAdd(Faction whichFaction)
  {
    SpawnKiljaeden();
    SetQuestTarget(CalculateQuestTarget());
  }

  private Faction CalculateQuestTarget()
  {
    var eligibleFactions = new List<Faction>();

    if (TheFrozenThrone.State == FrozenThroneState.Alive)
    {
      eligibleFactions.Add(_scourge);
    }

    if (_cthun.Unit != null && _cthun.Unit.Alive)
    {
      eligibleFactions.Add(_ahnQiraj);
    }

    if (_nordrassil.Unit != null && _nordrassil.Unit.Alive)
    {
      eligibleFactions.Add(_druids);
    }

    var factionTarget = eligibleFactions
      .OrderByDescending(f => f.Player?.GetPlayerData().ControlPoints.Count)
      .First();
    return factionTarget;
  }

  private void SetQuestTarget(Faction faction)
  {
    _questTarget = faction;

    if (faction == _scourge)
    {
      AddObjective(new ObjectiveFrozenThroneState(FrozenThroneState.Ruptured));
      AddObjective(new ObjectiveControlPoint(UNIT_N04R_ICECROWN_CITADEL, 0));
    }

    if (faction == _druids)
    {
      AddObjective(new ObjectiveControlCapital(_nordrassil, false));
      AddObjective(new ObjectiveControlPoint(UNIT_N01P_NORDRASSIL, 0));
    }

    if (faction == _ahnQiraj)
    {
      AddObjective(new ObjectiveLegendDead(_cthun));
      AddObjective(new ObjectiveControlPoint(UNIT_NLSE_TEMPLE_OF_AHN_QIRAJ));
    }
  }

  private void SpawnKiljaeden()
  {
    _kiljaeden = unit.Create(player.NeutralPassive, UNIT_U004_THE_DECEIVER_LEGION, 5827, -30923, 185);
    _kiljaeden.HeroLevel = 20;
    _kiljaeden.IsInvulnerable = true;
    var darkPortalEffect = effect.Create(@"Abilities\Spells\Demon\DarkPortal\DarkPortalTarget.mdl", _kiljaeden.X, _kiljaeden.Y);
    darkPortalEffect.Dispose();
  }

  private void RemoveKiljaeden()
  {
    if (_kiljaeden != null)
    {
      var darkPortalEffect = effect.Create(@"Abilities\Spells\Demon\DarkPortal\DarkPortalTarget.mdl", _kiljaeden.X, _kiljaeden.Y);
      darkPortalEffect.Dispose();
      _kiljaeden.Dispose();
    }
  }
}
