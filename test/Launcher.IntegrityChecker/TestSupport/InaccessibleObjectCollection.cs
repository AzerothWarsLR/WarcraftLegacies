using Launcher.IntegrityChecker.Exceptions;
using War3Api.Object;
using War3Api.Object.Abilities;
using Warcraft.Cartographer.Extensions;

namespace Launcher.IntegrityChecker.TestSupport;

/// <summary>
/// Contains <see cref="BaseObject"/>s that are inaccessible to the game.
/// </summary>
public sealed class InaccessibleObjectCollection(
  List<Unit> units,
  List<Upgrade> upgrades,
  List<Ability> abilities,
  List<Item> items,
  List<Doodad> doodads)
{
  public List<Unit> Units { get; } = units;

  public List<Upgrade> Upgrades { get; } = upgrades;

  public List<Ability> Abilities { get; } = abilities;

  public List<Item> Items { get; } = items;

  public List<Doodad> Doodads { get; } = doodads;

  public void RemoveWithChildren(BaseObject baseObject)
  {
    switch (baseObject)
    {
      case Item item:
        RemoveWithChildren(item);
        break;
      case Unit unit:
        RemoveWithChildren(unit);
        break;
      case Upgrade upgrade:
        RemoveWithChildren(upgrade);
        break;
      case Ability upgrade:
        RemoveWithChildren(upgrade);
        break;
      case Doodad doodad:
        RemoveWithChildren(doodad);
        break;
    }
  }

  public void RemoveWithChildren(Unit unit)
  {
    try
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

      foreach (var unitSold in unit.TechtreeUnitsSold)
      {
        RemoveWithChildren(unitSold);
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
    catch (Exception ex)
    {
      throw new UnremovedObjectException($"Could not remove unit {unit.GetReadableId()} - {unit.GetId()}", ex);
    }
  }

  private void RemoveWithChildren(Ability ability)
  {
    try
    {
      if (!Abilities.Contains(ability))
      {
        return;
      }

      switch (ability)
      {
        case ArchMageWaterElemental waterElemental:
          {
            for (var i = 1; i <= waterElemental.StatsLevels; i++)
            {
              RemoveWithChildren(waterElemental.DataSummonedUnitType[i]);
            }

            break;
          }
        case AuraPlagueAbomination auraPlagueAbomination:
          {
            for (var i = 1; i <= auraPlagueAbomination.StatsLevels; i++)
            {
              RemoveWithChildren(auraPlagueAbomination.DataPlagueWardUnitType[i]);
            }

            break;
          }
        case AuraPlagueAnimatedDead auraPlagueAnimatedDead:
          {
            for (var i = 1; i <= auraPlagueAnimatedDead.StatsLevels; i++)
            {
              RemoveWithChildren(auraPlagueAnimatedDead.DataPlagueWardUnitType[i]);
            }

            break;
          }
        case AuraPlagueCreep auraPlagueCreep:
          {
            for (var i = 1; i <= auraPlagueCreep.StatsLevels; i++)
            {
              RemoveWithChildren(auraPlagueCreep.DataPlagueWardUnitType[i]);
            }

            break;
          }
        case AuraPlagueCreepGfx auraPlagueCreepGfx:
          {
            for (var i = 1; i <= auraPlagueCreepGfx.StatsLevels; i++)
            {
              RemoveWithChildren(auraPlagueCreepGfx.DataPlagueWardUnitType[i]);
            }

            break;
          }
        case Bearform bearform:
          {
            for (var i = 1; i <= bearform.StatsLevels; i++)
            {
              RemoveWithChildren(bearform.DataAlternateFormUnit[i]);
            }

            break;
          }
        case BeastMasterSummonBear beastMasterSummonBear:
          {
            for (var i = 1; i <= beastMasterSummonBear.StatsLevels; i++)
            {
              RemoveWithChildren(beastMasterSummonBear.DataSummonedUnitType[i]);
            }

            break;
          }
        case BeastMasterSummonHawk beastMasterSummonHawk:
          {
            for (var i = 1; i <= beastMasterSummonHawk.StatsLevels; i++)
            {
              RemoveWithChildren(beastMasterSummonHawk.DataSummonedUnitType[i]);
            }

            break;
          }
        case BeastMasterSummonQuilbeast beastMasterSummonQuilbeast:
          {
            for (var i = 1; i <= beastMasterSummonQuilbeast.StatsLevels; i++)
            {
              RemoveWithChildren(beastMasterSummonQuilbeast.DataSummonedUnitType[i]);
            }

            break;
          }
        case BerserkerUpgrade berserkerUpgrade:
          {
            for (var i = 1; i <= berserkerUpgrade.StatsLevels; i++)
            {
              RemoveWithChildren(berserkerUpgrade.DataNewUnitType[i]);
            }

            break;
          }
        case BloodMagePhoenix bloodMagePhoenix:
          {
            for (var i = 1; i <= bloodMagePhoenix.StatsLevels; i++)
            {
              RemoveWithChildren(bloodMagePhoenix.DataSummonedUnitType[i]);
            }

            break;
          }
        case BrewmasterStormEarthAndFire brewmasterStormEarthAndFire:
          {
            for (var i = 1; i <= brewmasterStormEarthAndFire.StatsLevels; i++)
            {
              foreach (var unitType in brewmasterStormEarthAndFire.DataSummonedUnitTypes[i])
              {
                RemoveWithChildren(unitType);
              }
            }
          }
          break;
        case Burrow burrow:
          {
            for (var i = 1; i <= burrow.StatsLevels; i++)
            {
              if (!burrow.IsDataAlternateFormUnitModified[i])
              {
                continue;
              }

              RemoveWithChildren(burrow.DataAlternateFormUnit[i]);
            }

            break;
          }
        case BurrowScarabLvl2 burrowScarabLvl2:
          {
            for (var i = 1; i <= burrowScarabLvl2.StatsLevels; i++)
            {
              if (!burrowScarabLvl2.IsDataAlternateFormUnitModified[i])
              {
                continue;
              }

              RemoveWithChildren(burrowScarabLvl2.DataAlternateFormUnit[i]);
            }

            break;
          }
        case BurrowScarabLvl3 burrowScarabLvl3:
          {
            for (var i = 1; i <= burrowScarabLvl3.StatsLevels; i++)
            {
              if (!burrowScarabLvl3.IsDataAlternateFormUnitModified[i])
              {
                continue;
              }

              RemoveWithChildren(burrowScarabLvl3.DataAlternateFormUnit[i]);
            }

            break;
          }
        case ChaosGrom chaosGrom:
          {
            for (var i = 1; i <= chaosGrom.StatsLevels; i++)
            {
              RemoveWithChildren(chaosGrom.DataNewUnitType[i]);
            }

            break;
          }
        case ChaosGrunt chaosGrunt:
          {
            for (var i = 1; i <= chaosGrunt.StatsLevels; i++)
            {
              RemoveWithChildren(chaosGrunt.DataNewUnitType[i]);
            }

            break;
          }
        case ChaosKodo chaosKodo:
          {
            for (var i = 1; i <= chaosKodo.StatsLevels; i++)
            {
              RemoveWithChildren(chaosKodo.DataNewUnitType[i]);
            }

            break;
          }
        case ChaosPeon chaosPeon:
          {
            for (var i = 1; i <= chaosPeon.StatsLevels; i++)
            {
              RemoveWithChildren(chaosPeon.DataNewUnitType[i]);
            }

            break;
          }
        case ChaosRaider chaosRaider:
          {
            for (var i = 1; i <= chaosRaider.StatsLevels; i++)
            {
              RemoveWithChildren(chaosRaider.DataNewUnitType[i]);
            }

            break;
          }
        case ChaosShaman chaosShaman:
          {
            for (var i = 1; i <= chaosShaman.StatsLevels; i++)
            {
              RemoveWithChildren(chaosShaman.DataNewUnitType[i]);
            }

            break;
          }
        case CorporealForm corporealForm:
          {
            for (var i = 1; i <= corporealForm.StatsLevels; i++)
            {
              if (!corporealForm.IsDataAlternateFormUnitModified[i])
              {
                continue;
              }

              RemoveWithChildren(corporealForm.DataAlternateFormUnit[i]);
            }

            break;
          }
        case CryptLordLocustSwarm locustSwarm:
          {
            for (var i = 1; i <= locustSwarm.StatsLevels; i++)
            {
              if (!locustSwarm.IsDataSwarmUnitTypeModified[i])
              {
                continue;
              }

              RemoveWithChildren(locustSwarm.DataSwarmUnitType[i]);
            }

            break;
          }
        case DarkPortal darkPortal:
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

            break;
          }
        case DarkRangerBlackArrow darkRangerBlackArrow:
          {
            for (var i = 1; i <= darkRangerBlackArrow.StatsLevels; i++)
            {
              if (!darkRangerBlackArrow.IsDataSummonedUnitTypeModified[i])
              {
                continue;
              }

              RemoveWithChildren(darkRangerBlackArrow.DataSummonedUnitType[i]);
            }

            break;
          }
        case DemonHunterMetamorphosis demonHunterMetamorphosis:
          {
            for (var i = 1; i <= demonHunterMetamorphosis.StatsLevels; i++)
            {
              if (!demonHunterMetamorphosis.IsDataAlternateFormUnitModified[i])
              {
                continue;
              }

              RemoveWithChildren(demonHunterMetamorphosis.DataAlternateFormUnit[i]);
            }

            break;
          }
        case DreadlordInferno dreadlordInferno:
          {
            for (var i = 1; i <= dreadlordInferno.StatsLevels; i++)
            {
              RemoveWithChildren(dreadlordInferno.DataSummonedUnit[i]);
            }

            break;
          }
        case EtherealForm etherealForm:
          {
            for (var i = 1; i <= etherealForm.StatsLevels; i++)
            {
              RemoveWithChildren(etherealForm.DataAlternateFormUnit[i]);
            }

            break;
          }
        case EvilIllidanMetamorphosis evilIllidanMetamorphosis:
          {
            for (var i = 1; i <= evilIllidanMetamorphosis.StatsLevels; i++)
            {
              RemoveWithChildren(evilIllidanMetamorphosis.DataAlternateFormUnit[i]);
            }

            break;
          }
        case Exhume exhume:
          {
            for (var i = 1; i <= exhume.StatsLevels; i++)
            {
              if (!exhume.IsDataUnitTypeModified[i])
              {
                continue;
              }

              RemoveWithChildren(exhume.DataUnitType[i]);
            }

            break;
          }
        case Factory factory:
          {
            for (var i = 1; i <= factory.StatsLevels; i++)
            {
              RemoveWithChildren(factory.DataSpawnUnitID[i]);
            }

            break;
          }
        case FarseerSpiritWolf farseerSpiritWolf:
          {
            for (var i = 1; i <= farseerSpiritWolf.StatsLevels; i++)
            {
              if (farseerSpiritWolf.IsDataSummonedUnitModified[i])
              {
                RemoveWithChildren(farseerSpiritWolf.DataSummonedUnit[i]);
              }
            }

            break;
          }
        case FeralSpiritCreep feralSpiritCreep:
          {
            for (var i = 1; i <= feralSpiritCreep.StatsLevels; i++)
            {
              RemoveWithChildren(feralSpiritCreep.DataSummonedUnit[i]);
            }

            break;
          }
        case FeralSpiritCreepPig feralSpiritCreepPig:
          {
            for (var i = 1; i <= feralSpiritCreepPig.StatsLevels; i++)
            {
              RemoveWithChildren(feralSpiritCreepPig.DataSummonedUnit[i]);
            }

            break;
          }
        case FigurineBlueDrake figurineBlueDrake:
          {
            for (var i = 1; i <= figurineBlueDrake.StatsLevels; i++)
            {
              if (figurineBlueDrake.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineBlueDrake.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FigurineDoomGuard figurineDoomGuard:
          {
            for (var i = 1; i <= figurineDoomGuard.StatsLevels; i++)
            {
              if (figurineDoomGuard.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineDoomGuard.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FigurineDragonspawnOverseer figurineDragonspawnOverseer:
          {
            for (var i = 1; i <= figurineDragonspawnOverseer.StatsLevels; i++)
            {
              if (figurineDragonspawnOverseer.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineDragonspawnOverseer.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FigurineFelHound figurineFelHound:
          {
            for (var i = 1; i <= figurineFelHound.StatsLevels; i++)
            {
              if (figurineFelHound.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineFelHound.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FigurineFurbolg figurineFurbolg:
          {
            for (var i = 1; i <= figurineFurbolg.StatsLevels; i++)
            {
              if (figurineFurbolg.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineFurbolg.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FigurineFurbolgTracker figurineFurbolgTracker:
          {
            for (var i = 1; i <= figurineFurbolgTracker.StatsLevels; i++)
            {
              if (figurineFurbolgTracker.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineFurbolgTracker.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FigurineIceRevenant figurineIceRevenant:
          {
            for (var i = 1; i <= figurineIceRevenant.StatsLevels; i++)
            {
              if (figurineIceRevenant.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineIceRevenant.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FigurineRedDrake figurineRedDrake:
          {
            for (var i = 1; i <= figurineRedDrake.StatsLevels; i++)
            {
              if (figurineRedDrake.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineRedDrake.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FigurineRockGolem figurineRockGolem:
          {
            for (var i = 1; i <= figurineRockGolem.StatsLevels; i++)
            {
              if (figurineRockGolem.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineRockGolem.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FigurineSkeleton figurineSkeleton:
          {
            for (var i = 1; i <= figurineSkeleton.StatsLevels; i++)
            {
              if (figurineSkeleton.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineSkeleton.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FigurineUrsaWarrior figurineUrsaWarrior:
          {
            for (var i = 1; i <= figurineUrsaWarrior.StatsLevels; i++)
            {
              if (figurineUrsaWarrior.IsDataSummon1UnitTypeModified[i])
              {
                RemoveWithChildren(figurineUrsaWarrior.DataSummon1UnitType[i]);
              }
            }

            break;
          }
        case FirelordSummonLavaSpawn firelordSummonLavaSpawn:
          {
            for (var i = 1; i <= firelordSummonLavaSpawn.StatsLevels; i++)
            {
              RemoveWithChildren(firelordSummonLavaSpawn.DataSummonedUnitType[i]);
            }

            break;
          }
        case ForceOfNatureCreep forceOfNatureCreep:
          {
            for (var i = 1; i <= forceOfNatureCreep.StatsLevels; i++)
            {
              RemoveWithChildren(forceOfNatureCreep.DataSummonedUnitType[i]);
            }

            break;
          }
        case Graveyard graveyard:
          {
            for (var i = 1; i <= graveyard.StatsLevels; i++)
            {
              RemoveWithChildren(graveyard.DataCorpseUnitType[i]);
            }

            break;
          }
        case HealingWard_Ahwd healingWardAhwd:
          {
            for (var i = 1; i <= healingWardAhwd.StatsLevels; i++)
            {
              RemoveWithChildren(healingWardAhwd.DataWardUnitType[i]);
            }

            break;
          }
        case HealingWard_AIhw healingWardAIhw:
          {
            for (var i = 1; i <= healingWardAIhw.StatsLevels; i++)
            {
              RemoveWithChildren(healingWardAIhw.DataWardUnitType[i]);
            }

            break;
          }
        case HealingWardCreep healingWardCreep:
          {
            for (var i = 1; i <= healingWardCreep.StatsLevels; i++)
            {
              RemoveWithChildren(healingWardCreep.DataWardUnitType[i]);
            }

            break;
          }
        case HexCreep hexCreep:
          for (var i = 1; i <= hexCreep.StatsLevels; i++)
          {
            foreach (var morphAir in hexCreep.DataMorphUnitsAir[i])
            {
              RemoveWithChildren(morphAir);
            }
            foreach (var morphAir in hexCreep.DataMorphUnitsAmphibious[i])
            {
              RemoveWithChildren(morphAir);
            }
            foreach (var morphAir in hexCreep.DataMorphUnitsGround[i])
            {
              RemoveWithChildren(morphAir);
            }
            foreach (var morphAir in hexCreep.DataMorphUnitsWater[i])
            {
              RemoveWithChildren(morphAir);
            }
          }
          break;
        case IllidanMetamorphosis illidanMetamorphosis:
          {
            for (var i = 1; i <= illidanMetamorphosis.StatsLevels; i++)
            {
              RemoveWithChildren(illidanMetamorphosis.DataAlternateFormUnit[i]);
            }

            break;
          }
        case ItemInferno itemInferno:
          {
            for (var i = 1; i <= itemInferno.StatsLevels; i++)
            {
              RemoveWithChildren(itemInferno.DataSummonedUnit[i]);
            }

            break;
          }
        case ItemPlaceMine itemPlaceMine:
          {
            for (var i = 1; i <= itemPlaceMine.StatsLevels; i++)
            {
              RemoveWithChildren(itemPlaceMine.DataUnitType[i]);
            }

            break;
          }
        case KeeperForceOfNature keeperForceOfNature:
          {
            for (var i = 1; i <= keeperForceOfNature.StatsLevels; i++)
            {
              RemoveWithChildren(keeperForceOfNature.DataSummonedUnitType[i]);
            }

            break;
          }
        case Militia militia:
          {
            for (var i = 1; i <= militia.StatsLevels; i++)
            {
              RemoveWithChildren(militia.DataAlternateFormUnit[i]);
            }

            break;
          }
        case Parasite parasite:
          {
            for (var i = 1; i <= parasite.StatsLevels; i++)
            {
              RemoveWithChildren(parasite.DataUnitType[i]);
            }

            break;
          }
        case Phoenix phoenix:
          {
            for (var i = 1; i <= phoenix.StatsLevels; i++)
            {
              RemoveWithChildren(phoenix.DataAlternateFormUnit[i]);
            }

            break;
          }
        case PitLordDoom pitLordDoom:
          for (var i = 1; i <= pitLordDoom.StatsLevels; i++)
          {
            RemoveWithChildren(pitLordDoom.DataSummonedUnitType[i]);
          }

          break;
        case Polymorph polymorph:
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

            break;
          }
        case PolymorphCreep polymorphCreep:
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

            break;
          }
        case RainOfChaos rainOfChaos:
          {
            for (var i = 1; i <= rainOfChaos.StatsLevels; i++)
            {
              RemoveWithChildren(rainOfChaos.DataAbilityForUnitCreation[i]);
            }

            break;
          }
        case RaiseDead raiseDead:
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

            break;
          }
        case RaiseDeadCreep raiseDeadCreep:
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

            break;
          }
        case RaiseDeadItem raiseDeadItem:
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

            break;
          }
        case RavenFormDruid ravenFormDruid:
          {
            for (var i = 1; i <= ravenFormDruid.StatsLevels; i++)
            {
              RemoveWithChildren(ravenFormDruid.DataAlternateFormUnit[i]);
            }

            break;
          }
        case RavenFormMedivh ravenFormMedivh:
          {
            for (var i = 1; i <= ravenFormMedivh.StatsLevels; i++)
            {
              RemoveWithChildren(ravenFormMedivh.DataAlternateFormUnit[i]);
            }

            break;
          }
        case SeaWitchTornado seaWitchTornado:
          {
            for (var i = 1; i <= seaWitchTornado.StatsLevels; i++)
            {
              RemoveWithChildren(seaWitchTornado.DataSummonedUnitType[i]);
            }

            break;
          }
        case SentryWard sentryWard:
          {
            for (var i = 1; i <= sentryWard.StatsLevels; i++)
            {
              RemoveWithChildren(sentryWard.DataWardUnitType[i]);
            }

            break;
          }
        case SentryWardItem sentryWardItem:
          {
            for (var i = 1; i <= sentryWardItem.StatsLevels; i++)
            {
              RemoveWithChildren(sentryWardItem.DataWardUnitType[i]);
            }

            break;
          }
        case SerpentWardTentacleForgottenOne serpentWardTentacleForgottenOne:
          {
            for (var i = 1; i <= serpentWardTentacleForgottenOne.StatsLevels; i++)
            {
              RemoveWithChildren(serpentWardTentacleForgottenOne.DataSummonedUnitType[i]);
            }

            break;
          }
        case ShadowHunterSerpentWard shadowHunterSerpentWard:
          {
            for (var i = 1; i <= shadowHunterSerpentWard.StatsLevels; i++)
            {
              RemoveWithChildren(shadowHunterSerpentWard.DataSummonedUnitType[i]);
            }

            break;
          }
        case SpawnHydra spawnHydra:
          {
            for (var i = 1; i <= spawnHydra.StatsLevels; i++)
            {
              RemoveWithChildren(spawnHydra.DataUnitType[i]);
            }

            break;
          }
        case SpawnHydraHatchling spawnHydraHatchling:
          {
            for (var i = 1; i <= spawnHydraHatchling.StatsLevels; i++)
            {
              RemoveWithChildren(spawnHydraHatchling.DataUnitType[i]);
            }

            break;
          }
        case SpawnSkeleton spawnSkeleton:
          {
            for (var i = 1; i <= spawnSkeleton.StatsLevels; i++)
            {
              RemoveWithChildren(spawnSkeleton.DataUnitType[i]);
            }

            break;
          }
        case SpawnSpider spawnSpider:
          {
            for (var i = 1; i <= spawnSpider.StatsLevels; i++)
            {
              RemoveWithChildren(spawnSpider.DataUnitType[i]);
            }

            break;
          }
        case SpawnSpiderling spawnSpiderling:
          {
            for (var i = 1; i <= spawnSpiderling.StatsLevels; i++)
            {
              RemoveWithChildren(spawnSpiderling.DataUnitType[i]);
            }

            break;
          }
        case StasisTrap statisTrap:
          {
            for (var i = 1; i <= statisTrap.StatsLevels; i++)
            {
              RemoveWithChildren(statisTrap.DataWardUnitType[i]);
            }

            break;
          }
        case StoneForm stoneForm:
          {
            for (var i = 1; i <= stoneForm.StatsLevels; i++)
            {
              RemoveWithChildren(stoneForm.DataAlternateFormUnit[i]);
            }

            break;
          }
        case SubmergeMyrmidon submergeMyrmidon:
          {
            for (var i = 1; i <= submergeMyrmidon.StatsLevels; i++)
            {
              RemoveWithChildren(submergeMyrmidon.DataAlternateFormUnit[i]);
            }

            break;
          }
        case SubmergeRoyalGuard submergeRoyalGuard:
          {
            for (var i = 1; i <= submergeRoyalGuard.StatsLevels; i++)
            {
              RemoveWithChildren(submergeRoyalGuard.DataAlternateFormUnit[i]);
            }

            break;
          }
        case SubmergeSnapDragon submergeSnapDragon:
          {
            for (var i = 1; i <= submergeSnapDragon.StatsLevels; i++)
            {
              RemoveWithChildren(submergeSnapDragon.DataAlternateFormUnit[i]);
            }

            break;
          }
        case SummonHeadhunterItem summonHeadhunterItem:
          {
            for (var i = 1; i <= summonHeadhunterItem.StatsLevels; i++)
            {
              RemoveWithChildren(summonHeadhunterItem.DataSummonedUnit[i]);
            }

            break;
          }
        case SummonSeaElemental summonSeaElemental:
          {
            for (var i = 1; i <= summonSeaElemental.StatsLevels; i++)
            {
              RemoveWithChildren(summonSeaElemental.DataSummonedUnitType[i]);
            }

            break;
          }
        case TankUpgrade tankUpgrade:
          {
            for (var i = 1; i <= tankUpgrade.StatsLevels; i++)
            {
              RemoveWithChildren(tankUpgrade.DataNewUnitType[i]);
            }

            break;
          }
        case TichondriusInferno tichondriusInferno:
          {
            for (var i = 1; i <= tichondriusInferno.StatsLevels; i++)
            {
              RemoveWithChildren(tichondriusInferno.DataSummonedUnit[i]);
            }

            break;
          }
        case TinkererRoboGoblinLevel0 tinkererRoboGoblinLevel0:
          {
            for (var i = 1; i <= tinkererRoboGoblinLevel0.StatsLevels; i++)
            {
              RemoveWithChildren(tinkererRoboGoblinLevel0.DataAlternateFormUnit[i]);
            }

            break;
          }
        case TinkererRoboGoblinLevel1 tinkererRoboGoblinLevel1:
          {
            for (var i = 1; i <= tinkererRoboGoblinLevel1.StatsLevels; i++)
            {
              RemoveWithChildren(tinkererRoboGoblinLevel1.DataAlternateFormUnit[i]);
            }

            break;
          }
        case TinkererRoboGoblinLevel2 tinkererRoboGoblinLevel2:
          {
            for (var i = 1; i <= tinkererRoboGoblinLevel2.StatsLevels; i++)
            {
              RemoveWithChildren(tinkererRoboGoblinLevel2.DataAlternateFormUnit[i]);
            }

            break;
          }
        case TinkererRoboGoblinLevel3 tinkererRoboGoblinLevel3:
          {
            for (var i = 1; i <= tinkererRoboGoblinLevel3.StatsLevels; i++)
            {
              RemoveWithChildren(tinkererRoboGoblinLevel3.DataAlternateFormUnit[i]);
            }

            break;
          }
        case TinkererSummonFactoryLevel0 tinkererSummonFactoryLevel0:
          {
            for (var i = 1; i <= tinkererSummonFactoryLevel0.StatsLevels; i++)
            {
              RemoveWithChildren(tinkererSummonFactoryLevel0.DataFactoryUnitID[i]);
              RemoveWithChildren(tinkererSummonFactoryLevel0.DataSpawnUnitID[i]);
            }

            break;
          }
        case TinkererSummonFactoryLevel1 tinkererSummonFactoryLevel1:
          {
            for (var i = 1; i <= tinkererSummonFactoryLevel1.StatsLevels; i++)
            {
              RemoveWithChildren(tinkererSummonFactoryLevel1.DataFactoryUnitID[i]);
              RemoveWithChildren(tinkererSummonFactoryLevel1.DataSpawnUnitID[i]);
            }

            break;
          }
        case TinkererSummonFactoryLevel2 tinkererSummonFactoryLevel2:
          {
            for (var i = 1; i <= tinkererSummonFactoryLevel2.StatsLevels; i++)
            {
              RemoveWithChildren(tinkererSummonFactoryLevel2.DataFactoryUnitID[i]);
              RemoveWithChildren(tinkererSummonFactoryLevel2.DataSpawnUnitID[i]);
            }

            break;
          }
        case TinkererSummonFactoryLevel3 tinkererSummonFactoryLevel3:
          {
            for (var i = 1; i <= tinkererSummonFactoryLevel3.StatsLevels; i++)
            {
              RemoveWithChildren(tinkererSummonFactoryLevel3.DataFactoryUnitID[i]);
              RemoveWithChildren(tinkererSummonFactoryLevel3.DataSpawnUnitID[i]);
            }

            break;
          }
        case Vengeance vengeance:
          {
            for (var i = 1; i <= vengeance.StatsLevels; i++)
            {
              RemoveWithChildren(vengeance.DataUnitTypeOne[i]);
              RemoveWithChildren(vengeance.DataUnitTypeTwo[i]);
            }

            break;
          }
        case WardenSpiritOfVengeance wardenSpiritOfVengeance:
          {
            for (var i = 1; i <= wardenSpiritOfVengeance.StatsLevels; i++)
            {
              RemoveWithChildren(wardenSpiritOfVengeance.DataSummonedUnitType[i]);
            }

            break;
          }
        case WateryMinion wateryMinion:
          {
            for (var i = 1; i <= wateryMinion.StatsLevels; i++)
            {
              RemoveWithChildren(wateryMinion.DataSummonedUnitType[i]);
            }
            break;
          }
        case SpellBook spellBook:
          {
            for (var i = 1; i <= spellBook.StatsLevels; i++)
            {
              foreach (var spell in spellBook.DataSpellList[i])
              {
                RemoveWithChildren(spell);
              }

            }

            break;
          }
      }

      Abilities.Remove(ability);
    }
    catch (Exception ex)
    {
      throw new UnremovedObjectException($"Could not remove ability {ability.GetReadableId()} - {ability.GetId()}", ex);
    }
  }

  private void RemoveWithChildren(Upgrade upgrade)
  {
    if (!Upgrades.Contains(upgrade))
    {
      return;
    }

    Upgrades.Remove(upgrade);
  }

  private void RemoveWithChildren(Item item)
  {
    if (!Items.Contains(item))
    {
      return;
    }

    Items.Remove(item);

    foreach (var ability in item.AbilitiesAbilities)
    {
      RemoveWithChildren(ability);
    }
  }

  private void RemoveWithChildren(Doodad doodad)
  {
    if (!Doodads.Contains(doodad))
    {
      return;
    }

    Doodads.Remove(doodad);
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
    objects.AddRange(Items);
    return objects;
  }
}
