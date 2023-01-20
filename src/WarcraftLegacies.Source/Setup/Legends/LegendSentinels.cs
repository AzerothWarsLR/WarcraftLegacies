using MacroTools;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for setting up and storing all Sentinel <see cref="Legend"/>s.
  /// </summary>
  public sealed class LegendSentinels : IRegistersLegends
  {
    /// <summary>
    /// Leader of the Wardens.
    /// </summary>
    public LegendaryHero? Maiev { get; }

    /// <summary>
    /// High Priestess of Elune.
    /// </summary>
    public LegendaryHero? Tyrande { get; }
    
    /// <summary>
    /// Tyrande's second in command.
    /// </summary>
    public LegendaryHero? Shandris { get; }
    
    /// <summary>
    /// Night Elven Commander.
    /// </summary>
    public LegendaryHero? Jarod { get; }
    
    /// <summary>
    /// Night Elven town in Darkshore.
    /// </summary>
    public Capital? Auberdine { get; }
    
    /// <summary>
    /// Night Elven stronghold village led by Shandris.
    /// </summary>
    public Capital? Feathermoon { get; }

    /// <summary>
    /// Where the Wardens store their worst enemies.
    /// </summary>
    public Capital? VaultOfTheWardens { get; }
    
    public Capital? BlackrookHold { get; }
    
    /// <summary>
    /// Sets up all Sentinel <see cref="Legend"/>s.
    /// </summary>
    public LegendSentinels(PreplacedUnitSystem preplacedUnitSystem)
    {
      Maiev = new LegendaryHero("Maiev Shadowsong")
      {
        UnitType = FourCC("Ewrd")
      };

      Auberdine = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("e00J"))
      };

      Feathermoon = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("e00M"))
      };

      Tyrande = new LegendaryHero("Tyrande Whisperwind")
      {
        UnitType = FourCC("Etyr"),
        PlayerColor = PLAYER_COLOR_CYAN
      };

      Shandris = new LegendaryHero("Shandris Feathermoon")
      {
        UnitType = FourCC("E002"),
        StartingXp = 1000
      };

      Jarod = new LegendaryHero("Jarod Shadowsong")
      {
        UnitType = FourCC("O02E"),
        StartingXp = 4000
      };

      VaultOfTheWardens = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_N04G_VAULT_OF_THE_WARDENS_SENTINELS)
      };
      
      BlackrookHold = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H03C_BLACK_ROOK_HOLD_NEUTRAL_HOSTILE)
      };
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Maiev);
      LegendaryHeroManager.Register(Tyrande);
      LegendaryHeroManager.Register(Shandris);
      LegendaryHeroManager.Register(Jarod);
      CapitalManager.Register(Auberdine);
      CapitalManager.Register(Feathermoon);
      CapitalManager.Register(BlackrookHold);
    }
  }
}