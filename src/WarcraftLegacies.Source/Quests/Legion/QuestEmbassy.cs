using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestEmbassy : QuestData
  {
    private static readonly int AltarId = FourCC("u01N");

    public QuestEmbassy() : base("Infernal Foothold",
      "A stronger foothold in this world will be required to field the Burning Legion's war machines and to in more of its lieutenants."
      , "ReplaceableTextures\\CommandButtons\\BTNDemonBlackCitadel.blp")
    {
      AddObjective(new ObjectiveUpgrade(FourCC("e01H"), FourCC("e01F")));
      ResearchId = FourCC("R042");
    }

    protected override string CompletionPopup => "The Legion has secured a foothold on Azeroth.";

    protected override string RewardDescription =>
      "You can build the Infernal Machine Factory and summon Anetheron from the " + GetObjectName(AltarId);
  }
}