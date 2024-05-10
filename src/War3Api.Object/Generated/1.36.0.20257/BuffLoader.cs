using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    internal class BuffLoader
    {
        protected virtual Buff LoadPause(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Pause, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Pause)";
            buff.TextTooltip = "Stunned";
            buff.TextTooltipExtended = "This unit will not move.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNStun.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadStun(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Stun, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Stunned";
            buff.TextTooltipExtended = "This unit is stunned; it cannot move, attack or cast spells.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNStun.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadCargoHoldDeath(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CargoHoldDeath, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Dizziness";
            buff.TextTooltipExtended = "This unit is dizzy; its attack rate and movement speed are reduced.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNDizzy.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDefense(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Defense, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Scroll of Protection";
            buff.TextTooltipExtended = "This unit is affected by a Scroll of Protection; its armor is temporarily increased.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNScroll.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadDetected(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Detected, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Detected";
            buff.TextTooltipExtended = "This unit is detected; an enemy player can see it.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNDustOfAppearance.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadFreeze(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Freeze, db);
            buff.TextNameEditorOnly = "Freeze";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadFrost(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Frost, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Slowed";
            buff.TextTooltipExtended = "This unit is slowed; it moves more slowly than it normally does.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNFrost.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadInvulnerable(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Invulnerable, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Invulnerable";
            buff.TextTooltipExtended = "This unit is invulnerable; it will not take damage from attacks and cannot be targeted by spells.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNInvulnerable.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPoisonAttack(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PoisonAttack, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Non-stacking)";
            buff.TextTooltip = "Poison";
            buff.TextTooltipExtended = "This unit is poisoned, and will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNEnvenomedSpear.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadPoisonAttackStackDoT(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PoisonAttackStackDoT, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Stacking)";
            buff.TextTooltip = "Poison";
            buff.TextTooltipExtended = "This unit is poisoned; it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNEnvenomedSpear.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadPoisonAttackStackInfo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PoisonAttackStackInfo, db);
            buff.TextNameEditorOnly = "Poison (Info)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSharedVision(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SharedVision, db);
            buff.TextNameEditorOnly = "Shared Vision";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSpeedBonus(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpeedBonus, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Speed Bonus";
            buff.TextTooltipExtended = "This unit has a speed bonus; it moves more quickly than it normally does.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBoots.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadTeleportReveal(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.TeleportReveal, db);
            buff.TextNameEditorOnly = "Teleport Reveal";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadCloudOfFog_Bclf(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CloudOfFog_Bclf, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Cloud";
            buff.TextTooltipExtended = "This building has a Cloud on it, and cannot use its ranged attack.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNCloudOfFog.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadControlMagic(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ControlMagic, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Control Magic";
            buff.TextTooltipExtended = "This unit has been controlled; it obeys a new master now.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNControlMagic.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadHeal(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Heal, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Heal";
            buff.TextTooltipExtended = "This unit is being healed; lost hit points are being restored.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNHeal.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadInnerFire(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.InnerFire, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Inner Fire";
            buff.TextTooltipExtended = "This unit has Inner Fire; its armor and attack damage are increased.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNInnerFire.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 1;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadInvisibility_Binv(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Invisibility_Binv, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Invisibility";
            buff.TextTooltipExtended = "This unit is invisible; enemy units cannot see it. If it attacks or casts a spell, it will become visible.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNInvisibility.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadMagicLeashCaster(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.MagicLeashCaster, db);
            buff.TextNameEditorOnly = "Aerial Shackles (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "AerialShacklesLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadMagicLeashTarget(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.MagicLeashTarget, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Aerial Shackles";
            buff.TextTooltipExtended = "This unit is bound in Aerial Shackles; it cannot move or attack and will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNMagicLariet.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest,mount";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadMilitia(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Militia, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Militia";
            buff.TextTooltipExtended = "This unit has become Militia; its movement speed, attack rate, attack damage, and armor have been increased.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNCallToArms.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPhoenixFire(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PhoenixFire, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Phoenix Fire";
            buff.TextTooltipExtended = "This unit is being burned by Phoenix Fire; it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNMarkOfFire.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPhoenix(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Phoenix, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Phoenix";
            buff.TextTooltipExtended = "The power of the Phoenix unfolds.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPolymorph(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Polymorph, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Polymorph";
            buff.TextTooltipExtended = "This unit is Polymorphed; it is transformed into a sheep.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNPolymorph.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSlow(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Slow, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Slow";
            buff.TextTooltipExtended = "This unit is slowed; its movement speed and attack rate are reduced.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSlow.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadAuraBrilliance(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraBrilliance, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Brilliance Aura";
            buff.TextTooltipExtended = "This unit is under the effects of Brilliance Aura; it has an increased mana regeneration.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBrilliance.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadAuraDevotion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraDevotion, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Devotion Aura";
            buff.TextTooltipExtended = "This unit is under the effects of Devotion Aura; it has increased armor.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNDevotion.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadAvatar(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Avatar, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Avatar";
            buff.TextTooltipExtended = "This unit is in Avatar form; it has increased hit points, attack damage, armor, and is immune to spells.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNAvatar.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBanish(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Banish, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Banish";
            buff.TextTooltipExtended = "This unit is Banished; Banished creatures cannot attack, but they can cast spells and will take extra damage from Magic attacks and spells.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBanish.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "BanishLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBlizzard_BHbd(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Blizzard_BHbd, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Blizzard";
            buff.TextTooltipExtended = "This unit is being damaged by Blizzard.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBlizzard.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBlizzardAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BlizzardAoe, db);
            buff.TextNameEditorOnly = "Blizzard (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDivineShield(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DivineShield, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Divine Shield";
            buff.TextTooltipExtended = "This unit is under a Divine Shield; it is invulnerable.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNDivineIntervention.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDrainCaster(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainCaster, db);
            buff.TextNameEditorOnly = "Drain Life & Mana (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDrainCasterLife(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainCasterLife, db);
            buff.TextNameEditorOnly = "Drain Life (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDrainCasterMana(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainCasterMana, db);
            buff.TextNameEditorOnly = "Drain Mana (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDrainTarget(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainTarget, db);
            buff.TextNameEditorOnly = "Drain Life & Mana (Target)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDrainTargetLife(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainTargetLife, db);
            buff.TextNameEditorOnly = "Drain Life (Target)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDrainTargetMana(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainTargetMana, db);
            buff.TextNameEditorOnly = "Drain Mana (Target)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadFlameStrike_BHfs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.FlameStrike_BHfs, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Flame Strike";
            buff.TextTooltipExtended = "This unit is in a Flame Strike, and is taking damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNWallOfFire.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadThunderClap(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ThunderClap, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Thunder Clap";
            buff.TextTooltipExtended = "This unit has been hit by Thunder Clap; its movement speed and attack rate are reduced.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNThunderclap.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadWaterElemental(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WaterElemental, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Water Elemental";
            buff.TextTooltipExtended = "Summoned units are vulnerable to dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSummonWaterElemental.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAuraKotoBeast(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraKotoBeast, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "War Drums";
            buff.TextTooltipExtended = "This unit hears War Drums; it has increased attack damage.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNDrum.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadAuraRegenLife(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraRegenLife, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Healing Ward Aura";
            buff.TextTooltipExtended = "Increases life regeneration.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNHealingWard.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "FountainOfLifeLoop";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadAuraRegenMana(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraRegenMana, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Mana Regeneration Aura";
            buff.TextTooltipExtended = "This unit is under the effects of Mana Regeneration Aura; it has an increased mana regeneration rate.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "FountainOfLifeLoop";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadBallsOfFire_Bbof(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BallsOfFire_Bbof, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Burning Oil";
            buff.TextTooltipExtended = "This unit is caught in a burning oil fire; it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNWallOfFire.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBerserkerRage(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BerserkerRage, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Berserk";
            buff.TextTooltipExtended = "This unit is Berserk; it will deal more damage, but also take more damage from attacks.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBerserkForTrolls.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 2;
            buff.ArtTargetAttachmentPoint1Raw = "weapon,left";
            buff.ArtTargetAttachmentPoint2Raw = "weapon,right";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBloodlust(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Bloodlust, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Bloodlust";
            buff.TextTooltipExtended = "This unit has Bloodlust; its attack rate and movement speed are increased.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBloodLust.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 2;
            buff.ArtTargetAttachmentPoint1Raw = "hand,left";
            buff.ArtTargetAttachmentPoint2Raw = "hand,right";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadDevourVision(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DevourVision, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Devour";
            buff.TextTooltipExtended = "A unit is being devoured; it will take damage while providing vision to the owner.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNDevour.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDigesting(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Digesting, db);
            buff.TextNameEditorOnly = "Devour (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEnsnare(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Ensnare, db);
            buff.TextNameEditorOnly = "Ensnare (General)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNEnsnare.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEnsnareAir(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EnsnareAir, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Air)";
            buff.TextTooltip = "Ensnare";
            buff.TextTooltipExtended = "This unit is ensnared; it cannot move or fly.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNEnsnare.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest,mount";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEnsnareGround(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EnsnareGround, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Ground)";
            buff.TextTooltip = "Ensnare";
            buff.TextTooltipExtended = "This unit is ensnared; it cannot move or fly.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNEnsnare.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEvilEye(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EvilEye, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Sentry Ward";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSentryWard.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadHealingWard(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.HealingWard, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Healing Ward";
            buff.TextTooltipExtended = "This ward provides life regeneration for nearby friendly units.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNHealingWard.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadLightningShield(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.LightningShield, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Lightning Shield";
            buff.TextTooltipExtended = "This unit has a Lightning Shield; nearby friendly and enemy units will take damage if they are next to this unit.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNLightningShield.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadLightningShieldAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.LightningShieldAoe, db);
            buff.TextNameEditorOnly = "Lightning Shield (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadLiquidFire(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.LiquidFire, db);
            buff.TextNameEditorOnly = "Liquid Fire";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\PassiveButtons\\PASBTNLiquidFire.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "LiquidFireLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPurge(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Purge, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Purge";
            buff.TextTooltipExtended = "This unit is Purged; it has had all buffs removed, and has its movement speed slowed for a short duration.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNPurge.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSpiritLink(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpiritLink, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Spirit Link";
            buff.TextTooltipExtended = "This unit is Spirit Linked; it will distribute some of the damage it takes across other Spirit Linked units.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSpiritLink.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadStasisTrapTrigger(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.StasisTrapTrigger, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Stasis Trap";
            buff.TextTooltipExtended = "This ward will stun enemy land units when triggered.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNStasisTrap.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAuraCommand(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraCommand, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNGnollCommandAura.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAuraEndurance(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraEndurance, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Endurance Aura";
            buff.TextTooltipExtended = "This unit is under the effects of Endurance Aura; it has an increased movement speed and attack rate.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNCommand.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadEarthquake_BOeq(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Earthquake_BOeq, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Earthquake";
            buff.TextTooltipExtended = "This unit is in an Earthquake; its movement speed is greatly reduced.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNEarthquake.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEarthquakeAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EarthquakeAoe, db);
            buff.TextNameEditorOnly = "Earthquake (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadHex(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Hex, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Hex";
            buff.TextTooltipExtended = "This unit is Hexed; it has been transformed into a critter.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNHex.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadMirrorImage(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.MirrorImage, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Mirror Image";
            buff.TextTooltipExtended = "A duplicate illusion of the original Blademaster.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNMirrorImage.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadShockwave(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Shockwave, db);
            buff.TextNameEditorOnly = "Shockwave (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSpiritWolf(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpiritWolf, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Feral Spirit";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSpiritWolf.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadVoodoo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Voodoo, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Big Bad Voodoo";
            buff.TextTooltipExtended = "This unit is under the effects of Big Bad Voodoo, and is invulnerable.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBigBadVoodooSpell.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadVoodooCaster(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.VoodooCaster, db);
            buff.TextNameEditorOnly = "Big Bad Voodoo (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadWard(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Ward, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Ward";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadWhirlwindAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WhirlwindAoe, db);
            buff.TextNameEditorOnly = "Bladestorm (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadWindWalk(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WindWalk, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Wind Walk";
            buff.TextTooltipExtended = "This unit is Wind Walking; it is invisible, moves faster, and the first attack it makes while invisible will deal bonus damage.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNWindWalkOn.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBarkskin(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Barkskin, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Barkskin";
            buff.TextTooltipExtended = "This unit has Barkskin; it has increased armor.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBarkskin.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadCorrosiveBreath(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CorrosiveBreath, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Corrosive Breath";
            buff.TextTooltipExtended = "This building was hit by Corrosive Breath; it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNCorrosiveBreath.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadCyclone(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Cyclone, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Cyclone";
            buff.TextTooltipExtended = "This unit is in a Cyclone; it cannot move, attack or cast spells.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNCyclone.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "CycloneLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadCycloneTwo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CycloneTwo, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Extra)";
            buff.TextTooltip = "Cyclone";
            buff.TextTooltipExtended = "This unit is in a Cyclone; it cannot move, attack or cast spells.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNCyclone.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "sprite,first";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "CycloneLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEatTree(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EatTree, db);
            buff.TextNameEditorOnly = "Eat Tree";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadFaerieFire(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.FaerieFire, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Faerie Fire";
            buff.TextTooltipExtended = "This unit has Faerie Fire; it has reduced armor and can be seen by the enemy.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNFaerieFire.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "head";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadGrabTree(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.GrabTree, db);
            buff.TextNameEditorOnly = "War Club";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadManaFlare(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ManaFlare, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Mana Flare";
            buff.TextTooltipExtended = "This unit has Mana Flare on it; nearby enemy units that cast spells will take damage.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNManaFlare.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "MFPB";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "ManaFlareLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadManaFlareAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ManaFlareAoe, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Extra)";
            buff.TextTooltip = "Mana Flare";
            buff.TextTooltipExtended = "This unit has Mana Flare on it; nearby enemy units that cast spells will take damage.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNManaFlare.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "Abilities\\Spells\\Human\\ManaFlare\\ManaFlareMissile.mdl";
            buff.ArtMissileSpeed = 1000;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 1;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPhaseShift(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PhaseShift, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Phase Shift";
            buff.TextTooltipExtended = "This unit has shifted out of existence and cannot be harmed temporarily.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNPhaseShift.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadWispPhaseShift(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WispPhaseShift, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRejuvination(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Rejuvination, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Rejuvenation";
            buff.TextTooltipExtended = "This unit has Rejuvenation; it is healing hit points over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNRejuvenation.blp";
            buff.ArtTargetRaw = "Abilities\\Spells\\NightElf\\Rejuvenation\\RejuvenationTarget.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRoar(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Roar, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Roar";
            buff.TextTooltipExtended = "This unit has Roar; its attack damage has been increased.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBattleRoar.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadSlowPoison(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SlowPoison, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Non-stacking)";
            buff.TextTooltip = "Slow Poison";
            buff.TextTooltipExtended = "This unit was hit by Slow Poison; its movement speed and attack rate have been reduced, and it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSlowPoison.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadSlowPoisonStackDoT(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SlowPoisonStackDoT, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Stacking)";
            buff.TextTooltip = "Slow Poison";
            buff.TextTooltipExtended = "This unit was hit by Slow Poison; its movement speed and attack rate have been reduced, and it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\PassiveButtons\\PASBTNSlowPoison.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadSlowPoisonStackInfo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SlowPoisonStackInfo, db);
            buff.TextNameEditorOnly = "Slow Poison (Info)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadVengeance(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Vengeance, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Spirit of Vengeance";
            buff.TextTooltipExtended = "Vengeance was here.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNAvengingWatcher.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAuraThorns(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraThorns, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Thorns Aura";
            buff.TextTooltipExtended = "This unit is under the effects of Thorns Aura; melee units that attack it will take damage.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNThorns.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "head";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadAuraTrueshot(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraTrueshot, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Trueshot Aura";
            buff.TextTooltipExtended = "This unit is under the effects of Trueshot Aura; its ranged attacks will deal more damage.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNTrueShot.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadEntanglingRoots(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EntanglingRoots, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Entangling Roots";
            buff.TextTooltipExtended = "This unit has been hit by Entangling Roots; it cannot move and takes damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNEntanglingRoots.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadForceOfNature(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ForceOfNature, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Force of Nature";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNEnt.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadImmolation(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Immolation, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Immolation";
            buff.TextTooltipExtended = "This unit has Immolation; nearby enemy ground units will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNImmolationOn.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "head";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadImmolationAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ImmolationAoe, db);
            buff.TextNameEditorOnly = "Immolation (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadMetamorphosis(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Metamorphosis, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Metamorphosis";
            buff.TextTooltipExtended = "Transforms the Demon Hunter into a powerful Demon with a ranged attack.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNMetamorphosis.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadScout(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Scout, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Scout";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadShadowStrike(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ShadowStrike, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Shadow Strike";
            buff.TextTooltipExtended = "This unit was hit by Shadow Strike; it will take damage over time and move more slowly.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNShadowStrike.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSpiritOfVengeance(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpiritOfVengeance, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Vengeance";
            buff.TextTooltipExtended = "Vengeance is angry.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSpiritOfVengeance.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAntiMagicShell(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AntiMagicShell, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Anti-magic Shell";
            buff.TextTooltipExtended = "This unit has Anti-magic Shell; it cannot be targeted by spells. It can be dispelled.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNAntiMagicShell.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAntiMagicShellMatrix(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AntiMagicShellMatrix, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Extra)";
            buff.TextTooltip = "Anti-magic Shell";
            buff.TextTooltipExtended = "This unit has Anti-magic Shell; damage spells must destroy the shell to affect the unit.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNAntiMagicShell.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAuraBlightRegen(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraBlightRegen, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Aura of Blight";
            buff.TextTooltipExtended = "This unit is under the effects of Aura of Blight; it has a bonus to hit point regeneration.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNRegenerationAura.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadAuraPlague(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraPlague, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Disease";
            buff.TextTooltipExtended = "This unit is diseased; it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNPlagueCloud.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "head";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadCripple(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Cripple, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Cripple";
            buff.TextTooltipExtended = "This unit is Crippled; its movement speed, attack rate and damage have been reduced.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNCripple.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadCurse(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Curse, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Curse";
            buff.TextTooltipExtended = "This unit is Cursed; it can miss when it attacks.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNCurse.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadFreezingBreath(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.FreezingBreath, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Freezing Breath";
            buff.TextTooltipExtended = "This building is frozen; its abilities cannot be used and it cannot be repaired.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNFreezingBreath.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPlagueWard(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PlagueWard, db);
            buff.TextNameEditorOnly = "Disease Cloud";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPossession_Bpoc(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Possession_Bpoc, db);
            buff.TextNameEditorOnly = "Possession (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPossession_Bpos(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Possession_Bpos, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Possession";
            buff.TextTooltipExtended = "This unit is being possessed.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNPossession.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRaiseDead(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RaiseDead, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Skeletal Minion";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSkeletonWarrior.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadReplenish(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Replenish, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Replenish";
            buff.TextTooltipExtended = "This unit has been hit by Replenish; some of its hit points and mana have been restored.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNReplenishMana.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadReplenishLife(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ReplenishLife, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Essence of Blight";
            buff.TextTooltipExtended = "This unit has been hit by Essence of Blight; some of its hit points have been restored.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNReplenishHealth.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadReplenishMana(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ReplenishMana, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Spirit Touch";
            buff.TextTooltipExtended = "This unit has been hit by Spirit Touch; some of its mana has been restored.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNReplenishMana.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSpiderAttack(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpiderAttack, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Spiderling";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSpider.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadUnholyFrenzy(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.UnholyFrenzy, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Unholy Frenzy";
            buff.TextTooltipExtended = "This unit has Unholy Frenzy; its attack rate is increased, but it takes damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNUnholyFrenzy.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadUnsummon(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Unsummon, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Unsummon";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNUnsummonBuilding.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "AcolyteUnsummonLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadWeb(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Web, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Ground)";
            buff.TextTooltip = "Web";
            buff.TextTooltipExtended = "This unit is webbed; it is stuck to the ground and cannot move.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNWeb.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadWebAir(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WebAir, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Air)";
            buff.TextTooltip = "Web";
            buff.TextTooltipExtended = "This unit is webbed; it is stuck to the ground and cannot move.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNWeb.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest,mount";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAnimateDead_BUan(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AnimateDead_BUan, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Animate Dead";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNAnimateDead.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAuraUnholy(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraUnholy, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Unholy Aura";
            buff.TextTooltipExtended = "This unit is under the effects of Unholy Aura; it has an increased movement speed and hit point regeneration.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNUnholyAura.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadAuraVampiric(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraVampiric, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Vampiric Aura";
            buff.TextTooltipExtended = "This unit is under the effects of Vampiric Aura; damage it deals to enemy units will restore hit points.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNVampiricAura.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "origin";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 2;
            return buff;
        }

        protected virtual Buff LoadCarrionScarab(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CarrionScarab, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Carrion Beetles";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNCarrionScarabs.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadCarrionSwarm(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CarrionSwarm, db);
            buff.TextNameEditorOnly = "Carrion Swarm (Caster)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDeathAndDecayAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DeathAndDecayAoe, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Death and Decay";
            buff.TextTooltipExtended = "This unit is under Death and Decay; it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNDeathAndDecay.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadFrostArmor(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.FrostArmor, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Frost Armor";
            buff.TextTooltipExtended = "This unit has Frost Armor; it has increased armor, and melee units that attack it will have their movement speed and attack rate reduced for a short duration.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNFrostArmor.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "chest";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadImpale(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Impale, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Impale";
            buff.TextTooltipExtended = "This unit has been impaled; it is in the air for a short duration.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNImpale.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "sprite,first";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSleep(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Sleep, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Sleep";
            buff.TextTooltipExtended = "This unit is sleeping; it cannot move, attack, or cast spells. Attacking it will wake it up.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSleep.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "CreepSleepSnoreLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSleepPause(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SleepPause, db);
            buff.TextNameEditorOnly = "Sleep (Pause)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSleep.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSleepStun(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SleepStun, db);
            buff.TextNameEditorOnly = "Sleep (Stun)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSleep.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadThornyShield_BUts(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ThornyShield_BUts, db);
            buff.TextNameEditorOnly = "Spiked Carapace";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNThornShield.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 4;
            buff.ArtTargetAttachmentPoint1Raw = "chest,left";
            buff.ArtTargetAttachmentPoint2Raw = "chest,right";
            buff.ArtTargetAttachmentPoint3Raw = "chest,mount,left";
            buff.ArtTargetAttachmentPoint4Raw = "chest,mount,right";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadThornyShield_BUtt(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ThornyShield_BUtt, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNThornShield.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 2;
            buff.ArtTargetAttachmentPoint1Raw = "chest,mount,left";
            buff.ArtTargetAttachmentPoint2Raw = "chest,mount,right";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAuraSlow(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraSlow, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Slow Aura)";
            buff.TextTooltip = "Tornado";
            buff.TextTooltipExtended = "This unit is caught within a Tornado; its movement speed has been reduced temporarily.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNTornado.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBreathOfFrost(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BreathOfFrost, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Breath of Frost";
            buff.TextTooltipExtended = "This unit was hit by Breath of Frost; it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBreathOfFrost.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadCreepThunderClap(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CreepThunderClap, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Slam";
            buff.TextTooltipExtended = "This unit has been hit by Slam; its movement speed and attack rate are reduced.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNGolemThunderclap.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadFrenzy(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Frenzy, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Frenzy";
            buff.TextTooltipExtended = "This unit has Frenzy; its attack rate and movement speed are increased.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBloodLust.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 2;
            buff.ArtTargetAttachmentPoint1Raw = "hand,left";
            buff.ArtTargetAttachmentPoint2Raw = "hand,right";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadMechanicalCritter(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.MechanicalCritter, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Mechanical Critter";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadMindRot(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.MindRot, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Mind Rot";
            buff.TextTooltipExtended = "This unit has been hit by Mind Rot; it is losing mana over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNTemp.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPandaImmolation(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PandaImmolation, db);
            buff.TextNameEditorOnly = "Permanent Immolation";
            buff.TextEditorSuffix = " (Neutral Hostile 2)";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "chest";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadPermImmolation(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PermImmolation, db);
            buff.TextNameEditorOnly = "Permanent Immolation";
            buff.TextEditorSuffix = " (Neutral Hostile 1)";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "head";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSanctuary(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Sanctuary, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Sanctuary";
            buff.TextTooltipExtended = "This unit is under the effects of a Staff of Sanctuary; its hit points will regenerate over time, but it cannot move, attack or cast spells.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNStaffOfSanctuary.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadShadowSight(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ShadowSight, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Wand of Shadowsight";
            buff.TextTooltipExtended = "This unit was hit by a Wand of Shadowsight; it is revealed to an enemy player.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNWandOfShadowSight.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSpellShield(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpellShield, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Spell Shield";
            buff.TextTooltipExtended = "A protective shield that blocks a spell.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadTornadoDamageAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.TornadoDamageAoe, db);
            buff.TextNameEditorOnly = "Tornado Damage";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadTornadoSpin(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.TornadoSpin, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Tornado Spin";
            buff.TextTooltipExtended = "This unit is caught within a Tornado; it has been tossed into the air.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNTornado.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "sprite,first";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadTornadoSpinAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.TornadoSpinAoe, db);
            buff.TextNameEditorOnly = "Tornado Spin (Area)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBlackArrow(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BlackArrow, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Black Arrow";
            buff.TextTooltipExtended = "This unit was hit by a Black Arrow; if it dies, it will turn into a skeleton for the enemy.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNTheBlackArrow.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBreathOfFire(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BreathOfFire, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Breath of Fire";
            buff.TextTooltipExtended = "This unit has been hit by Breath of Fire; it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBreathOfFire.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadColdArrow(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ColdArrow, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Non-stacking)";
            buff.TextTooltip = "Cold Arrows";
            buff.TextTooltipExtended = "This unit was hit by a Cold Arrow; its attack rate and movement speed have been reduced.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNColdArrows.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadColdArrowStackDoT(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ColdArrowStackDoT, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Stacking)";
            buff.TextTooltip = "Cold Arrows";
            buff.TextTooltipExtended = "This unit was hit by a Cold Arrow; its attack rate and movement speed have been reduced.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNColdArrows.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadColdArrowStackInfo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ColdArrowStackInfo, db);
            buff.TextNameEditorOnly = "Cold Arrows";
            buff.TextEditorSuffix = " (Info)";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDarkMinion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DarkMinion, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Dark Minion";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNTheBlackArrow.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDoom(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Doom, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Doom";
            buff.TextTooltipExtended = "This unit has been stricken with Doom; it cannot cast spells and will take damage until it dies, and a Demon will spawn from its corpse. Doom cannot be dispelled or cancelled.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNDoom.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDoomMinion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DoomMinion, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Minion)";
            buff.TextTooltip = "Doom";
            buff.TextTooltipExtended = "This unit has been stricken with Doom; it will take damage until it dies, and a Demon will spawn from its corpse. Doom cannot be dispelled or cancelled.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDrunkenHaze(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrunkenHaze, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Drunken Haze";
            buff.TextTooltipExtended = "This unit was hit by a Drunken Haze; it has reduced movement speed and a chance to miss on attacks.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNStrongDrink.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadElementalFury(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ElementalFury, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Pandaren Elemental";
            buff.TextTooltipExtended = "I am a Pandaren Elemental; worship me.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNStormEarth&Fire.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadHowlOfTerror(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.HowlOfTerror, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Howl of Terror";
            buff.TextTooltipExtended = "This unit has heard the Howl of Terror; it deals less damage for a duration.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNHowlOfTerror.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadManaShield(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ManaShield, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Mana Shield";
            buff.TextTooltipExtended = "This unit has a Mana Shield; it is temporarily protected from physical damage and negative spells.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNNeutralManaShield.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSilence(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Silence, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Silence";
            buff.TextTooltipExtended = "This unit is Silenced; it cannot cast spells.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSilence.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadStampede(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Stampede, db);
            buff.TextNameEditorOnly = "Stampede";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSummonGrizzly(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SummonGrizzly, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Bear";
            buff.TextTooltipExtended = "A ferocious bear.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNGrizzlyBear.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSummonQuillbeast(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SummonQuillbeast, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Quilbeast";
            buff.TextTooltipExtended = "An angry quilbeast.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNQuillBeast.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSummonWarEagle(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SummonWarEagle, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Hawk";
            buff.TextTooltipExtended = "A proud hawk.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNWarEagle.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadTornado(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Tornado, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Timed Life)";
            buff.TextTooltip = "Tornado";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "TornadoLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadWateryMinion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WateryMinion, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Watery Minion";
            buff.TextTooltipExtended = "Summoned units take damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNMurgulTideWarrior.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBattleRoar(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BattleRoar, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Battle Roar";
            buff.TextTooltipExtended = "This unit has Battle Roar; its attack damage has been increased.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNBattleRoar.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 1;
            return buff;
        }

        protected virtual Buff LoadDarkConversion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DarkConversion, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Dark Conversion";
            buff.TextTooltipExtended = "This villager was hit by Dark Conversion; it will fall asleep and then turn into a zombie.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSleep.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadInfernal(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Infernal, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Infernal";
            buff.TextTooltipExtended = "This Infernal is mighty.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadParasite(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Parasite, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Parasite";
            buff.TextTooltipExtended = "This unit has been inflicted with a parasite; it will take damage over time, and if it dies while still afflicted, a minion will spawn from its corpse.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNParasite.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadParasiteMinion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ParasiteMinion, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Minion)";
            buff.TextTooltip = "Parasite";
            buff.TextTooltipExtended = "This unit has been inflicted with a parasite; it will take damage over time, and if it dies while still afflicted, a minion will spawn from its corpse.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNParasite.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRainOfFire_BNrd(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RainOfFire_BNrd, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Rain of Fire";
            buff.TextTooltipExtended = "This unit was hit by Rain of Fire; it will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNFire.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRainOfFireAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RainOfFireAoe, db);
            buff.TextNameEditorOnly = "Rain of Fire (Area)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSoulPreservation(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SoulPreservation, db);
            buff.TextNameEditorOnly = "Soul Preservation";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Soul Preservation";
            buff.TextTooltipExtended = "This unit is being preserved for later use.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSleep.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "SoulPreservation";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadCorruption(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Corruption, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Corruption";
            buff.TextTooltipExtended = "This unit was hit by an Orb of Corruption; its armor is temporarily reduced.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNOrbOfCorruption.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadFigurine(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Figurine, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Summoned Unit";
            buff.TextTooltipExtended = "Summoned units take additional damage from dispels.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadItemCloakOfFlames(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemCloakOfFlames, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Cloak of Flames";
            buff.TextTooltipExtended = "This unit has a Cloak of Flames; nearby enemy ground units will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNCloakOfFlames.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "head";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadItemIllusion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemIllusion, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Illusion";
            buff.TextTooltipExtended = "This unit is an illusion; it takes extra damage from enemies.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNWand.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRebirth(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Rebirth, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Reborn";
            buff.TextTooltipExtended = "This unit has been reborn.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNRune.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRegeneration(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Regeneration, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = " (Item)";
            buff.TextTooltip = "Rejuvenation";
            buff.TextTooltipExtended = "This unit will regenerate health and mana over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNGreaterRejuvScroll.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 2;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "origin";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRegenLife(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RegenLife, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Regeneration";
            buff.TextTooltipExtended = "This unit has Regeneration on it; its hit points will regenerate over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNHealingSalve.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRegenMana(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RegenMana, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Clarity Potion";
            buff.TextTooltipExtended = "This unit drank a Clarity Potion; its mana will regenerate over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNPotionOfClarity.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSoulTrapVision(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SoulTrapVision, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Soul Theft";
            buff.TextTooltipExtended = "This is the soul of a Hero.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNUsedSoulGem.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSpiritTroll(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpiritTroll, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Headhunter Spirit";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadItemWeb(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemWeb, db);
            buff.TextNameEditorOnly = "Item Web";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadItemMonsterLure(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemMonsterLure, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Monster Lure";
            buff.TextTooltipExtended = "Nearby creeps will be summoned to this lure.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadItemVampirePotion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemVampirePotion, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Vampiric Potion";
            buff.TextTooltipExtended = "This Hero used a Vampiric Potion; the Hero has increased damage and a life-draining attack.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNPotionOfVampirism.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadCloudOfFog_Xclf(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CloudOfFog_Xclf, db);
            buff.TextNameEditorOnly = "Cloud (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "CloudOfFogLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadFlare(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Flare, db);
            buff.TextNameEditorOnly = "Flare (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBlizzard_XHbz(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Blizzard_XHbz, db);
            buff.TextNameEditorOnly = "Blizzard (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "BlizzardWave";
            buff.SoundEffectSoundLoopingRaw = "BlizzardLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadFlameStrike_XHfs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.FlameStrike_XHfs, db);
            buff.TextNameEditorOnly = "Flame Strike (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "HumanFireLarge";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadBallsOfFire_Xbof(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BallsOfFire_Xbof, db);
            buff.TextNameEditorOnly = "Burning Oil (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "HumanFireLarge";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEarthquake_XOeq(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Earthquake_XOeq, db);
            buff.TextNameEditorOnly = "Earthquake (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "EarthquakeLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadReincarnation(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Reincarnation, db);
            buff.TextNameEditorOnly = "Reincarnation (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSentinel(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Sentinel, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadStarfall(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Starfall, db);
            buff.TextNameEditorOnly = "Starfall (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadTranquility(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Tranquility, db);
            buff.TextNameEditorOnly = "Tranquility (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "TranquilityLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadDeathAndDecay(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DeathAndDecay, db);
            buff.TextNameEditorOnly = "Death And Decay (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "DeathAndDecayLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadMonsoon_XNmo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Monsoon_XNmo, db);
            buff.TextNameEditorOnly = "Monsoon (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "MonsoonLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRainOfChaos(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RainOfChaos, db);
            buff.TextNameEditorOnly = "Rain of Chaos (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadRainOfFire_XErf(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RainOfFire_XErf, db);
            buff.TextNameEditorOnly = "Rain of Fire (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "RainOfFireWave";
            buff.SoundEffectSoundLoopingRaw = "RainOfFireLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadItemChangeTOD(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemChangeTOD, db);
            buff.TextNameEditorOnly = "Item Change Time of Day";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadStarfallTarget(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.StarfallTarget, db);
            buff.TextNameEditorOnly = "Starfall (Target)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadTranquilityTarget(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.TranquilityTarget, db);
            buff.TextNameEditorOnly = "Tranquility (Target)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadMonsoon_ANmd(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Monsoon_ANmd, db);
            buff.TextNameEditorOnly = "Monsoon";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "origin";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadInvisibility_Bivs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Invisibility_Bivs, db);
            buff.TextNameEditorOnly = "Invisibility (Extra)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAnimateDead_BUad(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AnimateDead_BUad, db);
            buff.TextNameEditorOnly = "Animate Dead (Extra)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadUltravision(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Ultravision, db);
            buff.TextNameEditorOnly = "Ultravision";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadAcidBomb(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AcidBomb, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Acid Bomb";
            buff.TextTooltipExtended = "This unit has been Acid Bombed.  It has reduced armor, and is being damaged over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNAcidBomb.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadChemicalRage(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ChemicalRage, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Chemical Rage";
            buff.TextTooltipExtended = "This unit is benefiting from Chemical Rage.  It is moving and attacking more quickly.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNChemicalRage.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadHealingSpray_BNhs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.HealingSpray_BNhs, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Healing Spray";
            buff.TextTooltipExtended = "This unit is being healed by Healing Spray.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNHealingSpray.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadHealingSpray_XNhs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.HealingSpray_XNhs, db);
            buff.TextNameEditorOnly = "Healing Spray (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadTransmute(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Transmute, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Transmute";
            buff.TextTooltipExtended = "This unit is being transmuted and will die very soon. It will be converted into gold which will be given to the player who cast Transmute.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNTransmute.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEngineeringUpgrade(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EngineeringUpgrade, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Engineering Upgrade";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNEngineeringUpgrade.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 4;
            buff.ArtTargetAttachmentPoint1Raw = "chest,left";
            buff.ArtTargetAttachmentPoint2Raw = "chest,right";
            buff.ArtTargetAttachmentPoint3Raw = "chest,mount,left";
            buff.ArtTargetAttachmentPoint4Raw = "chest,mount,right";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadClusterRockets_BNcs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ClusterRockets_BNcs, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Cluster Rockets";
            buff.TextTooltipExtended = "Cluster Rockets.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNClusterRockets.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadClusterRockets_XNcs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ClusterRockets_XNcs, db);
            buff.TextNameEditorOnly = "Cluster Rockets (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSummonFactory(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SummonFactory, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Pocket Factory";
            buff.TextTooltipExtended = "Pocket Factory.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadClockwerkGoblin(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ClockwerkGoblin, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Clockwerk Goblin";
            buff.TextTooltipExtended = "Clockwerk Goblin.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadIncinerate(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Incinerate, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Incinerate";
            buff.TextTooltipExtended = "This target is partially aflame, and will incinerate if it dies, causing damage to nearby units.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNIncinerate.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 1;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "chest";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadSoulBurn(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SoulBurn, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Soul Burn";
            buff.TextTooltipExtended = "This unit is afflicted by Soul Burn. It cannot cast spells, attacks for less damage, and will take damage over time.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNSoulBurn.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadLavaMonster(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.LavaMonster, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Lava Spawn";
            buff.TextTooltipExtended = "Lava Spawn.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "Abilities\\Weapons\\LavaSpawnMissile\\LavaSpawnBirthMissile.mdl";
            buff.ArtMissileSpeed = 200;
            buff.ArtMissileArc = 0.99f;
            buff.ArtMissileHomingEnabledRaw = 1;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadVolcano_BNvc(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Volcano_BNvc, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Volcano";
            buff.TextTooltipExtended = "Volcano.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNVolcano.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "overhead";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadVolcanoAOE(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.VolcanoAOE, db);
            buff.TextNameEditorOnly = "Volcano (Area)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadVolcano_XNvc(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Volcano_XNvc, db);
            buff.TextNameEditorOnly = "Volcano (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "Abilities\\Spells\\Other\\Volcano\\VolcanoMissile.mdl";
            buff.ArtMissileSpeed = 400;
            buff.ArtMissileArc = 0.8f;
            buff.ArtMissileHomingEnabledRaw = 1;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "VolcanoLoop";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTBASEDETECTOR(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTBASEDETECTOR, db);
            buff.TextNameEditorOnly = "Reveal (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTBLIGHT(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTBLIGHT, db);
            buff.TextNameEditorOnly = "Blight (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTHERODISSIPATE(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTHERODISSIPATE, db);
            buff.TextNameEditorOnly = "Hero Dissipate (Effect)";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireHumanSml(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireHumanSml, db);
            buff.TextNameEditorOnly = "Building Damage - Human Small";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\SmallBuildingFire\\SmallBuildingFire2.mdl,Environment\\SmallBuildingFire\\SmallBuildingFire1.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 2;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "HumanFireSmall";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireHumanMed(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireHumanMed, db);
            buff.TextNameEditorOnly = "Building Damage - Human Medium";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\LargeBuildingFire\\LargeBuildingFire2.mdl,Environment\\SmallBuildingFire\\SmallBuildingFire1.mdl,Environment\\LargeBuildingFire\\LargeBuildingFire0.mdl,Environment\\SmallBuildingFire\\SmallBuildingFire2.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 4;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,second";
            buff.ArtTargetAttachmentPoint3Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint4Raw = "sprite,fifth";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "HumanFireMedium";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireHumanLrg(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireHumanLrg, db);
            buff.TextNameEditorOnly = "Building Damage - Human Large";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\LargeBuildingFire\\LargeBuildingFire1.mdl,Environment\\LargeBuildingFire\\LargeBuildingFire0.mdl,Environment\\LargeBuildingFire\\LargeBuildingFire0.mdl,Environment\\SmallBuildingFire\\SmallBuildingFire1.mdl,Environment\\LargeBuildingFire\\LargeBuildingFire1.mdl,Environment\\SmallBuildingFire\\SmallBuildingFire0.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 6;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,second";
            buff.ArtTargetAttachmentPoint3Raw = "sprite,fifth";
            buff.ArtTargetAttachmentPoint4Raw = "sprite,third";
            buff.ArtTargetAttachmentPoint5Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint6Raw = "sprite,sixth";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "HumanFireLarge";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireOrcSml(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireOrcSml, db);
            buff.TextNameEditorOnly = "Building Damage - Orc Small";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\SmallBuildingFire\\SmallBuildingFire2.mdl,Environment\\SmallBuildingFire\\SmallBuildingFire1.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 2;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "HumanFireSmall";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireOrcMed(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireOrcMed, db);
            buff.TextNameEditorOnly = "Building Damage - Orc Medium";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\LargeBuildingFire\\LargeBuildingFire2.mdl,Environment\\SmallBuildingFire\\SmallBuildingFire1.mdl,Environment\\LargeBuildingFire\\LargeBuildingFire0.mdl,Environment\\SmallBuildingFire\\SmallBuildingFire2.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 4;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,second";
            buff.ArtTargetAttachmentPoint3Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint4Raw = "sprite,fifth";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "HumanFireMedium";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireOrcLrg(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireOrcLrg, db);
            buff.TextNameEditorOnly = "Building Damage - Orc Large";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\LargeBuildingFire\\LargeBuildingFire1.mdl,Environment\\LargeBuildingFire\\LargeBuildingFire0.mdl,Environment\\LargeBuildingFire\\LargeBuildingFire0.mdl,Environment\\SmallBuildingFire\\SmallBuildingFire1.mdl,Environment\\LargeBuildingFire\\LargeBuildingFire1.mdl,Environment\\SmallBuildingFire\\SmallBuildingFire0.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 6;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,second";
            buff.ArtTargetAttachmentPoint3Raw = "sprite,fifth";
            buff.ArtTargetAttachmentPoint4Raw = "sprite,third";
            buff.ArtTargetAttachmentPoint5Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint6Raw = "sprite,sixth";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "HumanFireLarge";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireNightElfSml(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireNightElfSml, db);
            buff.TextNameEditorOnly = "Building Damage - Night Elf Small";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\NightElfBuildingFire\\ElfSmallBuildingFire2.mdl,Environment\\NightElfBuildingFire\\ElfSmallBuildingFire1.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 2;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "NightElfFireSmall";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireNightElfMed(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireNightElfMed, db);
            buff.TextNameEditorOnly = "Building Damage - Night Elf Medium";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\NightElfBuildingFire\\ElfLargeBuildingFire2.mdl,Environment\\NightElfBuildingFire\\ElfSmallBuildingFire1.mdl,Environment\\NightElfBuildingFire\\ElfLargeBuildingFire0.mdl,Environment\\NightElfBuildingFire\\ElfSmallBuildingFire2.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 4;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,second";
            buff.ArtTargetAttachmentPoint3Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint4Raw = "sprite,fifth";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "NightElfFireMedium";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireNightElfLrg(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireNightElfLrg, db);
            buff.TextNameEditorOnly = "Building Damage - Night Elf Large";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\NightElfBuildingFire\\ElfLargeBuildingFire1.mdl,Environment\\NightElfBuildingFire\\ElfLargeBuildingFire0.mdl,Environment\\NightElfBuildingFire\\ElfLargeBuildingFire0.mdl,Environment\\NightElfBuildingFire\\ElfSmallBuildingFire1.mdl,Environment\\NightElfBuildingFire\\ElfLargeBuildingFire2.mdl,Environment\\NightElfBuildingFire\\ElfSmallBuildingFire0.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 6;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,second";
            buff.ArtTargetAttachmentPoint3Raw = "sprite,fifth";
            buff.ArtTargetAttachmentPoint4Raw = "sprite,third";
            buff.ArtTargetAttachmentPoint5Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint6Raw = "sprite,sixth";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "NightElfFireLarge";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireUndeadSml(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireUndeadSml, db);
            buff.TextNameEditorOnly = "Building Damage - Undead Small";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\UndeadBuildingFire\\UndeadSmallBuildingFire2.mdl,Environment\\UndeadBuildingFire\\UndeadSmallBuildingFire1.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 2;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "UndeadFireSmall";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireUndeadMed(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireUndeadMed, db);
            buff.TextNameEditorOnly = "Building Damage - Undead Medium";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\UndeadBuildingFire\\UndeadLargeBuildingFire2.mdl,Environment\\UndeadBuildingFire\\UndeadSmallBuildingFire1.mdl,Environment\\UndeadBuildingFire\\UndeadLargeBuildingFire0.mdl,Environment\\UndeadBuildingFire\\UndeadSmallBuildingFire2.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 4;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,second";
            buff.ArtTargetAttachmentPoint3Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint4Raw = "sprite,fifth";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "UndeadFireMedium";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireUndeadLrg(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireUndeadLrg, db);
            buff.TextNameEditorOnly = "Building Damage - Undead Large";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "";
            buff.TextTooltipExtended = "";
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "undead";
            buff.ArtIconRaw = "";
            buff.ArtTargetRaw = "Environment\\UndeadBuildingFire\\UndeadLargeBuildingFire1.mdl,Environment\\UndeadBuildingFire\\UndeadLargeBuildingFire0.mdl,Environment\\UndeadBuildingFire\\UndeadLargeBuildingFire0.mdl,Environment\\UndeadBuildingFire\\UndeadSmallBuildingFire1.mdl,Environment\\UndeadBuildingFire\\UndeadLargeBuildingFire2.mdl,Environment\\UndeadBuildingFire\\UndeadSmallBuildingFire0.mdl";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 6;
            buff.ArtTargetAttachmentPoint1Raw = "sprite,first";
            buff.ArtTargetAttachmentPoint2Raw = "sprite,second";
            buff.ArtTargetAttachmentPoint3Raw = "sprite,fifth";
            buff.ArtTargetAttachmentPoint4Raw = "sprite,third";
            buff.ArtTargetAttachmentPoint5Raw = "sprite,fourth";
            buff.ArtTargetAttachmentPoint6Raw = "sprite,sixth";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "UndeadFireLarge";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        protected virtual Buff LoadHealMultiplier(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.HealMultiplier, db);
            buff.TextNameEditorOnly = "";
            buff.TextEditorSuffix = "";
            buff.TextTooltip = "Heal Reduction";
            buff.TextTooltipExtended = "This unit restores health at a reduced rate.";
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            buff.ArtIconRaw = "ReplaceableTextures\\CommandButtons\\BTNOrbOfFire.blp";
            buff.ArtTargetRaw = "";
            buff.ArtSpecialRaw = "";
            buff.ArtEffectRaw = "";
            buff.ArtLightningRaw = "";
            buff.ArtMissileArtRaw = "";
            buff.ArtMissileSpeed = 0;
            buff.ArtMissileArc = 0;
            buff.ArtMissileHomingEnabledRaw = 0;
            buff.ArtTargetAttachments = 0;
            buff.ArtTargetAttachmentPoint1Raw = "";
            buff.ArtTargetAttachmentPoint2Raw = "";
            buff.ArtTargetAttachmentPoint3Raw = "";
            buff.ArtTargetAttachmentPoint4Raw = "";
            buff.ArtTargetAttachmentPoint5Raw = "";
            buff.ArtTargetAttachmentPoint6Raw = "";
            buff.ArtEffectAttachmentPointRaw = "";
            buff.ArtSpecialAttachmentPointRaw = "";
            buff.SoundEffectSoundRaw = "";
            buff.SoundEffectSoundLoopingRaw = "";
            buff.ArtRequiredSpellDetailRaw = 0;
            return buff;
        }

        public Buff Load(BuffType buffType, ObjectDatabaseBase db)
        {
            return buffType switch
            {
            BuffType.Pause => LoadPause(db), BuffType.Stun => LoadStun(db), BuffType.CargoHoldDeath => LoadCargoHoldDeath(db), BuffType.Defense => LoadDefense(db), BuffType.Detected => LoadDetected(db), BuffType.Freeze => LoadFreeze(db), BuffType.Frost => LoadFrost(db), BuffType.Invulnerable => LoadInvulnerable(db), BuffType.PoisonAttack => LoadPoisonAttack(db), BuffType.PoisonAttackStackDoT => LoadPoisonAttackStackDoT(db), BuffType.PoisonAttackStackInfo => LoadPoisonAttackStackInfo(db), BuffType.SharedVision => LoadSharedVision(db), BuffType.SpeedBonus => LoadSpeedBonus(db), BuffType.TeleportReveal => LoadTeleportReveal(db), BuffType.CloudOfFog_Bclf => LoadCloudOfFog_Bclf(db), BuffType.ControlMagic => LoadControlMagic(db), BuffType.Heal => LoadHeal(db), BuffType.InnerFire => LoadInnerFire(db), BuffType.Invisibility_Binv => LoadInvisibility_Binv(db), BuffType.MagicLeashCaster => LoadMagicLeashCaster(db), BuffType.MagicLeashTarget => LoadMagicLeashTarget(db), BuffType.Militia => LoadMilitia(db), BuffType.PhoenixFire => LoadPhoenixFire(db), BuffType.Phoenix => LoadPhoenix(db), BuffType.Polymorph => LoadPolymorph(db), BuffType.Slow => LoadSlow(db), BuffType.AuraBrilliance => LoadAuraBrilliance(db), BuffType.AuraDevotion => LoadAuraDevotion(db), BuffType.Avatar => LoadAvatar(db), BuffType.Banish => LoadBanish(db), BuffType.Blizzard_BHbd => LoadBlizzard_BHbd(db), BuffType.BlizzardAoe => LoadBlizzardAoe(db), BuffType.DivineShield => LoadDivineShield(db), BuffType.DrainCaster => LoadDrainCaster(db), BuffType.DrainCasterLife => LoadDrainCasterLife(db), BuffType.DrainCasterMana => LoadDrainCasterMana(db), BuffType.DrainTarget => LoadDrainTarget(db), BuffType.DrainTargetLife => LoadDrainTargetLife(db), BuffType.DrainTargetMana => LoadDrainTargetMana(db), BuffType.FlameStrike_BHfs => LoadFlameStrike_BHfs(db), BuffType.ThunderClap => LoadThunderClap(db), BuffType.WaterElemental => LoadWaterElemental(db), BuffType.AuraKotoBeast => LoadAuraKotoBeast(db), BuffType.AuraRegenLife => LoadAuraRegenLife(db), BuffType.AuraRegenMana => LoadAuraRegenMana(db), BuffType.BallsOfFire_Bbof => LoadBallsOfFire_Bbof(db), BuffType.BerserkerRage => LoadBerserkerRage(db), BuffType.Bloodlust => LoadBloodlust(db), BuffType.DevourVision => LoadDevourVision(db), BuffType.Digesting => LoadDigesting(db), BuffType.Ensnare => LoadEnsnare(db), BuffType.EnsnareAir => LoadEnsnareAir(db), BuffType.EnsnareGround => LoadEnsnareGround(db), BuffType.EvilEye => LoadEvilEye(db), BuffType.HealingWard => LoadHealingWard(db), BuffType.LightningShield => LoadLightningShield(db), BuffType.LightningShieldAoe => LoadLightningShieldAoe(db), BuffType.LiquidFire => LoadLiquidFire(db), BuffType.Purge => LoadPurge(db), BuffType.SpiritLink => LoadSpiritLink(db), BuffType.StasisTrapTrigger => LoadStasisTrapTrigger(db), BuffType.AuraCommand => LoadAuraCommand(db), BuffType.AuraEndurance => LoadAuraEndurance(db), BuffType.Earthquake_BOeq => LoadEarthquake_BOeq(db), BuffType.EarthquakeAoe => LoadEarthquakeAoe(db), BuffType.Hex => LoadHex(db), BuffType.MirrorImage => LoadMirrorImage(db), BuffType.Shockwave => LoadShockwave(db), BuffType.SpiritWolf => LoadSpiritWolf(db), BuffType.Voodoo => LoadVoodoo(db), BuffType.VoodooCaster => LoadVoodooCaster(db), BuffType.Ward => LoadWard(db), BuffType.WhirlwindAoe => LoadWhirlwindAoe(db), BuffType.WindWalk => LoadWindWalk(db), BuffType.Barkskin => LoadBarkskin(db), BuffType.CorrosiveBreath => LoadCorrosiveBreath(db), BuffType.Cyclone => LoadCyclone(db), BuffType.CycloneTwo => LoadCycloneTwo(db), BuffType.EatTree => LoadEatTree(db), BuffType.FaerieFire => LoadFaerieFire(db), BuffType.GrabTree => LoadGrabTree(db), BuffType.ManaFlare => LoadManaFlare(db), BuffType.ManaFlareAoe => LoadManaFlareAoe(db), BuffType.PhaseShift => LoadPhaseShift(db), BuffType.WispPhaseShift => LoadWispPhaseShift(db), BuffType.Rejuvination => LoadRejuvination(db), BuffType.Roar => LoadRoar(db), BuffType.SlowPoison => LoadSlowPoison(db), BuffType.SlowPoisonStackDoT => LoadSlowPoisonStackDoT(db), BuffType.SlowPoisonStackInfo => LoadSlowPoisonStackInfo(db), BuffType.Vengeance => LoadVengeance(db), BuffType.AuraThorns => LoadAuraThorns(db), BuffType.AuraTrueshot => LoadAuraTrueshot(db), BuffType.EntanglingRoots => LoadEntanglingRoots(db), BuffType.ForceOfNature => LoadForceOfNature(db), BuffType.Immolation => LoadImmolation(db), BuffType.ImmolationAoe => LoadImmolationAoe(db), BuffType.Metamorphosis => LoadMetamorphosis(db), BuffType.Scout => LoadScout(db), BuffType.ShadowStrike => LoadShadowStrike(db), BuffType.SpiritOfVengeance => LoadSpiritOfVengeance(db), BuffType.AntiMagicShell => LoadAntiMagicShell(db), BuffType.AntiMagicShellMatrix => LoadAntiMagicShellMatrix(db), BuffType.AuraBlightRegen => LoadAuraBlightRegen(db), BuffType.AuraPlague => LoadAuraPlague(db), BuffType.Cripple => LoadCripple(db), BuffType.Curse => LoadCurse(db), BuffType.FreezingBreath => LoadFreezingBreath(db), BuffType.PlagueWard => LoadPlagueWard(db), BuffType.Possession_Bpoc => LoadPossession_Bpoc(db), BuffType.Possession_Bpos => LoadPossession_Bpos(db), BuffType.RaiseDead => LoadRaiseDead(db), BuffType.Replenish => LoadReplenish(db), BuffType.ReplenishLife => LoadReplenishLife(db), BuffType.ReplenishMana => LoadReplenishMana(db), BuffType.SpiderAttack => LoadSpiderAttack(db), BuffType.UnholyFrenzy => LoadUnholyFrenzy(db), BuffType.Unsummon => LoadUnsummon(db), BuffType.Web => LoadWeb(db), BuffType.WebAir => LoadWebAir(db), BuffType.AnimateDead_BUan => LoadAnimateDead_BUan(db), BuffType.AuraUnholy => LoadAuraUnholy(db), BuffType.AuraVampiric => LoadAuraVampiric(db), BuffType.CarrionScarab => LoadCarrionScarab(db), BuffType.CarrionSwarm => LoadCarrionSwarm(db), BuffType.DeathAndDecayAoe => LoadDeathAndDecayAoe(db), BuffType.FrostArmor => LoadFrostArmor(db), BuffType.Impale => LoadImpale(db), BuffType.Sleep => LoadSleep(db), BuffType.SleepPause => LoadSleepPause(db), BuffType.SleepStun => LoadSleepStun(db), BuffType.ThornyShield_BUts => LoadThornyShield_BUts(db), BuffType.ThornyShield_BUtt => LoadThornyShield_BUtt(db), BuffType.AuraSlow => LoadAuraSlow(db), BuffType.BreathOfFrost => LoadBreathOfFrost(db), BuffType.CreepThunderClap => LoadCreepThunderClap(db), BuffType.Frenzy => LoadFrenzy(db), BuffType.MechanicalCritter => LoadMechanicalCritter(db), BuffType.MindRot => LoadMindRot(db), BuffType.PandaImmolation => LoadPandaImmolation(db), BuffType.PermImmolation => LoadPermImmolation(db), BuffType.Sanctuary => LoadSanctuary(db), BuffType.ShadowSight => LoadShadowSight(db), BuffType.SpellShield => LoadSpellShield(db), BuffType.TornadoDamageAoe => LoadTornadoDamageAoe(db), BuffType.TornadoSpin => LoadTornadoSpin(db), BuffType.TornadoSpinAoe => LoadTornadoSpinAoe(db), BuffType.BlackArrow => LoadBlackArrow(db), BuffType.BreathOfFire => LoadBreathOfFire(db), BuffType.ColdArrow => LoadColdArrow(db), BuffType.ColdArrowStackDoT => LoadColdArrowStackDoT(db), BuffType.ColdArrowStackInfo => LoadColdArrowStackInfo(db), BuffType.DarkMinion => LoadDarkMinion(db), BuffType.Doom => LoadDoom(db), BuffType.DoomMinion => LoadDoomMinion(db), BuffType.DrunkenHaze => LoadDrunkenHaze(db), BuffType.ElementalFury => LoadElementalFury(db), BuffType.HowlOfTerror => LoadHowlOfTerror(db), BuffType.ManaShield => LoadManaShield(db), BuffType.Silence => LoadSilence(db), BuffType.Stampede => LoadStampede(db), BuffType.SummonGrizzly => LoadSummonGrizzly(db), BuffType.SummonQuillbeast => LoadSummonQuillbeast(db), BuffType.SummonWarEagle => LoadSummonWarEagle(db), BuffType.Tornado => LoadTornado(db), BuffType.WateryMinion => LoadWateryMinion(db), BuffType.BattleRoar => LoadBattleRoar(db), BuffType.DarkConversion => LoadDarkConversion(db), BuffType.Infernal => LoadInfernal(db), BuffType.Parasite => LoadParasite(db), BuffType.ParasiteMinion => LoadParasiteMinion(db), BuffType.RainOfFire_BNrd => LoadRainOfFire_BNrd(db), BuffType.RainOfFireAoe => LoadRainOfFireAoe(db), BuffType.SoulPreservation => LoadSoulPreservation(db), BuffType.Corruption => LoadCorruption(db), BuffType.Figurine => LoadFigurine(db), BuffType.ItemCloakOfFlames => LoadItemCloakOfFlames(db), BuffType.ItemIllusion => LoadItemIllusion(db), BuffType.Rebirth => LoadRebirth(db), BuffType.Regeneration => LoadRegeneration(db), BuffType.RegenLife => LoadRegenLife(db), BuffType.RegenMana => LoadRegenMana(db), BuffType.SoulTrapVision => LoadSoulTrapVision(db), BuffType.SpiritTroll => LoadSpiritTroll(db), BuffType.ItemWeb => LoadItemWeb(db), BuffType.ItemMonsterLure => LoadItemMonsterLure(db), BuffType.ItemVampirePotion => LoadItemVampirePotion(db), BuffType.CloudOfFog_Xclf => LoadCloudOfFog_Xclf(db), BuffType.Flare => LoadFlare(db), BuffType.Blizzard_XHbz => LoadBlizzard_XHbz(db), BuffType.FlameStrike_XHfs => LoadFlameStrike_XHfs(db), BuffType.BallsOfFire_Xbof => LoadBallsOfFire_Xbof(db), BuffType.Earthquake_XOeq => LoadEarthquake_XOeq(db), BuffType.Reincarnation => LoadReincarnation(db), BuffType.Sentinel => LoadSentinel(db), BuffType.Starfall => LoadStarfall(db), BuffType.Tranquility => LoadTranquility(db), BuffType.DeathAndDecay => LoadDeathAndDecay(db), BuffType.Monsoon_XNmo => LoadMonsoon_XNmo(db), BuffType.RainOfChaos => LoadRainOfChaos(db), BuffType.RainOfFire_XErf => LoadRainOfFire_XErf(db), BuffType.ItemChangeTOD => LoadItemChangeTOD(db), BuffType.StarfallTarget => LoadStarfallTarget(db), BuffType.TranquilityTarget => LoadTranquilityTarget(db), BuffType.Monsoon_ANmd => LoadMonsoon_ANmd(db), BuffType.Invisibility_Bivs => LoadInvisibility_Bivs(db), BuffType.AnimateDead_BUad => LoadAnimateDead_BUad(db), BuffType.Ultravision => LoadUltravision(db), BuffType.AcidBomb => LoadAcidBomb(db), BuffType.ChemicalRage => LoadChemicalRage(db), BuffType.HealingSpray_BNhs => LoadHealingSpray_BNhs(db), BuffType.HealingSpray_XNhs => LoadHealingSpray_XNhs(db), BuffType.Transmute => LoadTransmute(db), BuffType.EngineeringUpgrade => LoadEngineeringUpgrade(db), BuffType.ClusterRockets_BNcs => LoadClusterRockets_BNcs(db), BuffType.ClusterRockets_XNcs => LoadClusterRockets_XNcs(db), BuffType.SummonFactory => LoadSummonFactory(db), BuffType.ClockwerkGoblin => LoadClockwerkGoblin(db), BuffType.Incinerate => LoadIncinerate(db), BuffType.SoulBurn => LoadSoulBurn(db), BuffType.LavaMonster => LoadLavaMonster(db), BuffType.Volcano_BNvc => LoadVolcano_BNvc(db), BuffType.VolcanoAOE => LoadVolcanoAOE(db), BuffType.Volcano_XNvc => LoadVolcano_XNvc(db), BuffType.EFFECTBASEDETECTOR => LoadEFFECTBASEDETECTOR(db), BuffType.EFFECTBLIGHT => LoadEFFECTBLIGHT(db), BuffType.EFFECTHERODISSIPATE => LoadEFFECTHERODISSIPATE(db), BuffType.EFFECTOnFireHumanSml => LoadEFFECTOnFireHumanSml(db), BuffType.EFFECTOnFireHumanMed => LoadEFFECTOnFireHumanMed(db), BuffType.EFFECTOnFireHumanLrg => LoadEFFECTOnFireHumanLrg(db), BuffType.EFFECTOnFireOrcSml => LoadEFFECTOnFireOrcSml(db), BuffType.EFFECTOnFireOrcMed => LoadEFFECTOnFireOrcMed(db), BuffType.EFFECTOnFireOrcLrg => LoadEFFECTOnFireOrcLrg(db), BuffType.EFFECTOnFireNightElfSml => LoadEFFECTOnFireNightElfSml(db), BuffType.EFFECTOnFireNightElfMed => LoadEFFECTOnFireNightElfMed(db), BuffType.EFFECTOnFireNightElfLrg => LoadEFFECTOnFireNightElfLrg(db), BuffType.EFFECTOnFireUndeadSml => LoadEFFECTOnFireUndeadSml(db), BuffType.EFFECTOnFireUndeadMed => LoadEFFECTOnFireUndeadMed(db), BuffType.EFFECTOnFireUndeadLrg => LoadEFFECTOnFireUndeadLrg(db), BuffType.HealMultiplier => LoadHealMultiplier(db), _ => throw new System.ComponentModel.InvalidEnumArgumentException(nameof(buffType), (int)buffType, typeof(BuffType))}

            ;
        }
    }
}