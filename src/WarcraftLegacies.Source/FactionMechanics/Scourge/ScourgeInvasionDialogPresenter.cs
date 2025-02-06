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
      foreach (var unit in GlobalGroup.EnumUnitsInRect(Regions.Northrend_Ambiance)
                 .Where(x => x.OwningPlayer() == pickingPlayer))
      {
        if (IsUnitType(unit, UNIT_TYPE_STRUCTURE) || IsUnitType(unit, UNIT_TYPE_ANCIENT) ||
            IsUnitType(unit, UNIT_TYPE_PEON) ||
            GetResourceAmount(unit) > 0 || OrderId2String(GetUnitCurrentOrder(unit)) == "harvest") 
          continue;
        
        if (invasionLocation != null)
          SetUnitPosition(unit, invasionLocation.Center.X, invasionLocation.Center.Y);
      }

      if (invasionLocation != null)
        pickingPlayer.RepositionCamera(invasionLocation.Center);
    }

    /// <inheritdoc />
    protected override ScourgeInvasionChoice GetDefaultChoice(player whichPlayer) => Choices.First();

    /// <inheritdoc />
    protected override bool IsChoiceActive(player whichPlayer, ScourgeInvasionChoice choice) => true;
  }
}