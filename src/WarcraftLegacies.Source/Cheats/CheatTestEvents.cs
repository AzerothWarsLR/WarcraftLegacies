using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.GameTime;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Registers some test events so the Events menu and banner can be tried out.
/// </summary>
public sealed class CheatTestEvents : Command
{
  /// <inheritdoc />
  public override string CommandText => "testevents";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Registers some test events to try out the Events menu.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    WorldEventManager.Register(new TestWorldEvent(GiveEveryoneGold, new ObjectiveTurn(GameTimeManager.Turn + 1))
    {
      Name = "The Gathering Storm",
      IconName = "Cyclone",
      Description = "Happens next turn after a 30 second warning. Every player gets 200 gold.",
      WarningDuration = 30
    });

    WorldEventManager.Register(new TestWorldEvent(() => OfferPath(cheater))
    {
      Name = "A Fateful Offer",
      IconName = "Scroll",
      Description = "Happens after a 20 second warning, then offers a new path to whoever used the cheat.",
      WarningDuration = 20
    });

    return "Registered test events.";
  }

  private static void GiveEveryoneGold()
  {
    foreach (var whichPlayer in Util.EnumeratePlayers())
    {
      whichPlayer.SetState(playerstate.ResourceGold, whichPlayer.GetState(playerstate.ResourceGold) + 200);
    }
  }

  private static void OfferPath(player whichPlayer)
  {
    var faction = whichPlayer.GetPlayerData().Faction;
    if (faction == null)
    {
      return;
    }

    faction.AddPath(new TestPath(500)
    {
      Name = "Answer the Call",
      IconName = "Sacrifice",
      Description = "Offered by the A Fateful Offer event. Gives 500 gold.",
      CommitDuration = 10
    });
  }
}
