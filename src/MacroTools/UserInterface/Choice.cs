namespace MacroTools.UserInterface
{
  /// <summary>A choice that can be made via a <see cref="ChoiceDialoguePresenter{T}"/>.</summary>
  public readonly struct Choice<T>
  {
    /// <summary>Internal data that the choice needs to know about.</summary>
    public T Data { get; init; }

    /// <summary>The text shown to the player.</summary>
    public string Name { get; init; }
  }
}