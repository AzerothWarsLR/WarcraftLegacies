namespace MacroTools.UserInterface
{
  /// <summary>A choice that can be made via a <see cref="ChoiceDialogPresenter{T}"/>.</summary>
  public sealed class Choice<T>
  {
    /// <summary>Internal data that the choice needs to know about.</summary>
    public T Data { get; }

    /// <summary>The text shown to the player.</summary>
    public string Name { get; }

    public Choice(T data, string name)
    {
      Data = data;
      Name = name;
    }
  }
}