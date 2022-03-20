using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Commands
{
  public static class AllyInfoCommand
  {
    private const string COMMAND = "-ally";
    private const string INFO_COLOR = "|c00add8e6";


    private static void Actions()
    {
      Person whichPerson = Person.ByHandle(GetTriggerPlayer());

      DisplayTextToPlayer(whichPerson.Player, 0, 0, @"The ally command have changed, they are now:
-invite (faction name)
-join (team name)
-uninvite (faction name)
-unally");
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      var i = 0;

      while (true)
      {
        if (i > Environment.MAX_PLAYERS)
        {
          break;
        }

        TriggerRegisterPlayerChatEvent(trig, Player(i), COMMAND, false);
        i = i + 1;
      }

      TriggerAddAction(trig, Actions);
    }
  }
}