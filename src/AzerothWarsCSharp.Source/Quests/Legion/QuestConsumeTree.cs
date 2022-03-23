using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestConsumeTree : QuestData
  {
    private Global()
    {
      return true;
    }

    public QuestConsumeTree() : base("Twilight of the Gods",
      "Consuming the World Tree will grant Archimonde immeasurable power && eliminate his mortal enemies, the Druids of Kalimdor, forever.",
      "ReplaceableTextures\\CommandButtons\\BTNGlazeroth.blp")
    {
      AddQuestItem(new QuestItemChannelRect(Regions.ArchimondeChannel, "The World Tree", LEGEND_ARCHIMONDE, 420, 90));
    }

    protected override string CompletionPopup =>
      "Archimonde has now consummed the World Tree && is now nigh unstoppable";

    protected override string CompletionDescription =>
      "By consuming the World Tree, Archimonde will obtain immense power. +80 to all stats. Additionally, the Druids faction will be eliminated.";


    bool operator

    protected override void OnComplete()
    {
      unit whichUnit = LEGEND_ARCHIMONDE.Unit;
      FACTION_DRUIDS.obliterate();
      BlzSetUnitName(whichUnit, "Devourer of Worlds");
      AddSpecialEffectTarget("Abilities\\Weapons\\GreenDragonMissile\\GreenDragonMissile.mdl", whichUnit,
        "hand, right");
      AddSpecialEffectTarget("Abilities\\Weapons\\GreenDragonMissile\\GreenDragonMissile.mdl", whichUnit, "hand, left");
      AddHeroAttributes(whichUnit, 80, 80, 80);
    }
  }
}