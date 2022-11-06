using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Warsong
{
    public class QuestScepterOfTheQueenWarsong : QuestData
    {
        public QuestScepterOfTheQueenWarsong(Rectangle area) : base("Royal Plunder", "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Feathermoon Stronghold falls, it would become a simple matter to slaughter the Highborne and plunder their artifacts.", "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2.blp")
        {
            HighBourneArea = area;
            AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendWarsong.StonemaulKeep));
            AddObjective(new ObjectiveLegendDead(LegendSentinels.legendFeathermoon));
            AddObjective(new ObjectiveAnyUnitInRect(HighBourneArea, "Dire Maul", true));
            HighBourneArea.Rect.MakeUnitsInvulnerable();
        }

        private Rectangle HighBourneArea { get; }
        protected override string CompletionPopup => "The Highborne are no longer implicitly defended by the Night Elven presence at Feathermoon Stronghold. The Horde unleashes their full might against these Night Elven arcanists.";
        protected override string RewardDescription => "Gain the Scepter of the Queen and turn all units in Dire Maul hostile";

        protected override void OnComplete(Faction whichFaction)
        {
            base.OnComplete(whichFaction);
            ArtifactSetup.ArtifactScepterofthequeen?.Item.SetPosition(new Point(GetRectCenterX(HighBourneArea.Rect), GetRectCenterY(HighBourneArea.Rect)));
            if (whichFaction.Player != null)
                HighBourneArea.Rect.ChangeUnitsOwningPlayer(Player(GetPlayerNeutralPassive()), whichFaction.Player);
        }
    }
}
