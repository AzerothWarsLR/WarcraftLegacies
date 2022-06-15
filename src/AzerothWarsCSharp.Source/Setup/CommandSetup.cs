using AzerothWarsCSharp.Source.Commands;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class CommandSetup
  {
    public static void Setup()
    {
      InviteCommand.Setup();
      JoinCommand.Setup();
      LimitedCommand.Setup();
      ObserverCommand.Setup();
      UnallyCommand.Setup();
      UninviteCommand.Setup();
    }
  }
}