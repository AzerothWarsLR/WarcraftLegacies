using MacroTools.FactionChoices;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup
{
  public static class FactionChoiceDialogSetup
  {
    public static void Setup()
    {
      new FactionChoiceDialogPresenter(ZandalarSetup.Zandalar, GoblinSetup.Goblin).Run(Player(8));
      new FactionChoiceDialogPresenter(IllidariSetup.Illidari, SunfurySetup.Sunfury).Run(Player(15));
      new FactionChoiceDialogPresenter(DalaranSetup.Dalaran, GilneasSetup.Gilneas).Run(Player(7));
    }
  }
}