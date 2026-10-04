using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Illidari.Powers;
using WarcraftLegacies.Source.Factions.Scourge.Mechanics;
using WarcraftLegacies.Source.Objectives;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Illidari.Quests;

public sealed class QuestKiljaedensCommand : QuestData
{
  private const string BargainUpheld = " The Deceiver upholds his end of the bargain, and bestows unto the Illidari his gift.";

  private readonly LegendaryHero _illidan;
  private readonly List<KiljaedenTarget> _targets;
  private readonly KiljaedenTarget _frozenThroneTarget;
  private KiljaedenTarget? _questTarget;
  private unit? _kiljaeden;

  public QuestKiljaedensCommand(LegendaryHero illidan) : base("Kil'jaeden's Command",
    "Before retreating to Outland, Illidan was visited by the demon lord Kil'jaeden, who demanded that he destroy the Legion's foes. The Deceiver has now come to claim his due, and this time he will not be denied.",
    @"ReplaceableTextures\CommandButtons\BTNKiljaedin.blp")
  {
    _illidan = illidan;
    _frozenThroneTarget = new KiljaedenTarget(AllLegends.Scourge.TheFrozenThrone, UNIT_N04R_ICECROWN_CITADEL,
      "With the Frozen Throne now ruptured beyond repair, Kil'jaeden's concerns over the upstart Lich King have been put to rest.")
    {
      IsFrozenThrone = true
    };
    _targets = new List<KiljaedenTarget>
    {
      _frozenThroneTarget,
      new(AllLegends.Druids.Nordrassil, UNIT_N01P_NORDRASSIL,
        "In an act of fratricide, Illidan has defeated the Legion's ancient enemies and seized Nordrassil for Kil'jaeden."),
      new(AllLegends.Tauren.ThunderBluff, UNIT_N03M_THUNDERBLUFF,
        "Thunder Bluff has fallen to the Illidari, and the Tauren who stood against the Legion at Mount Hyjal have been scattered across the plains of Mulgore."),
      new(AllLegends.Orc.Orgrimmar, UNIT_N07P_ORGRIMMAR,
        "Orgrimmar lies in ruins. The orcs who broke free of the Legion's blood curse have paid dearly for their defiance."),
      new(AllLegends.Dalaran.Dalaran, UNIT_N01B_DALARAN,
        "The Violet Citadel has fallen to the Illidari, and the Kirin Tor will never again stand in the Legion's way."),
      new(AllLegends.Quel.Sunwell, UNIT_N01O_SILVERMOON,
        "Illidan has seized the Sunwell, the font of power that Kil'jaeden covets as his gateway into Azeroth.")
    };
    AddObjective(new ObjectiveExpire(60, "Kil'jaeden's Command"));
    Knowledge = 10;
  }

  protected override string RewardDescription =>
    "You gain the Kil'jaeden's Cunning Power, which causes your units' magic and spell damage to execute enemies";

  protected override string PenaltyDescription => "Illidan loses 5 Strength, Agility, and Intelligence";

  /// <inheritdoc />
  public override string RewardFlavour => _questTarget == null ? "" : _questTarget.Flavour + BargainUpheld;

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
    try
    {
      SpawnKiljaeden();
      SetQuestTarget(CalculateQuestTarget(whichFaction));
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  private KiljaedenTarget CalculateQuestTarget(Faction questHolder)
  {
    if (questHolder.Player == null)
    {
      return _frozenThroneTarget;
    }

    var target = _targets
      .Where(x => IsEligible(x, questHolder.Player))
      .OrderByDescending(x => x.Capital.Unit!.Owner.GetPlayerData().ControlPoints.Count)
      .FirstOrDefault();

    return target ?? _frozenThroneTarget;
  }

  private static bool IsEligible(KiljaedenTarget target, player questHolder)
  {
    var capitalUnit = target.Capital.Unit;
    if (capitalUnit == null || !capitalUnit.Alive)
    {
      return false;
    }

    if (target.IsFrozenThrone && TheFrozenThrone.State != FrozenThroneState.Alive)
    {
      return false;
    }

    var owner = capitalUnit.Owner;
    if (owner.GetPlayerData().Faction == null)
    {
      return false;
    }

    return owner.GetPlayerData().Team?.Contains(questHolder) == false;
  }

  private void SetQuestTarget(KiljaedenTarget target)
  {
    _questTarget = target;

    if (target.IsFrozenThrone)
    {
      AddObjective(new ObjectiveEitherOf(new ObjectiveCapitalDead(target.Capital),
        new ObjectiveFrozenThroneState(FrozenThroneState.Ruptured)));
    }
    else
    {
      AddObjective(new ObjectiveControlCapital(target.Capital, false));
    }

    AddObjective(new ObjectiveControlPoint(target.ControlPointId, 0));
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

  private sealed class KiljaedenTarget
  {
    public KiljaedenTarget(Capital capital, int controlPointId, string flavour)
    {
      Capital = capital;
      ControlPointId = controlPointId;
      Flavour = flavour;
    }

    public Capital Capital { get; }

    public int ControlPointId { get; }

    public string Flavour { get; }

    public bool IsFrozenThrone { get; init; }
  }
}
