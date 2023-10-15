using System;
using static War3Api.Common;

namespace MacroTools.UserInterface
{
  public sealed class ChoiceDialoguePresenterEventArgs : EventArgs
  {
    public ChoiceDialoguePresenterEventArgs(player player, string choice)
    {
      Player = player;
      Choice = choice;
    }

    public player Player { get; }
    public string Choice { get; }
  }
}