namespace MacroTools.UserInterface;

/// <summary>A choice that can be made via a <see cref="ChoiceDialogPresenter{T}"/>.</summary>
public interface IChoice
{
  /// <summary>The text shown to the player.</summary>
  public string Name { get; }
}
