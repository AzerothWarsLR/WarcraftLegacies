using System;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Buffs;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public sealed class HeraldBuff : PassiveBuff
  {
    private const string DEATH_EFFECT = "Abilities\\Spells\\Items\\AIre\\AIreTarget.mdl";
    private const string RETURNTONYALOTHA_EFFECT = "Abilities\\Spells\\Items\\AIre\\AIreTarget.mdl";
    private BlackEmpirePortal? _linkedPortal; //Each Herald keeps a BlackEmpirePortal active while alive.

    public HeraldBuff(unit caster, unit target) : base(caster, target)
    {
      try
      {
        if (Instance != null)
        {
          throw new Exception($"Tried to create a second {nameof(HeraldBuff)}. There can only be one.");
        }

        Instance = this;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    public static HeraldBuff? Instance { get; private set; }

    public override void OnApply()
    {
      _linkedPortal = BlackEmpirePortalManager.CurrentObjective;
      _linkedPortal.State = BlackEmpirePortalState.ExitOnly;
      BlzSetUnitName(Target, $"Herald of {_linkedPortal?.Name}");
    }

    public override void OnDispose()
    {
      ReturnToNyalotha();
      if (_linkedPortal?.State == BlackEmpirePortalState.ExitOnly)
      {
        _linkedPortal.State = BlackEmpirePortalState.Closed;
      }

      _linkedPortal = null;
      Instance = null;
    }

    public override void OnDeath(bool killingBlow)
    {
      DestroyEffect(AddSpecialEffect(DEATH_EFFECT, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit())));
    }

    private static void ReturnUnitToNyalotha(unit whichUnit)
    {
      var angle = GetRandomReal(0, 360);
      var distance = GetRandomReal(100, 400);
      var x = MathEx.GetPolarOffsetX(-25543, distance, angle);
      var y = MathEx.GetPolarOffsetY(-1962, distance, angle);

      DestroyEffect(AddSpecialEffect(RETURNTONYALOTHA_EFFECT, GetUnitX(whichUnit), GetUnitY(whichUnit)));
      DestroyEffect(AddSpecialEffect(RETURNTONYALOTHA_EFFECT, x, y));

      SetUnitX(whichUnit, x);
      SetUnitY(whichUnit, y);
      IssueImmediateOrder(whichUnit, "stop");
    }

    private static void ReturnToNyalotha()
    {
      if (BlackEmpireSetup.BlackEmpire.Player != null)
        foreach (var unit in new GroupWrapper().EnumUnitsOfPlayer(BlackEmpireSetup.BlackEmpire.Player)
          .EmptyToList())
        {
          if (!Regions.NyalothaInstance.Contains(unit.GetPosition()) && !BlzIsUnitInvulnerable(unit) &&
              !IsUnitType(unit, UNIT_TYPE_ANCIENT))
          {
            if (IsUnitType(unit, UNIT_TYPE_STRUCTURE))
            {
              KillUnit(unit);
            }
            else
            {
              ReturnUnitToNyalotha(unit);
            }
          }
        }
    }
  }
}