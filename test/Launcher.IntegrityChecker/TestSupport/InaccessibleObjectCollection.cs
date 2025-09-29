using Launcher.Extensions;
using Launcher.IntegrityChecker.Exceptions;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace Launcher.IntegrityChecker.TestSupport;

/// <summary>
/// Contains <see cref="BaseObject"/>s that are inaccessible to the game.
/// </summary>
public sealed class InaccessibleObjectCollection(List<Unit> units, List<Upgrade> upgrades, List<Ability> abilities)
{
  public List<Unit> Units { get; } = units;

  public List<Upgrade> Upgrades { get; } = upgrades;

  public List<Ability> Abilities { get; } = abilities;

  public void RemoveWithChildren(BaseObject baseObject)
  {
    switch (baseObject)
    {
      case Unit unit:
        RemoveWithChildren(unit);
        break;
      case Upgrade upgrade:
        RemoveWithChildren(upgrade);
        break;
      case Ability upgrade:
        RemoveWithChildren(upgrade);
        break;
    }
  }

  public void RemoveWithChildren(Unit unit)
  {
    if (!Units.Contains(unit))
    {
      return;
    }

    Units.Remove(unit);

    foreach (var trainedUnit in unit.TechtreeUnitsTrained)
    {
      RemoveWithChildren(trainedUnit);
    }


    foreach (var builtStructure in unit.TechtreeStructuresBuilt)
    {
      RemoveWithChildren(builtStructure);
    }


    foreach (var upgradesTo in unit.TechtreeUpgradesTo)
    {
      RemoveWithChildren(upgradesTo);
    }


    foreach (var research in unit.TechtreeResearchesAvailable)
    {
      RemoveWithChildren(research);
    }


    foreach (var ability in unit.AbilitiesNormal)
    {
      RemoveWithChildren(ability);
    }


    foreach (var ability in unit.AbilitiesHero)
    {
      RemoveWithChildren(ability);
    }
  }

