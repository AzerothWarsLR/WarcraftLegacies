using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Sounds;
using MacroTools.Localization;

namespace MacroTools.Extensions;

public static class PlayerDisplayExtensions
{
  /// <summary>
  /// Displays a nicely formatted hint to the player.
  /// </summary>
  public static void DisplayHint(this player whichPlayer, string msg)
  {
    whichPlayer.DisplayTextTo($"\n|cff00ff00{Loc.Get("HINT")}|r - {msg}");
    if (player.LocalPlayer == whichPlayer)
    {
      SoundLibrary.Hint.Start();
    }
  }

  /// <summary>
  /// Displays a nicely formatted hint to the player that one of their heroes has gained some stats.
  /// </summary>
  public static void DisplayHeroReward(this unit whichUnit, int strength, int agility, int intelligence,
    int experience)
  {
    var display = $"\n|cff00ff00{Loc.Get("HERO REWARD EARNED")} -{whichUnit.HeroName}|r";
    if (strength > 0)
    {
      display = $"{display}\n+{strength} {Loc.Get("Strength")}";
    }

    if (agility > 0)
    {
      display = $"{display}\n+{agility} {Loc.Get("Agility")}";
    }

    if (intelligence > 0)
    {
      display = $"{display}\n+{intelligence} {Loc.Get("Intelligence")}";
    }

    if (experience > 0)
    {
      display = $"{display}\n+{experience} {Loc.Get("Experience")}";
    }

    whichUnit.Owner.DisplayTextTo(display);
    if (player.LocalPlayer == whichUnit.Owner)
    {
      SoundLibrary.Hint.Start();
    }
  }

  /// <summary>
  /// Displays a nicely formatted hint to the player that one of their unit limits has increased.
  /// </summary>
  public static void DisplayUnitLimit(this Faction whichFaction, int unitTypeId)
  {
    var message = Loc.Format(
      "You can now train up to {limit} units of type {unit}.",
      ("{limit}", whichFaction.GetObjectLimit(unitTypeId).ToString()),
      ("{unit}", GetObjectName(unitTypeId)));

    whichFaction.Player.DisplayTextTo($"\n|cff00ff00{Loc.Get("UNIT LIMIT CHANGED")} - {GetObjectName(unitTypeId)}|r\n{message}");
    if (player.LocalPlayer == whichFaction.Player)
    {
      SoundLibrary.Hint.Start();
    }
  }

  /// <summary>
  /// Displays a nicely formatted hint to the player that they have acquired a research.
  /// </summary>
  public static void DisplayResearchAcquired(this player whichPlayer, int researchId, int researchLevel)
  {
    whichPlayer.DisplayTextTo($"\n|cff00ff00{Loc.Get("RESEARCH ACQUIRED")} - {GetObjectName(researchId)}|r\n{BlzGetAbilityExtendedTooltip(researchId, researchLevel)}");
    if (player.LocalPlayer == whichPlayer)
    {
      SoundLibrary.Hint.Start();
    }
  }

  /// <summary>
  /// Displays a nicely formatted hint to the player that they have unlocked a new unit type.
  /// </summary>
  public static void DisplayUnitTypeAcquired(this player whichPlayer, int unitId, string flavor)
  {
    whichPlayer.DisplayTextTo($"\n|cff00ff00{Loc.Get("NEW UNIT ACQUIRED")} - {GetObjectName(unitId)}\n|r{Loc.Get(flavor)}");
    if (player.LocalPlayer == whichPlayer)
    {
      SoundLibrary.Hint.Start();
    }
  }

  /// <summary>
  /// Alerts the player that one of their researches has been refunded.
  /// </summary>
  public static void DisplayRefundedResearch(this player whichPlayer, int researchTypeId)
  {
    var message = Loc.Format(
      "You cannot research {research}. All resources spent on it have been refunded.",
      ("{research}", GetObjectName(researchTypeId)));

    whichPlayer.DisplayTextTo($"\n|cff008000{Loc.Get("REFUND")}|r - {message}");
  }

  /// <summary>
  /// Indicates to the player that they have acquired a new <see cref="Power"/>.
  /// </summary>
  public static player DisplayPowerAcquired(this player whichPlayer, Power power)
  {
    whichPlayer.DisplayTextTo($"\n|cff00ff00{Loc.Get("NEW POWER ACQUIRED")} - {power.Name}\n|r{power.Description}");
    if (player.LocalPlayer == whichPlayer)
    {
      SoundLibrary.Hint.Start();
    }

    return whichPlayer;
  }

  /// <summary>
  /// Indicates to the player that a <see cref="LegendaryHero"/> has been summoned.
  /// </summary>
  public static void DisplayLegendaryHeroSummoned(this player whichPlayer, LegendaryHero legendaryHero,
    string message)
  {
    whichPlayer.DisplayTextTo($"\n|cffd45e19{Loc.Get("LEGENDARY FOE SUMMONED")} - {legendaryHero.Name}\n|r{Loc.Get(message)}");
    SoundLibrary.Warning.Start();
  }

  /// <summary>
  /// Pings the minimap using some sensible defaults.
  /// </summary>
  public static player PingMinimapSimple(this player whichPlayer, float x, float y, float duration, int red = 255,
    int green = 255, int blue = 255, bool extraEffects = false)
  {
    if (player.LocalPlayer == whichPlayer)
    {
      PingMinimapEx(x, y, duration, red, green, blue, extraEffects);
    }

    return whichPlayer;
  }
}
