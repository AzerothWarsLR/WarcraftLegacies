
using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.UserInterface;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge
{
  public sealed class ScourgeInvasionDialogPresenter : ChoiceDialogPresenter<ScourgeInvasionChoice>
  {
    public ScourgeInvasionDialogPresenter(params ScourgeInvasionChoice[] invasionTargets) : base(invasionTargets,
      "Pick invasion location")
    {
    }

    protected override void OnChoicePicked(player pickingPlayer, ScourgeInvasionChoice choice)
    {
      HasChoiceBeenPicked = true;
      if (choice.Location == null)
        return;

      var invasionLocation = choice.Location;
      var center = invasionLocation.Center;
      var spreadRadius = 10;
      var angle = 0f;
      var angleStep = 45f;
      const float degreesToRadians = (float)(Math.PI / 180);

      var unitsToTeleport = GlobalGroup.EnumUnitsInRect(Regions.Northrend_Ambiance)
        .Where(x => x.OwningPlayer() == pickingPlayer)
        .Where(unit => !IsUnitType(unit, UNIT_TYPE_STRUCTURE) &&
                       !IsUnitType(unit, UNIT_TYPE_ANCIENT) &&
                       !IsUnitType(unit, UNIT_TYPE_PEON) &&
                       GetResourceAmount(unit) == 0 &&
                       OrderId2String(GetUnitCurrentOrder(unit)) != "harvest");

      foreach (var unit in unitsToTeleport)
      {
        var x = center.X + spreadRadius * (float)Math.Cos(angle * degreesToRadians);
        var y = center.Y + spreadRadius * (float)Math.Sin(angle * degreesToRadians);
        SetUnitPosition(unit, x, y);

        if (IsUnitType(unit, UNIT_TYPE_SUMMONED) && choice.AttackTarget != null)
        {
          IssuePointOrder(unit, "attack", choice.AttackTarget.X, choice.AttackTarget.Y);
        }

        angle += angleStep;
        if (angle >= 360)
        {
          angle = 0;
          spreadRadius += 10;
        }
      }
      
      pickingPlayer.RepositionCamera(invasionLocation.Center);
    }

    protected override ScourgeInvasionChoice GetDefaultChoice(player whichPlayer) => Choices.First();

    protected override bool IsChoiceActive(player whichPlayer, ScourgeInvasionChoice choice) => true;
  }
}