using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
    public class QuestScepterOfTheQueenSentinels : QuestData
    {
        public QuestScepterOfTheQueenSentinels(Rectangle area) : base("Return to the Fold", "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Stonemaul falls, it would be safe for them to come out.", "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2.blp")
        {
            HighBourneArea = area;
            AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendSentinels.legendFeathermoon));
            AddObjective(new ObjectiveLegendDead(LegendWarsong.StonemaulKeep));
            AddObjective(new ObjectiveAnyUnitInRect(Regions.HighBourne, "Dire Maul", true));
            ResearchId = FourCC("R020");
            HighBourneArea.Rect.MakeUnitsInvulnerable();
        }

        private Rectangle HighBourneArea { get; }
        protected override string CompletionPopup => "The Shen'dralar, the Highborne survivors of the Sundering, swear allegiance to their fellow Night Elves. As a sign of their loyalty, they offer up an artifact they have guarded for thousands of years: the Scepter of the Queen.";
        protected override string RewardDescription => "Gain the Scepter of the Queen and control of all units in Dire Maul";

        protected override void OnComplete(Faction whichFaction)
        {
            ArtifactSetup.ArtifactScepterofthequeen?.Item.SetPosition(new Point(GetRectCenterX(HighBourneArea.Rect), GetRectCenterY(HighBourneArea.Rect)));
            SetPlayerTechResearched(whichFaction.Player, ResearchId, 1);
            if (whichFaction.Player != null)
                HighBourneArea.Rect.ChangeUnitsOwningPlayer(Player(GetPlayerNeutralPassive()), whichFaction.Player);
        }

        protected override void OnAdd(Faction whichFaction)
        {
            base.OnAdd(whichFaction);
            whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
        }

        protected override void OnFail(Faction whichFaction)
        {
            base.OnFail(whichFaction);
            whichFaction.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
        }

        
    }
}
