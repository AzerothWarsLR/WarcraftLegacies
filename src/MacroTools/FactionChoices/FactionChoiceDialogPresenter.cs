using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.UserInterface;
using static War3Api.Common;

namespace MacroTools.FactionChoices
{
  /// <summary>Allows a player to choose between one of two factions at the start of the game.</summary>
  public sealed class FactionChoiceDialogPresenter : ChoiceDialogPresenter<Faction>
  {
    /// <summary>Initializes a new instance of the <see cref="FactionChoiceDialogPresenter"/> class.</summary>
    public FactionChoiceDialogPresenter(params Faction[] factions) : base(ConvertToFactionChoices(factions),
      "Pick your Faction")
    {
    }

    protected override void OnChoicePicked(player pickingPlayer, Choice<Faction> choice)
    {
      var pickedFaction = choice.Data;
      HasChoiceBeenPicked = true;
      
      var startingUnits = pickedFaction.StartingUnits;

      foreach (var unit in startingUnits)
        unit.ReplaceWithFactionEquivalent(pickedFaction).Rescue(pickingPlayer);

      if (pickedFaction.StartingCameraPosition != null)
        pickingPlayer.RepositionCamera(pickedFaction.StartingCameraPosition);

      pickingPlayer.SetFaction(pickedFaction);
      FactionManager.Register(pickedFaction);

      var unpickedFactions = Choices.Where(x => x.Data != choice.Data).ToList();
      foreach (var unpickedFaction in unpickedFactions)
        unpickedFaction.Data.OnNotPicked();
    }

    /// <inheritdoc />
    protected override Choice<Faction> GetDefaultChoice(player whichPlayer) => Choices.First();

    private static Choice<Faction>[] ConvertToFactionChoices(IEnumerable<Faction> factions)
    {
      return factions
        .Select(x => new Choice<Faction>(x, $"{x.Name} {x.LearningDifficulty.ToColoredText()}"))
        .ToArray();
    }
  }
}