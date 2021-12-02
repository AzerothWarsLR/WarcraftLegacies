using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries.Commands
{
  public class Command
  {
    public string Activator { get; }
    public OnCommandDelegate OnCommand { get; }
    
    public delegate void OnCommandDelegate(player triggerPlayer, string[] arguments);

    protected Command(string activator, OnCommandDelegate onCommand)
    {
      Activator = activator;
      OnCommand = onCommand;
    }
  }
}