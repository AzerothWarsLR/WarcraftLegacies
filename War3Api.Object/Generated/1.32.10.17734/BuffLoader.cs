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
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadStun(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Stun, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadCargoHoldDeath(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CargoHoldDeath, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadDefense(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Defense, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadDetected(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Detected, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadFreeze(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Freeze, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadFrost(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Frost, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadInvulnerable(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Invulnerable, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadPoisonAttack(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PoisonAttack, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadPoisonAttackStackDoT(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PoisonAttackStackDoT, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadPoisonAttackStackInfo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PoisonAttackStackInfo, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSharedVision(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SharedVision, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSpeedBonus(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpeedBonus, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadTeleportReveal(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.TeleportReveal, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadCloudOfFog_Bclf(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CloudOfFog_Bclf, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadControlMagic(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ControlMagic, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadHeal(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Heal, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadInnerFire(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.InnerFire, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadInvisibility_Binv(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Invisibility_Binv, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadMagicLeashCaster(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.MagicLeashCaster, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadMagicLeashTarget(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.MagicLeashTarget, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadMilitia(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Militia, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadPhoenixFire(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PhoenixFire, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadPhoenix(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Phoenix, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadPolymorph(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Polymorph, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadSlow(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Slow, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadAuraBrilliance(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraBrilliance, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadAuraDevotion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraDevotion, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadAvatar(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Avatar, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadBanish(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Banish, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadBlizzard_BHbd(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Blizzard_BHbd, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadBlizzardAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BlizzardAoe, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadDivineShield(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DivineShield, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadDrainCaster(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainCaster, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadDrainCasterLife(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainCasterLife, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadDrainCasterMana(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainCasterMana, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadDrainTarget(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainTarget, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadDrainTargetLife(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainTargetLife, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadDrainTargetMana(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrainTargetMana, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadFlameStrike_BHfs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.FlameStrike_BHfs, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadThunderClap(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ThunderClap, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadWaterElemental(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WaterElemental, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadAuraKotoBeast(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraKotoBeast, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadAuraRegenLife(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraRegenLife, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadAuraRegenMana(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraRegenMana, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadBallsOfFire_Bbof(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BallsOfFire_Bbof, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadBerserkerRage(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BerserkerRage, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadBloodlust(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Bloodlust, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadDevourVision(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DevourVision, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadDigesting(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Digesting, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadEnsnare(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Ensnare, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadEnsnareAir(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EnsnareAir, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadEnsnareGround(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EnsnareGround, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadEvilEye(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EvilEye, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadHealingWard(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.HealingWard, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadLightningShield(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.LightningShield, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadLightningShieldAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.LightningShieldAoe, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadLiquidFire(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.LiquidFire, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadPurge(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Purge, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadSpiritLink(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpiritLink, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadStasisTrapTrigger(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.StasisTrapTrigger, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadAuraCommand(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraCommand, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadAuraEndurance(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraEndurance, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadEarthquake_BOeq(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Earthquake_BOeq, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadEarthquakeAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EarthquakeAoe, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadHex(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Hex, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadMirrorImage(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.MirrorImage, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadShockwave(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Shockwave, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadSpiritWolf(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpiritWolf, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadVoodoo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Voodoo, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadVoodooCaster(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.VoodooCaster, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadWard(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Ward, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadWhirlwindAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WhirlwindAoe, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadWindWalk(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WindWalk, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadBarkskin(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Barkskin, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadCorrosiveBreath(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CorrosiveBreath, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadCyclone(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Cyclone, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadCycloneTwo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CycloneTwo, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadEatTree(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EatTree, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadFaerieFire(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.FaerieFire, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadGrabTree(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.GrabTree, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadManaFlare(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ManaFlare, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadManaFlareAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ManaFlareAoe, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadPhaseShift(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PhaseShift, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadWispPhaseShift(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WispPhaseShift, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadRejuvination(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Rejuvination, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadRoar(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Roar, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadSlowPoison(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SlowPoison, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadSlowPoisonStackDoT(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SlowPoisonStackDoT, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadSlowPoisonStackInfo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SlowPoisonStackInfo, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadVengeance(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Vengeance, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadAuraThorns(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraThorns, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadAuraTrueshot(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraTrueshot, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadEntanglingRoots(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EntanglingRoots, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadForceOfNature(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ForceOfNature, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadImmolation(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Immolation, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadImmolationAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ImmolationAoe, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadMetamorphosis(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Metamorphosis, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadScout(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Scout, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadShadowStrike(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ShadowStrike, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadSpiritOfVengeance(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpiritOfVengeance, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadAntiMagicShell(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AntiMagicShell, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadAntiMagicShellMatrix(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AntiMagicShellMatrix, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadAuraBlightRegen(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraBlightRegen, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadAuraPlague(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraPlague, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadCripple(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Cripple, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadCurse(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Curse, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadFreezingBreath(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.FreezingBreath, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadPlagueWard(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PlagueWard, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadPossession_Bpoc(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Possession_Bpoc, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadPossession_Bpos(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Possession_Bpos, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadRaiseDead(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RaiseDead, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadReplenish(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Replenish, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadReplenishLife(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ReplenishLife, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadReplenishMana(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ReplenishMana, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadSpiderAttack(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpiderAttack, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadUnholyFrenzy(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.UnholyFrenzy, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadUnsummon(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Unsummon, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadWeb(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Web, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadWebAir(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WebAir, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadAnimateDead_BUan(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AnimateDead_BUan, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadAuraUnholy(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraUnholy, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadAuraVampiric(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraVampiric, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadCarrionScarab(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CarrionScarab, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadCarrionSwarm(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CarrionSwarm, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadDeathAndDecayAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DeathAndDecayAoe, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadFrostArmor(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.FrostArmor, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadImpale(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Impale, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadSleep(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Sleep, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadSleepPause(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SleepPause, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadSleepStun(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SleepStun, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadThornyShield_BUts(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ThornyShield_BUts, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadThornyShield_BUtt(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ThornyShield_BUtt, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadAuraSlow(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AuraSlow, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadBreathOfFrost(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BreathOfFrost, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadCreepThunderClap(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CreepThunderClap, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadFrenzy(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Frenzy, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadMechanicalCritter(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.MechanicalCritter, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadMindRot(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.MindRot, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadPandaImmolation(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PandaImmolation, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadPermImmolation(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.PermImmolation, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSanctuary(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Sanctuary, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadShadowSight(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ShadowSight, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSpellShield(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpellShield, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadTornadoDamageAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.TornadoDamageAoe, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadTornadoSpin(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.TornadoSpin, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadTornadoSpinAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.TornadoSpinAoe, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadBlackArrow(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BlackArrow, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadBreathOfFire(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BreathOfFire, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadColdArrow(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ColdArrow, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadColdArrowStackDoT(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ColdArrowStackDoT, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadColdArrowStackInfo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ColdArrowStackInfo, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadDarkMinion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DarkMinion, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadDoom(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Doom, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadDoomMinion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DoomMinion, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadDrunkenHaze(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DrunkenHaze, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadElementalFury(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ElementalFury, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadHowlOfTerror(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.HowlOfTerror, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadManaShield(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ManaShield, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSilence(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Silence, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadStampede(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Stampede, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSummonGrizzly(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SummonGrizzly, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSummonQuillbeast(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SummonQuillbeast, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSummonWarEagle(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SummonWarEagle, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadTornado(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Tornado, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadWateryMinion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.WateryMinion, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadBattleRoar(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BattleRoar, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadDarkConversion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DarkConversion, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadInfernal(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Infernal, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadParasite(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Parasite, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadParasiteMinion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ParasiteMinion, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadRainOfFire_BNrd(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RainOfFire_BNrd, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadRainOfFireAoe(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RainOfFireAoe, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSoulPreservation(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SoulPreservation, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadCorruption(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Corruption, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadFigurine(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Figurine, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadItemCloakOfFlames(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemCloakOfFlames, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadItemIllusion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemIllusion, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadRebirth(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Rebirth, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadRegeneration(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Regeneration, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadRegenLife(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RegenLife, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadRegenMana(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RegenMana, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSoulTrapVision(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SoulTrapVision, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSpiritTroll(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SpiritTroll, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadItemWeb(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemWeb, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadItemMonsterLure(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemMonsterLure, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadItemVampirePotion(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemVampirePotion, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadCloudOfFog_Xclf(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.CloudOfFog_Xclf, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadFlare(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Flare, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadBlizzard_XHbz(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Blizzard_XHbz, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadFlameStrike_XHfs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.FlameStrike_XHfs, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadBallsOfFire_Xbof(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.BallsOfFire_Xbof, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadEarthquake_XOeq(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Earthquake_XOeq, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadReincarnation(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Reincarnation, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadSentinel(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Sentinel, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadStarfall(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Starfall, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadTranquility(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Tranquility, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadDeathAndDecay(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.DeathAndDecay, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadMonsoon_XNmo(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Monsoon_XNmo, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadRainOfChaos(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RainOfChaos, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadRainOfFire_XErf(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.RainOfFire_XErf, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadItemChangeTOD(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ItemChangeTOD, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadStarfallTarget(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.StarfallTarget, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadTranquilityTarget(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.TranquilityTarget, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadMonsoon_ANmd(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Monsoon_ANmd, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadInvisibility_Bivs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Invisibility_Bivs, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadAnimateDead_BUad(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AnimateDead_BUad, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadUltravision(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Ultravision, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadAcidBomb(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.AcidBomb, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadChemicalRage(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ChemicalRage, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadHealingSpray_BNhs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.HealingSpray_BNhs, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadHealingSpray_XNhs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.HealingSpray_XNhs, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadTransmute(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Transmute, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadEngineeringUpgrade(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EngineeringUpgrade, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadClusterRockets_BNcs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ClusterRockets_BNcs, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadClusterRockets_XNcs(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ClusterRockets_XNcs, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSummonFactory(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SummonFactory, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadClockwerkGoblin(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.ClockwerkGoblin, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadIncinerate(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Incinerate, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadSoulBurn(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.SoulBurn, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadLavaMonster(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.LavaMonster, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadVolcano_BNvc(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Volcano_BNvc, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadVolcanoAOE(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.VolcanoAOE, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadVolcano_XNvc(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.Volcano_XNvc, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadEFFECTBASEDETECTOR(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTBASEDETECTOR, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadEFFECTBLIGHT(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTBLIGHT, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadEFFECTHERODISSIPATE(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTHERODISSIPATE, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "other";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireHumanSml(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireHumanSml, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireHumanMed(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireHumanMed, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireHumanLrg(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireHumanLrg, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "human";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireOrcSml(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireOrcSml, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireOrcMed(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireOrcMed, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireOrcLrg(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireOrcLrg, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "orc";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireNightElfSml(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireNightElfSml, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireNightElfMed(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireNightElfMed, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireNightElfLrg(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireNightElfLrg, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "nightelf";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireUndeadSml(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireUndeadSml, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireUndeadMed(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireUndeadMed, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadEFFECTOnFireUndeadLrg(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.EFFECTOnFireUndeadLrg, db);
            buff.StatsIsAnEffectRaw = 1;
            buff.StatsRaceRaw = "undead";
            return buff;
        }

        protected virtual Buff LoadHealMultiplier(ObjectDatabaseBase db)
        {
            var buff = new Buff(BuffType.HealMultiplier, db);
            buff.StatsIsAnEffectRaw = 0;
            buff.StatsRaceRaw = "other";
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