using War3Map.Template.Common.Constants;

using static War3Api.Common;

namespace War3Map.Template.Source
{
    internal static class Program
    {
        private static void Main()
        {
            for (var i = 0; i < PlayerConstants.PlayerSlotCount; i++)
            {
                BlzDisplayChatMessage(Player(i), 0, "Hello world!");
            }
        }
    }
}