using AzerothWarsCSharp.Template.Source.Setup;
using AzerothWarsCSharp.Common.Constants;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source
{
  internal static class Program
  {
    private static void Main()
    {
      for (var i = 0; i < PlayerConstants.PlayerSlotCount; i++)
      {
        BlzDisplayChatMessage(Player(i), 0, "Hello world!");
      }
      GameSetup.Initialize();
    }
  }
}