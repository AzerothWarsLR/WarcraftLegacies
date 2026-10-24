using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Dalaran.Paths;

/// <summary>With Gilneas City in Dalaran's hands, Genn Greymane raises the kingdom of Gilneas in its place.</summary>
public abstract class PathGilneas : FactionPath
{
  private readonly GilneasTransformation _transformation;

  protected PathGilneas(GilneasTransformation transformation)
  {
    _transformation = transformation;
    IconName = "Greymane";
    AddMustStayTrueRequirement(new ObjectiveControlCapital(AllLegends.Gilneas.GilneasCastle, false) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <summary>The text shown to the player once Gilneas forms; {faction} is replaced with the faction's name.</summary>
  protected string IntroTemplate { get; init; } = "";

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    var whichPlayer = faction.Player;
    _transformation.Execute(faction);
    if (whichPlayer == null)
    {
      return;
    }

    var gilneas = whichPlayer.GetPlayerData().Faction;
    if (gilneas != null)
    {
      whichPlayer.DisplayTextTo(Loc.Format(IntroTemplate,
        ("{faction}", $"{gilneas.PrefixCol}{Loc.Get("Kingdom of Gilneas")}|r")));
      OnFormed(gilneas);
    }
  }

  /// <summary>Runs once Gilneas has formed, for anything only this path gives it.</summary>
  protected virtual void OnFormed(Faction gilneas)
  {
  }
}