  public void RemoveWithChildren(Ability ability)
  {
    try
    {
      if (!Abilities.Contains(ability))
      {
        return;
      }

      if (ability is ArchMageWaterElemental waterElemental)
      {
        for (var i = 1; i <= waterElemental.StatsLevels; i++)
        {
          RemoveWithChildren(waterElemental.DataSummonedUnitType[i]);
        }
      }

      if (ability is AuraPlagueAbomination auraPlagueAbomination)
      {
        for (var i = 1; i <= auraPlagueAbomination.StatsLevels; i++)
        {
          RemoveWithChildren(auraPlagueAbomination.DataPlagueWardUnitType[i]);
        }
      }

      if (ability is AuraPlagueAnimatedDead auraPlagueAnimatedDead)
      {
        for (var i = 1; i <= auraPlagueAnimatedDead.StatsLevels; i++)
        {
          RemoveWithChildren(auraPlagueAnimatedDead.DataPlagueWardUnitType[i]);
        }
      }

      if (ability is AuraPlagueCreep auraPlagueCreep)
      {
        for (var i = 1; i <= auraPlagueCreep.StatsLevels; i++)
        {
          RemoveWithChildren(auraPlagueCreep.DataPlagueWardUnitType[i]);
        }
      }

      if (ability is AuraPlagueCreepGfx auraPlagueCreepGfx)
      {
        for (var i = 1; i <= auraPlagueCreepGfx.StatsLevels; i++)
        {
          RemoveWithChildren(auraPlagueCreepGfx.DataPlagueWardUnitType[i]);
        }
      }

      if (ability is Bearform bearform)
      {
        for (var i = 1; i <= bearform.StatsLevels; i++)
        {
          RemoveWithChildren(bearform.DataAlternateFormUnit[i]);
        }
      }

      if (ability is BeastMasterSummonBear beastMasterSummonBear)
      {
        for (var i = 1; i <= beastMasterSummonBear.StatsLevels; i++)
        {
          RemoveWithChildren(beastMasterSummonBear.DataSummonedUnitType[i]);
        }
      }

      if (ability is BeastMasterSummonHawk beastMasterSummonHawk)
      {
        for (var i = 1; i <= beastMasterSummonHawk.StatsLevels; i++)
        {
          RemoveWithChildren(beastMasterSummonHawk.DataSummonedUnitType[i]);
        }
      }

      if (ability is BeastMasterSummonQuilbeast beastMasterSummonQuilbeast)
      {
        for (var i = 1; i <= beastMasterSummonQuilbeast.StatsLevels; i++)
        {
          RemoveWithChildren(beastMasterSummonQuilbeast.DataSummonedUnitType[i]);
        }
      }

      if (ability is BerserkerUpgrade berserkerUpgrade)
      {
        for (var i = 1; i <= berserkerUpgrade.StatsLevels; i++)
        {
          RemoveWithChildren(berserkerUpgrade.DataNewUnitType[i]);
        }
      }

      if (ability is BloodMagePhoenix bloodMagePhoenix)
      {
        for (var i = 1; i <= bloodMagePhoenix.StatsLevels; i++)
        {
          RemoveWithChildren(bloodMagePhoenix.DataSummonedUnitType[i]);
        }
      }

      if (ability is Burrow burrow)
      {
        for (var i = 1; i <= burrow.StatsLevels; i++)
        {
          if (!burrow.IsDataAlternateFormUnitModified[i])
          {
            continue;
          }

          RemoveWithChildren(burrow.DataAlternateFormUnit[i]);
        }
      }

      if (ability is BurrowScarabLvl2 burrowScarabLvl2)
      {
        for (var i = 1; i <= burrowScarabLvl2.StatsLevels; i++)
        {
          if (!burrowScarabLvl2.IsDataAlternateFormUnitModified[i])
          {
            continue;
          }

          RemoveWithChildren(burrowScarabLvl2.DataAlternateFormUnit[i]);
        }
      }

      if (ability is BurrowScarabLvl3 burrowScarabLvl3)
      {
        for (var i = 1; i <= burrowScarabLvl3.StatsLevels; i++)
        {
          if (!burrowScarabLvl3.IsDataAlternateFormUnitModified[i])
          {
            continue;
          }

          RemoveWithChildren(burrowScarabLvl3.DataAlternateFormUnit[i]);
        }
      }

      if (ability is ChaosGrom chaosGrom)
      {
        for (var i = 1; i <= chaosGrom.StatsLevels; i++)
        {
          RemoveWithChildren(chaosGrom.DataNewUnitType[i]);
        }
      }

      if (ability is ChaosGrunt chaosGrunt)
      {
        for (var i = 1; i <= chaosGrunt.StatsLevels; i++)
        {
          RemoveWithChildren(chaosGrunt.DataNewUnitType[i]);
        }
      }

      if (ability is ChaosKodo chaosKodo)
      {
        for (var i = 1; i <= chaosKodo.StatsLevels; i++)
        {
          RemoveWithChildren(chaosKodo.DataNewUnitType[i]);
        }
      }

      if (ability is ChaosPeon chaosPeon)
      {
        for (var i = 1; i <= chaosPeon.StatsLevels; i++)
        {
          RemoveWithChildren(chaosPeon.DataNewUnitType[i]);
        }
      }

      if (ability is ChaosRaider chaosRaider)
      {
        for (var i = 1; i <= chaosRaider.StatsLevels; i++)
        {
          RemoveWithChildren(chaosRaider.DataNewUnitType[i]);
        }
      }

      if (ability is ChaosShaman chaosShaman)
      {
        for (var i = 1; i <= chaosShaman.StatsLevels; i++)
        {
          RemoveWithChildren(chaosShaman.DataNewUnitType[i]);
        }
      }

      if (ability is CorporealForm corporealForm)
      {
        for (var i = 1; i <= corporealForm.StatsLevels; i++)
        {
          if (!corporealForm.IsDataAlternateFormUnitModified[i])
          {
            continue;
          }

          RemoveWithChildren(corporealForm.DataAlternateFormUnit[i]);
        }
      }

      if (ability is CryptLordLocustSwarm locustSwarm)
      {
        for (var i = 1; i <= locustSwarm.StatsLevels; i++)
        {
          if (!locustSwarm.IsDataSwarmUnitTypeModified[i])
          {
            continue;
          }

          RemoveWithChildren(locustSwarm.DataSwarmUnitType[i]);
        }
      }

      if (ability is DarkPortal darkPortal)
      {
        for (var i = 1; i <= darkPortal.StatsLevels; i++)
        {
          if (!darkPortal.IsDataSpawnedUnitsModified[i])
          {
            continue;
          }

          foreach (var unit in darkPortal.DataSpawnedUnits[i])
          {
            RemoveWithChildren(unit);
          }
        }
      }

      if (ability is DarkRangerBlackArrow darkRangerBlackArrow)
      {
        for (var i = 1; i <= darkRangerBlackArrow.StatsLevels; i++)
        {
          if (!darkRangerBlackArrow.IsDataSummonedUnitTypeModified[i])
          {
            continue;
          }

          RemoveWithChildren(darkRangerBlackArrow.DataSummonedUnitType[i]);
        }
      }

      if (ability is DemonHunterMetamorphosis demonHunterMetamorphosis)
      {
        for (var i = 1; i <= demonHunterMetamorphosis.StatsLevels; i++)
        {
          if (!demonHunterMetamorphosis.IsDataAlternateFormUnitModified[i])
          {
            continue;
          }

          RemoveWithChildren(demonHunterMetamorphosis.DataAlternateFormUnit[i]);
        }
      }

      if (ability is DreadlordInferno dreadlordInferno)
      {
        for (var i = 1; i <= dreadlordInferno.StatsLevels; i++)
        {
          RemoveWithChildren(dreadlordInferno.DataSummonedUnit[i]);
        }
      }

      if (ability is EtherealForm etherealForm)
      {
        for (var i = 1; i <= etherealForm.StatsLevels; i++)
        {
          RemoveWithChildren(etherealForm.DataAlternateFormUnit[i]);
        }
      }

      if (ability is EvilIllidanMetamorphosis evilIllidanMetamorphosis)
      {
        for (var i = 1; i <= evilIllidanMetamorphosis.StatsLevels; i++)
        {
          RemoveWithChildren(evilIllidanMetamorphosis.DataAlternateFormUnit[i]);
        }
      }

      if (ability is Exhume exhume)
      {
        for (var i = 1; i <= exhume.StatsLevels; i++)
        {
          if (!exhume.IsDataUnitTypeModified[i])
          {
            continue;
          }

          RemoveWithChildren(exhume.DataUnitType[i]);
        }
      }

      if (ability is Factory factory)
      {
        for (var i = 1; i <= factory.StatsLevels; i++)
        {
          RemoveWithChildren(factory.DataSpawnUnitID[i]);
        }
      }

      if (ability is FarseerSpiritWolf farseerSpiritWolf)
      {
        for (var i = 1; i <= farseerSpiritWolf.StatsLevels; i++)
        {
          if (farseerSpiritWolf.IsDataSummonedUnitModified[i])
          {
            RemoveWithChildren(farseerSpiritWolf.DataSummonedUnit[i]);
          }
        }
      }

      if (ability is FeralSpiritCreep feralSpiritCreep)
      {
        for (var i = 1; i <= feralSpiritCreep.StatsLevels; i++)
        {
          RemoveWithChildren(feralSpiritCreep.DataSummonedUnit[i]);
        }
      }

      if (ability is FeralSpiritCreepPig feralSpiritCreepPig)
      {
        for (var i = 1; i <= feralSpiritCreepPig.StatsLevels; i++)
        {
          RemoveWithChildren(feralSpiritCreepPig.DataSummonedUnit[i]);
        }
      }

      if (ability is FigurineBlueDrake figurineBlueDrake)
      {
        for (var i = 1; i <= figurineBlueDrake.StatsLevels; i++)
        {
          if (figurineBlueDrake.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineBlueDrake.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FigurineDoomGuard figurineDoomGuard)
      {
        for (var i = 1; i <= figurineDoomGuard.StatsLevels; i++)
        {
          if (figurineDoomGuard.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineDoomGuard.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FigurineDragonspawnOverseer figurineDragonspawnOverseer)
      {
        for (var i = 1; i <= figurineDragonspawnOverseer.StatsLevels; i++)
        {
          if (figurineDragonspawnOverseer.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineDragonspawnOverseer.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FigurineFelHound figurineFelHound)
      {
        for (var i = 1; i <= figurineFelHound.StatsLevels; i++)
        {
          if (figurineFelHound.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineFelHound.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FigurineFurbolg figurineFurbolg)
      {
        for (var i = 1; i <= figurineFurbolg.StatsLevels; i++)
        {
          if (figurineFurbolg.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineFurbolg.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FigurineFurbolgTracker figurineFurbolgTracker)
      {
        for (var i = 1; i <= figurineFurbolgTracker.StatsLevels; i++)
        {
          if (figurineFurbolgTracker.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineFurbolgTracker.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FigurineIceRevenant figurineIceRevenant)
      {
        for (var i = 1; i <= figurineIceRevenant.StatsLevels; i++)
        {
          if (figurineIceRevenant.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineIceRevenant.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FigurineRedDrake figurineRedDrake)
      {
        for (var i = 1; i <= figurineRedDrake.StatsLevels; i++)
        {
          if (figurineRedDrake.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineRedDrake.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FigurineRockGolem figurineRockGolem)
      {
        for (var i = 1; i <= figurineRockGolem.StatsLevels; i++)
        {
          if (figurineRockGolem.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineRockGolem.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FigurineSkeleton figurineSkeleton)
      {
        for (var i = 1; i <= figurineSkeleton.StatsLevels; i++)
        {
          if (figurineSkeleton.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineSkeleton.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FigurineUrsaWarrior figurineUrsaWarrior)
      {
        for (var i = 1; i <= figurineUrsaWarrior.StatsLevels; i++)
        {
          if (figurineUrsaWarrior.IsDataSummon1UnitTypeModified[i])
          {
            RemoveWithChildren(figurineUrsaWarrior.DataSummon1UnitType[i]);
          }
        }
      }

      if (ability is FirelordSummonLavaSpawn firelordSummonLavaSpawn)
      {
        for (var i = 1; i <= firelordSummonLavaSpawn.StatsLevels; i++)
        {
          RemoveWithChildren(firelordSummonLavaSpawn.DataSummonedUnitType[i]);
        }
      }

      if (ability is ForceOfNatureCreep forceOfNatureCreep)
      {
        for (var i = 1; i <= forceOfNatureCreep.StatsLevels; i++)
        {
          RemoveWithChildren(forceOfNatureCreep.DataSummonedUnitType[i]);
        }
      }

      if (ability is Graveyard graveyard)
      {
        for (var i = 1; i <= graveyard.StatsLevels; i++)
        {
          RemoveWithChildren(graveyard.DataCorpseUnitType[i]);
        }
      }

      if (ability is HealingWard_Ahwd healingWardAhwd)
      {
        for (var i = 1; i <= healingWardAhwd.StatsLevels; i++)
        {
          RemoveWithChildren(healingWardAhwd.DataWardUnitType[i]);
        }
      }

      if (ability is HealingWard_AIhw healingWardAIhw)
      {
        for (var i = 1; i <= healingWardAIhw.StatsLevels; i++)
        {
          RemoveWithChildren(healingWardAIhw.DataWardUnitType[i]);
        }
      }

      if (ability is HealingWardCreep healingWardCreep)
      {
        for (var i = 1; i <= healingWardCreep.StatsLevels; i++)
        {
          RemoveWithChildren(healingWardCreep.DataWardUnitType[i]);
        }
      }

      if (ability is IllidanMetamorphosis illidanMetamorphosis)
      {
        for (var i = 1; i <= illidanMetamorphosis.StatsLevels; i++)
        {
          RemoveWithChildren(illidanMetamorphosis.DataAlternateFormUnit[i]);
        }
      }

      if (ability is ItemInferno itemInferno)
      {
        for (var i = 1; i <= itemInferno.StatsLevels; i++)
        {
          RemoveWithChildren(itemInferno.DataSummonedUnit[i]);
        }
      }

      if (ability is ItemPlaceMine itemPlaceMine)
      {
        for (var i = 1; i <= itemPlaceMine.StatsLevels; i++)
        {
          RemoveWithChildren(itemPlaceMine.DataUnitType[i]);
        }
      }

      if (ability is KeeperForceOfNature keeperForceOfNature)
      {
        for (var i = 1; i <= keeperForceOfNature.StatsLevels; i++)
        {
          RemoveWithChildren(keeperForceOfNature.DataSummonedUnitType[i]);
        }
      }

      if (ability is Militia militia)
      {
        for (var i = 1; i <= militia.StatsLevels; i++)
        {
          RemoveWithChildren(militia.DataAlternateFormUnit[i]);
        }
      }

      if (ability is Parasite parasite)
      {
        for (var i = 1; i <= parasite.StatsLevels; i++)
        {
          RemoveWithChildren(parasite.DataUnitType[i]);
        }
      }

      if (ability is Phoenix phoenix)
      {
        for (var i = 1; i <= phoenix.StatsLevels; i++)
        {
          RemoveWithChildren(phoenix.DataAlternateFormUnit[i]);
        }
      }

      if (ability is Polymorph polymorph)
      {
        for (var i = 1; i <= polymorph.StatsLevels; i++)
        {
          foreach (var morphAir in polymorph.DataMorphUnitsAir[i])
          {
            RemoveWithChildren(morphAir);
          }
          foreach (var morphAir in polymorph.DataMorphUnitsAmphibious[i])
          {
            RemoveWithChildren(morphAir);
          }
          foreach (var morphAir in polymorph.DataMorphUnitsGround[i])
          {
            RemoveWithChildren(morphAir);
          }
          foreach (var morphAir in polymorph.DataMorphUnitsWater[i])
          {
            RemoveWithChildren(morphAir);
          }
        }
      }

      if (ability is PolymorphCreep polymorphCreep)
      {
        for (var i = 1; i <= polymorphCreep.StatsLevels; i++)
        {
          foreach (var morphAir in polymorphCreep.DataMorphUnitsAir[i])
          {
            RemoveWithChildren(morphAir);
          }
          foreach (var morphAir in polymorphCreep.DataMorphUnitsAmphibious[i])
          {
            RemoveWithChildren(morphAir);
          }
          foreach (var morphAir in polymorphCreep.DataMorphUnitsGround[i])
          {
            RemoveWithChildren(morphAir);
          }
          foreach (var morphAir in polymorphCreep.DataMorphUnitsWater[i])
          {
            RemoveWithChildren(morphAir);
          }
        }
      }

      if (ability is RainOfChaos rainOfChaos)
      {
        for (var i = 1; i <= rainOfChaos.StatsLevels; i++)
        {
          RemoveWithChildren(rainOfChaos.DataAbilityForUnitCreation[i]);
        }
      }

      if (ability is RaiseDead raiseDead)
      {
        for (var i = 1; i <= raiseDead.StatsLevels; i++)
        {
          if (raiseDead.IsDataUnitTypeOneModified[i])
          {
            RemoveWithChildren(raiseDead.DataUnitTypeOne[i]);
          }
          if (raiseDead.IsDataUnitTypeTwoModified[i])
          {
            RemoveWithChildren(raiseDead.DataUnitTypeTwo[i]);
          }
        }
      }

      if (ability is RaiseDeadCreep raiseDeadCreep)
      {
        for (var i = 1; i <= raiseDeadCreep.StatsLevels; i++)
        {
          if (raiseDeadCreep.IsDataUnitTypeOneModified[i])
          {
            RemoveWithChildren(raiseDeadCreep.DataUnitTypeOne[i]);
          }
          if (raiseDeadCreep.IsDataUnitTypeTwoModified[i])
          {
            RemoveWithChildren(raiseDeadCreep.DataUnitTypeTwo[i]);
          }
        }
      }

      if (ability is RaiseDeadItem raiseDeadItem)
      {
        for (var i = 1; i <= raiseDeadItem.StatsLevels; i++)
        {
          if (raiseDeadItem.IsDataUnitTypeOneModified[i])
          {
            RemoveWithChildren(raiseDeadItem.DataUnitTypeOne[i]);
          }
          if (raiseDeadItem.IsDataUnitTypeTwoModified[i])
          {
            RemoveWithChildren(raiseDeadItem.DataUnitTypeTwo[i]);
          }
        }
      }

      if (ability is RavenFormDruid ravenFormDruid)
      {
        for (var i = 1; i <= ravenFormDruid.StatsLevels; i++)
        {
          RemoveWithChildren(ravenFormDruid.DataAlternateFormUnit[i]);
        }
      }

      if (ability is RavenFormMedivh ravenFormMedivh)
      {
        for (var i = 1; i <= ravenFormMedivh.StatsLevels; i++)
        {
          RemoveWithChildren(ravenFormMedivh.DataAlternateFormUnit[i]);
        }
      }

      if (ability is SeaWitchTornado seaWitchTornado)
      {
        for (var i = 1; i <= seaWitchTornado.StatsLevels; i++)
        {
          RemoveWithChildren(seaWitchTornado.DataSummonedUnitType[i]);
        }
      }

      if (ability is SentryWard sentryWard)
      {
        for (var i = 1; i <= sentryWard.StatsLevels; i++)
        {
          RemoveWithChildren(sentryWard.DataWardUnitType[i]);
        }
      }

      if (ability is SentryWardItem sentryWardItem)
      {
        for (var i = 1; i <= sentryWardItem.StatsLevels; i++)
        {
          RemoveWithChildren(sentryWardItem.DataWardUnitType[i]);
        }
      }

      if (ability is SerpentWardTentacleForgottenOne serpentWardTentacleForgottenOne)
      {
        for (var i = 1; i <= serpentWardTentacleForgottenOne.StatsLevels; i++)
        {
          RemoveWithChildren(serpentWardTentacleForgottenOne.DataSummonedUnitType[i]);
        }
      }

      if (ability is ShadowHunterSerpentWard shadowHunterSerpentWard)
      {
        for (var i = 1; i <= shadowHunterSerpentWard.StatsLevels; i++)
        {
          RemoveWithChildren(shadowHunterSerpentWard.DataSummonedUnitType[i]);
        }
      }

      if (ability is SpawnHydra spawnHydra)
      {
        for (var i = 1; i <= spawnHydra.StatsLevels; i++)
        {
          RemoveWithChildren(spawnHydra.DataUnitType[i]);
        }
      }

      if (ability is SpawnHydraHatchling spawnHydraHatchling)
      {
        for (var i = 1; i <= spawnHydraHatchling.StatsLevels; i++)
        {
          RemoveWithChildren(spawnHydraHatchling.DataUnitType[i]);
        }
      }

      if (ability is SpawnSkeleton spawnSkeleton)
      {
        for (var i = 1; i <= spawnSkeleton.StatsLevels; i++)
        {
          RemoveWithChildren(spawnSkeleton.DataUnitType[i]);
        }
      }

      if (ability is SpawnSpider spawnSpider)
      {
        for (var i = 1; i <= spawnSpider.StatsLevels; i++)
        {
          RemoveWithChildren(spawnSpider.DataUnitType[i]);
        }
      }

      if (ability is SpawnSpiderling spawnSpiderling)
      {
        for (var i = 1; i <= spawnSpiderling.StatsLevels; i++)
        {
          RemoveWithChildren(spawnSpiderling.DataUnitType[i]);
        }
      }

      if (ability is StasisTrap statisTrap)
      {
        for (var i = 1; i <= statisTrap.StatsLevels; i++)
        {
          RemoveWithChildren(statisTrap.DataWardUnitType[i]);
        }
      }

      if (ability is StoneForm stoneForm)
      {
        for (var i = 1; i <= stoneForm.StatsLevels; i++)
        {
          RemoveWithChildren(stoneForm.DataAlternateFormUnit[i]);
        }
      }

      if (ability is SubmergeMyrmidon submergeMyrmidon)
      {
        for (var i = 1; i <= submergeMyrmidon.StatsLevels; i++)
        {
          RemoveWithChildren(submergeMyrmidon.DataAlternateFormUnit[i]);
        }
      }

      if (ability is SubmergeRoyalGuard submergeRoyalGuard)
      {
        for (var i = 1; i <= submergeRoyalGuard.StatsLevels; i++)
        {
          RemoveWithChildren(submergeRoyalGuard.DataAlternateFormUnit[i]);
        }
      }

      if (ability is SubmergeSnapDragon submergeSnapDragon)
      {
        for (var i = 1; i <= submergeSnapDragon.StatsLevels; i++)
        {
          RemoveWithChildren(submergeSnapDragon.DataAlternateFormUnit[i]);
        }
      }

      if (ability is SummonHeadhunterItem summonHeadhunterItem)
      {
        for (var i = 1; i <= summonHeadhunterItem.StatsLevels; i++)
        {
          RemoveWithChildren(summonHeadhunterItem.DataSummonedUnit[i]);
        }
      }

      if (ability is SummonSeaElemental summonSeaElemental)
      {
        for (var i = 1; i <= summonSeaElemental.StatsLevels; i++)
        {
          RemoveWithChildren(summonSeaElemental.DataSummonedUnitType[i]);
        }
      }

      if (ability is TankUpgrade tankUpgrade)
      {
        for (var i = 1; i <= tankUpgrade.StatsLevels; i++)
        {
          RemoveWithChildren(tankUpgrade.DataNewUnitType[i]);
        }
      }

      if (ability is TichondriusInferno tichondriusInferno)
      {
        for (var i = 1; i <= tichondriusInferno.StatsLevels; i++)
        {
          RemoveWithChildren(tichondriusInferno.DataSummonedUnit[i]);
        }
      }

      if (ability is TinkererRoboGoblinLevel0 tinkererRoboGoblinLevel0)
      {
        for (var i = 1; i <= tinkererRoboGoblinLevel0.StatsLevels; i++)
        {
          RemoveWithChildren(tinkererRoboGoblinLevel0.DataAlternateFormUnit[i]);
        }
      }

      if (ability is TinkererRoboGoblinLevel1 tinkererRoboGoblinLevel1)
      {
        for (var i = 1; i <= tinkererRoboGoblinLevel1.StatsLevels; i++)
        {
          RemoveWithChildren(tinkererRoboGoblinLevel1.DataAlternateFormUnit[i]);
        }
      }

      if (ability is TinkererRoboGoblinLevel2 tinkererRoboGoblinLevel2)
      {
        for (var i = 1; i <= tinkererRoboGoblinLevel2.StatsLevels; i++)
        {
          RemoveWithChildren(tinkererRoboGoblinLevel2.DataAlternateFormUnit[i]);
        }
      }

      if (ability is TinkererRoboGoblinLevel3 tinkererRoboGoblinLevel3)
      {
        for (var i = 1; i <= tinkererRoboGoblinLevel3.StatsLevels; i++)
        {
          RemoveWithChildren(tinkererRoboGoblinLevel3.DataAlternateFormUnit[i]);
        }
      }

      if (ability is TinkererSummonFactoryLevel0 tinkererSummonFactoryLevel0)
      {
        for (var i = 1; i <= tinkererSummonFactoryLevel0.StatsLevels; i++)
        {
          RemoveWithChildren(tinkererSummonFactoryLevel0.DataFactoryUnitID[i]);
          RemoveWithChildren(tinkererSummonFactoryLevel0.DataSpawnUnitID[i]);
        }
      }

      if (ability is TinkererSummonFactoryLevel1 tinkererSummonFactoryLevel1)
      {
        for (var i = 1; i <= tinkererSummonFactoryLevel1.StatsLevels; i++)
        {
          RemoveWithChildren(tinkererSummonFactoryLevel1.DataFactoryUnitID[i]);
          RemoveWithChildren(tinkererSummonFactoryLevel1.DataSpawnUnitID[i]);
        }
      }

      if (ability is TinkererSummonFactoryLevel2 tinkererSummonFactoryLevel2)
      {
        for (var i = 1; i <= tinkererSummonFactoryLevel2.StatsLevels; i++)
        {
          RemoveWithChildren(tinkererSummonFactoryLevel2.DataFactoryUnitID[i]);
          RemoveWithChildren(tinkererSummonFactoryLevel2.DataSpawnUnitID[i]);
        }
      }

      if (ability is TinkererSummonFactoryLevel3 tinkererSummonFactoryLevel3)
      {
        for (var i = 1; i <= tinkererSummonFactoryLevel3.StatsLevels; i++)
        {
          RemoveWithChildren(tinkererSummonFactoryLevel3.DataFactoryUnitID[i]);
          RemoveWithChildren(tinkererSummonFactoryLevel3.DataSpawnUnitID[i]);
        }
      }

      if (ability is Vengeance vengeance)
      {
        for (var i = 1; i <= vengeance.StatsLevels; i++)
        {
          RemoveWithChildren(vengeance.DataUnitTypeOne[i]);
          RemoveWithChildren(vengeance.DataUnitTypeTwo[i]);
        }
      }

      if (ability is WardenSpiritOfVengeance wardenSpiritOfVengeance)
      {
        for (var i = 1; i <= wardenSpiritOfVengeance.StatsLevels; i++)
        {
          RemoveWithChildren(wardenSpiritOfVengeance.DataSummonedUnitType[i]);
        }
      }

      if (ability is WateryMinion wateryMinion)
      {
        for (var i = 1; i <= wateryMinion.StatsLevels; i++)
        {
          RemoveWithChildren(wateryMinion.DataSummonedUnitType[i]);
        }
      }

      Abilities.Remove(ability);
    }
    catch (Exception ex)
    {
      throw new UnremovedObjectException($"Could not remove ability {ability.GetReadableId()} - {ability.GetId()}", ex);
    }
  }

  /// <summary>
  /// Returns all <see cref="BaseObject"/>s in the collection.
  /// </summary>
  public List<BaseObject> GetAllObjects()
  {
    var objects = new List<BaseObject>();
    objects.AddRange(Units);
    objects.AddRange(Upgrades);
    objects.AddRange(Abilities);
    return objects;
  }

  private void RemoveWithChildren(Upgrade upgrade)
  {
    if (!Upgrades.Contains(upgrade))
    {
      return;
    }

    Upgrades.Remove(upgrade);
  }
}
