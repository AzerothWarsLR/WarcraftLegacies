using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Factions.Illidari;

/// <summary>The Fel Horde pays part of its income to the Illidari.</summary>
public sealed class OutlandTithe
{
  /// <summary>The share of the Fel Horde's income that goes to the Illidari, as a percentage.</summary>
  public const int Percent = 25;

  private const float Share = Percent / 100f;

  private readonly Faction _felHorde;
  private readonly Faction _illidari;

  public OutlandTithe(Faction felHorde, Faction illidari)
  {
    _felHorde = felHorde;
    _illidari = illidari;
  }

  public void Start()
  {
    var felHordePlayer = _felHorde.Player;
    var illidariPlayer = _illidari.Player;
    if (felHordePlayer == null || illidariPlayer == null)
    {
      return;
    }

    var felHordeData = felHordePlayer.GetPlayerData();
    felHordeData.PayTithe(illidariPlayer.GetPlayerData(), Share);
    _felHorde.ScoreStatusChanged += _ => felHordeData.StopTithe();
    _illidari.ScoreStatusChanged += _ => felHordeData.StopTithe();

    var message = Loc.Format("{felHorde} bends the knee, and {percent}% of its income now flows to {illidari}.",
      ("{felHorde}", _felHorde.ColoredName), ("{percent}", Percent.ToString()), ("{illidari}", _illidari.ColoredName));
    felHordePlayer.DisplayTextTo(message);
    illidariPlayer.DisplayTextTo(message);
  }
}
