using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestConsumeTree : QuestData
  {
    public QuestConsumeTree() : base("Twilight of the Gods",
      "Consuming the World Tree will grant Archimonde immeasurable power and eliminate his mortal enemies, the Druids of Kalimdor, forever.",
      "ReplaceableTextures\\CommandButtons\\BTNGlazeroth.blp")
    {
      AddQuestItem(new QuestItemChannelRect(Regions.ArchimondeChannel, "The World Tree",
        LegendLegion.LEGEND_ARCHIMONDE, 420, 90));
      Global = true;
    }

    protected override string CompletionPopup =>
      "Archimonde has now consummed the World Tree and is now nigh unstoppable";

    protected override string RewardDescription =>
      "By consuming the World Tree, Archimonde will obtain immense power. +80 to all stats. Additionally, the Druids faction will be eliminated.";


    protected override void OnComplete()
    {
      unit whichUnit = LegendLegion.LEGEND_ARCHIMONDE.Unit;
      DruidsSetup.factionDruids.Obliterate();
      BlzSetUnitName(whichUnit, "Devourer of Worlds");
      AddSpecialEffectTarget("Abilities\\Weapons\\GreenDragonMissile\\GreenDragonMissile.mdl", whichUnit,
        "hand, right");
      AddSpecialEffectTarget("Abilities\\Weapons\\GreenDragonMissile\\GreenDragonMissile.mdl", whichUnit, "hand, left");
      whichUnit.AddHeroAttributes(80, 80, 80);
    }
  }
}