using MacroTools;
using MacroTools.FactionChoices;
using WarcraftLegacies.Source.Factions;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup
{
  public static class FactionChoiceDialogSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      new FactionChoiceDialogPresenter(ZandalarSetup.Zandalar, GoblinSetup.Goblin).Run(Player(8));
      new FactionChoiceDialogPresenter(IllidariSetup.Illidari, SunfurySetup.Sunfury).Run(Player(15));
      new FactionChoiceDialogPresenter(new Dalaran(preplacedUnitSystem, artifactSetup, allLegendSetup),
        new Gilneas(preplacedUnitSystem, artifactSetup, allLegendSetup)).Run(Player(7));
    }
  }
}